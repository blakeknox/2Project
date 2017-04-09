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
        decimal EmpPayRate; // holding the employees payrate 
        decimal wkpay; // for holding the weeks calculated pay
        DataTable dtNewData = null; // creates datatable to populate with calculated weeks pay

        public NewPayrollData()
        {
            InitializeComponent();
        }

        private void NewPayrollData_Load(object sender, EventArgs e)
        {
            GetEmployees();
            CreateDataTable();
        }

        //form closing event
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            decimal hrsworked;
            Boolean blnIsOk = true;

            hrsworked = 0;
            if (txtHoursWorked.Text.Trim().Length > 0)
            {
                try
                {
                    hrsworked = Convert.ToDecimal(txtHoursWorked.Text);
                    if (hrsworked > 0 && hrsworked <= 80)
                    {
                        wkpay = hrsworked * EmpPayRate;
                    }
                    else
                    {
                        lblError.Text = "Please enter a number between 1 and 80. in the hours worked.";
                        blnIsOk = false;
                    }
                }
                catch (Exception ex)
                {
                    lblError.Text = "Please enter a valid number in hours worked" + ex.Message;
                    blnIsOk = false;
                }
                if (blnIsOk)
                {
                    dtNewData.Rows.Add(cboEmpList.Text, txtWeekEnding.Text, txtHoursWorked.Text, (wkpay).ToString("N2"));
                    cboEmpList.Text = "";
                    txtWeekEnding.Text = "";
                    txtHoursWorked.Text = "";
                }
            }
            else
            {
                lblError.Text = "Please enter a number between 1 and 80. in the hours worked.";
            }


        }

        private void CreateDataTable()
        {
            lblError.Text = "";

            //** Remove any existing datatable
            if (dtNewData != null)
            {
                dtNewData.Dispose();
            }

            dtNewData = new DataTable();
            dtNewData.TableName = "NewDataEntry";
            dtNewData.Columns.Add("Name", typeof(String));
            dtNewData.Columns.Add("Week Ending", typeof(String));
            dtNewData.Columns.Add("Hours", typeof(String));
            dtNewData.Columns.Add("Total Pay", typeof(String));

            dgvEmpData.DataSource = dtNewData;

            //**Size columns and set other formatting for datagridview
            dgvEmpData.AllowUserToAddRows = false;
            dgvEmpData.AllowUserToDeleteRows = false;
            dgvEmpData.AllowUserToOrderColumns = false;
            dgvEmpData.Columns[0].Width = 200;
            dgvEmpData.Columns[1].Width = 125;
            dgvEmpData.Columns[2].Width = 125;
            dgvEmpData.Columns[3].Width = 150;
        }

        private void pdPrint_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Font fDoc;
            Single sglXPos;
            Single sglYPos;
            Int32 intRow;
            Decimal decTotalValue;

            fDoc = new Font("Arial", 12);

            e.Graphics.DrawString("Summary of Pay Entries", fDoc, System.Drawing.Brushes.Black, Convert.ToSingle(250.0), Convert.ToSingle(75.0));

            sglYPos = Convert.ToSingle(125);
            e.Graphics.DrawString("Name", fDoc, System.Drawing.Brushes.Black, Convert.ToSingle(30.0), sglYPos);
            e.Graphics.DrawString("Week Ending", fDoc, System.Drawing.Brushes.Black, Convert.ToSingle(200.0), sglYPos);
            e.Graphics.DrawString("Hours", fDoc, System.Drawing.Brushes.Black, Convert.ToSingle(400.0), sglYPos);
            e.Graphics.DrawString("Total Pay", fDoc, System.Drawing.Brushes.Black, Convert.ToSingle(600.0), sglYPos);
            decTotalValue = Convert.ToDecimal(0.0);
            for (intRow = 0; intRow < dtNewData.Rows.Count; intRow++)
            {
                sglXPos = Convert.ToSingle(30);
                sglYPos += Convert.ToSingle(fDoc.Height);
                e.Graphics.DrawString(dtNewData.Rows[intRow]["Name"].ToString(), fDoc, System.Drawing.Brushes.Black, sglXPos, sglYPos);
                sglXPos = Convert.ToSingle(200);
                e.Graphics.DrawString(dtNewData.Rows[intRow]["Week Ending"].ToString(), fDoc, System.Drawing.Brushes.Black, sglXPos, sglYPos);
                sglXPos = Convert.ToSingle(400);
                e.Graphics.DrawString(dtNewData.Rows[intRow]["Hours"].ToString(), fDoc, System.Drawing.Brushes.Black, sglXPos, sglYPos);
                sglXPos = Convert.ToSingle(600);
                e.Graphics.DrawString(dtNewData.Rows[intRow]["Total Pay"].ToString(), fDoc, System.Drawing.Brushes.Black, sglXPos, sglYPos);

                decTotalValue += Convert.ToDecimal(dtNewData.Rows[intRow]["Total Pay"]);
            }

            sglYPos += (Convert.ToSingle(fDoc.Height * 2));
            e.Graphics.DrawString("Total Value: " + decTotalValue.ToString("c"), fDoc, System.Drawing.Brushes.Black, Convert.ToSingle(50.0), sglYPos);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            DialogResult dlgAnswer;

            lblError.Text = "";

            dlgAnswer = pdlgData.ShowDialog();
            if (dlgAnswer == DialogResult.OK)
            {
                pdPrint.PrinterSettings = pdlgData.PrinterSettings;

                //**Call BeginPrint here to print cover page, etc

                //**Print a single page. Normally will be a while loop.
                pdPrint.Print();

                //**Call EndPrint here to print a summary page.
            }
        }
    }
}
