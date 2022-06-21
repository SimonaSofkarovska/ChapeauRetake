
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
            this.cmbMenu = new System.Windows.Forms.ComboBox();
            this.txtComments = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAddItem = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lstCurrentOrder = new System.Windows.Forms.ListView();
            this.ItemName = new System.Windows.Forms.ColumnHeader();
            this.Quantity = new System.Windows.Forms.ColumnHeader();
            this.Requests = new System.Windows.Forms.ColumnHeader();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnCloseWindow = new System.Windows.Forms.Button();
            this.btnEditItem = new System.Windows.Forms.Button();
            this.cmbQuantity = new System.Windows.Forms.ComboBox();
            this.btnLunchMenu = new System.Windows.Forms.RadioButton();
            this.btnDinnerMenu = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbMenuFilter = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // cmbMenu
            // 
            this.cmbMenu.FormattingEnabled = true;
            this.cmbMenu.Location = new System.Drawing.Point(48, 279);
            this.cmbMenu.Name = "cmbMenu";
            this.cmbMenu.Size = new System.Drawing.Size(453, 28);
            this.cmbMenu.TabIndex = 1;
            // 
            // txtComments
            // 
            this.txtComments.Location = new System.Drawing.Point(48, 396);
            this.txtComments.Name = "txtComments";
            this.txtComments.Size = new System.Drawing.Size(453, 27);
            this.txtComments.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(559, 256);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Amount: ";
            // 
            // btnAddItem
            // 
            this.btnAddItem.Location = new System.Drawing.Point(333, 485);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(168, 77);
            this.btnAddItem.TabIndex = 0;
            this.btnAddItem.Text = "Add item";
            this.btnAddItem.UseVisualStyleBackColor = true;
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(48, 373);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "Special requests: ";
            // 
            // lstCurrentOrder
            // 
            this.lstCurrentOrder.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ItemName,
            this.Quantity,
            this.Requests});
            this.lstCurrentOrder.HideSelection = false;
            this.lstCurrentOrder.Location = new System.Drawing.Point(0, 599);
            this.lstCurrentOrder.Name = "lstCurrentOrder";
            this.lstCurrentOrder.Size = new System.Drawing.Size(810, 281);
            this.lstCurrentOrder.TabIndex = 9;
            this.lstCurrentOrder.UseCompatibleStateImageBehavior = false;
            this.lstCurrentOrder.View = System.Windows.Forms.View.Details;
            // 
            // ItemName
            // 
            this.ItemName.Text = "Item name";
            this.ItemName.Width = 300;
            // 
            // Quantity
            // 
            this.Quantity.Text = "Quantity";
            this.Quantity.Width = 80;
            // 
            // Requests
            // 
            this.Requests.Text = "Special requests";
            this.Requests.Width = 400;
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(328, 922);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(156, 84);
            this.btnRemove.TabIndex = 10;
            this.btnRemove.Text = "Remove item";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(596, 922);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(156, 84);
            this.btnSubmit.TabIndex = 11;
            this.btnSubmit.Text = "Submit order";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnCloseWindow
            // 
            this.btnCloseWindow.Location = new System.Drawing.Point(48, 31);
            this.btnCloseWindow.Name = "btnCloseWindow";
            this.btnCloseWindow.Size = new System.Drawing.Size(129, 43);
            this.btnCloseWindow.TabIndex = 13;
            this.btnCloseWindow.Text = "Close ";
            this.btnCloseWindow.UseVisualStyleBackColor = true;
            this.btnCloseWindow.Click += new System.EventHandler(this.btnCloseWindow_Click);
            // 
            // btnEditItem
            // 
            this.btnEditItem.Location = new System.Drawing.Point(74, 922);
            this.btnEditItem.Name = "btnEditItem";
            this.btnEditItem.Size = new System.Drawing.Size(156, 84);
            this.btnEditItem.TabIndex = 14;
            this.btnEditItem.Text = "Edit";
            this.btnEditItem.UseVisualStyleBackColor = true;
            this.btnEditItem.Click += new System.EventHandler(this.btnEditItem_Click);
            // 
            // cmbQuantity
            // 
            this.cmbQuantity.FormattingEnabled = true;
            this.cmbQuantity.Location = new System.Drawing.Point(559, 279);
            this.cmbQuantity.Name = "cmbQuantity";
            this.cmbQuantity.Size = new System.Drawing.Size(48, 28);
            this.cmbQuantity.TabIndex = 17;
            // 
            // btnLunchMenu
            // 
            this.btnLunchMenu.AutoSize = true;
            this.btnLunchMenu.Location = new System.Drawing.Point(559, 128);
            this.btnLunchMenu.Name = "btnLunchMenu";
            this.btnLunchMenu.Size = new System.Drawing.Size(109, 24);
            this.btnLunchMenu.TabIndex = 18;
            this.btnLunchMenu.TabStop = true;
            this.btnLunchMenu.Text = "Lunch menu";
            this.btnLunchMenu.UseVisualStyleBackColor = true;
            this.btnLunchMenu.CheckedChanged += new System.EventHandler(this.btnLunchMenu_CheckedChanged);
            // 
            // btnDinnerMenu
            // 
            this.btnDinnerMenu.AutoSize = true;
            this.btnDinnerMenu.Location = new System.Drawing.Point(559, 169);
            this.btnDinnerMenu.Name = "btnDinnerMenu";
            this.btnDinnerMenu.Size = new System.Drawing.Size(115, 24);
            this.btnDinnerMenu.TabIndex = 19;
            this.btnDinnerMenu.TabStop = true;
            this.btnDinnerMenu.Text = "Dinner menu";
            this.btnDinnerMenu.UseVisualStyleBackColor = true;
            this.btnDinnerMenu.CheckedChanged += new System.EventHandler(this.btnDinnerMenu_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 256);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 20);
            this.label1.TabIndex = 20;
            this.label1.Text = "Menu";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(48, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 20);
            this.label4.TabIndex = 22;
            this.label4.Text = "Filter menu";
            // 
            // cmbMenuFilter
            // 
            this.cmbMenuFilter.FormattingEnabled = true;
            this.cmbMenuFilter.Location = new System.Drawing.Point(48, 168);
            this.cmbMenuFilter.Name = "cmbMenuFilter";
            this.cmbMenuFilter.Size = new System.Drawing.Size(151, 28);
            this.cmbMenuFilter.TabIndex = 23;
            this.cmbMenuFilter.SelectedIndexChanged += new System.EventHandler(this.cmbMenuFilter_SelectedIndexChanged);
            // 
            // WaiterView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(810, 1055);
            this.Controls.Add(this.cmbMenuFilter);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDinnerMenu);
            this.Controls.Add(this.btnLunchMenu);
            this.Controls.Add(this.cmbQuantity);
            this.Controls.Add(this.btnEditItem);
            this.Controls.Add(this.btnCloseWindow);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.lstCurrentOrder);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnAddItem);
            this.Controls.Add(this.txtComments);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbMenu);
            this.Name = "WaiterView";
            this.Text = "WaiterView";
            this.Load += new System.EventHandler(this.WaiterView_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cmbMenu;
        private System.Windows.Forms.TextBox txtComments;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAddItem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView lstCurrentOrder;
        private System.Windows.Forms.ColumnHeader ItemName;
        private System.Windows.Forms.ColumnHeader Quantity;
        private System.Windows.Forms.ColumnHeader Requests;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnCloseWindow;
        private System.Windows.Forms.Button btnEditItem;
        private System.Windows.Forms.ComboBox cmbQuantity;
        private System.Windows.Forms.RadioButton btnLunchMenu;
        private System.Windows.Forms.RadioButton btnDinnerMenu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbMenuFilter;
    }
}