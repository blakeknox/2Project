using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace _2Project
{
    public partial class NewPayrollData : Form
    {
        decimal EmpPayRate; // holding the employees payrate 
        decimal wkpay; // for holding the weeks calculated pay
        DataTable dtNewData = null; // creates datatable to populate with calculated weeks pay
        DataSet dsData = null;
        


        public NewPayrollData()
        {
            InitializeComponent();
        }

        private void NewPayrollData_Load(object sender, EventArgs e)
        {
            GetEmployees();
            CreateDataTable();
            btnExport.Enabled = false;
            btnPrint.Enabled = false;
            btnCommit.Enabled = false;
            cboEmpList.DropDownStyle = ComboBoxStyle.DropDownList;

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


        //Validating data and add it to the datagrid view
        private void btnAdd_Click(object sender, EventArgs e)
        {
            decimal hrsworked;
            decimal overtimepay;
            Boolean blnIsOk = true;
            lblError.Text = "";

            hrsworked = 0;
            overtimepay = 0;
        
            if (txtHoursWorked.Text.Trim().Length > 0 && txtWeekEnding.Text.Trim().Length == 8 )
            {
                try
                {
                    hrsworked = Convert.ToDecimal(txtHoursWorked.Text);
                    if (hrsworked > 0 && hrsworked <= 80)
                    {
                        
                        try
                        {
                            Convert.ToDecimal(txtWeekEnding.Text);
                        }
                        catch (Exception ex)
                        {
                            lblError.Text = "Please enter a valid date" + ex.Message;
                            blnIsOk = false;
                        }
                        if(hrsworked > 40)
                        {
                            wkpay = (EmpPayRate * 40) + ((EmpPayRate * 1.5m) * (hrsworked - 40));
                        }
                        else
                        {
                            wkpay = hrsworked * EmpPayRate;
                        }

                    }
                    else
                    {
                        lblError.Text = "Please enter a number between 1 and 80. in the hours worked.";
                        blnIsOk = false;
                    }
                    btnPrint.Enabled = true;
                    btnExport.Enabled = true;
                    btnCommit.Enabled = true;
                }
                catch (Exception ex)
                {
                    lblError.Text = "Please enter a valid number in hours worked" + ex.Message;
                    blnIsOk = false;
                }
                
                if (blnIsOk)
                {
                    dtNewData.Rows.Add(Convert.ToInt32(cboEmpList.SelectedValue),cboEmpList.Text, txtWeekEnding.Text, txtHoursWorked.Text, (wkpay).ToString("N2"));
                    txtWeekEnding.Text = "";
                    txtHoursWorked.Text = "";
                }
            }
            else
            {
                lblError.Text = "Enter a number 1-80 in hours/ enter a valid date.";
            }


        }


        //creating the datatable for the dgv 
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
            dtNewData.Columns.Add("EmpID", typeof(String));
            dtNewData.Columns.Add("FullName", typeof(String));
            dtNewData.Columns.Add("WeekEnding", typeof(String));
            dtNewData.Columns.Add("HoursWorked", typeof(String));
            dtNewData.Columns.Add("TotalPay", typeof(String));

            dgvEmpData.DataSource = dtNewData;

            //**Size columns and set other formatting for datagridview
            dgvEmpData.AllowUserToAddRows = false;
            dgvEmpData.AllowUserToDeleteRows = false;
            dgvEmpData.AllowUserToOrderColumns = false;
            dgvEmpData.Columns[0].Width = 25;
            dgvEmpData.Columns[1].Width = 75;
            dgvEmpData.Columns[2].Width = 125;
            dgvEmpData.Columns[3].Width = 125;
            dgvEmpData.Columns[4].Width = 150;
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
            e.Graphics.DrawString("FullName", fDoc, System.Drawing.Brushes.Black, Convert.ToSingle(30.0), sglYPos);
            e.Graphics.DrawString("WeekEnding", fDoc, System.Drawing.Brushes.Black, Convert.ToSingle(200.0), sglYPos);
            e.Graphics.DrawString("HoursWorked", fDoc, System.Drawing.Brushes.Black, Convert.ToSingle(400.0), sglYPos);
            e.Graphics.DrawString("TotalPay", fDoc, System.Drawing.Brushes.Black, Convert.ToSingle(600.0), sglYPos);
            decTotalValue = Convert.ToDecimal(0.0);
            for (intRow = 0; intRow < dtNewData.Rows.Count; intRow++)
            {
                sglXPos = Convert.ToSingle(30);
                sglYPos += Convert.ToSingle(fDoc.Height);
                e.Graphics.DrawString(dtNewData.Rows[intRow]["FullName"].ToString(), fDoc, System.Drawing.Brushes.Black, sglXPos, sglYPos);
                sglXPos = Convert.ToSingle(200);
                e.Graphics.DrawString(dtNewData.Rows[intRow]["WeekEnding"].ToString(), fDoc, System.Drawing.Brushes.Black, sglXPos, sglYPos);
                sglXPos = Convert.ToSingle(400);
                e.Graphics.DrawString(dtNewData.Rows[intRow]["HoursWorked"].ToString(), fDoc, System.Drawing.Brushes.Black, sglXPos, sglYPos);
                sglXPos = Convert.ToSingle(600);
                e.Graphics.DrawString(dtNewData.Rows[intRow]["TotalPay"].ToString(), fDoc, System.Drawing.Brushes.Black, sglXPos, sglYPos);

                decTotalValue += Convert.ToDecimal(dtNewData.Rows[intRow]["TotalPay"]);
            }

            sglYPos += (Convert.ToSingle(fDoc.Height * 2));
            e.Graphics.DrawString("Total Value: " + decTotalValue.ToString("c"), fDoc, System.Drawing.Brushes.Black, Convert.ToSingle(50.0), sglYPos);
            e.Graphics.DrawString("Total Records Printed: " + dtNewData.Rows.Count.ToString(), fDoc, System.Drawing.Brushes.Black, Convert.ToSingle(50.0), sglYPos);
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


        //Adding the payroll information into the Database.
        private void btnCommit_Click(object sender, EventArgs e)
        {
            Int32 intIndx;

            for(intIndx = 0; intIndx < dtNewData.Rows.Count; intIndx++)
            {
                clsDatabase.InsertPayroll(Convert.ToInt32(dtNewData.Rows[intIndx]["EmpID"]), Convert.ToString(dtNewData.Rows[intIndx]["WeekEnding"]), Convert.ToDecimal(dtNewData.Rows[intIndx]["HoursWorked"]));
            }
            btnCommit.Enabled = false;

        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            DialogResult dlgAnswer;
            DataSet dsXML;

            sfdXML.DefaultExt = "xml";
            sfdXML.Filter = "XML files (*.xml)|*.xml|All files(*.*)|*.*";
            sfdXML.InitialDirectory = "C:\\";
            sfdXML.OverwritePrompt = true;
            sfdXML.Title = "Save XML File";

            dlgAnswer = sfdXML.ShowDialog();
            if (dlgAnswer == DialogResult.OK)
            {
                dtNewData.WriteXml(sfdXML.FileName);

                //**this is not part of the console app and may cause issues
                //**Now read back into another dataset
                dsXML = new DataSet();
                dsXML.ReadXml(sfdXML.FileName);
                //dtNewData.DataSource = dsXML.Tables[0];
            }
        }
    }
}
