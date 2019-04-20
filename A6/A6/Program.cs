using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace A6
{

    public struct TypeOfSize5
    {
        byte variable1;
        byte variable2;
        byte variable3;
        byte variable4;
        byte variable5;
    }
    public struct TypeOfSize22
    {
        TypeOfSize5 type1;
        TypeOfSize5 type2;
        TypeOfSize5 type3;
        TypeOfSize5 type4;
        byte variable1;
        byte variable2;

    }
    public struct TypeOfSize125
    {
        TypeOfSize22 type22_1;
        TypeOfSize22 type22_2;
        TypeOfSize22 type22_3;
        TypeOfSize22 type22_4;
        TypeOfSize22 type22_5;
        TypeOfSize5 type5_1;
        TypeOfSize5 type5_2;
        TypeOfSize5 type5_3;

    }
    public struct TypeOfSize1024
    {
        TypeOfSize125 type125_1;
        TypeOfSize125 type125_2;
        TypeOfSize125 type125_3;
        TypeOfSize125 type125_4;
        TypeOfSize125 type125_5;
        TypeOfSize125 type125_6;
        TypeOfSize125 type125_7;
        TypeOfSize125 type125_8;
        TypeOfSize22 type22_1;
        byte variable1;
        byte variable2;
    }
    public struct TypeOfSize32768
    {
        TypeOfSize1024 type1024_1;
        TypeOfSize1024 type1024_2;
        TypeOfSize1024 type1024_3;
        TypeOfSize1024 type1024_4;
        TypeOfSize1024 type1024_5;
        TypeOfSize1024 type1024_6;
        TypeOfSize1024 type1024_7;
        TypeOfSize1024 type1024_8;
        TypeOfSize1024 type1024_9;
        TypeOfSize1024 type1024_10;
        TypeOfSize1024 type1024_11;
        TypeOfSize1024 type1024_12;
        TypeOfSize1024 type1024_13;
        TypeOfSize1024 type1024_14;
        TypeOfSize1024 type1024_15;
        TypeOfSize1024 type1024_16;
        TypeOfSize1024 type1024_17;
        TypeOfSize1024 type1024_18;
        TypeOfSize1024 type1024_19;
        TypeOfSize1024 type1024_20;
        TypeOfSize1024 type1024_21;
        TypeOfSize1024 type1024_22;
        TypeOfSize1024 type1024_23;
        TypeOfSize1024 type1024_24;
        TypeOfSize1024 type1024_25;
        TypeOfSize1024 type1024_26;
        TypeOfSize1024 type1024_27;
        TypeOfSize1024 type1024_28;
        TypeOfSize1024 type1024_29;
        TypeOfSize1024 type1024_30;
        TypeOfSize1024 type1024_31;
        TypeOfSize125 type125_1;
        TypeOfSize125 type125_2;
        TypeOfSize125 type125_3;
        TypeOfSize125 type125_4;
        TypeOfSize125 type125_5;
        TypeOfSize125 type125_6;
        TypeOfSize125 type125_7;
        TypeOfSize125 type125_8;
        TypeOfSize5 type5_1;
        TypeOfSize5 type5_2;
        TypeOfSize5 type5_3;
        TypeOfSize5 type5_4;
        byte variable1;
        byte variable2;
        byte variable3;
        byte variable4;
    }
    public struct TypeForMaxStackOfDepth3000
    {
        TypeOfSize125 type125_1;
        byte variable1;
        byte variable2;
    }
    public struct TypeForMaxStackOfDepth1000
    {
        TypeOfSize125 type125_1;
        TypeOfSize125 type125_2;
        TypeOfSize125 type125_3;
        TypeOfSize125 type125_4;
    }
    public struct TypeForMaxStackOfDepth100
    {
        TypeOfSize1024 type1024_1;
        TypeOfSize1024 type1024_2;
        TypeOfSize1024 type1024_3;
        TypeOfSize1024 type1024_4;
        TypeOfSize125 type125_2;
        TypeOfSize125 type125_3;
        TypeOfSize125 type125_4;
        TypeOfSize125 type125_5;
        TypeOfSize125 type125_6;

    }
    public struct TypeForMaxStackOfDepth10
    {
        TypeOfSize32768 type32768_1;
        TypeOfSize1024 type1024_1;
        TypeOfSize1024 type1024_2;
        TypeOfSize1024 type1024_3;
        TypeOfSize1024 type1024_4;
        TypeOfSize1024 type1024_5;
        TypeOfSize1024 type1024_6;
        TypeOfSize1024 type1024_7;
        TypeOfSize1024 type1024_8;
        TypeOfSize1024 type1024_9;
    }
    public class TypeWithMemoryOnHeap
    {

        List<int[]> listOfArray;
        public void Allocate()
        {
            listOfArray = new List<int[]>();
            for (int i = 0; i < 1000; i++)
                listOfArray.Add(new int[1000]);
        }
        public void DeAllocate()
        {
            listOfArray.Clear();
        }
    }
    public struct StructOrClass1
    {
        public int X;
    }
    public class StructOrClass2
    {
        public int X;
    }
        
    public class StructOrClass3
    {
        public StructOrClass2 X = new StructOrClass2();
    }
    
    public enum FutureHusbandType : int
    {
        None =0 ,
        HasBigNose =1 ,
        IsBald =2 ,
        IsShort = 4
    }
    public class Program
    {
        public static int GetObjectType(object o)
        {
            if (o is string)
                return 0;
            else if (o is Array)
                return 1;
            else if (o is int)
                return 2;
            return -1;
        }
        public static bool IdealHusband(FutureHusbandType fht)
        {
            if (((int)fht == 1) || ((int)fht == 2) || ((int)fht == 4) || ((int)fht == (1 | 2 | 4)))
                return false;
            else if (((int)fht == (1 | 2)) || ((int)fht == (1 | 4)) || ((int)fht == (2 | 4))) 
                return true;

            return false;
        }
        public static void Main(string[] args)
        {

        }
    }
}
