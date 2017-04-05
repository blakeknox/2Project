using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2Project
{
    public partial class NewPayrollData : Form
    {
        decimal EmpPayRate;

        public NewPayrollData()
        {
            InitializeComponent();
        }

        private void NewPayrollData_Load(object sender, EventArgs e)
        {
            GetEmployees();
        }

        private void NewPayrollData_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dlgAnswer;

            dlgAnswer = MessageBox.Show("Do you want to exit?", "Exit Program", MessageBoxButtons.YesNo);
            if (dlgAnswer == System.Windows.Forms.DialogResult.Yes)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void GetEmployees()
        {
            DataSet dsData;

            lblError.Text = "";

            dsData = clsDatabase.GetEmployeeNames();
            if (dsData == null)
            {
                lblError.Text = "Error retreiving employee names";
            }
            else if (dsData.Tables.Count < 1)
            {
                lblError.Text = "Error retreiving employee names";
                dsData.Dispose();
            }
            else
            {
                cboEmpList.DataSource = dsData.Tables[0];
                cboEmpList.DisplayMember = "FullName";
                cboEmpList.ValueMember = "EmpID";

                if (cboEmpList.Items.Count > 0)
                {
                    cboEmpList.SelectedIndex = 0;
                    GetEmployeePayrate(Convert.ToInt32(cboEmpList.SelectedValue));
                }
            }
        }

        private void cboEmpList_SelectionChangeCommitted(object sender, EventArgs e)
        {
            lblError.Text = "";
            if (cboEmpList.SelectedIndex >= 0)
            {
                GetEmployeePayrate(Convert.ToInt32(cboEmpList.SelectedValue));
            }
        }
        private void GetEmployeePayrate(Int32 intEmpID)
        {
            //DataSet dsData;
            Decimal decPayrate;

            decPayrate = clsDatabase.GetEmployeePayrate(intEmpID);

            if (decPayrate < 0m)
            {
                lblError.Text = "Unable to retrieve payrate for specified Employee";
                EmpPayRate = 0;
            }
            else
            {
                EmpPayRate = decPayrate;
            }


        }

    }
}
