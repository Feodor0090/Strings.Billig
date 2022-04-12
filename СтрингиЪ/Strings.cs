 using System;
using System.Collections.Generic;

namespace СтрингиЪ
{
    /// <summary>
    /// Работа со строками
    /// </summary>
    public class Strings
    {
        public static int MyIndexOf(string source, string sub, int start = 0)
        {
            int index = -1;
            int i, j;
            int N = source.Length;
            int M = sub.Length;
            for (i = start; i < N - M + 1; i++)
                if (source[i] == sub[0])
                {
                    for (j = 0; j < M; j++)
                        if (!(source[i + j] == sub[j]))
                            break;
                    if (j == M)
                    {
                        index = i;
                        break;
                    }
                }

            return index;
        }

        public static List<int> AllIndexOf(string source, string pattern)
        {
            List<int> result = new List<int>();
            int start = 0;
            int res = MyIndexOf(source, pattern, start);
            while (res != -1)
            {
                result.Add(res);
                start = res + 1;
                res = MyIndexOf(source, pattern, start);
            }

            return result;
        }

        static int[] PrefixFunction(string pattern)
        {
            int m = pattern.Length;
            int[] res = new int[m];
            res[0] = 0;
            int k = 0;
            for (int i = 1; i < m; i++)
            {
                while ((k > 0) && (pattern[k] != pattern[i])) k = res[k - 1];
                if (pattern[k] == pattern[i]) k++;
                res[i] = k;
            }

            return res;
        }

        public static int IndexOf_KMP(string source, string pattern)
        {
            int n = source.Length;
            int m = pattern.Length;
            int[] pref = PrefixFunction(pattern);
            int i = 0, k = 0;
            while (i < n && k < m)
            {
                if (source[i] == pattern[k])
                {
                    i++;
                    k++;
                }
                else if (k == 0) i++;
                else
                    k = pref[k - 1];
            }

            if (k == m) return i - k;
            else return -1;
        }

        public static List<int> IndexOfKMP_Best(string source, string pattern)
        {
            string expand = pattern + "#" + source;
            int m = pattern.Length;
            int[] pref = PrefixFunction(expand);
            List<int> res = new List<int>();
            int n = pref.Length;
            for (int i = 0; i < n; i++)
                if (pref[i] == m)
                    res.Add(i - 2 * m);
            return res;
        }
    }
}