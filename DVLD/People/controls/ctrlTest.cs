using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD;
namespace DVLD.People.controls
{
    public partial class ctrlTest : UserControl
    {
        public event Action<int> onPersonSelected;
        protected virtual void PersonSelected(int PersonID)
        {
            Action<int> handler = onPersonSelected;
            handler(PersonID);
        }
        public ctrlTest()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            onPersonSelected(15);
        }
    }
}
