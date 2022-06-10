
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
            this.label1 = new System.Windows.Forms.Label();
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
            this.menuFilter = new System.Windows.Forms.MenuStrip();
            this.startersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.entrementsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dessertsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drinksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.beerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.spiritdrinkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.coffeaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmbQuantity = new System.Windows.Forms.ComboBox();
            this.btnLunchMenu = new System.Windows.Forms.RadioButton();
            this.btnDinnerMenu = new System.Windows.Forms.RadioButton();
            this.menuFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbMenu
            // 
            this.cmbMenu.FormattingEnabled = true;
            this.cmbMenu.Location = new System.Drawing.Point(154, 235);
            this.cmbMenu.Name = "cmbMenu";
            this.cmbMenu.Size = new System.Drawing.Size(347, 28);
            this.cmbMenu.TabIndex = 1;
            // 
            // txtComments
            // 
            this.txtComments.Location = new System.Drawing.Point(154, 349);
            this.txtComments.Name = "txtComments";
            this.txtComments.Size = new System.Drawing.Size(347, 27);
            this.txtComments.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 238);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Select menu item:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(560, 238);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Amount: ";
            // 
            // btnAddItem
            // 
            this.btnAddItem.Location = new System.Drawing.Point(333, 453);
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
            this.label3.Location = new System.Drawing.Point(18, 352);
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
            this.lstCurrentOrder.Location = new System.Drawing.Point(-1, 603);
            this.lstCurrentOrder.Name = "lstCurrentOrder";
            this.lstCurrentOrder.Size = new System.Drawing.Size(812, 281);
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
            this.Quantity.Width = 100;
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
            this.btnCloseWindow.Location = new System.Drawing.Point(18, 143);
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
            // menuFilter
            // 
            this.menuFilter.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuFilter.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startersToolStripMenuItem,
            this.entrementsToolStripMenuItem,
            this.mainsToolStripMenuItem,
            this.dessertsToolStripMenuItem,
            this.drinksToolStripMenuItem,
            this.beerToolStripMenuItem,
            this.wineToolStripMenuItem,
            this.spiritdrinkToolStripMenuItem,
            this.coffeaToolStripMenuItem});
            this.menuFilter.Location = new System.Drawing.Point(0, 0);
            this.menuFilter.Name = "menuFilter";
            this.menuFilter.Size = new System.Drawing.Size(810, 28);
            this.menuFilter.TabIndex = 16;
            this.menuFilter.Text = "menuStrip1";
            this.menuFilter.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuFilter_ItemClicked);
            // 
            // startersToolStripMenuItem
            // 
            this.startersToolStripMenuItem.Name = "startersToolStripMenuItem";
            this.startersToolStripMenuItem.Size = new System.Drawing.Size(73, 24);
            this.startersToolStripMenuItem.Text = "Starters";
            // 
            // entrementsToolStripMenuItem
            // 
            this.entrementsToolStripMenuItem.Name = "entrementsToolStripMenuItem";
            this.entrementsToolStripMenuItem.Size = new System.Drawing.Size(97, 24);
            this.entrementsToolStripMenuItem.Text = "Entrements";
            // 
            // mainsToolStripMenuItem
            // 
            this.mainsToolStripMenuItem.Name = "mainsToolStripMenuItem";
            this.mainsToolStripMenuItem.Size = new System.Drawing.Size(62, 24);
            this.mainsToolStripMenuItem.Text = "Mains";
            // 
            // dessertsToolStripMenuItem
            // 
            this.dessertsToolStripMenuItem.Name = "dessertsToolStripMenuItem";
            this.dessertsToolStripMenuItem.Size = new System.Drawing.Size(78, 24);
            this.dessertsToolStripMenuItem.Text = "Desserts";
            // 
            // drinksToolStripMenuItem
            // 
            this.drinksToolStripMenuItem.Name = "drinksToolStripMenuItem";
            this.drinksToolStripMenuItem.Size = new System.Drawing.Size(93, 24);
            this.drinksToolStripMenuItem.Text = "Soft drinks";
            // 
            // beerToolStripMenuItem
            // 
            this.beerToolStripMenuItem.Name = "beerToolStripMenuItem";
            this.beerToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.beerToolStripMenuItem.Text = "Beer";
            // 
            // wineToolStripMenuItem
            // 
            this.wineToolStripMenuItem.Name = "wineToolStripMenuItem";
            this.wineToolStripMenuItem.Size = new System.Drawing.Size(57, 24);
            this.wineToolStripMenuItem.Text = "Wine";
            // 
            // spiritdrinkToolStripMenuItem
            // 
            this.spiritdrinkToolStripMenuItem.Name = "spiritdrinkToolStripMenuItem";
            this.spiritdrinkToolStripMenuItem.Size = new System.Drawing.Size(101, 24);
            this.spiritdrinkToolStripMenuItem.Text = "Spirit drinks";
            // 
            // coffeaToolStripMenuItem
            // 
            this.coffeaToolStripMenuItem.Name = "coffeaToolStripMenuItem";
            this.coffeaToolStripMenuItem.Size = new System.Drawing.Size(96, 24);
            this.coffeaToolStripMenuItem.Text = "Coffee/Tea";
            // 
            // cmbQuantity
            // 
            this.cmbQuantity.FormattingEnabled = true;
            this.cmbQuantity.Location = new System.Drawing.Point(660, 235);
            this.cmbQuantity.Name = "cmbQuantity";
            this.cmbQuantity.Size = new System.Drawing.Size(48, 28);
            this.cmbQuantity.TabIndex = 17;
            // 
            // btnLunchMenu
            // 
            this.btnLunchMenu.AutoSize = true;
            this.btnLunchMenu.Location = new System.Drawing.Point(210, 64);
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
            this.btnDinnerMenu.Location = new System.Drawing.Point(423, 64);
            this.btnDinnerMenu.Name = "btnDinnerMenu";
            this.btnDinnerMenu.Size = new System.Drawing.Size(115, 24);
            this.btnDinnerMenu.TabIndex = 19;
            this.btnDinnerMenu.TabStop = true;
            this.btnDinnerMenu.Text = "Dinner menu";
            this.btnDinnerMenu.UseVisualStyleBackColor = true;
            this.btnDinnerMenu.CheckedChanged += new System.EventHandler(this.btnDinnerMenu_CheckedChanged);
            // 
            // WaiterView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(810, 1055);
            this.Controls.Add(this.btnDinnerMenu);
            this.Controls.Add(this.btnLunchMenu);
            this.Controls.Add(this.cmbQuantity);
            this.Controls.Add(this.menuFilter);
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
            this.Controls.Add(this.label1);
            this.Name = "WaiterView";
            this.Text = "WaiterView";
            this.Load += new System.EventHandler(this.WaiterView_Load);
            this.menuFilter.ResumeLayout(false);
            this.menuFilter.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cmbMenu;
        private System.Windows.Forms.TextBox txtComments;
        private System.Windows.Forms.Label label1;
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
        private System.Windows.Forms.MenuStrip menuFilter;
        private System.Windows.Forms.ToolStripMenuItem startersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem entrementsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mainsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dessertsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem drinksToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem beerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem spiritdrinkToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem coffeaToolStripMenuItem;
        private System.Windows.Forms.ComboBox cmbQuantity;
        private System.Windows.Forms.RadioButton btnLunchMenu;
        private System.Windows.Forms.RadioButton btnDinnerMenu;
    }
}