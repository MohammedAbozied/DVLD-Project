using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_Business;

namespace DVLD.People
{
    public partial class frmFindPerson : Form
    {
        // create event to back personID
        public class DataBackEventArgs : EventArgs
        {
            public int PersonID { get;  }
            public DataBackEventArgs(int PersonID)
            {
                this.PersonID = PersonID; 
            }

        }
        public event EventHandler<DataBackEventArgs> frmDataBack;
        protected virtual void onDataBack(int personID)
        {
            frmDataBack?.Invoke(this, new DataBackEventArgs(personID));   
        }
        //-----------------------------------------------------------
        public frmFindPerson()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            onDataBack(ctrlPersonCardWithFilter1.PersonID);
            this.Close();
        }




    }
}
