using System;
using System.Linq;
using System.Collections.Generic;

namespace HashTables
{
    public class MyHashTable
    {
        private int _size = 0;
        private List<List<(string, int)>> _data;
        public MyHashTable(int legnth)
        {
            _size = legnth;
            _data = new List<List<(string, int)>>();
        }

        public int HashValue(string key)
        {
            var hash = 0;
            for (int i = 0; i < key.Length; i++)
            {
                hash = (hash + (int)key[i]) % +_size;
            }
            return hash;
        }

        public void Set(string key, int value)
        {
            var address = HashValue(key);
            _data[address].Add((key, value));
        }

        public int? Get(string key)
        {
            var hashedValue = HashValue(key);
            var count = _data[hashedValue].Count;
            return count > 0 ? _data[hashedValue].Where(x => x.Item1 == key).First().Item2 : null;
        }

        public IEnumerable<string> Keys()
        {
            return _data.SelectMany(x => x.Select(y => y.Item1));
        }


/* 
REFLECTION: We didn't answer the QS ;_; 
It is called FIRST recurring NOT MOST recurring char

*/
        //Google Question
        //Given an array = [2,5,1,2,3,5,1,2,4]:
        //It should return 2

        //Given an array = [2,1,1,2,3,5,1,2,4]:
        //It should return 1

        //Given an array = [2,3,4,5]:
        //It should return undefined
        // i: int[] 
        //  may contain dupes, may be neg or zero
        // length: may be empty
        // o: most repeated int
        // what do we do in a tie breaker
        // time: O(n)
        /*
        [2,5,1,2,3,5,1,2,4]:

        // set
        1
        3
        4

        maxReps:3

        // dict (key: reps, value: value in arr)
        2:2,5
        3:2

        return dict[3][0]

        */
        public int? RecurringInteger(int[] arr)
        {            var maxRepCount = int.MinValue;
            int? maxRepCountKey = null;
            var dict = new Dictionary<int, int>();
            foreach (var item in arr)
            {
                if (dict.ContainsKey(item))
                {
                    dict[item] = dict[item]++;
                    if (dict[item] > maxRepCount)
                    {
                        maxRepCount = dict[item];
                        maxRepCountKey = item;
                    }
                }
            }
            return maxRepCountKey!=null ? dict[(int)maxRepCountKey]:null ;
        }
    }
}