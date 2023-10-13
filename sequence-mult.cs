// Given a number n > 1 as input, compute the respective sequence.
// Given a number n, you are to compute the sequence of positive numbers 
// where for each number a, the n-times multiple n*a is missing. 
// to avoid infinite sequence: lists up to 50. 

using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Diagnostics;
//using System.Linq;

class program {
    static void Main(string[] args){
      //  IEnumerable<int> seq = Enumerable.Range(1,50);
        List<int> op2 = operation(2, 100);
        List<int> op3 = operation(17,200);
        op2.ForEach(p => Console.WriteLine(p));
        Console.WriteLine("########");
        op3.ForEach(p => Console.WriteLine(p));
    }

    public static List<int> operation(int n, int tam){
        List<int> res = new List<int>();
        List<int> exc = new List<int>();
        int cont = 0;
        while(tam > 0){
            cont++;
            if(!exc.Contains(cont)){
                res.Add(cont);
                exc.Add(cont*n);
            }
            tam -= 1;
        }
        return res;
    }

   

}