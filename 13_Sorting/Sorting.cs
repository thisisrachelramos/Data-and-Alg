using System;

namespace Sorting
{
    public class BubbleSort
    {

        public BubbleSort()
        {

        }

        public int[] Sort(int[] list)
        {

            var end = list.Length;

            var slow = 0;
            var fast = 1;
            while (end > 0)
            {
                while (fast <= end)
                {
                    if (slow > fast)
                    {
                        var oldValue = list[fast];
                        list[fast] = list[slow];
                        list[slow] = oldValue;
                    }
                    slow++;
                    fast++;
                }
                slow = 0;
                fast = 1;
                end--;
            }
            return list;
        }

        public static int[] Sortv2(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr.Length -1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        var temp = arr[j + 1];
                        arr[j + 1] = arr[j];
                        arr[j] = temp;
                    }
                }
            }
            return arr;
        }


   static void Main(string[] args)
    {
        int[] array = {8, 1, 56, 4, 7, 1, 87, 0};
        foreach (var item in BubbleSortV3(array))
        {
            Console.WriteLine(item);
        }
    }

        public static int[] BubbleSortV3(int[] input){

                for (int i = 0; i < input.Length - 1; i++) 
                {
                    for (int j = 0; j < input.Length - 1 - i; j++)
                    {
                        //Console.WriteLine($"Comparing {input[j]}-{input[j+1]}");
                        if (input[j] > input[j+1])
                        {
                            var temp = input[j];
                            input[j] = input[j + 1];
                            input[j + 1] = temp;

                        }
                    }
                }
                return input;
        }

        public int[] SelectionSort(int[] arr)
        {
            var startIndex = 0;
            while (startIndex < arr.Length)
            {
                var minIndex = startIndex;

                for (int i = startIndex; i < arr.Length; i++)
                {
                    if (arr[i] < arr[minIndex])
                    {
                        minIndex = i;
                    }
                }
                var temp = arr[startIndex];
                arr[startIndex] = arr[minIndex];
                arr[minIndex] = temp;

                startIndex++;
            }
            return arr;
        }

        /*
        Reflection: BEST for small sets.
        Inserts its self in handy and tiny scenarios
        */
        public int[] InsertionSort(int[] inputArray)
        {
            for (int i = 0; i < inputArray.Length - 1; i++)
            {
                for (int j = i + 1; j > 0; j--)
                {
                    if (inputArray[j - 1] > inputArray[j])
                    {
                        int temp = inputArray[j - 1];
                        inputArray[j - 1] = inputArray[j];
                        inputArray[j] = temp;
                    }
                  }
            }
            return inputArray;         
        }

        public int[] MergeSort(int[] arr)
        {
            // 0 OR 1: return
            if (arr.Length <= 1)
            {
                return arr;
            }
            // var middle = arr len/2
            var mid = arr.Length / 2;
            // thatll be the left arr len
            int[] left = new int[mid];
            // right arr will either be same (len of mid) if even
            // OR mid+1 if odd
            int[] right = arr.Length % 2 == 0 ?
            new int[mid] : new int[mid + 1];

            // iterate through right to populate
            var x = 0;
            for (int i = mid; i < arr.Length; i++)
            {
                right[x] = arr[i];
                x++;
            }

            // iterate left to populate
            for (int j = 0; j < mid; j++)
            {
                left[j] = arr[j];
            }

            // split up 
            var leftResult = MergeSort(left);
            var rightResult = MergeSort(right);

            // sort the left and right into final array
            return Merge(left, right);
        }

        public int[] Merge(int[] left, int[] right)
        {
            int resultLength = right.Length + left.Length;
            int[] result = new int[resultLength];

            int indexLeft = 0, indexRight = 0, indexResult = 0;

            while (indexLeft < left.Length || indexRight < right.Length)
            {
                if (indexLeft < left.Length && indexRight < right.Length)
                {
                    if (left[indexLeft] <= right[indexRight])
                    {
                        result[indexResult] = left[indexLeft];
                        indexLeft++;
                        indexResult++;
                    }
                    else
                    {
                        result[indexResult] = right[indexRight];
                        indexRight++;
                        indexResult++;
                    }
                }
                else if (indexLeft < left.Length)
                {
                    result[indexResult] = left[indexLeft];
                    indexLeft++;
                    indexResult++;
                }
                else if (indexRight < right.Length)
                {
                    result[indexResult] = right[indexRight];
                    indexRight++;
                    indexResult++;
                }
            }
            return result;
        }

    }

//#1 - Sort 10 schools around your house by distance: Insertion
// space complexity: O(1) ~O(n) if small!

//#2 - eBay sorts listings by the current Bid amount: Mergesort
//radix or counting sort since it is based on integers on a certain range!

//#3 - Sport scores on ESPN: 
// Quicksort for better space complexity

//#4 - Massive database (can't fit all into memory) needs to sort through past year's user data: 
//Mergesort (we dont care about memory as stated in QS)

//#5 - Almost sorted Udemy review data needs to update and add 2 new reviews: Quicksort
// Insertion sort for preordered list and adding only 2: Insertion sort
//#6 - Temperature Records for the past 50 years in Canada: Mergesort
//radix or counting sort BUT it cannot have decimals
// or Quicksort to save on dat space complexity

//#7 - Large user name database needs to be sorted. Data is very random. Quicksort

//#8 - You want to teach sorting for the first time Bubble/Selection

}