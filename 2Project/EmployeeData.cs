using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace _2Project
{
    public partial class EmployeeData : Form
    {
        //*****
        //** Global variable
        //*****
        DataSet dsEmp = null;
        Int32 intCurrRow = 0;
        DataSet dsCurrEmp = null;
        public EmployeeData()
        {
            InitializeComponent();
        }

        private void EmployeeData_Load(object sender, EventArgs e)
        {
            LoadEmployees();
            lblError.Text = "";
        }
        //*******************************************************
        //** Procedure: LoadEmployees()
        //**   Fills (or refreshes) employee dataset
        //*******************************************************
        private void LoadEmployees()
        {
            lblError.Text = "";

            //** Remove any existing dataset
            if (dsEmp != null)
            {
                dsEmp.Dispose();
            }

            //** Initialize current row indicator
            intCurrRow = 0;

            //** Disable navigation
            //DisableNav();

            dsEmp = clsDatabase.GetEmployees();
            if (dsEmp == null)
            {
                lblError.Text = "Error retrieving employee data";
            }
            else if (dsEmp.Tables.Count < 1)
            {
                lblError.Text = "Error retrieving employee data";
                dsEmp.Dispose();
                dsEmp = null;
            }
            else if (dsEmp.Tables[0].Rows.Count < 1)
            {
                lblError.Text = "No employee data";
                //ClearDataFields();
                dsEmp.Dispose();
                dsEmp = null;
            }
            else
            {
                //EnableNav();
                ShowEmployee();
            }
        }
        private void ShowEmployee()
        {
            
            txtEmpID.Text = dsEmp.Tables[0].Rows[intCurrRow]["EmpID"].ToString();
            txtPayRate.Text = dsEmp.Tables[0].Rows[intCurrRow]["PayRate"].ToString();
            txtLName.Text = dsEmp.Tables[0].Rows[intCurrRow]["LName"].ToString();
            txtFName.Text = dsEmp.Tables[0].Rows[intCurrRow]["FName"].ToString();
            if (dsEmp.Tables[0].Rows[intCurrRow]["MInit"] == DBNull.Value)
            {
                txtMInit.Text = "";
            }
            else
            {
                txtMInit.Text = dsEmp.Tables[0].Rows[intCurrRow]["MInit"].ToString();
            }
            DisplayEmployee(Convert.ToInt32(txtEmpID.Text));

        }
        private void DisplayEmployee(Int32 intEmpID)
        {
            DataSet dsData;

            dsData = clsDatabase.GetCurrEmployee(intEmpID);
            if (dsData == null)
            {
                lblError.Text = "Error retrieving Employee info";
            }
            else if (dsData.Tables.Count < 1)
            {
                lblError.Text = "Error retrieving Employee info";
                dsData.Dispose();
            }
            else
            {
                dgvEmpData.DataSource = dsData.Tables[0];
            }


        }

        private void btnFirst_Click_1(object sender, EventArgs e)
        {
            lblError.Text = "";
            intCurrRow = 0;
            ShowEmployee();
        }

        private void btnNext_Click_1(object sender, EventArgs e)
        {
            lblError.Text = "";
            intCurrRow += 1;
            if (intCurrRow >= dsEmp.Tables[0].Rows.Count)
            {
                intCurrRow = 0;
            }
            ShowEmployee();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            lblError.Text = "";
            intCurrRow += -1;
            if (intCurrRow < 0)
            {
                intCurrRow = dsEmp.Tables[0].Rows.Count - 1;
            }
            ShowEmployee();
        }

        private void btnLast_Click_1(object sender, EventArgs e)
        {
            lblError.Text = "";
            intCurrRow = dsEmp.Tables[0].Rows.Count - 1;
            ShowEmployee();
        }

        private void EmployeeData_FormClosing(object sender, FormClosingEventArgs e)
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
       

    }

}
