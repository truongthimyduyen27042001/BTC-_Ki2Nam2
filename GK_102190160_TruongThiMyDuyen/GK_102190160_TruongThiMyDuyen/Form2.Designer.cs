namespace GK_102190160_TruongThiMyDuyen
{
    partial class Form2
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.MSGV = new System.Windows.Forms.Label();
            this.txtMSGV = new System.Windows.Forms.TextBox();
            this.txtNameGV = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNumber = new System.Windows.Forms.TextBox();
            this.SDT = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.MACS = new System.Windows.Forms.Label();
            this.cbbMaCS = new System.Windows.Forms.ComboBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCancel);
            this.groupBox1.Controls.Add(this.btnOK);
            this.groupBox1.Controls.Add(this.cbbMaCS);
            this.groupBox1.Controls.Add(this.MACS);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.txtNumber);
            this.groupBox1.Controls.Add(this.SDT);
            this.groupBox1.Controls.Add(this.txtNameGV);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtMSGV);
            this.groupBox1.Controls.Add(this.MSGV);
            this.groupBox1.Location = new System.Drawing.Point(27, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(736, 404);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Detail Teacher";
            // 
            // MSGV
            // 
            this.MSGV.AutoSize = true;
            this.MSGV.Location = new System.Drawing.Point(7, 43);
            this.MSGV.Name = "MSGV";
            this.MSGV.Size = new System.Drawing.Size(74, 17);
            this.MSGV.TabIndex = 0;
            this.MSGV.Text = "IDTeacher";
            // 
            // txtMSGV
            // 
            this.txtMSGV.Location = new System.Drawing.Point(115, 43);
            this.txtMSGV.Name = "txtMSGV";
            this.txtMSGV.Size = new System.Drawing.Size(216, 22);
            this.txtMSGV.TabIndex = 1;
            // 
            // txtNameGV
            // 
            this.txtNameGV.Location = new System.Drawing.Point(115, 99);
            this.txtNameGV.Name = "txtNameGV";
            this.txtNameGV.Size = new System.Drawing.Size(216, 22);
            this.txtNameGV.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Name";
            // 
            // txtNumber
            // 
            this.txtNumber.Location = new System.Drawing.Point(115, 147);
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Size = new System.Drawing.Size(216, 22);
            this.txtNumber.TabIndex = 5;
            // 
            // SDT
            // 
            this.SDT.AutoSize = true;
            this.SDT.Location = new System.Drawing.Point(7, 150);
            this.SDT.Name = "SDT";
            this.SDT.Size = new System.Drawing.Size(102, 17);
            this.SDT.TabIndex = 4;
            this.SDT.Text = "Number phone";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(452, 43);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(217, 22);
            this.dateTimePicker1.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(405, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "NS";
            // 
            // MACS
            // 
            this.MACS.AutoSize = true;
            this.MACS.Location = new System.Drawing.Point(10, 200);
            this.MACS.Name = "MACS";
            this.MACS.Size = new System.Drawing.Size(65, 17);
            this.MACS.TabIndex = 8;
            this.MACS.Text = "Mã cơ sở";
            // 
            // cbbMaCS
            // 
            this.cbbMaCS.FormattingEnabled = true;
            this.cbbMaCS.Location = new System.Drawing.Point(115, 200);
            this.cbbMaCS.Name = "cbbMaCS";
            this.cbbMaCS.Size = new System.Drawing.Size(216, 24);
            this.cbbMaCS.TabIndex = 9;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(115, 305);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 10;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(270, 305);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.ComboBox cbbMaCS;
        private System.Windows.Forms.Label MACS;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox txtNumber;
        private System.Windows.Forms.Label SDT;
        private System.Windows.Forms.TextBox txtNameGV;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMSGV;
        private System.Windows.Forms.Label MSGV;
    }
}