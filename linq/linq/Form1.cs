using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using static System.Convert;

namespace linq
{
    public partial class Form1 : Form
    {
        Humans first,second;
        public Form1()
        {
            InitializeComponent();
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                ofd.FilterIndex = 2;

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    first = new Humans(ofd.FileName);
                }
            }
            first.Fill_ListBox(listBox1);
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                ofd.FilterIndex = 2;

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    second = new Humans(ofd.FileName);
                }
                second.Fill_ListBox(listBox2);
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            logicinfo.Text = "";
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    {
                        logicinfo.Text = "Больше";
                    }break;
                case 1:
                    {
                        logicinfo.Text = "Меньше";
                    }
                    break;
                case 2:
                    {
                        logicinfo.Text = "Больше либо равно";
                    }
                    break;
                case 3:
                    {
                        logicinfo.Text = "Меньше либо равно";
                    }
                    break;
                case 4:
                    {
                        logicinfo.Text = "Не равно";
                    }
                    break;
            }
        }
        private int lastText;
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
            {
                try
                {
                    lastText = ToInt32(textBox1.Text);
                }
                catch
                {
                    textBox1.Text = lastText.ToString();
                }
            }else
            {
                lastText = 0;
            }
        }
        IEnumerable<People> peoples;
        private void button1_Click(object sender, EventArgs e)
        {
            var ppls = first.peoples.Union(second.peoples);
            
           switch (comboBox1.SelectedIndex)
           {
               //>
               case 0:
                   {
                        peoples = from pe in ppls where pe.Age > lastText select pe;
                   }break;
               //<
               case 1:
                   {
                        peoples = from pe in ppls where pe.Age < lastText select pe;
                    }
                   break;
               //>=
               case 2:
                   {
                        peoples = from pe in ppls where pe.Age >= lastText select pe;
                    }
                   break;
               //<=
               case 3:
                   {
                        peoples = from pe in ppls where pe.Age <= lastText select pe;
                    }
                   break;
               //<>
               case 4:
                   {
                        peoples = from pe in ppls where pe.Age != lastText select pe;
                    }
                   break;
           }
            listBox3.Items.Clear();
            foreach (var ppl in peoples)
            {
                listBox3.Items.Add(ppl);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
