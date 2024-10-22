namespace DVLD.People
{
    partial class frmTest
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
            this.ctrlTest1 = new DVLD.People.controls.ctrlTest();
            this.SuspendLayout();
            // 
            // ctrlTest1
            // 
            this.ctrlTest1.Location = new System.Drawing.Point(101, 116);
            this.ctrlTest1.Name = "ctrlTest1";
            this.ctrlTest1.Size = new System.Drawing.Size(1124, 382);
            this.ctrlTest1.TabIndex = 0;
            // 
            // frmTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1332, 723);
            this.Controls.Add(this.ctrlTest1);
            this.Name = "frmTest";
            this.Text = "frmTest";
            this.ResumeLayout(false);

        }

        #endregion

        private controls.ctrlTest ctrlTest1;
    }
}