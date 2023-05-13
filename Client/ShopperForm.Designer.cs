
namespace Client
{
    partial class ShopperForm
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
            this.Purchasebth = new System.Windows.Forms.Button();
            this.ListBox = new System.Windows.Forms.ListBox();
            this.ProductList = new System.Windows.Forms.ComboBox();
            this.Namelbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Purchasebth
            // 
            this.Purchasebth.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Purchasebth.Location = new System.Drawing.Point(335, 200);
            this.Purchasebth.Name = "Purchasebth";
            this.Purchasebth.Size = new System.Drawing.Size(151, 33);
            this.Purchasebth.TabIndex = 5;
            this.Purchasebth.Text = "Purchase";
            this.Purchasebth.UseVisualStyleBackColor = true;
            this.Purchasebth.Click += new System.EventHandler(this.Purchasebth_Click);
            // 
            // ListBox
            // 
            this.ListBox.BackColor = System.Drawing.SystemColors.Control;
            this.ListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListBox.FormattingEnabled = true;
            this.ListBox.ItemHeight = 20;
            this.ListBox.Location = new System.Drawing.Point(12, 37);
            this.ListBox.Name = "ListBox";
            this.ListBox.Size = new System.Drawing.Size(291, 204);
            this.ListBox.TabIndex = 4;
            // 
            // ProductList
            // 
            this.ProductList.BackColor = System.Drawing.SystemColors.Control;
            this.ProductList.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProductList.FormattingEnabled = true;
            this.ProductList.Location = new System.Drawing.Point(309, 37);
            this.ProductList.Name = "ProductList";
            this.ProductList.Size = new System.Drawing.Size(210, 28);
            this.ProductList.TabIndex = 3;
            // 
            // Namelbl
            // 
            this.Namelbl.AutoSize = true;
            this.Namelbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Namelbl.Location = new System.Drawing.Point(12, 9);
            this.Namelbl.Name = "Namelbl";
            this.Namelbl.Size = new System.Drawing.Size(185, 25);
            this.Namelbl.TabIndex = 6;
            this.Namelbl.Text = "Welcome Customer";
            // 
            // ShopperForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 255);
            this.Controls.Add(this.Namelbl);
            this.Controls.Add(this.Purchasebth);
            this.Controls.Add(this.ListBox);
            this.Controls.Add(this.ProductList);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximumSize = new System.Drawing.Size(551, 302);
            this.MinimumSize = new System.Drawing.Size(551, 302);
            this.Name = "ShopperForm";
            this.Text = "ShopperForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Purchasebth;
        private System.Windows.Forms.ListBox ListBox;
        private System.Windows.Forms.ComboBox ProductList;
        private System.Windows.Forms.Label Namelbl;
    }
}