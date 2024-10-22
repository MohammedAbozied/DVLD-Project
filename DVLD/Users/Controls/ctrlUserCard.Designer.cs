namespace DVLD.Users.Controls
{
    partial class ctrlUserCard
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gbLoginInfo = new System.Windows.Forms.GroupBox();
            this.lblIsActive = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblUserID = new System.Windows.Forms.Label();
            this.lblIsActiveCtrl = new System.Windows.Forms.Label();
            this.lblUserNameCtrl = new System.Windows.Forms.Label();
            this.lblUserIdCtrl = new System.Windows.Forms.Label();
            this.ctrlPersonCard1 = new DVLD.People.controls.ctrlPersonCard();
            this.gbLoginInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbLoginInfo
            // 
            this.gbLoginInfo.Controls.Add(this.lblIsActive);
            this.gbLoginInfo.Controls.Add(this.lblUserName);
            this.gbLoginInfo.Controls.Add(this.lblUserID);
            this.gbLoginInfo.Controls.Add(this.lblIsActiveCtrl);
            this.gbLoginInfo.Controls.Add(this.lblUserNameCtrl);
            this.gbLoginInfo.Controls.Add(this.lblUserIdCtrl);
            this.gbLoginInfo.Font = new System.Drawing.Font("Andalus", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbLoginInfo.Location = new System.Drawing.Point(3, 494);
            this.gbLoginInfo.Name = "gbLoginInfo";
            this.gbLoginInfo.Size = new System.Drawing.Size(1078, 126);
            this.gbLoginInfo.TabIndex = 0;
            this.gbLoginInfo.TabStop = false;
            this.gbLoginInfo.Text = "Login Information";
            // 
            // lblIsActive
            // 
            this.lblIsActive.AutoSize = true;
            this.lblIsActive.Font = new System.Drawing.Font("Andalus", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIsActive.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblIsActive.Location = new System.Drawing.Point(900, 53);
            this.lblIsActive.Name = "lblIsActive";
            this.lblIsActive.Size = new System.Drawing.Size(69, 36);
            this.lblIsActive.TabIndex = 6;
            this.lblIsActive.Text = "[????]";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Font = new System.Drawing.Font("Andalus", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblUserName.Location = new System.Drawing.Point(358, 53);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(69, 36);
            this.lblUserName.TabIndex = 4;
            this.lblUserName.Text = "[????]";
            // 
            // lblUserID
            // 
            this.lblUserID.AutoSize = true;
            this.lblUserID.Font = new System.Drawing.Font("Andalus", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblUserID.Location = new System.Drawing.Point(103, 53);
            this.lblUserID.Name = "lblUserID";
            this.lblUserID.Size = new System.Drawing.Size(69, 36);
            this.lblUserID.TabIndex = 3;
            this.lblUserID.Text = "[????]";
            // 
            // lblIsActiveCtrl
            // 
            this.lblIsActiveCtrl.AutoSize = true;
            this.lblIsActiveCtrl.Font = new System.Drawing.Font("Andalus", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIsActiveCtrl.Location = new System.Drawing.Point(777, 56);
            this.lblIsActiveCtrl.Name = "lblIsActiveCtrl";
            this.lblIsActiveCtrl.Size = new System.Drawing.Size(96, 31);
            this.lblIsActiveCtrl.TabIndex = 2;
            this.lblIsActiveCtrl.Text = "is Active : ";
            // 
            // lblUserNameCtrl
            // 
            this.lblUserNameCtrl.AutoSize = true;
            this.lblUserNameCtrl.Font = new System.Drawing.Font("Andalus", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserNameCtrl.Location = new System.Drawing.Point(242, 56);
            this.lblUserNameCtrl.Name = "lblUserNameCtrl";
            this.lblUserNameCtrl.Size = new System.Drawing.Size(119, 31);
            this.lblUserNameCtrl.TabIndex = 1;
            this.lblUserNameCtrl.Text = "User Name : ";
            // 
            // lblUserIdCtrl
            // 
            this.lblUserIdCtrl.AutoSize = true;
            this.lblUserIdCtrl.Font = new System.Drawing.Font("Andalus", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserIdCtrl.Location = new System.Drawing.Point(6, 56);
            this.lblUserIdCtrl.Name = "lblUserIdCtrl";
            this.lblUserIdCtrl.Size = new System.Drawing.Size(91, 31);
            this.lblUserIdCtrl.TabIndex = 0;
            this.lblUserIdCtrl.Text = "User ID : ";
            // 
            // ctrlPersonCard1
            // 
            this.ctrlPersonCard1.BackColor = System.Drawing.Color.White;
            this.ctrlPersonCard1.Location = new System.Drawing.Point(3, 3);
            this.ctrlPersonCard1.Name = "ctrlPersonCard1";
            this.ctrlPersonCard1.Size = new System.Drawing.Size(1087, 485);
            this.ctrlPersonCard1.TabIndex = 1;
            // 
            // ctrlUserCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.ctrlPersonCard1);
            this.Controls.Add(this.gbLoginInfo);
            this.Name = "ctrlUserCard";
            this.Size = new System.Drawing.Size(1091, 634);
            this.gbLoginInfo.ResumeLayout(false);
            this.gbLoginInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbLoginInfo;
        private System.Windows.Forms.Label lblIsActiveCtrl;
        private System.Windows.Forms.Label lblUserNameCtrl;
        private System.Windows.Forms.Label lblUserIdCtrl;
        private System.Windows.Forms.Label lblUserID;
        private People.controls.ctrlPersonCard ctrlPersonCard1;
        private System.Windows.Forms.Label lblIsActive;
        private System.Windows.Forms.Label lblUserName;
    }
}
