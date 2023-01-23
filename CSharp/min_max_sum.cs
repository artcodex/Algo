using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Result
{

    /*
     * Complete the 'miniMaxSum' function below.
     *
     * The function accepts INTEGER_ARRAY arr as parameter.
     */

    public static void miniMaxSum(List<int> arr)
    {
        int min = arr.Min();
        int max = arr.Max();
        
        long minValue = arr.Where((v) => v!=max).Sum((s)=>(long)s);
        long maxValue = arr.Where((v) => v!=min).Sum((s)=>(long)s);
        
        minValue += (max * (arr.Where((v) => v == max).Count() - 1));
        maxValue += (min * (arr.Where((v) => v == min).Count() - 1));
        
        Console.WriteLine($"{minValue} {maxValue}");
    }

}

class Solution
{
    public static void Main(string[] args)
    {

        List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

        Result.miniMaxSum(arr);
    }
}

