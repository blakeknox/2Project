namespace _2Project
{
    partial class NewPayrollData
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
            this.dgvEmpData = new System.Windows.Forms.DataGridView();
            this.lblPayrollData = new System.Windows.Forms.Label();
            this.lblEmp = new System.Windows.Forms.Label();
            this.cboEmpList = new System.Windows.Forms.ComboBox();
            this.lblWeek = new System.Windows.Forms.Label();
            this.txtWeekEnding = new System.Windows.Forms.TextBox();
            this.lblHours = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnCommit = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.lblError = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmpData)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvEmpData
            // 
            this.dgvEmpData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmpData.Location = new System.Drawing.Point(32, 246);
            this.dgvEmpData.Name = "dgvEmpData";
            this.dgvEmpData.RowTemplate.Height = 24;
            this.dgvEmpData.Size = new System.Drawing.Size(689, 233);
            this.dgvEmpData.TabIndex = 0;
            // 
            // lblPayrollData
            // 
            this.lblPayrollData.AutoSize = true;
            this.lblPayrollData.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPayrollData.Location = new System.Drawing.Point(41, 23);
            this.lblPayrollData.Name = "lblPayrollData";
            this.lblPayrollData.Size = new System.Drawing.Size(182, 32);
            this.lblPayrollData.TabIndex = 1;
            this.lblPayrollData.Text = "Payroll Data";
            // 
            // lblEmp
            // 
            this.lblEmp.AutoSize = true;
            this.lblEmp.Location = new System.Drawing.Point(60, 103);
            this.lblEmp.Name = "lblEmp";
            this.lblEmp.Size = new System.Drawing.Size(70, 17);
            this.lblEmp.TabIndex = 2;
            this.lblEmp.Text = "Employee";
            // 
            // cboEmpList
            // 
            this.cboEmpList.FormattingEnabled = true;
            this.cboEmpList.Location = new System.Drawing.Point(150, 100);
            this.cboEmpList.Name = "cboEmpList";
            this.cboEmpList.Size = new System.Drawing.Size(121, 24);
            this.cboEmpList.TabIndex = 3;
            this.cboEmpList.SelectionChangeCommitted += new System.EventHandler(this.cboEmpList_SelectionChangeCommitted);
            // 
            // lblWeek
            // 
            this.lblWeek.AutoSize = true;
            this.lblWeek.Location = new System.Drawing.Point(73, 159);
            this.lblWeek.Name = "lblWeek";
            this.lblWeek.Size = new System.Drawing.Size(44, 17);
            this.lblWeek.TabIndex = 4;
            this.lblWeek.Text = "Week";
            // 
            // txtWeekEnding
            // 
            this.txtWeekEnding.Location = new System.Drawing.Point(150, 156);
            this.txtWeekEnding.Name = "txtWeekEnding";
            this.txtWeekEnding.Size = new System.Drawing.Size(121, 22);
            this.txtWeekEnding.TabIndex = 5;
            // 
            // lblHours
            // 
            this.lblHours.AutoSize = true;
            this.lblHours.Location = new System.Drawing.Point(307, 159);
            this.lblHours.Name = "lblHours";
            this.lblHours.Size = new System.Drawing.Size(99, 17);
            this.lblHours.TabIndex = 6;
            this.lblHours.Text = "Hours Worked";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(422, 156);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 22);
            this.textBox1.TabIndex = 7;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(565, 197);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnCommit
            // 
            this.btnCommit.Location = new System.Drawing.Point(37, 498);
            this.btnCommit.Name = "btnCommit";
            this.btnCommit.Size = new System.Drawing.Size(75, 23);
            this.btnCommit.TabIndex = 9;
            this.btnCommit.Text = "Commit";
            this.btnCommit.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(150, 498);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Export";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(274, 498);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 11;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(395, 498);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 12;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(53, 540);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(46, 17);
            this.lblError.TabIndex = 13;
            this.lblError.Text = "label1";
            // 
            // NewPayrollData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(751, 573);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnCommit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lblHours);
            this.Controls.Add(this.txtWeekEnding);
            this.Controls.Add(this.lblWeek);
            this.Controls.Add(this.cboEmpList);
            this.Controls.Add(this.lblEmp);
            this.Controls.Add(this.lblPayrollData);
            this.Controls.Add(this.dgvEmpData);
            this.Name = "NewPayrollData";
            this.Text = "NewPayrollData";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NewPayrollData_FormClosing);
            this.Load += new System.EventHandler(this.NewPayrollData_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmpData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvEmpData;
        private System.Windows.Forms.Label lblPayrollData;
        private System.Windows.Forms.Label lblEmp;
        private System.Windows.Forms.ComboBox cboEmpList;
        private System.Windows.Forms.Label lblWeek;
        private System.Windows.Forms.TextBox txtWeekEnding;
        private System.Windows.Forms.Label lblHours;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnCommit;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblError;
    }
}