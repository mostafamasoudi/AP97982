using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.FileIO;

namespace E2.Linq
{
    public class MessageAnalysis
    {
        public List<MessageData> Messages { get; set; }

        public MessageAnalysis()
        {
            Messages = new List<MessageData>();
        }

        public static MessageAnalysis MessageAnalysisFactory(string csvAddress)
        {
            MessageAnalysis messageAnalysis = new MessageAnalysis();
            using (TextFieldParser parser = new TextFieldParser(csvAddress))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                var fields = parser.ReadFields();

                while (!parser.EndOfData)
                {
                    fields = parser.ReadFields();
                    messageAnalysis.AppendMessage(fields);
                }
            }

            return messageAnalysis;
        }

        public void AppendMessage(string[] fields)
        {
            Messages.Add(new MessageData(fields));
        }

        public MessageData MostRepliedMessage()
        {
            return Messages.Select(d => new
            {
                message = d,
                id = d.Id,
                replayCount = Messages.Where(s => s.ReplyMessageId == d.Id)
                                      .Count()
            })
            .OrderByDescending(d => d.replayCount)
            .First()
            .message;
            
        }

        public Tuple<string, int>[] MostPostedMessagePersons()
        {
            List<Tuple<string, int>> list = new List<Tuple<string, int>>();
            Messages.Where(d => !d.Author.Contains("Ali Heydari"))
                    .Where(d => !d.Author.Contains("Sauleh Eetemadi"))
                    .GroupBy(d => d.Author)
                    .OrderByDescending(g => g.Count())
                    .Take(5)
                    .Select(g => new
                    {
                        author = g.Key,
                        messageCount = g.Count()
                    })
                    .ToList()
                    .ForEach(d => list.Add(Tuple.Create(d.author, d.messageCount)));
            return list.ToArray();
        }

        public Tuple<string, int>[] MostActivesAtMidNight()
        {
            List<Tuple<string, int>> list = new List<Tuple<string, int>>();
            var listname =
            Messages.Where(d => d.DateTime.Hour >= 0)
                    .Where(d => d.DateTime.Hour <= 4)
                    .GroupBy(d => d.Author)
                    .OrderByDescending(g => g.Count())
                    .Take(5)
                    .Select(g => g.Key)
                    .ToList();

            listname.Select(d => new
            {
                name = d,
                totalcount = Messages.Where(u => u.Author == d).Count()
            }).ToList()
            .ForEach(d => list.Add(Tuple.Create(d.name, d.totalcount)));
            //please check my answer
            return list.ToArray();

        }

        public string StudentWithMostUnansweredQuestions()
        {

           var name= Messages.Select(d => new
            {
                message = d,
                replaycount = Messages.Where(s => s.ReplyMessageId == d.Id)
                                    .Count()
            })
            .Where(d => d.message.Content.Contains('?') || d.message.Content.Contains('؟'))
            .OrderBy(d => d.replaycount)
            .First()
            .message
            .Author;
            Console.WriteLine(name);
            //my answer : mostafa masoudi
            return name;
        }
    }
}