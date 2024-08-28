namespace WinFormsTwo
{
    partial class AccountForm
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
            this.txtID = new System.Windows.Forms.TextBox();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnSet = new System.Windows.Forms.Button();
            this.btnGet = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnDestroy = new System.Windows.Forms.Button();
            this.btnGC = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtBalance = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(28, 56);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(100, 20);
            this.txtID.TabIndex = 1;
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(53, 118);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(75, 30);
            this.btnCreate.TabIndex = 2;
            this.btnCreate.Text = "Create";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnSet
            // 
            this.btnSet.Location = new System.Drawing.Point(168, 118);
            this.btnSet.Name = "btnSet";
            this.btnSet.Size = new System.Drawing.Size(75, 30);
            this.btnSet.TabIndex = 3;
            this.btnSet.Text = "Set";
            this.btnSet.UseVisualStyleBackColor = true;
            this.btnSet.Click += new System.EventHandler(this.btnSet_Click);
            // 
            // btnGet
            // 
            this.btnGet.Location = new System.Drawing.Point(285, 118);
            this.btnGet.Name = "btnGet";
            this.btnGet.Size = new System.Drawing.Size(75, 30);
            this.btnGet.TabIndex = 4;
            this.btnGet.Text = "Get";
            this.btnGet.UseVisualStyleBackColor = true;
            this.btnGet.Click += new System.EventHandler(this.btnGet_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(53, 174);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 30);
            this.btnClear.TabIndex = 5;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnDestroy
            // 
            this.btnDestroy.Location = new System.Drawing.Point(168, 174);
            this.btnDestroy.Name = "btnDestroy";
            this.btnDestroy.Size = new System.Drawing.Size(75, 30);
            this.btnDestroy.TabIndex = 6;
            this.btnDestroy.Text = "Destroy";
            this.btnDestroy.UseVisualStyleBackColor = true;
            this.btnDestroy.Click += new System.EventHandler(this.btnDestroy_Click);
            // 
            // btnGC
            // 
            this.btnGC.Location = new System.Drawing.Point(285, 174);
            this.btnGC.Name = "btnGC";
            this.btnGC.Size = new System.Drawing.Size(75, 30);
            this.btnGC.TabIndex = 7;
            this.btnGC.Text = "GC";
            this.btnGC.UseVisualStyleBackColor = true;
            this.btnGC.Click += new System.EventHandler(this.btnGC_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "ID";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(168, 56);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(100, 20);
            this.txtName.TabIndex = 9;
            // 
            // txtBalance
            // 
            this.txtBalance.Location = new System.Drawing.Point(316, 56);
            this.txtBalance.Name = "txtBalance";
            this.txtBalance.Size = new System.Drawing.Size(100, 20);
            this.txtBalance.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(168, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(316, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Balance";
            // 
            // AccountForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 226);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBalance);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGC);
            this.Controls.Add(this.btnDestroy);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnGet);
            this.Controls.Add(this.btnSet);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.txtID);
            this.Name = "AccountForm";
            this.Text = "Account Form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnSet;
        private System.Windows.Forms.Button btnGet;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnDestroy;
        private System.Windows.Forms.Button btnGC;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtBalance;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

