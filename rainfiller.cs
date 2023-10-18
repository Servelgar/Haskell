using System;
using System.Text;


// Given n non-negative integers representing an elevation map 
// where the width of each bar i 1, compute how much water it can 
// trap after raining

public class Solution {
    static void Main(string[] args){
       int[] height = {0,1,0,2,1,0,1,3,2,1,2,1};
       int[] height2 = {4,2,0,3,2,5};
       int[] height3 = {3,0,3};
       int s = Trap(height3);
       Console.WriteLine(s);
    }

    static int Trap(int[] height) {
        // Water is stored if it's surrounded of elevation/terrain or water
        // this could change on the vertical line
        int area = 0, i = 0;
        int j = height.Length - 1;
        int primero = height[i];
        int segundo = height[j];
        while(i < j){
            if(primero <= segundo){
                i++;
                area += Math.Max(0, primero - height[i]);
                primero = Math.Max(primero, height[i]);
            } else {
                j--;
                area += Math.Max(0, segundo - height[j]);
                segundo = Math.Max(segundo, height[j]);
            }
        }
        return area;
    }



}
