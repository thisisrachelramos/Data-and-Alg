/* 
Reflection:
1. Merge sorted arrays
    We most likely are limited by our array with smaller numbers
    See: https://stackoverflow.com/questions/30589449/merge-two-arrays-and-return-sorted-array-in-c-sharp
    And: https://i.stack.imgur.com/ObWK9.png
2. Two Sum
    Dictionary of values we are looking for, if not found, add myself! (not the target value)
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Arrays
{
    public class Question68
    {
        public static string ReverseString(string stringToReverse)
        {
            return new string(stringToReverse.Reverse().ToArray());
        }
        /*
        public static void Main(){
           var result = ReverseString("Hello, my name is Pusheen");
          Console.WriteLine($"Is this backwards?: {result}") ;
          return;
        }
    */
    }

    public class Question70
    {
        //mergeSortedArrays([0,3,4,31], [3,4,6,30]);
        //mergeSortedArrays([0,3,4,31], [30, 100]);
        public static List<int> MergeSortedArrays(int[] arr1, int[] arr2)
        {
            // check if empty
            var i = 0;
            var j = 0;

            List<int> resultArray = new List<int>();
            while (i < arr1.Length && j < arr2.Length)
            {

                if (arr1[i] == arr2[j])
                {
                    resultArray.Add(arr1[i]);
                    i++;
                    j++;
                }
                if (arr1[i] < arr2[j])
                {
                    resultArray.Add(arr1[i]);
                    i++;
                }
                if (arr1[i] > arr2[j])
                {
                    resultArray.Add(arr2[j]);
                    j++;
                }
            }

            // now get the tails
            while (i < arr1.Length)
            {
                resultArray.Add(arr1[i]);
                i++;
            }

            while (j < arr2.Length)
            {
                resultArray.Add(arr2[j]);
                j++;
            }
            return resultArray;
        }

        /* 
                public static void Main(){
                    int[] arr1 = {0,3,4,31};
                    int[]  arr2 = {3,4,6,30};
                    var result = MergeSortedArrays(arr1, arr2);
                    Console.WriteLine($"Merged sorted arrays: {String.Join(" ", result)}") ;
                    return;
                } */
    }

    public class LeetCode
    {
        public int[] TwoSum(int[] nums, int target)
        {
            // init result arr
            int[] result = new int[2];
            // dict valueToFind
            var valueToFindDict = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                // for loop i=0
                // var target =  key: target - nums[i];

                // if contains in valueToFind, return i and dict value
                // else
                // var target = key: target - nums[i] value: index (i)
                var valueToFind = target - nums[i];
                if (valueToFindDict.ContainsKey(valueToFind))
                {
                    result[0] = i;
                    result[1] = valueToFindDict[valueToFind];
                    return result;
                }
                else
                {
                    valueToFindDict.Add(nums[i], i);
                }
            }
            return result;
        }

        // BIG O(n^2) Kadans algorithm
        public int maxContiguousSubarraySum(int[] array)
        {
            // declare set max var
            var maxSum = Int32.MinValue;

            // first loop is left index
            for (int left = 0; left < array.Length; left++)
            {
                // set running sum to 0
                var runningSum = 0;
                // second loop is right which is first equal to right
                for (int right = left; right < array.Length; right++)
                {
                    // runningSum += right[j]
                    runningSum += array[right];
                    // update maxSum
                    maxSum = Math.Max(runningSum, maxSum);
                }
            }
            return maxSum;
        }
        /* 
        Reflection: move everything to the left and then fill the end with zeros
         */
        public void MoveZeroes(int[] nums)
        {
            // zeroValueIndex = -1
            var zeroValueIndex = -1;
            // nonZeroValueIndex = -1
            var nonZeroValueIndex = -1;
            for (int i = 0; i < nums.Length; i++)
            {
                // for loop
                if (nums[i] == 0 && zeroValueIndex == -1)
                {
                    // if 0 value
                    //  set zeroValueIndex
                    zeroValueIndex = i;
                }
                if (nums[i] != 0)
                {
                    // if non zero
                    // set nonZeroValueIndex
                    nonZeroValueIndex = i;
                }

                if (zeroValueIndex > -1 && nonZeroValueIndex > -1)
                {
                    // if value is 0 and nonZeroValueIndex is < -1
                    // swap 
                    if (zeroValueIndex > nonZeroValueIndex)
                    {
                        continue;
                    }
                    nums[zeroValueIndex] = nums[nonZeroValueIndex];
                    nums[nonZeroValueIndex] = 0;
                    // nums[nonZeroValueIndex] = nums[zeroValueIndex]
                    // set nonzero to -1
                    nonZeroValueIndex = -1;
                    // set zeroindex to nonzero index
                    zeroValueIndex++;
                }
            }
        }

        /* Reflection: sometimes another loop is better than getting fancy with the vars */
        public void MoveZeroesCleaned(int[] nums)
        {
            var slowIndex = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != 0)
                {
                    nums[slowIndex++] = nums[i];
                }
            }

            for (int j = slowIndex; j < nums.Length; j++)
            {
                nums[j] = 0;
            }
        }

        /* It is contains for HashSET (and Add, but thats the same for map) */
        public bool ContainsDuplicate(int[] nums)
        {
            HashSet<int> set = new HashSet<int>();
            foreach (var num in nums)
            {
                if (set.Contains(num))
                {
                    return true;
                }
                set.Add(num);
            }

            return false;

        }

        public void RotateArray(int[] nums, int k)
        {


            var rotation = k > nums.Length ? k % nums.Length : k;
            if (rotation == nums.Length || rotation == 0)
            {
                return;
            }
            var newArray = new int[nums.Length];
            var numsRotationPoint = nums.Length - rotation;
            var j = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                var numsTailIndex = numsRotationPoint + i;
                if (numsTailIndex < nums.Length)
                {
                    newArray[i] = nums[numsTailIndex];
                }
                // tails
                else
                {
                    newArray[i] = nums[j++];
                }
            }

            nums = newArray;

        }

        /* REFLECTION
        REGEX [^] is NOT in collection, then you can list the things you want to strip away from the 
        valid word before you compare lengths
        
         */
        public static string LongestWord(string sen)
        {
            // split
            var splitSen = sen.Split(' ');
            var longestWord = String.Empty;
            var longestWordLength = Int32.MinValue;
            // regex
            var regexString = "[^a-zA-Z0-9_.]+";
            // if len == 1 return word match
            // else for each
            foreach (var word in splitSen)
            {
                // if match regex, update length and update word;
                var strippeWord = Regex.Replace(word, regexString, String.Empty);
                if (strippeWord.Length > longestWordLength)
                {
                    longestWordLength = strippeWord.Length;
                    longestWord = strippeWord;
                }
            }

            // code goes here  
            return longestWord;

        }

    }
}