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

namespace DVLD.People.controls
{
    public partial class ctrlPersonCardWithFilter : UserControl
    {

        public class DataBackEventArgs : EventArgs
        {
            public int PersonID { get; }
            public DataBackEventArgs(int PersonID) 
            { 
                this.PersonID = PersonID;
            }
        }
        public event EventHandler<DataBackEventArgs> PersonSelected;
        protected virtual void OnPersonSelected(int PersonID)
        {
            PersonSelected?.Invoke(this, new DataBackEventArgs(PersonID));
        }
        public ctrlPersonCardWithFilter()
        {
            InitializeComponent();
        }

        private bool _ShowAddPerson = true;
        public bool ShowAddPerson 
        { 
            get 
            {
                return _ShowAddPerson;
            } 
            set 
            {
                _ShowAddPerson=value;
                btnAddNewPerson.Visible = _ShowAddPerson;
            } 
        }

        public void Filter_Focus()
        {
            txtFilterBy.Focus();
        }

        private bool _FilterEnabled = true;
        public bool FilterEnabled
        {
            get
            {
                return _FilterEnabled;
            }
            set
            {
                _FilterEnabled=value;
                gbFilter.Enabled = _FilterEnabled;
            }
        }

        public int PersonID 
        {
            get{ return ctrlPersonInformation.PersonId;}
        }

        public clsPerson SelectedPerson
        {
            get
            {
                return ctrlPersonInformation.SelectedPerson;
            }

        }


        private void FindPerson()
        {
            switch(cbFilterBy.Text)
            {
                case "National No":
                    ctrlPersonInformation.LoadPersonInfo((string)txtFilterBy.Text);
                    break;

                case "Person ID":
                    ctrlPersonInformation.LoadPersonInfo(int.Parse(txtFilterBy.Text));
                    break;

                default:
                    break;
            }
            OnPersonSelected(PersonID);
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterBy.Text = "";
            txtFilterBy.Focus();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fields are not valid!, put the mouse over the red icon(s) to see the error", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            FindPerson();
        }

        private void txtFilterBy_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFilterBy.Text.Trim()))
            {
                errorProvider1.SetError(txtFilterBy, "this field is required");
            }
            else
                errorProvider1.SetError(txtFilterBy, null);
        }

        private void ctrlPersonCardWithFilter_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 0;
            txtFilterBy.Focus();
        }

        private void txtFilterBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the pressed key is Enter (character code 13)
            if (e.KeyChar == (char)13)
            {
                btnFind.PerformClick();
            }

            //this will allow only digits if person id is selected
            if (cbFilterBy.Text == "Person ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);


        }


        private void btnAddNewPerson_Click_1(object sender, EventArgs e)
        {
            frmAddUpdatePerson frmAddNewPerson = new frmAddUpdatePerson();

            // Subscribe to the DataBack event
            frmAddNewPerson.DataBack += (s, args) =>
            {
                // Access the PersonID from the event arguments
                int personID = args.PersonID;

                // Update UI elements and perform actions
                cbFilterBy.SelectedIndex = 1;
                txtFilterBy.Text = personID.ToString();
                ctrlPersonInformation.LoadPersonInfo(personID);
            };

            // Show the form as a dialog
            frmAddNewPerson.ShowDialog();
        }

        public void LoadPersonInfo(int personID)
        {
            ctrlPersonInformation.LoadPersonInfo(personID);
        }
    }
}
