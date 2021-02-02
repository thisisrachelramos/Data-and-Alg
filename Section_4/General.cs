using System;
using System.Collections.Generic;
using System.Linq;

namespace General
{
    public class Question1
    {
        // Given 2 arrays, create a function that let's a user know (true/false) whether these two arrays contain any common items
        //For Example:
        //const array1 = ['a', 'b', 'c', 'x'];//const array2 = ['z', 'y', 'i'];
        //should return false.
        //-----------
        //const array1 = ['a', 'b', 'c', 'x'];//const array2 = ['z', 'y', 'x'];
        //should return true.

        // 2 parameters - arrays - no size limit
        // return true or false

        // input: arrays
        // output: bool
        // constraints: characters. (ASCII range?) no size limit. dupes in one array
        // time: O(n)

        // var HashMap 
        // arr1 max i  (3)
        // arr2 max j (2)

        // iterate through longest
        // index = 
        // ^^^ remember for index minus 1

        // tradl for loop
        // if ( index > maxi)
        // check arr1
        // if ( index > maxj)
        // check arr2
        // if not in hash map  
        // add to map (key is 1 or 2 to signal which, value is arr value)
        // else return true
        // return true
        public static bool HasCommonItem(char[] arr1, char[] arr2)
        {
            HashSet<char> set = new HashSet<char>();
            foreach (var item1 in arr1)
            {
                if (!set.Contains(item1))
                {


                    set.Add(item1);
                }
            }

            foreach (var item2 in arr2)
            {
                if (set.Contains(item2))
                {
                    return true;
                }

            }
            return false;
        }
        /*
        public static void Main(){
            char[] array1 = {'a', 'b', 'c', 'x'};
           char[]  array2 = {'z', 'y', 'x'};
           var result = HasCommonItem(array1,array2);
          Console.WriteLine($"Has common item?: {result}") ;
          return;
        }
        */
    }

}