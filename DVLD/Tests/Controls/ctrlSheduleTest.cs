using DVLD_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Tests.Controls
{
    public partial class ctrlScheduleTest : UserControl
    {
        public ctrlScheduleTest()
        {
            InitializeComponent();
        }

        private clsTestType.enTestType _TestType;
        public clsTestType.enTestType TestType
        { 
            get
            {
                return _TestType;
            }
            set
            {
                switch(_TestType)
                {
                    case clsTestType.enTestType.VisionTest:
                        {
                            _TestType = value;
                            pbTestImage.Image = Resources.Vision_512;
                            gbScheduleTest.Text = "Vision Test";
                            break;
                        }
                    case clsTestType.enTestType.WrittenTest:
                        {
                            _TestType = value;
                            pbTestImage.Image = Resources.Written_Test_512;
                            gbScheduleTest.Text = "Written Test";
                            break;
                        }
                    case clsTestType.enTestType.PracticalTest:
                        {
                            _TestType = value;
                            pbTestImage.Image = Resources.Street_Test_32;
                            gbScheduleTest.Text = "Practical Test";
                            break;
                        }

                        
                }

            }
        }




    }
}
