using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

// Given n pairs of parentheses, 
// write a function to generate all combinations of
//  well-formed parentheses.
// 1 <= n <= 8

public class Solution {
    int max;
    List<string> result = new List<string>();

    static void Main(string[] args){
        Console.WriteLine(GenerateParenthesis(3));
    }

    public List<string> GenerateParenthesis(int n) {
        max = n;
        GenerateAndCheck("",0,0);
        return result;
    }

    private void GenerateAndCheck(string str, int a, int b){
        if (a == b && a == max){
            result.Add(str);
            return;
        }
        if(a < max){
            GenerateAndCheck(str + "(", a + 1, b);
        }
        if (b < a){
            GenerateAndCheck(str + ")", a, b+1);
        }
    }


}
