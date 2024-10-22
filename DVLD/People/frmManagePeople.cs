using System;
using System.Data;
using System.Windows.Forms;
using DVLD_Business;

namespace DVLD.People
{
    public partial class frmManagePeople : Form
    {
        public frmManagePeople()
        {
            InitializeComponent();
        }


       private static DataTable _dtAllPeople = clsPerson.GetAllPeople().DefaultView.ToTable(false, "PersonID", "NationalNo",
                                                       "FirstName", "SecondName", "ThirdName", "LastName",
                                                       "GendorCaption", "DateOfBirth", "CountryName",
                                                       "Phone", "Email");
       private DataView _dvPeople = new DataView(_dtAllPeople);


        private void _Refresh_PeopleList()
        {
            _dvPeople.RowFilter = "";
            cbFilterBy.SelectedIndex = 0;
        }

        private void frmManagePeople_Load(object sender, EventArgs e)
        {

            cbFilterBy.SelectedIndex = 0;
            dgvListPeople.DataSource = _dvPeople;
            lblCountPeople.Text = dgvListPeople.Rows.Count.ToString();

            dgvListPeople.Columns[0].HeaderText = "Person ID";
            dgvListPeople.Columns[0].Width = 90;

            dgvListPeople.Columns[1].HeaderText = "National No";
            dgvListPeople.Columns[1].Width = 90;

            dgvListPeople.Columns[2].HeaderText = "Frist Name";
            dgvListPeople.Columns[2].Width = 90;

            dgvListPeople.Columns[3].HeaderText = "Second Name";
            dgvListPeople.Columns[3].Width = 90;

            dgvListPeople.Columns[4].HeaderText = "Third Name";
            dgvListPeople.Columns[4].Width = 90;

            dgvListPeople.Columns[5].HeaderText = "Last Name";
            dgvListPeople.Columns[5].Width = 90;

            dgvListPeople.Columns[6].HeaderText = "Gendor Caption";
            dgvListPeople.Columns[6].Width = 90;

            dgvListPeople.Columns[7].HeaderText = "Year Of Birth";
            dgvListPeople.Columns[7].Width = 90;

            dgvListPeople.Columns[8].HeaderText = "Country Name";
            dgvListPeople.Columns[8].Width = 90;

            dgvListPeople.Columns[9].HeaderText = "Phone";
            dgvListPeople.Columns[9].Width = 130;

            dgvListPeople.Columns[10].HeaderText = "Email";
            dgvListPeople.Columns[10].Width = 135;

        }
        private void txtFilterBy_TextChanged(object sender, EventArgs e)
        {

            string filterColumn = cbFilterBy.Text.Replace(" ", "");

            if (!string.IsNullOrEmpty(txtFilterBy.Text.Trim()))
            {

                if (filterColumn == "PersonID")
                {
                    if (int.TryParse(txtFilterBy.Text.Trim(), out int id))
                    {
                        _dvPeople.RowFilter = $"[{filterColumn}] = {id}";
                    }
                    else
                    {
                        _dvPeople.RowFilter = "";
                    }
                }
                else
                {
                    filterColumn = (filterColumn == "Gendor" ? "GendorCaption" : filterColumn);
                    filterColumn = (filterColumn == "Country" ? "CountryName" : filterColumn);

                    _dvPeople.RowFilter = $"[{filterColumn}] LIKE '%{txtFilterBy.Text.Trim()}%'";
                }
            }
            else
            {
                _dvPeople.RowFilter = "";
            }

            lblCountPeople.Text = _dvPeople.Count.ToString();
        

        }

        private void rbMaleFilter_CheckedChanged(object sender, EventArgs e)
        {
            if (rbMaleFilter.Checked)
            {
                _dvPeople.RowFilter = "[GendorCaption] = 'Male'";
            }
            else
                _dvPeople.RowFilter = "";

            lblCountPeople.Text = _dvPeople.Count.ToString();
        }

        private void rbFemaleFilter_CheckedChanged(object sender, EventArgs e)
        {
            if (rbFemaleFilter.Checked)
            {
                _dvPeople.RowFilter = "[GendorCaption] = 'Female'";
            }
            else
                _dvPeople.RowFilter = "";

           lblCountPeople.Text = _dvPeople.Count.ToString();
        }
        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterBy.Text = "";
            rbMaleFilter.Checked = false;
            rbFemaleFilter.Checked = false;

            rbMaleFilter.Visible = (cbFilterBy.Text == "Gendor");
            rbFemaleFilter.Visible = (cbFilterBy.Text == "Gendor");
            rbMaleFilter.Checked = (cbFilterBy.Text == "Gendor");
            
            txtFilterBy.Visible = (cbFilterBy.Text != "None" && cbFilterBy.Text !="Gendor");
            txtFilterBy.Focus();



        }
        private void btnAddNewPerson_Click(object sender, EventArgs e)
        { 
            frmAddUpdatePerson frmAddPerson = new frmAddUpdatePerson();
            frmAddPerson.ShowDialog();
            _Refresh_PeopleList();
        }

        private void addANewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson frmAddPerson = new frmAddUpdatePerson();
            frmAddPerson.ShowDialog();
            _Refresh_PeopleList();
        }

        private void updatePersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmAddUpdatePerson((int)dgvListPeople.CurrentRow.Cells[0].Value);
            frm.ShowDialog();

            _Refresh_PeopleList();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int personID = (int)dgvListPeople.CurrentRow.Cells[0].Value;
            if (MessageBox.Show($"are you sure you want delete person with id : {personID}", "Delete Person", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
            {
                if (clsPerson.DeletePerson(personID))
                {
                    MessageBox.Show("person deleted successfully", "successful", MessageBoxButtons.OK);
                    _Refresh_PeopleList();
                }
                else
                    MessageBox.Show("person was not deleted because there is data linked to it.", "fail delete", MessageBoxButtons.OK);
            }

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmPersonInfo frmPersonInfo = new frmPersonInfo((int)dgvListPeople.CurrentRow.Cells[0].Value);
            frmPersonInfo.ShowDialog();
        }

        private void lblRefreshList_Click(object sender, EventArgs e)
        {
            _Refresh_PeopleList();
        }



    }
}
