using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using СтрингиЪ;

namespace WinFormsСтринг
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBoxAnswer.Text = "";
        }

        private void reference_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Программа предназначена для поиска позиции подстроки в некотором тексте с использованием различных алгоритмов. Введите в поле \"Текст\" ваш текст для " +
                "просмотра, в \"Элемент\" искомую подстроку. Щёлкните кнопку с именем алгоритма для его выполнения, результат отобразится в поле справа.");
        }

        private void MyIndexOffButton_Click(object sender, EventArgs e)
        {
            textBoxAnswer.Text = "";
            string text = textBoxTask.Text;
            string pattern = textBoxPattern.Text;
            
            if (String.IsNullOrEmpty(text))
            {
                textBoxAnswer.Text = "Введите текст";
            }
            if (String.IsNullOrEmpty(pattern))
            {
                textBoxAnswer.Text = "Введите паттерн";
            }
            if(!String.IsNullOrEmpty(text)& !String.IsNullOrEmpty(pattern))
            {
                textBoxAnswer.Text = Strings.MyIndexOf(text, pattern).ToString();
            }



        }

        private void ALLIndexOff_Click(object sender, EventArgs e)
        {
            textBoxAnswer.Text = "";
            string text = textBoxTask.Text;
            string pattern = textBoxPattern.Text;
            List<int> res= new List<int>();

            if (String.IsNullOrEmpty(text))
            {
                textBoxAnswer.Text = "Введите текст";
            }
            if (String.IsNullOrEmpty(pattern))
            {
                textBoxAnswer.Text = "Введите паттерн";
            }
            if (!String.IsNullOrEmpty(text) & !String.IsNullOrEmpty(pattern))
            {
                 res = Strings.AllIndexOf(text, pattern);
                for (int i = 0; i < res.Count; i++)
                {
                    textBoxAnswer.Text += res[i].ToString() + ";";
                }
            }
        }

        private void IndexOf_KPMbutton_Click(object sender, EventArgs e)
        {
            textBoxAnswer.Text = "";
            string text = textBoxTask.Text;
            string pattern = textBoxPattern.Text;

            if (String.IsNullOrEmpty(text))
            {
                textBoxAnswer.Text = "Введите текст";
            }
            if (String.IsNullOrEmpty(pattern))
            {
                textBoxAnswer.Text = "Введите паттерн";
            }
            if (!String.IsNullOrWhiteSpace(text) & !String.IsNullOrEmpty(pattern))
            {
                textBoxAnswer.Text = Strings.IndexOf_KMP(text, pattern).ToString();
            }
        }

        private void IndexOf_KPMBest_Click(object sender, EventArgs e)
        {
            textBoxAnswer.Text = "";
            string text = textBoxTask.Text;
            string pattern = textBoxPattern.Text;
            List<int> res = new List<int>();

            if (String.IsNullOrEmpty(text))
            {
                textBoxAnswer.Text = "Введите текст";
            }
            if (String.IsNullOrEmpty(pattern))
            {
                textBoxAnswer.Text = "Введите паттерн";
            }
            if (!String.IsNullOrEmpty(text) & !String.IsNullOrEmpty(pattern))
            {
                res = Strings.IndexOfKMP_Best(text, pattern);
                for (int i = 0; i < res.Count; i++)
                {
                    textBoxAnswer.Text += res[i].ToString() + ";";
                }
            }
        }
    }
}
