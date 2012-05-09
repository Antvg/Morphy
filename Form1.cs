using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace Morphy
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            XmlWriter output = null; //черт его знает зачем, но нужно.
            XmlWriterSettings Settings = new XmlWriterSettings(); //XML Обьява

            Settings.Indent = true; //отступ
            Settings.IndentChars = "    "; // собственно сам отступ - 4 пробела
            //Settings.ConformanceLevel = ConformanceLevel.Fragment;
            Settings.NewLineChars = "\n"; //переход

            string txt1;
            txt1 = textBox1.Text;

            string[] Words = new string[1000];
            char[] Lex = new char[] {' ','.',',','!','?',':',';'};
            string Word;
            string tt;
            tt = "";
            int b;
            Word = "";
            b = 0;

            for (int i = 0; i < txt1.Length; i++) //загоняем слова в массив
            {
                //tt += txt1[i];
                //if (((IList<string>)Lex).Contains(txt1[i])) //перевод в лист для контейна
                if (((IList<char>)Lex).Contains(txt1[i]))
                {
                    Words[b] = Word;
                    Word = "";
                    b++;
                    //tt = "";
                }
                else
                {
                   Word += txt1[i];
                   //tt = "";
                }
            }

            output = XmlWriter.Create("result.xml", Settings); //массив слов в XML

            output.WriteStartElement("Слова"); //делаем корневой нод

            for (int i = 0; i < b; i++)
            {
                output.WriteStartElement(Words[i]);
                output.WriteAttributeString("падеж", "склонительный");
                output.WriteAttributeString("тип", "существительное");
                output.WriteEndElement();

            }

            output.WriteEndElement();
                
            output.Flush();
                
            output.Close();

            }
    }
}
