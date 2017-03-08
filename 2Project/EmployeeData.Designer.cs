namespace _2Project
{
    partial class EmployeeData
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
            this.label1 = new System.Windows.Forms.Label();
            this.lblEmpID = new System.Windows.Forms.Label();
            this.lblFName = new System.Windows.Forms.Label();
            this.lblLName = new System.Windows.Forms.Label();
            this.lblPayRate = new System.Windows.Forms.Label();
            this.lblMInit = new System.Windows.Forms.Label();
            this.txtEmpID = new System.Windows.Forms.TextBox();
            this.txtPayRate = new System.Windows.Forms.TextBox();
            this.txtMInit = new System.Windows.Forms.TextBox();
            this.txtLName = new System.Windows.Forms.TextBox();
            this.txtFName = new System.Windows.Forms.TextBox();
            this.btnFirst = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnLast = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvEmpData = new System.Windows.Forms.DataGridView();
            this.lblError = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmpData)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(240, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(190, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Employee Data";
            // 
            // lblEmpID
            // 
            this.lblEmpID.AutoSize = true;
            this.lblEmpID.Location = new System.Drawing.Point(43, 25);
            this.lblEmpID.Name = "lblEmpID";
            this.lblEmpID.Size = new System.Drawing.Size(87, 17);
            this.lblEmpID.TabIndex = 1;
            this.lblEmpID.Text = "Employee ID";
            // 
            // lblFName
            // 
            this.lblFName.AutoSize = true;
            this.lblFName.Location = new System.Drawing.Point(54, 60);
            this.lblFName.Name = "lblFName";
            this.lblFName.Size = new System.Drawing.Size(76, 17);
            this.lblFName.TabIndex = 2;
            this.lblFName.Text = "First Name";
            // 
            // lblLName
            // 
            this.lblLName.AutoSize = true;
            this.lblLName.Location = new System.Drawing.Point(54, 98);
            this.lblLName.Name = "lblLName";
            this.lblLName.Size = new System.Drawing.Size(76, 17);
            this.lblLName.TabIndex = 3;
            this.lblLName.Text = "Last Name";
            // 
            // lblPayRate
            // 
            this.lblPayRate.AutoSize = true;
            this.lblPayRate.Location = new System.Drawing.Point(64, 169);
            this.lblPayRate.Name = "lblPayRate";
            this.lblPayRate.Size = new System.Drawing.Size(66, 17);
            this.lblPayRate.TabIndex = 4;
            this.lblPayRate.Text = "Pay Rate";
            // 
            // lblMInit
            // 
            this.lblMInit.AutoSize = true;
            this.lblMInit.Location = new System.Drawing.Point(45, 135);
            this.lblMInit.Name = "lblMInit";
            this.lblMInit.Size = new System.Drawing.Size(85, 17);
            this.lblMInit.TabIndex = 5;
            this.lblMInit.Text = "Middle Initial";
            // 
            // txtEmpID
            // 
            this.txtEmpID.Location = new System.Drawing.Point(232, 20);
            this.txtEmpID.Name = "txtEmpID";
            this.txtEmpID.ReadOnly = true;
            this.txtEmpID.Size = new System.Drawing.Size(100, 22);
            this.txtEmpID.TabIndex = 6;
            // 
            // txtPayRate
            // 
            this.txtPayRate.Location = new System.Drawing.Point(232, 164);
            this.txtPayRate.Name = "txtPayRate";
            this.txtPayRate.ReadOnly = true;
            this.txtPayRate.Size = new System.Drawing.Size(100, 22);
            this.txtPayRate.TabIndex = 7;
            // 
            // txtMInit
            // 
            this.txtMInit.Location = new System.Drawing.Point(232, 130);
            this.txtMInit.Name = "txtMInit";
            this.txtMInit.ReadOnly = true;
            this.txtMInit.Size = new System.Drawing.Size(100, 22);
            this.txtMInit.TabIndex = 8;
            // 
            // txtLName
            // 
            this.txtLName.Location = new System.Drawing.Point(232, 93);
            this.txtLName.Name = "txtLName";
            this.txtLName.ReadOnly = true;
            this.txtLName.Size = new System.Drawing.Size(100, 22);
            this.txtLName.TabIndex = 9;
            // 
            // txtFName
            // 
            this.txtFName.Location = new System.Drawing.Point(232, 55);
            this.txtFName.Name = "txtFName";
            this.txtFName.ReadOnly = true;
            this.txtFName.Size = new System.Drawing.Size(100, 22);
            this.txtFName.TabIndex = 10;
            // 
            // btnFirst
            // 
            this.btnFirst.Location = new System.Drawing.Point(47, 298);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(75, 23);
            this.btnFirst.TabIndex = 11;
            this.btnFirst.Text = "First";
            this.btnFirst.UseVisualStyleBackColor = true;
            this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click_1);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(168, 298);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 12;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click_1);
            // 
            // btnPrevious
            // 
            this.btnPrevious.Location = new System.Drawing.Point(279, 298);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(75, 23);
            this.btnPrevious.TabIndex = 13;
            this.btnPrevious.Text = "Previous";
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnLast
            // 
            this.btnLast.Location = new System.Drawing.Point(399, 298);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(75, 23);
            this.btnLast.TabIndex = 14;
            this.btnLast.Text = "Last";
            this.btnLast.UseVisualStyleBackColor = true;
            this.btnLast.Click += new System.EventHandler(this.btnLast_Click_1);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(612, 501);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 15;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtEmpID);
            this.groupBox1.Controls.Add(this.txtFName);
            this.groupBox1.Controls.Add(this.txtLName);
            this.groupBox1.Controls.Add(this.txtMInit);
            this.groupBox1.Controls.Add(this.txtPayRate);
            this.groupBox1.Controls.Add(this.lblEmpID);
            this.groupBox1.Controls.Add(this.lblPayRate);
            this.groupBox1.Controls.Add(this.lblMInit);
            this.groupBox1.Controls.Add(this.lblFName);
            this.groupBox1.Controls.Add(this.lblLName);
            this.groupBox1.Location = new System.Drawing.Point(47, 75);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(427, 217);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Employee Information";
            // 
            // dgvEmpData
            // 
            this.dgvEmpData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmpData.Location = new System.Drawing.Point(47, 344);
            this.dgvEmpData.Name = "dgvEmpData";
            this.dgvEmpData.ReadOnly = true;
            this.dgvEmpData.RowTemplate.Height = 24;
            this.dgvEmpData.Size = new System.Drawing.Size(565, 150);
            this.dgvEmpData.TabIndex = 17;
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Location = new System.Drawing.Point(20, 512);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(0, 17);
            this.lblError.TabIndex = 18;
            // 
            // EmployeeData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(713, 536);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.dgvEmpData);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnLast);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnFirst);
            this.Controls.Add(this.label1);
            this.Name = "EmployeeData";
            this.Text = "EmployeeData";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EmployeeData_FormClosing);
            this.Load += new System.EventHandler(this.EmployeeData_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmpData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblEmpID;
        private System.Windows.Forms.Label lblFName;
        private System.Windows.Forms.Label lblLName;
        private System.Windows.Forms.Label lblPayRate;
        private System.Windows.Forms.Label lblMInit;
        private System.Windows.Forms.TextBox txtEmpID;
        private System.Windows.Forms.TextBox txtPayRate;
        private System.Windows.Forms.TextBox txtMInit;
        private System.Windows.Forms.TextBox txtLName;
        private System.Windows.Forms.TextBox txtFName;
        private System.Windows.Forms.Button btnFirst;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Button btnLast;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvEmpData;
        private System.Windows.Forms.Label lblError;
    }
}