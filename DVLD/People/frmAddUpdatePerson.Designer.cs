namespace DVLD.People
{
    partial class frmAddUpdatePerson
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddUpdatePerson));
            this.gbPersonCard = new System.Windows.Forms.GroupBox();
            this.lblCountryImage = new System.Windows.Forms.Label();
            this.lblPhoneImage = new System.Windows.Forms.Label();
            this.lblDateOfBirthImage = new System.Windows.Forms.Label();
            this.lblAddressImage = new System.Windows.Forms.Label();
            this.lblEmailImage = new System.Windows.Forms.Label();
            this.lblFemaleImage = new System.Windows.Forms.Label();
            this.lblMaleImage = new System.Windows.Forms.Label();
            this.lblNationalNoImage = new System.Windows.Forms.Label();
            this.lblNameImage = new System.Windows.Forms.Label();
            this.lblRemoveImage = new System.Windows.Forms.Label();
            this.lblSetImage = new System.Windows.Forms.Label();
            this.cbCountry = new System.Windows.Forms.ComboBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.dtpDateOfBirth = new System.Windows.Forms.DateTimePicker();
            this.txtAddress = new System.Windows.Forms.RichTextBox();
            this.rbFemale = new System.Windows.Forms.RadioButton();
            this.rbMale = new System.Windows.Forms.RadioButton();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtNationalNo = new System.Windows.Forms.TextBox();
            this.pbPersonImage = new System.Windows.Forms.PictureBox();
            this.lblLastName = new System.Windows.Forms.Label();
            this.lblThirdName = new System.Windows.Forms.Label();
            this.lblSecondName = new System.Windows.Forms.Label();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.txtThirdName = new System.Windows.Forms.TextBox();
            this.txtSecondName = new System.Windows.Forms.TextBox();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.lblCountry = new System.Windows.Forms.Label();
            this.lblPhone = new System.Windows.Forms.Label();
            this.lblDateOfBirth = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblGendor = new System.Windows.Forms.Label();
            this.lblNationalNo = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblAddUpdatePerson = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblPersonID = new System.Windows.Forms.Label();
            this.lblPersonIDImage = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.gbPersonCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPersonImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // gbPersonCard
            // 
            this.gbPersonCard.Controls.Add(this.lblCountryImage);
            this.gbPersonCard.Controls.Add(this.lblPhoneImage);
            this.gbPersonCard.Controls.Add(this.lblDateOfBirthImage);
            this.gbPersonCard.Controls.Add(this.lblAddressImage);
            this.gbPersonCard.Controls.Add(this.lblEmailImage);
            this.gbPersonCard.Controls.Add(this.lblFemaleImage);
            this.gbPersonCard.Controls.Add(this.lblMaleImage);
            this.gbPersonCard.Controls.Add(this.lblNationalNoImage);
            this.gbPersonCard.Controls.Add(this.lblNameImage);
            this.gbPersonCard.Controls.Add(this.lblRemoveImage);
            this.gbPersonCard.Controls.Add(this.lblSetImage);
            this.gbPersonCard.Controls.Add(this.cbCountry);
            this.gbPersonCard.Controls.Add(this.txtPhone);
            this.gbPersonCard.Controls.Add(this.dtpDateOfBirth);
            this.gbPersonCard.Controls.Add(this.txtAddress);
            this.gbPersonCard.Controls.Add(this.rbFemale);
            this.gbPersonCard.Controls.Add(this.rbMale);
            this.gbPersonCard.Controls.Add(this.txtEmail);
            this.gbPersonCard.Controls.Add(this.txtNationalNo);
            this.gbPersonCard.Controls.Add(this.pbPersonImage);
            this.gbPersonCard.Controls.Add(this.lblLastName);
            this.gbPersonCard.Controls.Add(this.lblThirdName);
            this.gbPersonCard.Controls.Add(this.lblSecondName);
            this.gbPersonCard.Controls.Add(this.lblFirstName);
            this.gbPersonCard.Controls.Add(this.txtLastName);
            this.gbPersonCard.Controls.Add(this.txtThirdName);
            this.gbPersonCard.Controls.Add(this.txtSecondName);
            this.gbPersonCard.Controls.Add(this.txtFirstName);
            this.gbPersonCard.Controls.Add(this.lblCountry);
            this.gbPersonCard.Controls.Add(this.lblPhone);
            this.gbPersonCard.Controls.Add(this.lblDateOfBirth);
            this.gbPersonCard.Controls.Add(this.lblAddress);
            this.gbPersonCard.Controls.Add(this.lblEmail);
            this.gbPersonCard.Controls.Add(this.lblGendor);
            this.gbPersonCard.Controls.Add(this.lblNationalNo);
            this.gbPersonCard.Controls.Add(this.lblName);
            this.gbPersonCard.Location = new System.Drawing.Point(12, 105);
            this.gbPersonCard.Name = "gbPersonCard";
            this.gbPersonCard.Size = new System.Drawing.Size(1113, 473);
            this.gbPersonCard.TabIndex = 1;
            this.gbPersonCard.TabStop = false;
            this.gbPersonCard.Text = "Person Information";
            // 
            // lblCountryImage
            // 
            this.lblCountryImage.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCountryImage.Image = global::DVLD.Properties.Resources.Country_32;
            this.lblCountryImage.Location = new System.Drawing.Point(608, 249);
            this.lblCountryImage.Name = "lblCountryImage";
            this.lblCountryImage.Size = new System.Drawing.Size(40, 42);
            this.lblCountryImage.TabIndex = 80;
            this.lblCountryImage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPhoneImage
            // 
            this.lblPhoneImage.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhoneImage.Image = global::DVLD.Properties.Resources.Phone_32;
            this.lblPhoneImage.Location = new System.Drawing.Point(608, 187);
            this.lblPhoneImage.Name = "lblPhoneImage";
            this.lblPhoneImage.Size = new System.Drawing.Size(40, 42);
            this.lblPhoneImage.TabIndex = 79;
            this.lblPhoneImage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDateOfBirthImage
            // 
            this.lblDateOfBirthImage.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateOfBirthImage.Image = global::DVLD.Properties.Resources.Calendar_32;
            this.lblDateOfBirthImage.Location = new System.Drawing.Point(608, 125);
            this.lblDateOfBirthImage.Name = "lblDateOfBirthImage";
            this.lblDateOfBirthImage.Size = new System.Drawing.Size(40, 42);
            this.lblDateOfBirthImage.TabIndex = 78;
            this.lblDateOfBirthImage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblAddressImage
            // 
            this.lblAddressImage.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddressImage.Image = global::DVLD.Properties.Resources.Address_32;
            this.lblAddressImage.Location = new System.Drawing.Point(165, 320);
            this.lblAddressImage.Name = "lblAddressImage";
            this.lblAddressImage.Size = new System.Drawing.Size(35, 36);
            this.lblAddressImage.TabIndex = 77;
            this.lblAddressImage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblEmailImage
            // 
            this.lblEmailImage.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmailImage.Image = global::DVLD.Properties.Resources.Email_32;
            this.lblEmailImage.Location = new System.Drawing.Point(165, 254);
            this.lblEmailImage.Name = "lblEmailImage";
            this.lblEmailImage.Size = new System.Drawing.Size(35, 33);
            this.lblEmailImage.TabIndex = 76;
            this.lblEmailImage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblFemaleImage
            // 
            this.lblFemaleImage.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFemaleImage.Image = global::DVLD.Properties.Resources.Woman_32;
            this.lblFemaleImage.Location = new System.Drawing.Point(280, 193);
            this.lblFemaleImage.Name = "lblFemaleImage";
            this.lblFemaleImage.Size = new System.Drawing.Size(35, 30);
            this.lblFemaleImage.TabIndex = 75;
            this.lblFemaleImage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMaleImage
            // 
            this.lblMaleImage.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaleImage.Image = global::DVLD.Properties.Resources.Man_32;
            this.lblMaleImage.Location = new System.Drawing.Point(165, 192);
            this.lblMaleImage.Name = "lblMaleImage";
            this.lblMaleImage.Size = new System.Drawing.Size(35, 33);
            this.lblMaleImage.TabIndex = 74;
            this.lblMaleImage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblNationalNoImage
            // 
            this.lblNationalNoImage.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNationalNoImage.Location = new System.Drawing.Point(165, 130);
            this.lblNationalNoImage.Name = "lblNationalNoImage";
            this.lblNationalNoImage.Padding = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblNationalNoImage.Size = new System.Drawing.Size(35, 33);
            this.lblNationalNoImage.TabIndex = 73;
            this.lblNationalNoImage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblNameImage
            // 
            this.lblNameImage.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNameImage.Image = global::DVLD.Properties.Resources.Person_32;
            this.lblNameImage.Location = new System.Drawing.Point(165, 72);
            this.lblNameImage.Name = "lblNameImage";
            this.lblNameImage.Size = new System.Drawing.Size(35, 33);
            this.lblNameImage.TabIndex = 72;
            this.lblNameImage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblRemoveImage
            // 
            this.lblRemoveImage.BackColor = System.Drawing.Color.Transparent;
            this.lblRemoveImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRemoveImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblRemoveImage.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRemoveImage.ForeColor = System.Drawing.Color.Red;
            this.lblRemoveImage.Location = new System.Drawing.Point(934, 386);
            this.lblRemoveImage.Name = "lblRemoveImage";
            this.lblRemoveImage.Size = new System.Drawing.Size(89, 25);
            this.lblRemoveImage.TabIndex = 71;
            this.lblRemoveImage.Text = "Remove";
            this.lblRemoveImage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblRemoveImage.Click += new System.EventHandler(this.lblRemoveImage_Click);
            // 
            // lblSetImage
            // 
            this.lblSetImage.AutoSize = true;
            this.lblSetImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSetImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSetImage.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSetImage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblSetImage.Location = new System.Drawing.Point(934, 347);
            this.lblSetImage.Name = "lblSetImage";
            this.lblSetImage.Size = new System.Drawing.Size(89, 25);
            this.lblSetImage.TabIndex = 70;
            this.lblSetImage.Text = "Set Image";
            this.lblSetImage.Click += new System.EventHandler(this.lblSetImage_Click);
            // 
            // cbCountry
            // 
            this.cbCountry.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCountry.FormattingEnabled = true;
            this.cbCountry.Location = new System.Drawing.Point(650, 255);
            this.cbCountry.Name = "cbCountry";
            this.cbCountry.Size = new System.Drawing.Size(200, 31);
            this.cbCountry.TabIndex = 59;
            // 
            // txtPhone
            // 
            this.txtPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPhone.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhone.Location = new System.Drawing.Point(650, 193);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(200, 30);
            this.txtPhone.TabIndex = 57;
            this.txtPhone.Validating += new System.ComponentModel.CancelEventHandler(this.ValidateEmptyTextBox);
            // 
            // dtpDateOfBirth
            // 
            this.dtpDateOfBirth.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDateOfBirth.Location = new System.Drawing.Point(650, 131);
            this.dtpDateOfBirth.Name = "dtpDateOfBirth";
            this.dtpDateOfBirth.Size = new System.Drawing.Size(200, 30);
            this.dtpDateOfBirth.TabIndex = 55;
            // 
            // txtAddress
            // 
            this.txtAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAddress.Font = new System.Drawing.Font("Andalus", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddress.Location = new System.Drawing.Point(206, 321);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(644, 122);
            this.txtAddress.TabIndex = 62;
            this.txtAddress.Text = "";
            // 
            // rbFemale
            // 
            this.rbFemale.AutoSize = true;
            this.rbFemale.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbFemale.Location = new System.Drawing.Point(318, 195);
            this.rbFemale.Name = "rbFemale";
            this.rbFemale.Size = new System.Drawing.Size(85, 27);
            this.rbFemale.TabIndex = 51;
            this.rbFemale.Text = "Female";
            this.rbFemale.UseVisualStyleBackColor = true;
            this.rbFemale.CheckedChanged += new System.EventHandler(this.rbFemale_CheckedChanged);
            // 
            // rbMale
            // 
            this.rbMale.AutoSize = true;
            this.rbMale.Checked = true;
            this.rbMale.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbMale.Location = new System.Drawing.Point(206, 195);
            this.rbMale.Name = "rbMale";
            this.rbMale.Size = new System.Drawing.Size(68, 27);
            this.rbMale.TabIndex = 50;
            this.rbMale.TabStop = true;
            this.rbMale.Text = "Male";
            this.rbMale.UseVisualStyleBackColor = true;
            this.rbMale.CheckedChanged += new System.EventHandler(this.rbMale_CheckedChanged);
            // 
            // txtEmail
            // 
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Location = new System.Drawing.Point(206, 255);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(197, 30);
            this.txtEmail.TabIndex = 52;
            this.txtEmail.Validating += new System.ComponentModel.CancelEventHandler(this.txtEmail_Validating);
            // 
            // txtNationalNo
            // 
            this.txtNationalNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNationalNo.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNationalNo.Location = new System.Drawing.Point(206, 131);
            this.txtNationalNo.Name = "txtNationalNo";
            this.txtNationalNo.Size = new System.Drawing.Size(197, 30);
            this.txtNationalNo.TabIndex = 49;
            this.txtNationalNo.Validating += new System.ComponentModel.CancelEventHandler(this.txtNationalNo_Validating);
            // 
            // pbPersonImage
            // 
            this.pbPersonImage.BackColor = System.Drawing.Color.White;
            this.pbPersonImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbPersonImage.InitialImage = ((System.Drawing.Image)(resources.GetObject("pbPersonImage.InitialImage")));
            this.pbPersonImage.Location = new System.Drawing.Point(877, 135);
            this.pbPersonImage.Name = "pbPersonImage";
            this.pbPersonImage.Size = new System.Drawing.Size(197, 197);
            this.pbPersonImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPersonImage.TabIndex = 69;
            this.pbPersonImage.TabStop = false;
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.Font = new System.Drawing.Font("Andalus", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.lblLastName.Location = new System.Drawing.Point(915, 30);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(84, 27);
            this.lblLastName.TabIndex = 68;
            this.lblLastName.Text = "Last Name";
            // 
            // lblThirdName
            // 
            this.lblThirdName.AutoSize = true;
            this.lblThirdName.Font = new System.Drawing.Font("Andalus", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThirdName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.lblThirdName.Location = new System.Drawing.Point(688, 30);
            this.lblThirdName.Name = "lblThirdName";
            this.lblThirdName.Size = new System.Drawing.Size(96, 27);
            this.lblThirdName.TabIndex = 67;
            this.lblThirdName.Text = "Third Name";
            // 
            // lblSecondName
            // 
            this.lblSecondName.AutoSize = true;
            this.lblSecondName.Font = new System.Drawing.Font("Andalus", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSecondName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.lblSecondName.Location = new System.Drawing.Point(451, 30);
            this.lblSecondName.Name = "lblSecondName";
            this.lblSecondName.Size = new System.Drawing.Size(106, 27);
            this.lblSecondName.TabIndex = 66;
            this.lblSecondName.Text = "Second Name";
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Font = new System.Drawing.Font("Andalus", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFirstName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.lblFirstName.Location = new System.Drawing.Point(233, 30);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(87, 27);
            this.lblFirstName.TabIndex = 65;
            this.lblFirstName.Text = "Frist Name";
            // 
            // txtLastName
            // 
            this.txtLastName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLastName.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLastName.Location = new System.Drawing.Point(877, 72);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(197, 30);
            this.txtLastName.TabIndex = 48;
            this.txtLastName.Validating += new System.ComponentModel.CancelEventHandler(this.ValidateEmptyTextBox);
            // 
            // txtThirdName
            // 
            this.txtThirdName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtThirdName.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtThirdName.Location = new System.Drawing.Point(650, 72);
            this.txtThirdName.Name = "txtThirdName";
            this.txtThirdName.Size = new System.Drawing.Size(197, 30);
            this.txtThirdName.TabIndex = 47;
            // 
            // txtSecondName
            // 
            this.txtSecondName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSecondName.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSecondName.Location = new System.Drawing.Point(423, 72);
            this.txtSecondName.Name = "txtSecondName";
            this.txtSecondName.Size = new System.Drawing.Size(197, 30);
            this.txtSecondName.TabIndex = 46;
            this.txtSecondName.Validating += new System.ComponentModel.CancelEventHandler(this.ValidateEmptyTextBox);
            // 
            // txtFirstName
            // 
            this.txtFirstName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFirstName.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFirstName.Location = new System.Drawing.Point(206, 72);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(197, 30);
            this.txtFirstName.TabIndex = 45;
            this.txtFirstName.Validating += new System.ComponentModel.CancelEventHandler(this.ValidateEmptyTextBox);
            // 
            // lblCountry
            // 
            this.lblCountry.AutoSize = true;
            this.lblCountry.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCountry.Location = new System.Drawing.Point(496, 258);
            this.lblCountry.Name = "lblCountry";
            this.lblCountry.Size = new System.Drawing.Size(81, 25);
            this.lblCountry.TabIndex = 64;
            this.lblCountry.Text = "Country";
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhone.Location = new System.Drawing.Point(511, 196);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(66, 25);
            this.lblPhone.TabIndex = 63;
            this.lblPhone.Text = "Phone";
            // 
            // lblDateOfBirth
            // 
            this.lblDateOfBirth.AutoSize = true;
            this.lblDateOfBirth.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateOfBirth.Location = new System.Drawing.Point(451, 134);
            this.lblDateOfBirth.Name = "lblDateOfBirth";
            this.lblDateOfBirth.Size = new System.Drawing.Size(126, 25);
            this.lblDateOfBirth.TabIndex = 61;
            this.lblDateOfBirth.Text = "Date Of Birth";
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddress.Location = new System.Drawing.Point(39, 320);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(80, 25);
            this.lblAddress.TabIndex = 60;
            this.lblAddress.Text = "Address";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.Location = new System.Drawing.Point(39, 258);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(58, 25);
            this.lblEmail.TabIndex = 58;
            this.lblEmail.Text = "Email";
            // 
            // lblGendor
            // 
            this.lblGendor.AutoSize = true;
            this.lblGendor.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGendor.Location = new System.Drawing.Point(39, 196);
            this.lblGendor.Name = "lblGendor";
            this.lblGendor.Size = new System.Drawing.Size(75, 25);
            this.lblGendor.TabIndex = 56;
            this.lblGendor.Text = "Gendor";
            // 
            // lblNationalNo
            // 
            this.lblNationalNo.AutoSize = true;
            this.lblNationalNo.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNationalNo.Location = new System.Drawing.Point(39, 134);
            this.lblNationalNo.Name = "lblNationalNo";
            this.lblNationalNo.Size = new System.Drawing.Size(115, 25);
            this.lblNationalNo.TabIndex = 54;
            this.lblNationalNo.Text = "National No";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblName.Location = new System.Drawing.Point(39, 72);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(62, 25);
            this.lblName.TabIndex = 53;
            this.lblName.Text = "Name";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblAddUpdatePerson
            // 
            this.lblAddUpdatePerson.AutoSize = true;
            this.lblAddUpdatePerson.BackColor = System.Drawing.Color.Transparent;
            this.lblAddUpdatePerson.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddUpdatePerson.ForeColor = System.Drawing.Color.Red;
            this.lblAddUpdatePerson.Location = new System.Drawing.Point(509, 21);
            this.lblAddUpdatePerson.Name = "lblAddUpdatePerson";
            this.lblAddUpdatePerson.Size = new System.Drawing.Size(94, 32);
            this.lblAddUpdatePerson.TabIndex = 2;
            this.lblAddUpdatePerson.Text = "[????]";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Person ID :";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Andalus", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.Green;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.Location = new System.Drawing.Point(379, 596);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(106, 51);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save       ";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Andalus", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.Red;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.Location = new System.Drawing.Point(540, 596);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(106, 51);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close       ";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblPersonID
            // 
            this.lblPersonID.AutoSize = true;
            this.lblPersonID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPersonID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblPersonID.Location = new System.Drawing.Point(166, 70);
            this.lblPersonID.Name = "lblPersonID";
            this.lblPersonID.Size = new System.Drawing.Size(61, 20);
            this.lblPersonID.TabIndex = 5;
            this.lblPersonID.Text = "[????]";
            // 
            // lblPersonIDImage
            // 
            this.lblPersonIDImage.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPersonIDImage.Location = new System.Drawing.Point(125, 62);
            this.lblPersonIDImage.Name = "lblPersonIDImage";
            this.lblPersonIDImage.Padding = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblPersonIDImage.Size = new System.Drawing.Size(35, 33);
            this.lblPersonIDImage.TabIndex = 38;
            this.lblPersonIDImage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // frmAddUpdatePerson
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(1150, 659);
            this.Controls.Add(this.lblPersonIDImage);
            this.Controls.Add(this.lblPersonID);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblAddUpdatePerson);
            this.Controls.Add(this.gbPersonCard);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmAddUpdatePerson";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmAddUpdatePerson";
            this.Load += new System.EventHandler(this.frmAddUpdatePerson_Load);
            this.gbPersonCard.ResumeLayout(false);
            this.gbPersonCard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPersonImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox gbPersonCard;
        private System.Windows.Forms.Label lblAddUpdatePerson;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblPersonID;
        private System.Windows.Forms.Label lblPersonIDImage;
        private System.Windows.Forms.Label lblCountryImage;
        private System.Windows.Forms.Label lblPhoneImage;
        private System.Windows.Forms.Label lblDateOfBirthImage;
        private System.Windows.Forms.Label lblAddressImage;
        private System.Windows.Forms.Label lblEmailImage;
        private System.Windows.Forms.Label lblFemaleImage;
        private System.Windows.Forms.Label lblMaleImage;
        private System.Windows.Forms.Label lblNationalNoImage;
        private System.Windows.Forms.Label lblNameImage;
        public System.Windows.Forms.Label lblRemoveImage;
        public System.Windows.Forms.Label lblSetImage;
        public System.Windows.Forms.ComboBox cbCountry;
        public System.Windows.Forms.TextBox txtPhone;
        public System.Windows.Forms.DateTimePicker dtpDateOfBirth;
        public System.Windows.Forms.RichTextBox txtAddress;
        public System.Windows.Forms.RadioButton rbFemale;
        public System.Windows.Forms.RadioButton rbMale;
        public System.Windows.Forms.TextBox txtEmail;
        public System.Windows.Forms.TextBox txtNationalNo;
        public System.Windows.Forms.PictureBox pbPersonImage;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.Label lblThirdName;
        private System.Windows.Forms.Label lblSecondName;
        private System.Windows.Forms.Label lblFirstName;
        public System.Windows.Forms.TextBox txtLastName;
        public System.Windows.Forms.TextBox txtThirdName;
        public System.Windows.Forms.TextBox txtSecondName;
        public System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label lblCountry;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label lblDateOfBirth;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblGendor;
        private System.Windows.Forms.Label lblNationalNo;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}