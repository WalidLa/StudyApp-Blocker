using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace StudyApp_Block
{
    public class CloseProg
    {
        protected List<string> proclList = new List<string>();
       // protected List<string> active;
        // protected Process[] _process; 
        
        public CloseProg(List<string> list)
        {
            this.proclList = list;
            CheckActive();
        }

        public void CheckActive()
        {
            //active = new List<string>();
            foreach (var process in proclList)
            {
                foreach (var na in Process.GetProcessesByName(process))
                {
                    na.Kill();
                    MessageBox.Show(na.ProcessName + " was closed. \nGO TO STUDY", "Removed", MessageBoxButtons.OK);
                }
            }
            
        }
    }
}