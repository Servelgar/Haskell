// Given a number, starting with 1
// Create new numbers (children) by taking the last digit n
// And concatenating 1 through n+1 
// A071159

using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;


//public class a{public static void main(String[]a)
//{float b=Float.parseFloat(a[0]);float c=1;
//for(int i=2;i<=b;i++)c*=(i+b)/i;System.out.print(c);}}


class program {
    static void Main(string[] args){
        // Diagonal Binary Sequence
        int n = int.Parse(args[0]);
        List<int> seq = new List<int>();
        seq = catalSeque(n, seq);
        
        

       // int nthTerm = catalSeque(n).IndexOf(n - 1);
       // Console.WriteLine(nthTerm);

    }

    static List<int> step(int n){
        List<int> res = new List<int>();
        for (int i = 1; i <= (n%10 + 1); i++){
            res.Add(10*n +  i);
        }
        return res;
    }

    static List<int> catalSeque(int n, List<int> seq){
        if(n == 1){
            seq.Insert(0,1);
        } else {
            seq.Concat(seq.map(t => step(t)));
            catalSeque(n-1,seq);
        }
        return seq;
    }


}