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

            Settings.NewLineChars = "\n"; //переход

            string txt1;
            txt1 = textBox1.Text;

            string[] Words = new string[100];
            string[] Lex = new string[] {" ",".",",","!","?",":",";"};
            string Word;
            int a,b,i,j,c;

            a = txt1.Length;
            b = 1;

            for (i = 1; i <= a; i++)
            {
                if (txt1[i] in Lex) 
                {
                    Word = Word + txt1[i];
                }
                else
                {
                    Words[b] = Word;
                    Word = "";
                    b++;
                }
            }

            output = XmlWriter.Create("xmlt.xml", Settings);
            
                output.WriteStartElement(txt1);
                output.WriteAttributeString("падеж", "склонительный");
                output.WriteEndElement();
                output.Flush();
                output.Close();

            


        }
    }
}
