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
     * Complete the 'appendAndDelete' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts following parameters:
     *  1. STRING s
     *  2. STRING t
     *  3. INTEGER k
     */

    public static string appendAndDelete(string s, string t, int k)
    {
        if (s.Length + t.Length <= k) {
            return "Yes";
        }
        
        var len = Math.Min(s.Length, t.Length);
        int i=0;
        for (i=0; i < len; i++) {
            if (s[i] != t[i]) {
                break;
            }
        }
        
        var dels = s.Length - i;
        var adds = t.Length - i;
        var total = dels + adds;
        
        if (total == k || total == 0) {
            return "Yes";
        } else {
            if (total < k && dels == s.Length) {
                return "Yes";
            } else if (total < k && (k-total) % 2 == 0) {
                return "Yes";
            } else {
                return "No";
            }
        }
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string s = Console.ReadLine();

        string t = Console.ReadLine();

        int k = Convert.ToInt32(Console.ReadLine().Trim());

        string result = Result.appendAndDelete(s, t, k);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}

