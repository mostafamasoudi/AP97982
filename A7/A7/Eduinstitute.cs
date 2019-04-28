using System;
using System.Collections.Generic;

namespace A7
{
    public class EduInstitute<TTeacher> where TTeacher : ITeacher, ICitizen
    {
        private string _Title;
        private Degree _MinimumDegree;
        private List<TTeacher> _Teachers;
        public string Title { get => _Title; set => _Title = value; }
        public Degree MinimumDegree { get => _MinimumDegree; set => _MinimumDegree = value; }
        public List<TTeacher> Teachers { get => _Teachers; set => _Teachers = value; }
        public EduInstitute(string title,Degree minimumdegree)
        {
            this.Title = title;
            this.MinimumDegree = minimumdegree;
        }
        public bool Register(TTeacher teacher)
        {
            if (this.IsEligible(teacher))
            {
                Teachers.Add(teacher);
                return true;
            }
            else
                return false;
        }

        public bool IsEligible(TTeacher teacher)
        {
            if (teacher.TopDegree <= this.MinimumDegree)
                return true;
            else
                return false;
        }
    }
}