using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudyApp_Block
{
    public partial class Form2 : Form
    {
        Form parent;
        protected static int hours = 0;
        public Form2()
        {
            InitializeComponent();
            parent = ParentForm;

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label1.Text = "Hours : " + trackBar1.Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            DialogResult a = MessageBox.Show("Are you sure you want to set timer to" + trackBar1.Value.ToString(), "Timer set!", MessageBoxButtons.OKCancel);
            if(a == DialogResult.OK)
            {
                hours = trackBar1.Value;
                this.Hide();
            }
            
        }

        public static void ResetTimerSettingS()
        {
            hours = 0; 
        }


        public int Hours => hours;

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
