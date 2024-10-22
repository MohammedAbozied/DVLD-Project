using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using DVLD_Business;

namespace DVLD.People.controls
{
    public partial class ctrlPersonCard : UserControl
    {

        private int _PersonID = -1;
        public int PersonId 
        {   get
            {
                return _PersonID;
            }
        }

        private clsPerson _Person;
        public clsPerson SelectedPerson 
        { 
            get { return _Person; } 
        }
        public ctrlPersonCard()
        {
            InitializeComponent();
        }

        // Load Method usually initialize person with 'find' method, then call 'fill' method 
        public void LoadPersonInfo(int PersonID)
        {
            _Person = clsPerson.Find(PersonID);

            if(_Person == null)
            {
                ResetPersonInfo();
                MessageBox.Show($"no person with id : {PersonID}", "Person not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FillPersonInfo();
        }
        public void LoadPersonInfo(string NationalNo)
        {
            _Person = clsPerson.Find(NationalNo);

            if (_Person == null)
            {
                ResetPersonInfo();
                MessageBox.Show($"no person with NationalNo : {NationalNo}", "Person not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            lblEditPersonInfo.Visible = true;
            _FillPersonInfo();
        }
        private void _FillPersonInfo()
        {
            lblEditPersonInfo.Visible = true;
            _PersonID = _Person.PersonID;
            lblPersonID.Text =_Person.PersonID.ToString();
            lblFullName.Text = _Person.FullName; 
            lblNationalNo.Text = _Person.NationalNo.ToString();

            lblGendor.Text = (_Person.Gendor==0?"Male":"Female");

            lblEmail.Text = _Person.Email;
            lblAddress.Text = _Person.Address;
            lblPhone.Text = _Person.Phone;
            lblCountry.Text = _Person.CountryInfo.CountryName;

            lblDateOfBirth.Text = _Person.DateOfBirth.ToShortDateString();

            lblGendorImage.Image = (_Person.Gendor == 0 ? Resources.Man_32 : Resources.Woman_32);

            _LoadPersonImage();

        }
        public void ResetPersonInfo()
        {
            _PersonID = -1;
            lblEditPersonInfo.Visible = false;
            lblPersonID.Text = "[????]";
            lblNationalNo.Text = "[????]";
            lblFullName.Text = "[????]";
            lblGendorImage.Image = Resources.Man_32;
            lblGendor.Text = "[????]";
            lblEmail.Text = "[????]";
            lblPhone.Text = "[????]";
            lblDateOfBirth.Text = "[????]";
            lblCountry.Text = "[????]";
            lblAddress.Text = "[????]";
            pbPersonImage.Image =pbPersonImage.InitialImage;

        }
        private void _LoadPersonImage()
        {
            string ImagePath = _Person.ImagePath;

            if(ImagePath == "")
                pbPersonImage.Image = (_Person.Gendor == 0 ? Resources.Male_512 : Resources.Female_512);

            else
            {
                if(File.Exists(ImagePath))
                {
                    pbPersonImage.Image = Image.FromFile(ImagePath);
                }
                else
                    MessageBox.Show("Could not find this image: = " + ImagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


        }

        private void lblEditPersonInfo_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson frmUpdatePerson = new frmAddUpdatePerson(_Person.PersonID);
            frmUpdatePerson.ShowDialog();
            LoadPersonInfo(_Person.PersonID);
        }


    }
}
