namespace AutoCheckAndSendReport
{
    partial class FrmMain
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tbpJuchu = new System.Windows.Forms.TabPage();
            this.dtgJuchuu = new System.Windows.Forms.DataGridView();
            this.tbpSeihin = new System.Windows.Forms.TabPage();
            this.dtgSeihin = new System.Windows.Forms.DataGridView();
            this.tbpBuhin = new System.Windows.Forms.TabPage();
            this.dtgBuhin = new System.Windows.Forms.DataGridView();
            this.pnRight = new System.Windows.Forms.Panel();
            this.pnBot = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblMessage = new System.Windows.Forms.Label();
            this.pnMid = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ファイルToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.受注残をひらくToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ーToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
            this.製品負荷を開くToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.部品負荷を開くToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ヘルプToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1.SuspendLayout();
            this.tbpJuchu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgJuchuu)).BeginInit();
            this.tbpSeihin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgSeihin)).BeginInit();
            this.tbpBuhin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgBuhin)).BeginInit();
            this.pnBot.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.pnMid.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tbpJuchu);
            this.tabControl1.Controls.Add(this.tbpSeihin);
            this.tabControl1.Controls.Add(this.tbpBuhin);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(792, 323);
            this.tabControl1.TabIndex = 0;
            // 
            // tbpJuchu
            // 
            this.tbpJuchu.Controls.Add(this.dtgJuchuu);
            this.tbpJuchu.Location = new System.Drawing.Point(4, 32);
            this.tbpJuchu.Name = "tbpJuchu";
            this.tbpJuchu.Padding = new System.Windows.Forms.Padding(3);
            this.tbpJuchu.Size = new System.Drawing.Size(784, 287);
            this.tbpJuchu.TabIndex = 0;
            this.tbpJuchu.Text = "受注残";
            this.tbpJuchu.UseVisualStyleBackColor = true;
            // 
            // dtgJuchuu
            // 
            this.dtgJuchuu.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dtgJuchuu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgJuchuu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgJuchuu.Location = new System.Drawing.Point(3, 3);
            this.dtgJuchuu.Name = "dtgJuchuu";
            this.dtgJuchuu.RowTemplate.Height = 21;
            this.dtgJuchuu.Size = new System.Drawing.Size(778, 281);
            this.dtgJuchuu.TabIndex = 0;
            // 
            // tbpSeihin
            // 
            this.tbpSeihin.Controls.Add(this.dtgSeihin);
            this.tbpSeihin.Location = new System.Drawing.Point(4, 32);
            this.tbpSeihin.Name = "tbpSeihin";
            this.tbpSeihin.Padding = new System.Windows.Forms.Padding(3);
            this.tbpSeihin.Size = new System.Drawing.Size(718, 287);
            this.tbpSeihin.TabIndex = 1;
            this.tbpSeihin.Text = "製品負荷リスト";
            this.tbpSeihin.UseVisualStyleBackColor = true;
            // 
            // dtgSeihin
            // 
            this.dtgSeihin.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dtgSeihin.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgSeihin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgSeihin.Location = new System.Drawing.Point(3, 3);
            this.dtgSeihin.Name = "dtgSeihin";
            this.dtgSeihin.RowTemplate.Height = 21;
            this.dtgSeihin.Size = new System.Drawing.Size(712, 281);
            this.dtgSeihin.TabIndex = 0;
            // 
            // tbpBuhin
            // 
            this.tbpBuhin.Controls.Add(this.dtgBuhin);
            this.tbpBuhin.Location = new System.Drawing.Point(4, 32);
            this.tbpBuhin.Name = "tbpBuhin";
            this.tbpBuhin.Size = new System.Drawing.Size(718, 287);
            this.tbpBuhin.TabIndex = 2;
            this.tbpBuhin.Text = "部品負荷リスト";
            this.tbpBuhin.UseVisualStyleBackColor = true;
            // 
            // dtgBuhin
            // 
            this.dtgBuhin.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dtgBuhin.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgBuhin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgBuhin.Location = new System.Drawing.Point(0, 0);
            this.dtgBuhin.Name = "dtgBuhin";
            this.dtgBuhin.RowTemplate.Height = 21;
            this.dtgBuhin.Size = new System.Drawing.Size(718, 287);
            this.dtgBuhin.TabIndex = 0;
            // 
            // pnRight
            // 
            this.pnRight.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnRight.Location = new System.Drawing.Point(792, 31);
            this.pnRight.Name = "pnRight";
            this.pnRight.Size = new System.Drawing.Size(150, 363);
            this.pnRight.TabIndex = 1;
            // 
            // pnBot
            // 
            this.pnBot.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnBot.Controls.Add(this.tableLayoutPanel1);
            this.pnBot.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnBot.Location = new System.Drawing.Point(0, 354);
            this.pnBot.Name = "pnBot";
            this.pnBot.Size = new System.Drawing.Size(792, 40);
            this.pnBot.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.lblMessage, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(792, 40);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMessage.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.ForeColor = System.Drawing.Color.Blue;
            this.lblMessage.Location = new System.Drawing.Point(3, 0);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(786, 40);
            this.lblMessage.TabIndex = 0;
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnMid
            // 
            this.pnMid.Controls.Add(this.tabControl1);
            this.pnMid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnMid.Location = new System.Drawing.Point(0, 31);
            this.pnMid.Name = "pnMid";
            this.pnMid.Size = new System.Drawing.Size(792, 323);
            this.pnMid.TabIndex = 3;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.menuStrip1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ファイルToolStripMenuItem,
            this.ヘルプToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(942, 31);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ファイルToolStripMenuItem
            // 
            this.ファイルToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.受注残をひらくToolStripMenuItem,
            this.ーToolStripMenuItem,
            this.製品負荷を開くToolStripMenuItem,
            this.toolStripMenuItem1,
            this.部品負荷を開くToolStripMenuItem});
            this.ファイルToolStripMenuItem.Image = global::AutoCheckAndSendReport.Properties.Resources._1477633922_BT_folder_file_open;
            this.ファイルToolStripMenuItem.Name = "ファイルToolStripMenuItem";
            this.ファイルToolStripMenuItem.Size = new System.Drawing.Size(92, 27);
            this.ファイルToolStripMenuItem.Text = "ファイル";
            // 
            // 受注残をひらくToolStripMenuItem
            // 
            this.受注残をひらくToolStripMenuItem.Image = global::AutoCheckAndSendReport.Properties.Resources._1477633939_open_file;
            this.受注残をひらくToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.受注残をひらくToolStripMenuItem.Name = "受注残をひらくToolStripMenuItem";
            this.受注残をひらくToolStripMenuItem.Size = new System.Drawing.Size(199, 28);
            this.受注残をひらくToolStripMenuItem.Text = "受注残を開く";
            this.受注残をひらくToolStripMenuItem.Click += new System.EventHandler(this.受注残をひらくToolStripMenuItem_Click);
            // 
            // ーToolStripMenuItem
            // 
            this.ーToolStripMenuItem.Name = "ーToolStripMenuItem";
            this.ーToolStripMenuItem.Size = new System.Drawing.Size(196, 6);
            // 
            // 製品負荷を開くToolStripMenuItem
            // 
            this.製品負荷を開くToolStripMenuItem.Image = global::AutoCheckAndSendReport.Properties.Resources._1477633939_open_file;
            this.製品負荷を開くToolStripMenuItem.Name = "製品負荷を開くToolStripMenuItem";
            this.製品負荷を開くToolStripMenuItem.Size = new System.Drawing.Size(199, 28);
            this.製品負荷を開くToolStripMenuItem.Text = "製品負荷を開く";
            this.製品負荷を開くToolStripMenuItem.Click += new System.EventHandler(this.製品負荷を開くToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(196, 6);
            // 
            // 部品負荷を開くToolStripMenuItem
            // 
            this.部品負荷を開くToolStripMenuItem.Image = global::AutoCheckAndSendReport.Properties.Resources._1477633939_open_file;
            this.部品負荷を開くToolStripMenuItem.Name = "部品負荷を開くToolStripMenuItem";
            this.部品負荷を開くToolStripMenuItem.Size = new System.Drawing.Size(199, 28);
            this.部品負荷を開くToolStripMenuItem.Text = "部品負荷を開く";
            this.部品負荷を開くToolStripMenuItem.Click += new System.EventHandler(this.部品負荷を開くToolStripMenuItem_Click);
            // 
            // ヘルプToolStripMenuItem
            // 
            this.ヘルプToolStripMenuItem.Name = "ヘルプToolStripMenuItem";
            this.ヘルプToolStripMenuItem.Size = new System.Drawing.Size(68, 27);
            this.ヘルプToolStripMenuItem.Text = "ヘルプ";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(942, 394);
            this.Controls.Add(this.pnMid);
            this.Controls.Add(this.pnBot);
            this.Controls.Add(this.pnRight);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Name = "FrmMain";
            this.Text = "AUTO CHECK AND SEND REPORT";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tbpJuchu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgJuchuu)).EndInit();
            this.tbpSeihin.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgSeihin)).EndInit();
            this.tbpBuhin.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgBuhin)).EndInit();
            this.pnBot.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.pnMid.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tbpJuchu;
        private System.Windows.Forms.TabPage tbpSeihin;
        private System.Windows.Forms.TabPage tbpBuhin;
        private System.Windows.Forms.Panel pnRight;
        private System.Windows.Forms.Panel pnBot;
        private System.Windows.Forms.Panel pnMid;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ファイルToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 受注残をひらくToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator ーToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 製品負荷を開くToolStripMenuItem;
        private System.Windows.Forms.DataGridView dtgJuchuu;
        private System.Windows.Forms.DataGridView dtgSeihin;
        private System.Windows.Forms.DataGridView dtgBuhin;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 部品負荷を開くToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ヘルプToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblMessage;
    }
}

