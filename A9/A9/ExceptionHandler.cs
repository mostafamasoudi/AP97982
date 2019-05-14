using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A9
{
    public class ExceptionHandler
    {
        public string FinallyBlockStringOut { get; set; }
        public string ErrorMsg { get; set; }
        public readonly bool DoNotThrow;
        private string _Input;

        public string Input
        {
            get
            {
                try
                {
                    if(_Input==null)
                    {
                        string a = null;
                        int length = a.Length;
                    }
                    else
                    {
                        return _Input;
                    }
                }
                catch
                {
                    if (!DoNotThrow)
                        throw;
                    ErrorMsg = "Caught exception in GetMethod";
                }
                return null;
            }
            set
            {
                try
                {

                    if (value == null)
                    {
                        string a = null;
                        int length = a.Length;
                    }
                    else
                    {
                        _Input = value;
                    }
                }
                catch
                {
                    if (!DoNotThrow)
                        throw;
                    ErrorMsg = "Caught exception in SetMethod";
                }
            }
        }

        public ExceptionHandler(
            string input,
            bool causeExceptionInConstructor,
            bool doNotThrow = false)
        {
            DoNotThrow = doNotThrow;
            this._Input = input;
            try
            {
                if (causeExceptionInConstructor)
                {
                    string a = null;
                    int length = a.Length;
                }
            }
            catch
            {
                if (!DoNotThrow)
                    throw;
                ErrorMsg = "Caught exception in constructor";
            }
        }

        public void FinallyBlockMethod(string keyword)
        {
            try
            {
                this.FinallyBlockStringOut = "InTryBlock:";
                if (keyword==null)
                {
                    this.FinallyBlockStringOut += ":Object reference not set to an instance of an object.";
                    if(this.DoNotThrow == false)
                    {
                        int a = keyword.Length;
                    }
                        
                }
                else if(keyword== "beautiful")
                {
                    FinallyBlockStringOut +=
                        $"{keyword}:{keyword.Length}:DoneWriting";
                }
                else if(keyword== "ugly")
                {
                    return;
                }

            }
            catch
            {
                if (!DoNotThrow)
                    throw;
            }
            finally
            {
                this.FinallyBlockStringOut +=
                   ":InFinallyBlock";
            }
            this.FinallyBlockStringOut += ":EndOfMethod";
        }

        public void NestedMethods()
            => MethodA();
        
        public void MethodA() 
            => MethodB();
        
        public void MethodB()
            => MethodC();
        
        public void MethodC()
            => MethodD();
        
        public void MethodD()
           => throw new NotImplementedException();
        


        public void OverflowExceptionMethod()
        {
            try
            {
                int i = int.MaxValue;
                checked
                {
                    if (Input != "10")
                    {
                        i++;
                    }
                }
                
            }
            catch (OverflowException e)
            {
                if (!DoNotThrow)
                    throw;
                ErrorMsg = $"Caught exception {e.GetType()}";
            }
        }

        public void FormatExceptionMethod()
        {
			try
            {
                int i = int.Parse(Input);
            }
            catch(FormatException e)
            {
                if (!DoNotThrow)
                    throw;
                ErrorMsg = $"Caught exception {e.GetType()}";
            }
        } 

        public void FileNotFoundExceptionMethod()
        {
            try
            {
                if(Input != "10")
                {
                    string line = File.ReadAllText("mytext.txt");
                }
            }
            catch(FileNotFoundException e)
            {
                if (!DoNotThrow)
                    throw;
                else
                    this.ErrorMsg = $"Caught exception {e.GetType()}";
            }
        }

        public void IndexOutOfRangeExceptionMethod()
        {
            try
            {
                if (Input != "0")
                {
                    int[] array = new int[1] { 0 };
                    int a = array[1];
                }
            }
            catch(IndexOutOfRangeException i)
            {
                if (!this.DoNotThrow)
                    throw;
                else
                    this.ErrorMsg = $"Caught exception {i.GetType()}";
            }
        }

        public void OutOfMemoryExceptionMethod()
        {
            try
            {
                if (Input != "10")
                {
                    int[] a = new int[int.MaxValue];
                }
            }
            catch(OutOfMemoryException e)
            {
                if (!this.DoNotThrow)
                    throw;
                else
                    this.ErrorMsg = $"Caught exception {e.GetType()}";
            }
        }

        public void MultiExceptionMethod()
        {
            try
            {
                if(Input=="1")
                {
                    int[] array = new int[1];
                    array[1] = 1;

                    int[] array2 = new int[int.MaxValue];
                }
                if (Input != "0")
                {
                    int[] array2 = new int[int.MaxValue];

                    int[] array = new int[1];
                    array[1] = 1;
                }
            }
            catch (IndexOutOfRangeException e)
            {
                if (!DoNotThrow)
                    throw;
                ErrorMsg = $"Caught exception {e.GetType()}";
            }
            catch (OutOfMemoryException e)
            {
                if (!DoNotThrow)
                    throw;
                ErrorMsg = $"Caught exception {e.GetType()}";
            }
        }

        public static void ThrowIfOdd(int v)
        {
            if (v % 2 == 1)
                throw new InvalidDataException();
        }
    }
}
