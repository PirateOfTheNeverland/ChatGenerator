namespace ChatVolumizer
{
    partial class ChatVolumizer
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
            this.lblChats = new System.Windows.Forms.Label();
            this.IDT_CHATCOUNT = new System.Windows.Forms.TextBox();
            this.IDB_START = new System.Windows.Forms.Button();
            this.lblChatsNotifier = new System.Windows.Forms.Label();
            this.IDB_STOP = new System.Windows.Forms.Button();
            this.lblSite = new System.Windows.Forms.Label();
            this.IDT_SITEID = new System.Windows.Forms.TextBox();
            this.IDCB_THREADING = new System.Windows.Forms.CheckBox();
            this.lblThreadingNotifier = new System.Windows.Forms.Label();
            this.lblDelay = new System.Windows.Forms.Label();
            this.IDT_DELAY = new System.Windows.Forms.TextBox();
            this.lblVolumeCount = new System.Windows.Forms.Label();
            this.IDT_VOLUMECOUNT = new System.Windows.Forms.TextBox();
            this.IDCB_FORCECLOSE = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.IDB_SAVELOG = new System.Windows.Forms.Button();
            this.IDT_LOG = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblChats
            // 
            this.lblChats.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblChats.Location = new System.Drawing.Point(12, 58);
            this.lblChats.Name = "lblChats";
            this.lblChats.Size = new System.Drawing.Size(165, 23);
            this.lblChats.TabIndex = 0;
            this.lblChats.Text = "Number of chats:";
            this.lblChats.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // IDT_CHATCOUNT
            // 
            this.IDT_CHATCOUNT.AccessibleName = "id_txt_chat_count";
            this.IDT_CHATCOUNT.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.IDT_CHATCOUNT.Location = new System.Drawing.Point(183, 60);
            this.IDT_CHATCOUNT.Name = "IDT_CHATCOUNT";
            this.IDT_CHATCOUNT.Size = new System.Drawing.Size(100, 20);
            this.IDT_CHATCOUNT.TabIndex = 1;
            // 
            // IDB_START
            // 
            this.IDB_START.Location = new System.Drawing.Point(329, 25);
            this.IDB_START.Name = "IDB_START";
            this.IDB_START.Size = new System.Drawing.Size(75, 56);
            this.IDB_START.TabIndex = 2;
            this.IDB_START.Text = "ROCK ON!";
            this.IDB_START.UseVisualStyleBackColor = true;
            this.IDB_START.Click += new System.EventHandler(this.IDB_START_Click);
            // 
            // lblChatsNotifier
            // 
            this.lblChatsNotifier.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblChatsNotifier.Location = new System.Drawing.Point(12, 129);
            this.lblChatsNotifier.Name = "lblChatsNotifier";
            this.lblChatsNotifier.Size = new System.Drawing.Size(392, 43);
            this.lblChatsNotifier.TabIndex = 3;
            this.lblChatsNotifier.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // IDB_STOP
            // 
            this.IDB_STOP.Location = new System.Drawing.Point(172, 362);
            this.IDB_STOP.Name = "IDB_STOP";
            this.IDB_STOP.Size = new System.Drawing.Size(75, 23);
            this.IDB_STOP.TabIndex = 4;
            this.IDB_STOP.Text = "Stop party";
            this.IDB_STOP.UseVisualStyleBackColor = true;
            this.IDB_STOP.Click += new System.EventHandler(this.IDB_STOP_Click);
            // 
            // lblSite
            // 
            this.lblSite.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSite.Location = new System.Drawing.Point(12, 23);
            this.lblSite.Name = "lblSite";
            this.lblSite.Size = new System.Drawing.Size(165, 23);
            this.lblSite.TabIndex = 5;
            this.lblSite.Text = "Site ID:";
            this.lblSite.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // IDT_SITEID
            // 
            this.IDT_SITEID.AccessibleName = "id_txt_site_id";
            this.IDT_SITEID.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.IDT_SITEID.Location = new System.Drawing.Point(183, 25);
            this.IDT_SITEID.Name = "IDT_SITEID";
            this.IDT_SITEID.Size = new System.Drawing.Size(100, 20);
            this.IDT_SITEID.TabIndex = 6;
            // 
            // IDCB_THREADING
            // 
            this.IDCB_THREADING.AutoSize = true;
            this.IDCB_THREADING.Location = new System.Drawing.Point(12, 190);
            this.IDCB_THREADING.Name = "IDCB_THREADING";
            this.IDCB_THREADING.Size = new System.Drawing.Size(92, 17);
            this.IDCB_THREADING.TabIndex = 7;
            this.IDCB_THREADING.Text = "Use threading";
            this.IDCB_THREADING.UseVisualStyleBackColor = true;
            this.IDCB_THREADING.CheckedChanged += new System.EventHandler(this.IDCB_THREADING_CheckedChanged);
            // 
            // lblThreadingNotifier
            // 
            this.lblThreadingNotifier.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblThreadingNotifier.Location = new System.Drawing.Point(12, 265);
            this.lblThreadingNotifier.Name = "lblThreadingNotifier";
            this.lblThreadingNotifier.Size = new System.Drawing.Size(392, 72);
            this.lblThreadingNotifier.TabIndex = 8;
            this.lblThreadingNotifier.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDelay
            // 
            this.lblDelay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDelay.Location = new System.Drawing.Point(161, 186);
            this.lblDelay.Name = "lblDelay";
            this.lblDelay.Size = new System.Drawing.Size(137, 23);
            this.lblDelay.TabIndex = 9;
            this.lblDelay.Text = "Delay (ms):";
            this.lblDelay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // IDT_DELAY
            // 
            this.IDT_DELAY.AccessibleName = "id_txt_site_id";
            this.IDT_DELAY.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.IDT_DELAY.Location = new System.Drawing.Point(304, 188);
            this.IDT_DELAY.Name = "IDT_DELAY";
            this.IDT_DELAY.Size = new System.Drawing.Size(100, 20);
            this.IDT_DELAY.TabIndex = 10;
            // 
            // lblVolumeCount
            // 
            this.lblVolumeCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblVolumeCount.Location = new System.Drawing.Point(12, 91);
            this.lblVolumeCount.Name = "lblVolumeCount";
            this.lblVolumeCount.Size = new System.Drawing.Size(165, 23);
            this.lblVolumeCount.TabIndex = 11;
            this.lblVolumeCount.Text = "Volumizing count:";
            this.lblVolumeCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // IDT_VOLUMECOUNT
            // 
            this.IDT_VOLUMECOUNT.AccessibleName = "id_txt_chat_count";
            this.IDT_VOLUMECOUNT.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.IDT_VOLUMECOUNT.Location = new System.Drawing.Point(183, 93);
            this.IDT_VOLUMECOUNT.Name = "IDT_VOLUMECOUNT";
            this.IDT_VOLUMECOUNT.Size = new System.Drawing.Size(100, 20);
            this.IDT_VOLUMECOUNT.TabIndex = 12;
            // 
            // IDCB_FORCECLOSE
            // 
            this.IDCB_FORCECLOSE.AutoSize = true;
            this.IDCB_FORCECLOSE.Location = new System.Drawing.Point(12, 213);
            this.IDCB_FORCECLOSE.Name = "IDCB_FORCECLOSE";
            this.IDCB_FORCECLOSE.Size = new System.Drawing.Size(81, 17);
            this.IDCB_FORCECLOSE.TabIndex = 13;
            this.IDCB_FORCECLOSE.Text = "Force close";
            this.IDCB_FORCECLOSE.UseVisualStyleBackColor = true;
            this.IDCB_FORCECLOSE.CheckedChanged += new System.EventHandler(this.IDCB_FORCECLOSE_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.IDT_LOG);
            this.groupBox1.Location = new System.Drawing.Point(411, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(549, 379);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Log";
            // 
            // IDB_SAVELOG
            // 
            this.IDB_SAVELOG.Location = new System.Drawing.Point(677, 362);
            this.IDB_SAVELOG.Name = "IDB_SAVELOG";
            this.IDB_SAVELOG.Size = new System.Drawing.Size(75, 23);
            this.IDB_SAVELOG.TabIndex = 15;
            this.IDB_SAVELOG.Text = "Save log";
            this.IDB_SAVELOG.UseVisualStyleBackColor = true;
            // 
            // IDT_LOG
            // 
            this.IDT_LOG.Location = new System.Drawing.Point(7, 20);
            this.IDT_LOG.Multiline = true;
            this.IDT_LOG.Name = "IDT_LOG";
            this.IDT_LOG.ReadOnly = true;
            this.IDT_LOG.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.IDT_LOG.Size = new System.Drawing.Size(536, 323);
            this.IDT_LOG.TabIndex = 0;
            // 
            // ChatVolumizer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(972, 404);
            this.Controls.Add(this.IDB_SAVELOG);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.IDCB_FORCECLOSE);
            this.Controls.Add(this.IDT_VOLUMECOUNT);
            this.Controls.Add(this.lblVolumeCount);
            this.Controls.Add(this.IDT_DELAY);
            this.Controls.Add(this.lblDelay);
            this.Controls.Add(this.lblThreadingNotifier);
            this.Controls.Add(this.IDCB_THREADING);
            this.Controls.Add(this.IDT_SITEID);
            this.Controls.Add(this.lblSite);
            this.Controls.Add(this.IDB_STOP);
            this.Controls.Add(this.lblChatsNotifier);
            this.Controls.Add(this.IDB_START);
            this.Controls.Add(this.IDT_CHATCOUNT);
            this.Controls.Add(this.lblChats);
            this.Name = "ChatVolumizer";
            this.Text = "Chat volumizer";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblChats;
        private System.Windows.Forms.TextBox IDT_CHATCOUNT;
        private System.Windows.Forms.Button IDB_START;
        private System.Windows.Forms.Label lblChatsNotifier;
        private System.Windows.Forms.Button IDB_STOP;
        private System.Windows.Forms.Label lblSite;
        private System.Windows.Forms.TextBox IDT_SITEID;
        private System.Windows.Forms.CheckBox IDCB_THREADING;
        private System.Windows.Forms.Label lblThreadingNotifier;
        private System.Windows.Forms.Label lblDelay;
        private System.Windows.Forms.TextBox IDT_DELAY;
        private System.Windows.Forms.Label lblVolumeCount;
        private System.Windows.Forms.TextBox IDT_VOLUMECOUNT;
        private System.Windows.Forms.CheckBox IDCB_FORCECLOSE;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox IDT_LOG;
        private System.Windows.Forms.Button IDB_SAVELOG;
    }
}

