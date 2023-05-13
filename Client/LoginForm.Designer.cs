
namespace Client
{
    partial class LoginForm
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
            this.Loginbtn = new System.Windows.Forms.Button();
            this.hostName_lbl = new System.Windows.Forms.Label();
            this.AccountNum = new System.Windows.Forms.TextBox();
            this.HostName = new System.Windows.Forms.TextBox();
            this.AccountNum_lbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Loginbtn
            // 
            this.Loginbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Loginbtn.Location = new System.Drawing.Point(12, 86);
            this.Loginbtn.Name = "Loginbtn";
            this.Loginbtn.Size = new System.Drawing.Size(124, 33);
            this.Loginbtn.TabIndex = 9;
            this.Loginbtn.Text = "Login";
            this.Loginbtn.UseVisualStyleBackColor = true;
            this.Loginbtn.Click += new System.EventHandler(this.Loginbtn_Click);
            // 
            // hostName_lbl
            // 
            this.hostName_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.hostName_lbl.Location = new System.Drawing.Point(12, 9);
            this.hostName_lbl.Name = "hostName_lbl";
            this.hostName_lbl.Size = new System.Drawing.Size(124, 28);
            this.hostName_lbl.TabIndex = 8;
            this.hostName_lbl.Text = "Host Name";
            // 
            // AccountNum
            // 
            this.AccountNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.AccountNum.Location = new System.Drawing.Point(142, 54);
            this.AccountNum.Name = "AccountNum";
            this.AccountNum.Size = new System.Drawing.Size(216, 26);
            this.AccountNum.TabIndex = 7;
            // 
            // HostName
            // 
            this.HostName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.HostName.Location = new System.Drawing.Point(142, 9);
            this.HostName.Name = "HostName";
            this.HostName.Size = new System.Drawing.Size(216, 26);
            this.HostName.TabIndex = 6;
            // 
            // AccountNum_lbl
            // 
            this.AccountNum_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.AccountNum_lbl.Location = new System.Drawing.Point(12, 54);
            this.AccountNum_lbl.Name = "AccountNum_lbl";
            this.AccountNum_lbl.Size = new System.Drawing.Size(124, 28);
            this.AccountNum_lbl.TabIndex = 5;
            this.AccountNum_lbl.Text = "Account No.";
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 129);
            this.Controls.Add(this.Loginbtn);
            this.Controls.Add(this.hostName_lbl);
            this.Controls.Add(this.AccountNum);
            this.Controls.Add(this.HostName);
            this.Controls.Add(this.AccountNum_lbl);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximumSize = new System.Drawing.Size(396, 176);
            this.MinimumSize = new System.Drawing.Size(396, 176);
            this.Name = "LoginForm";
            this.Text = "Login Form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Loginbtn;
        private System.Windows.Forms.Label hostName_lbl;
        private System.Windows.Forms.TextBox AccountNum;
        private System.Windows.Forms.TextBox HostName;
        private System.Windows.Forms.Label AccountNum_lbl;
    }
}

