using System;
using System.IO;
using System.Text;

// Calcular el maximo area dado dos lineas perpendiculares al eje x en 
// n lineas 
// O(n)

class Solution {
    static void Main(string[] args){
        int[] height = {1,8,6,2,5,4,8,3,7};
        int m = MaxArea(height);
        Console.WriteLine(m);

    }

    static int MaxArea(int[] height) {
        int max = 0;
        int i = 0;
        int j = height.Length - 1;
        while(i < j){
            int rect = ((j - i) * (Math.Min(height[i],height[j])));
            max = Math.Max(max,rect);
            if(height[i] < height[j]){
                i++;
            } else {
                j--;
            }
        }

        return max;
    }
}
