﻿namespace PcFirma
{
    partial class CustomersProduct
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
            this.ExitButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.dataOfProducts = new System.Windows.Forms.DataGridView();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataOfProducts)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Yu Gothic UI", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(434, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(266, 81);
            this.label1.TabIndex = 34;
            this.label1.Text = "Products";
            // 
            // ExitButton
            // 
            this.ExitButton.Font = new System.Drawing.Font("Yu Gothic UI", 16.8F);
            this.ExitButton.Location = new System.Drawing.Point(804, 618);
            this.ExitButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(204, 57);
            this.ExitButton.TabIndex = 33;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = true;
            // 
            // addButton
            // 
            this.addButton.Font = new System.Drawing.Font("Yu Gothic UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addButton.Location = new System.Drawing.Point(214, 618);
            this.addButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(213, 57);
            this.addButton.TabIndex = 30;
            this.addButton.Text = "Buy";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // dataOfProducts
            // 
            this.dataOfProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataOfProducts.Location = new System.Drawing.Point(121, 155);
            this.dataOfProducts.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataOfProducts.Name = "dataOfProducts";
            this.dataOfProducts.RowHeadersWidth = 51;
            this.dataOfProducts.RowTemplate.Height = 24;
            this.dataOfProducts.Size = new System.Drawing.Size(660, 437);
            this.dataOfProducts.TabIndex = 29;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(820, 155);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(242, 436);
            this.listBox1.TabIndex = 35;
            this.listBox1.DoubleClick += new System.EventHandler(this.listBox1_DoubleClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Yu Gothic UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(913, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 31);
            this.label2.TabIndex = 36;
            this.label2.Text = "Cart";
            // 
            // CustomersProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1183, 712);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.dataOfProducts);
            this.Name = "CustomersProduct";
            this.Text = "CustomersProduct";
            this.Activated += new System.EventHandler(this.CustomersProduct_Activated);
            ((System.ComponentModel.ISupportInitialize)(this.dataOfProducts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.DataGridView dataOfProducts;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label2;
    }
}