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

namespace _2Project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblError.Text = "";
            btnAddPayroll.Enabled = true;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
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
        //********************************
        //**btnExit
        //**Procedure: direct button click to form closing
        //*******************************
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBrowseEmp_Click(object sender, EventArgs e)
        {
            EmployeeData EmpData = new EmployeeData();
            EmpData.ShowDialog();
        }

        private void btnAddPayroll_Click(object sender, EventArgs e)
        {
            NewPayrollData PayData = new NewPayrollData();
            PayData.ShowDialog();
        }
    }
}
