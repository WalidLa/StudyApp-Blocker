using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;


namespace StudyApp_Block
{
    public partial class Form1 : Form
    {
        protected static List<string> proclList = new List<string>();
        protected CloseProg a;
        private Form2 timersetting = new Form2();
        private ProcessListView listboxviewf = new ProcessListView();
        private Thread sleepb;

        public Form1()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {

            DialogResult info = MessageBox.Show("idk man", "Informations", MessageBoxButtons.OK);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string tmp = textBox1.Text;
            if (tmp == "")
                MessageBox.Show("Please enter a processer name (without \".exe\" ", "Try Again", MessageBoxButtons.OK);
            else
            {
                AddToList(tmp);
                DialogResult Added = MessageBox.Show(tmp + " Has been added", "Done!", MessageBoxButtons.OK);
            }

            textBox1.Clear();
            textBox1.Focus();

            listboxviewf.UpdateListB();
        }

        public void AddToList(string tmp)
        {
            proclList.Add(tmp);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {

                switch (timersetting.Hours)
                {
                    case 0:
                        KillNo();
                        break;
                    default:
                        KillTimer();
                        break;
                }
            }
        }

        private void _KillTimer()
        {

            var time = DateTime.Now.Hour;
            time += timersetting.Hours;
            Thread.Sleep(5000);
            a = new CloseProg(proclList);
            while (time != DateTime.Now.Hour)
            {
                a.CheckActive();
                Thread.Sleep(5000);
            }

            checkBox1.Checked = false;


        }
        private void KillTimer()
        {
            sleepb = new Thread(_KillTimer);
            sleepb.Start();

        }

        private void KillNo()
        {
            sleepb = new Thread(_KillNo);
            sleepb.Start();
        }

        private void _KillNo()
        {
            a = new CloseProg(proclList);
            Thread.Sleep(2000);
            while (checkBox1.Checked)
            {
                a.CheckActive();
                Thread.Sleep(2000);

            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            timersetting.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            listboxviewf.Show();
        }

        public static List<string> ProclList
        {
            get { return proclList; }
            set { proclList = value; }
        }
          
    }
}
