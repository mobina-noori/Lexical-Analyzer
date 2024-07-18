using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lexical_Analyzer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var sKeywords = new List<string>(){
                "using","import","include","asm","else","auto","bool","break","case","catch","char","class","const","const_cast",
                "continue","default","delete","do","double","dynamic_cast","else","enum","explicit",
                "export","extern","false","float","for","friend","goto","if","inline","int","long",
                "main","mutable","namespace","new","operator","private","protected","public",
                "register","reinterpret_cast","return","short","signed","sizeof","static","cout",
                "static_cast","struct","switch","template","this","throw","true","try","typedef",
                "typeid","typename","union","unsigned","using","virtual","void","void","volatile","wchar_t","while"};
            OpenFileDialog fd = new OpenFileDialog();
            List<String> list = new List<String>();
            List<String> list1 = new List<String>();
            fd.Title = "Choose a source code";
            fd.Filter = "txt files (*.txt)|*.txt|cpp files(*.cpp)|*.cpp";
            fd.FilterIndex = 3;
            fd.RestoreDirectory = true;
            richTextBox1.Clear();
            richTextBox2.Clear();
            if (fd.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = fd.FileName;
            }
            string[] lines = System.IO.File.ReadAllLines(@textBox1.Text);
            foreach (string li in lines)
            {
                richTextBox1.AppendText(li + "\n");
            }
            foreach (string li in lines)
            {
                list.Add(li);
            }
            int blokeNumber = 0;
            richTextBox2.AppendText("Token" + "      " + "Type" + "                " + "Row" + "             " + "Column" + "        " + "Bloke Number" + "\n");
            for (int i = 0; i < list.Count; i++)
            {

                string temp = "";
                int j = 0;
                foreach (Char ch in list[i])
                {
                    if (ch != ' ')
                    {
                        temp = temp + ch;

                    }
                    j++;
                    if (ch == '+' || ch == '-' || ch == '*' || ch == '/' || ch == '%' || ch == '&' || ch == '^'
                    || ch == '<' || ch == '>' || ch == '!' || ch == '=')
                    {
                        richTextBox2.AppendText(ch + "              " + "operator" + "               " + (i + 1) + "                " + j + "             " + blokeNumber + "\n");
                    }
                    else if (ch == '{' || ch == '}' || ch == ';' || ch == ',' || ch == '(' || ch == ')')
                    {
                        if (ch == '{')
                        {
                            blokeNumber++;
                        }
                        richTextBox2.AppendText(ch + "              " + "Delimiters" + "                " + (i + 1) + "                " + j + "             " + blokeNumber + "\n");
                    }
                    else
                    {
                        foreach (String KeyW in sKeywords)
                        {
                            if (temp == KeyW)
                            {
                                temp = "";
                                richTextBox2.AppendText(KeyW + "              " + "Key word" + "                " + (i + 1) + "                " + j + "             " + blokeNumber + "\n");
                            }
                        }
                    }

                }
            }
        }
        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
