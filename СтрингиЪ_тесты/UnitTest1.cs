using System;
using System.Collections.Generic;
using NUnit.Framework;
using СтрингиЪ;

namespace СтрингиЪ_тесты
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void MyIndexOf()
        {
            string str = "dfu1hf1138198f111fk1s1df1k1ldf1jk_if18873r1u1h11e1";
            for (int i = 0; i < short.MaxValue; i++)
            {
                char sub = (char)i;
                Assert.AreEqual(str.IndexOf(sub), Strings.MyIndexOf(str, sub.ToString()));
            }
        }

        [Test]
        public void MyIndexOfLong()
        {
            string str = "dfu1hf1138198f111fk1s1df1k1ldf1jk_if18873r1u1h11e1";
            for (int i = 32; i < short.MaxValue; i++)
            {
                string sub = ((char)i) + "1";
                Assert.AreEqual(str.IndexOf(sub, StringComparison.Ordinal), Strings.MyIndexOf(str, sub));
            }
        }

        [Test]
        public void MyIndexOfLongStart()
        {
            string str = "dfu1hf1138198f111fk1s1df1k1ldf1jk_if18873r1u1h11e1";
            for (int s = 0; s < str.Length - 2; s++)
            for (int i = 32; i < short.MaxValue; i++)
            {
                string sub = ((char)i) + "1";
                Assert.AreEqual(str.IndexOf(sub, s,StringComparison.Ordinal), Strings.MyIndexOf(str, sub, s));
            }
        }

        [Test]
        public void MyIndexOfAll()
        {
            string str = "dfu1hf1138198f111fk1s1df1k1ldf1jk_if18873r1u1h11e1";
            string sub = "u1";
            List<int> correct = new List<int>()
            {
                2, str.LastIndexOf(sub)
            };
            Assert.AreEqual(correct, Strings.AllIndexOf(str, sub));
        }

        [Test]
        public void KMP()
        {
            string str = "dfu1hf1138198f111fk1s1df1k1ldf1jk_if18873r1u1h11e1";
            for (int i = 0; i < short.MaxValue; i++)
            {
                string sub = ((char)i) + "1";
                Assert.AreEqual(str.IndexOf(sub, StringComparison.Ordinal), Strings.IndexOf_KMP(str, sub));
            }
        }
        [Test]
        public void KMPAll()
        {
            string str = "dfu1hf1138198f111fk1s1df1k1ldf1jk_if18873r1u1h11e1";
            string sub = "u1";
            List<int> correct = new List<int>()
            {
                2, str.LastIndexOf(sub)
            };
            Assert.AreEqual(correct, Strings.IndexOfKMP_Best(str, sub));
        }
    }
}