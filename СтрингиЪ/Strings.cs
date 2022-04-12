 using System;
using System.Collections.Generic;

namespace СтрингиЪ
{
    /// <summary>
    /// Работа со строками
    /// </summary>
    public class Strings
    {
        /// <summary>
        /// Индекс первого вхождения подстроки sub
        /// в строку source, начиная с индекса start
        /// </summary>
        /// <param name="source">строка, в которой производится поиск</param>
        /// <param name="sub">подстрока</param>
        /// <param name="start">индекс начала проверки вхождения</param>
        /// <returns>индекс первого вхождения подсроки в строку начиная с индекса start. Если вхождения нет, возвращает -1</returns>
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
        /// <summary>
        /// поиск всех вхождений образца pattern в исходную строку source
        /// </summary>
        /// <param name="source">строка, в которой производится поиск</param>
        /// <param name="pattern">образец</param>
        /// <returns>список индексов начала вхождения</returns>
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
        /// <summary>
        /// Вспомогательная функция метода КМП(Кнута, Морриса, Пратта)
        /// эффективного поиска вхождения подстроки в строку
        /// подсчёт длины префиксов, совпадающих с суффиксами
        /// </summary>
        /// <param name="pattern">образец для поиска</param>
        /// <returns>массив длин префиксов</returns>
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
        /// <summary>
        /// Эффективный алгоритм КМП поиска вхождения  образца
        /// pattern в строку source
        /// </summary>
        /// <param name="source">исходная строка</param>
        /// <param name="pattern">образец для поиска</param>
        /// <returns>Индекс первого вхождения. Если вхождения нет, вохвращает -1</returns>
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
        /// <summary>
        /// Список всех вхождений pattern в строку source
        /// </summary>
        /// <param name="source">строка, в которой производится поиск</param>
        /// <param name="pattern">образец</param>
        /// <returns>список всех вхождений</returns>
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