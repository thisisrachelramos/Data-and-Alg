using System;
using System.Collections.Generic;
namespace Recursion
{


    public class Exercise154
    {

        /*
 Reflection: We did good (:
 Only plus is to remember that factorials can stop at 2! since 1*x = x, so we can skip that op
 */
        public static int CalculateFactorial(int value)
        {
            if (value == 2)
            {
                return value;
            }

            return CalculateFactorial(value - 1) * value;
        }

        public static int CalculateFactorialIterative(int value)
        {
            var result = 1;
            for (int i = value; i > 1; i--)
            {
                result *= i;
            }
            return result;
        }

        //    public static void Main(){
        //       // var result = CalculateFactorialIterative(5);
        //      var result = CalculateFactorial(5);
        //     Console.WriteLine($"Answer is: {result}");
        // }

        public int FibonacciIterative(int n)
        {
            var list = new List<int>() { 0, 1 };
            for (int i = 2; i < n; i++)
            {
                list.Add(list[i - 1] + list[i - 2]);
            }
            return list[n];
        }
        /*
         Reflection: We did good (:
       Could clean up those if conditions to a < case
       BIG O: 2^n EXPONENTIAL (not to be confused with QUADRATIC (n^2))
         */
        public int Fibonacci(int n)
        {
            if (n == 0)
            {
                return 0;
            }
            if (n == 1)
            {
                return 1;
            }
            return Fibonacci(n - 1) + Fibonacci(n - 2);
        }


        /*
        Reflection: Strings are immutable in C# soooo we had to
            - create a result sting by creating a NEW string with a given length and filler char
            - Use the .Insert(i,string) function that RETURNS a string...
        Besides that we nailed it... only had to look up new string() and .Insert
        */
        public static string ReverseStringIteratively(string input)
        {
            var result = new string(' ', input.Length);
            for (int i = 0; i < input.Length; i++)
            {
                result = result.Insert(i, input[input.Length - 1 - i].ToString());
            }
            return result;
        }

        public  string ReverseStringIterativelyV2(string input)
        {
            var result = input.ToCharArray();
            for (int i = 0; i < input.Length; i++)
            {
                result[i] = input[input.Length - 1 - i];
            }
            return new string(result);
        }

        public static string ReverseStringRecursive(string input)
        {
            if (input.Length == 0){
                return input;
            }

            return ReverseStringRecursive(input.Substring(1)) + input[0];
        }
/*
y
o
y
o

m
a
s
t
e
r
y

since its recursive its going to return BACKWARDSSSSSSSSSSSSSSSSS
*/
        public static void Main()
        {
            // var result = FibonacciIterative(5);
            //var result = Fibonacci(7);
            var result = ReverseStringRecursive("yoyo mastery");
            Console.WriteLine($"Answer is: {result}");
        }


    }



}