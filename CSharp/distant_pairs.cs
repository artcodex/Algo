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



class Solution
{
    static Dictionary<(int, int), int> partialResults = new Dictionary<(int, int), int>();
    private static int calcPdist(int a, int b, int c) {
        if (partialResults.ContainsKey((a, b))) {
            
            return partialResults[(a, b)];
            
        }
        
        var result = Math.Min(Math.Abs(a-b), c - Math.Abs(a-b));
        if (partialResults.Count < 1000) {
            partialResults.Add((a, b), result);
        }
        
        return result;
    }
    
    private static int calculatePointDistance(List<int> a, List<int> b, int c) {
        int a1 = a[0], a2 = a[1];
        int b1 = b[0], b2 = b[1];
        
        var acc = Math.Min(calcPdist(a1,a2, c), calcPdist(b1, b2, c));    
        acc = Math.Min(acc, calcPdist(a1, b2, c));
        acc = Math.Min(acc, calcPdist(b1, a2, c));
        acc = Math.Min(acc, calcPdist(a1, b1, c));
        acc = Math.Min(acc, calcPdist(a2, b2, c));
        
        return acc;
    }
    
    public static void Main(string[] args)
    {
        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int n = Convert.ToInt32(firstMultipleInput[0]);

        int c = Convert.ToInt32(firstMultipleInput[1]);

        List<List<int>> points = new List<List<int>>();

        for (int i = 0; i < n; i++)
        {
            points.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(pointsTemp => Convert.ToInt32(pointsTemp)).ToList());
        }
        
        var maxAcc = 0;
        for(int i=0; i < points.Count; i++) {
            for (int j=i+1; j < points.Count; j++) {
                maxAcc = Math.Max(maxAcc, calculatePointDistance(points[i], points[j], c));
            }
        }
        // Write your code here
        Console.WriteLine(maxAcc);
    }
}
