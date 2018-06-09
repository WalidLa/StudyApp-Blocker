using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace StudyApp_Block
{
    public partial class ProcessListView : Form
    {
        Form parent;
        // private static int lastitem = 0;

        public ProcessListView()
        {
            InitializeComponent();
            parent = ParentForm;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void UpdateListB()
        {
            listBox1.Items.Clear();
            for (var i = 0; i < Form1.ProclList.Count; i++)
            {
                listBox1.Items.Add(Form1.ProclList[i]);
                //lastitem++;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UpdateListB();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count == 0)
                return; 
            var tmp = listBox1.SelectedIndex;
            Form1.ProclList.RemoveAt(tmp);
            listBox1.Items.Remove(listBox1.SelectedItem);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count == 0)
                return;
            listBox1.Sorted = true; 
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            Form1.ProclList.Clear();
        }

        private void SaveButtom_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count == 0)
            {
                MessageBox.Show("Please make sure to add processors first or update your list! ", "Failed to save", MessageBoxButtons.OK);
                return; 
            }
            string savetext = ""; 
            for (var i = 0; i < Form1.ProclList.Count; i++)
            {
                savetext += Form1.ProclList[i] + "-||"; 
            }
            SaveFileDialog savedialog = new SaveFileDialog();
            savedialog.Filter = "Save File|*.sav";
            savedialog.Title = "Save your list File";
            savedialog.ShowDialog();


            if (savedialog.FileName != "" && savedialog.FileName != null)
            {
                File.WriteAllText(savedialog.FileName, savetext);
            }
        }

        private void LoadButtom_Click(object sender, EventArgs e)
        {
            OpenFileDialog loaddialog = new OpenFileDialog();
            loaddialog.Title = "Open List File";
            loaddialog.Filter = "Sav files|*.sav";
            //loaddialog.InitialDirectory = @"C:\";
            if (loaddialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (loaddialog.OpenFile() != null)
                    {
                        string filename = loaddialog.FileName;
                        string filetext = File.ReadAllText(filename);
                        AddToListFromLoad(filetext);
                        UpdateListB();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        void AddToListFromLoad(string file)
        {
            Form1.ProclList.Clear(); 
            string tmp = ""; 
            for (int i = 0; i < file.Length; i++)
            {
                if (file[i] != ' ' && file[i] != '|' && file[i] != '-')
                {
                    tmp += file[i];
                }
                else if (file[i] == '-' && tmp != "")
                {
                    Form1.ProclList.Add(tmp);
                    tmp = "";
                }
                else
                    tmp = ""; 
            }
        }
    }
}
