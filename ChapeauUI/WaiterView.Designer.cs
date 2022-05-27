
namespace ChapeauUI
{
    partial class WaiterView
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
            this.btn_confirmOrder = new System.Windows.Forms.Button();
            this.cmbMenu = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn_confirmOrder
            // 
            this.btn_confirmOrder.Location = new System.Drawing.Point(290, 394);
            this.btn_confirmOrder.Name = "btn_confirmOrder";
            this.btn_confirmOrder.Size = new System.Drawing.Size(245, 29);
            this.btn_confirmOrder.TabIndex = 0;
            this.btn_confirmOrder.Text = "Confirm Order";
            this.btn_confirmOrder.UseVisualStyleBackColor = true;
            // 
            // cmbMenu
            // 
            this.cmbMenu.FormattingEnabled = true;
            this.cmbMenu.Location = new System.Drawing.Point(290, 138);
            this.cmbMenu.Name = "cmbMenu";
            this.cmbMenu.Size = new System.Drawing.Size(245, 28);
            this.cmbMenu.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(290, 237);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(245, 27);
            this.textBox1.TabIndex = 2;
            // 
            // WaiterView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.cmbMenu);
            this.Controls.Add(this.btn_confirmOrder);
            this.Name = "WaiterView";
            this.Text = "WaiterView";
            this.Load += new System.EventHandler(this.WaiterView_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_confirmOrder;
        private System.Windows.Forms.ComboBox cmbMenu;
        private System.Windows.Forms.TextBox textBox1;
    }
}