﻿
namespace ChapeauUI
{
    partial class KitchenBar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KitchenBar));
            this.lvOrderDetail = new System.Windows.Forms.ListView();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
            this.lvOrders = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblwhat = new System.Windows.Forms.Label();
            this.btn_mrkready = new System.Windows.Forms.Button();
            this.lblUser = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.lblDateTime = new System.Windows.Forms.Label();
            this.btn_Refresh = new System.Windows.Forms.Button();
            this.btn_Undo = new System.Windows.Forms.Button();
            this.btn_Logout = new System.Windows.Forms.Button();
            this.btn_Preparing = new System.Windows.Forms.Button();
            this.btn_History = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lvOrderDetail
            // 
            this.lvOrderDetail.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9});
            this.lvOrderDetail.FullRowSelect = true;
            this.lvOrderDetail.GridLines = true;
            this.lvOrderDetail.HideSelection = false;
            this.lvOrderDetail.Location = new System.Drawing.Point(61, 455);
            this.lvOrderDetail.Name = "lvOrderDetail";
            this.lvOrderDetail.Size = new System.Drawing.Size(573, 262);
            this.lvOrderDetail.TabIndex = 0;
            this.lvOrderDetail.UseCompatibleStateImageBehavior = false;
            this.lvOrderDetail.View = System.Windows.Forms.View.Details;
            this.lvOrderDetail.SelectedIndexChanged += new System.EventHandler(this.lvOrderDetail_SelectedIndexChanged);
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Item";
            this.columnHeader5.Width = 120;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Amount";
            this.columnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader6.Width = 78;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Status";
            this.columnHeader7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader7.Width = 100;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Time";
            this.columnHeader8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader8.Width = 90;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Requests";
            this.columnHeader9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader9.Width = 170;
            // 
            // lvOrders
            // 
            this.lvOrders.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lvOrders.FullRowSelect = true;
            this.lvOrders.GridLines = true;
            this.lvOrders.HideSelection = false;
            this.lvOrders.Location = new System.Drawing.Point(61, 191);
            this.lvOrders.Name = "lvOrders";
            this.lvOrders.Size = new System.Drawing.Size(341, 240);
            this.lvOrders.TabIndex = 1;
            this.lvOrders.UseCompatibleStateImageBehavior = false;
            this.lvOrders.View = System.Windows.Forms.View.Details;
            this.lvOrders.SelectedIndexChanged += new System.EventHandler(this.lvOrders_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Order nr.";
            this.columnHeader1.Width = 80;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Table";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 80;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Time";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 80;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Waiter";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader4.Width = 80;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(232, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(226, 99);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 22;
            this.pictureBox1.TabStop = false;
            // 
            // lblwhat
            // 
            this.lblwhat.AutoSize = true;
            this.lblwhat.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblwhat.Location = new System.Drawing.Point(250, 103);
            this.lblwhat.Name = "lblwhat";
            this.lblwhat.Size = new System.Drawing.Size(197, 45);
            this.lblwhat.TabIndex = 23;
            this.lblwhat.Text = "Kitchen/Bar";
            // 
            // btn_mrkready
            // 
            this.btn_mrkready.BackColor = System.Drawing.Color.Lime;
            this.btn_mrkready.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.btn_mrkready.Location = new System.Drawing.Point(341, 735);
            this.btn_mrkready.Name = "btn_mrkready";
            this.btn_mrkready.Size = new System.Drawing.Size(293, 49);
            this.btn_mrkready.TabIndex = 24;
            this.btn_mrkready.Text = "MARK AS READY";
            this.btn_mrkready.UseVisualStyleBackColor = false;
            this.btn_mrkready.Click += new System.EventHandler(this.btn_mrkready_Click);
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(557, 103);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(29, 15);
            this.lblUser.TabIndex = 25;
            this.lblUser.Text = "user";
            this.lblUser.Click += new System.EventHandler(this.lblUser_Click);
            // 
            // lblDateTime
            // 
            this.lblDateTime.AutoSize = true;
            this.lblDateTime.Location = new System.Drawing.Point(61, 103);
            this.lblDateTime.Name = "lblDateTime";
            this.lblDateTime.Size = new System.Drawing.Size(54, 15);
            this.lblDateTime.TabIndex = 26;
            this.lblDateTime.Text = "datetime";
            // 
            // btn_Refresh
            // 
            this.btn_Refresh.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btn_Refresh.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_Refresh.Location = new System.Drawing.Point(446, 268);
            this.btn_Refresh.Name = "btn_Refresh";
            this.btn_Refresh.Size = new System.Drawing.Size(188, 63);
            this.btn_Refresh.TabIndex = 28;
            this.btn_Refresh.Text = "Refresh";
            this.btn_Refresh.UseVisualStyleBackColor = false;
            this.btn_Refresh.Click += new System.EventHandler(this.btn_Refresh_Click);
            // 
            // btn_Undo
            // 
            this.btn_Undo.BackColor = System.Drawing.Color.RosyBrown;
            this.btn_Undo.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_Undo.Location = new System.Drawing.Point(446, 354);
            this.btn_Undo.Name = "btn_Undo";
            this.btn_Undo.Size = new System.Drawing.Size(188, 54);
            this.btn_Undo.TabIndex = 30;
            this.btn_Undo.Text = "Undo";
            this.btn_Undo.UseVisualStyleBackColor = false;
            this.btn_Undo.Click += new System.EventHandler(this.btn_Undo_Click);
            // 
            // btn_Logout
            // 
            this.btn_Logout.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.btn_Logout.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.btn_Logout.Location = new System.Drawing.Point(12, 12);
            this.btn_Logout.Name = "btn_Logout";
            this.btn_Logout.Size = new System.Drawing.Size(117, 45);
            this.btn_Logout.TabIndex = 31;
            this.btn_Logout.Text = "Logout";
            this.btn_Logout.UseVisualStyleBackColor = false;
            this.btn_Logout.Click += new System.EventHandler(this.btn_Logout_Click);
            // 
            // btn_Preparing
            // 
            this.btn_Preparing.BackColor = System.Drawing.Color.LightSalmon;
            this.btn_Preparing.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_Preparing.Location = new System.Drawing.Point(61, 735);
            this.btn_Preparing.Name = "btn_Preparing";
            this.btn_Preparing.Size = new System.Drawing.Size(274, 49);
            this.btn_Preparing.TabIndex = 32;
            this.btn_Preparing.Text = "Preparing";
            this.btn_Preparing.UseVisualStyleBackColor = false;
            this.btn_Preparing.Click += new System.EventHandler(this.btn_Preparing_Click);
            // 
            // btn_History
            // 
            this.btn_History.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btn_History.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_History.Location = new System.Drawing.Point(446, 191);
            this.btn_History.Name = "btn_History";
            this.btn_History.Size = new System.Drawing.Size(188, 52);
            this.btn_History.TabIndex = 33;
            this.btn_History.Text = "History";
            this.btn_History.UseVisualStyleBackColor = false;
            this.btn_History.Click += new System.EventHandler(this.btn_History_Click);
            // 
            // KitchenBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(671, 821);
            this.Controls.Add(this.btn_History);
            this.Controls.Add(this.btn_Preparing);
            this.Controls.Add(this.btn_Logout);
            this.Controls.Add(this.btn_Undo);
            this.Controls.Add(this.btn_Refresh);
            this.Controls.Add(this.lblDateTime);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.btn_mrkready);
            this.Controls.Add(this.lblwhat);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lvOrders);
            this.Controls.Add(this.lvOrderDetail);
            this.Name = "KitchenBar";
            this.Text = "KitchenBar";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvOrderDetail;
        private System.Windows.Forms.ListView lvOrders;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblwhat;
        private System.Windows.Forms.Button btn_mrkready;
        private System.Windows.Forms.Label lblUser;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label lblDateTime;
        private System.Windows.Forms.Button btn_Refresh;
        private System.Windows.Forms.Button btn_Undo;
        private System.Windows.Forms.Button btn_Logout;
        private System.Windows.Forms.Button btn_Preparing;
        private System.Windows.Forms.Button btn_History;
    }
}