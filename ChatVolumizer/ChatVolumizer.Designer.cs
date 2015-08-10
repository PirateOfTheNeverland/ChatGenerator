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
            this.IDT_CHATCOUNT = new System.Windows.Forms.TextBox();
            this.IDB_START = new System.Windows.Forms.Button();
            this.lblSteadySettingsHint = new System.Windows.Forms.Label();
            this.IDB_STOP = new System.Windows.Forms.Button();
            this.lblSite = new System.Windows.Forms.Label();
            this.IDT_SITEID = new System.Windows.Forms.TextBox();
            this.IDCB_THREADING = new System.Windows.Forms.CheckBox();
            this.lblCommonSettingsHint = new System.Windows.Forms.Label();
            this.lblDelay = new System.Windows.Forms.Label();
            this.IDT_DELAY = new System.Windows.Forms.TextBox();
            this.lblVolumeCount = new System.Windows.Forms.Label();
            this.IDT_VOLUMECOUNT = new System.Windows.Forms.TextBox();
            this.IDCB_FORCECLOSE = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.IDT_LOG = new System.Windows.Forms.TextBox();
            this.IDB_SAVELOG = new System.Windows.Forms.Button();
            this.GB_MSG_TYPE = new System.Windows.Forms.GroupBox();
            this.IDRB_MSGTYPE_XTRAFAT1KB = new System.Windows.Forms.RadioButton();
            this.IDRB_MSGTYPE_FAT512 = new System.Windows.Forms.RadioButton();
            this.IDRB_MSGTYPE_MINIMAL = new System.Windows.Forms.RadioButton();
            this.GB_LOADPROFILE = new System.Windows.Forms.GroupBox();
            this.IDRB_LPTYPE_BOOST = new System.Windows.Forms.RadioButton();
            this.IDRB_LPTYPE_STEADY = new System.Windows.Forms.RadioButton();
            this.GB_STEADY_SETTINGS = new System.Windows.Forms.GroupBox();
            this.IDT_TIMECOUNT = new System.Windows.Forms.TextBox();
            this.IDRB_STEADYLIMIT_TIME = new System.Windows.Forms.RadioButton();
            this.IDRB_STEADYLIMIT_CHAT = new System.Windows.Forms.RadioButton();
            this.GB_BOOST_SETTINGS = new System.Windows.Forms.GroupBox();
            this.lblBoostSettingsHint = new System.Windows.Forms.Label();
            this.lblBoostLifetime = new System.Windows.Forms.Label();
            this.IDT_BOOST_LIFETIME = new System.Windows.Forms.TextBox();
            this.lblBoostFinish = new System.Windows.Forms.Label();
            this.IDT_BOOST_FINISH = new System.Windows.Forms.TextBox();
            this.lblBoostStart = new System.Windows.Forms.Label();
            this.IDT_BOOST_START = new System.Windows.Forms.TextBox();
            this.GB_COMMON_SETTINGS = new System.Windows.Forms.GroupBox();
            this.lblWidgetTitle = new System.Windows.Forms.Label();
            this.IDT_WIDGETTITLE = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.GB_MSG_TYPE.SuspendLayout();
            this.GB_LOADPROFILE.SuspendLayout();
            this.GB_STEADY_SETTINGS.SuspendLayout();
            this.GB_BOOST_SETTINGS.SuspendLayout();
            this.GB_COMMON_SETTINGS.SuspendLayout();
            this.SuspendLayout();
            // 
            // IDT_CHATCOUNT
            // 
            this.IDT_CHATCOUNT.AccessibleName = "id_txt_chat_count";
            this.IDT_CHATCOUNT.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.IDT_CHATCOUNT.Location = new System.Drawing.Point(123, 24);
            this.IDT_CHATCOUNT.Name = "IDT_CHATCOUNT";
            this.IDT_CHATCOUNT.Size = new System.Drawing.Size(157, 20);
            this.IDT_CHATCOUNT.TabIndex = 1;
            this.IDT_CHATCOUNT.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IDT_CHATCOUNT_KeyPress);
            // 
            // IDB_START
            // 
            this.IDB_START.Location = new System.Drawing.Point(160, 12);
            this.IDB_START.Name = "IDB_START";
            this.IDB_START.Size = new System.Drawing.Size(75, 56);
            this.IDB_START.TabIndex = 8;
            this.IDB_START.Text = "ROCK ON!";
            this.IDB_START.UseVisualStyleBackColor = true;
            this.IDB_START.Click += new System.EventHandler(this.IDB_START_Click);
            // 
            // lblSteadySettingsHint
            // 
            this.lblSteadySettingsHint.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSteadySettingsHint.Location = new System.Drawing.Point(286, 24);
            this.lblSteadySettingsHint.Name = "lblSteadySettingsHint";
            this.lblSteadySettingsHint.Size = new System.Drawing.Size(193, 66);
            this.lblSteadySettingsHint.TabIndex = 3;
            this.lblSteadySettingsHint.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // IDB_STOP
            // 
            this.IDB_STOP.Location = new System.Drawing.Point(298, 32);
            this.IDB_STOP.Name = "IDB_STOP";
            this.IDB_STOP.Size = new System.Drawing.Size(75, 23);
            this.IDB_STOP.TabIndex = 9;
            this.IDB_STOP.Text = "Stop party";
            this.IDB_STOP.UseVisualStyleBackColor = true;
            this.IDB_STOP.Click += new System.EventHandler(this.IDB_STOP_Click);
            // 
            // lblSite
            // 
            this.lblSite.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSite.Location = new System.Drawing.Point(9, 16);
            this.lblSite.Name = "lblSite";
            this.lblSite.Size = new System.Drawing.Size(108, 23);
            this.lblSite.TabIndex = 5;
            this.lblSite.Text = "Site ID:";
            this.lblSite.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // IDT_SITEID
            // 
            this.IDT_SITEID.AccessibleName = "id_txt_site_id";
            this.IDT_SITEID.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.IDT_SITEID.Location = new System.Drawing.Point(123, 18);
            this.IDT_SITEID.Name = "IDT_SITEID";
            this.IDT_SITEID.Size = new System.Drawing.Size(157, 20);
            this.IDT_SITEID.TabIndex = 0;
            this.IDT_SITEID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IDT_SITEID_KeyPress);
            // 
            // IDCB_THREADING
            // 
            this.IDCB_THREADING.AutoSize = true;
            this.IDCB_THREADING.Checked = true;
            this.IDCB_THREADING.CheckState = System.Windows.Forms.CheckState.Checked;
            this.IDCB_THREADING.Location = new System.Drawing.Point(123, 75);
            this.IDCB_THREADING.Name = "IDCB_THREADING";
            this.IDCB_THREADING.Size = new System.Drawing.Size(92, 17);
            this.IDCB_THREADING.TabIndex = 4;
            this.IDCB_THREADING.Text = "Use threading";
            this.IDCB_THREADING.UseVisualStyleBackColor = true;
            this.IDCB_THREADING.CheckedChanged += new System.EventHandler(this.IDCB_THREADING_CheckedChanged);
            // 
            // lblCommonSettingsHint
            // 
            this.lblCommonSettingsHint.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCommonSettingsHint.Location = new System.Drawing.Point(286, 18);
            this.lblCommonSettingsHint.Name = "lblCommonSettingsHint";
            this.lblCommonSettingsHint.Size = new System.Drawing.Size(193, 78);
            this.lblCommonSettingsHint.TabIndex = 8;
            this.lblCommonSettingsHint.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDelay
            // 
            this.lblDelay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDelay.Location = new System.Drawing.Point(9, 68);
            this.lblDelay.Name = "lblDelay";
            this.lblDelay.Size = new System.Drawing.Size(108, 23);
            this.lblDelay.TabIndex = 9;
            this.lblDelay.Text = "Delay (ms):";
            this.lblDelay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // IDT_DELAY
            // 
            this.IDT_DELAY.AccessibleName = "id_txt_site_id";
            this.IDT_DELAY.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.IDT_DELAY.Location = new System.Drawing.Point(123, 70);
            this.IDT_DELAY.Name = "IDT_DELAY";
            this.IDT_DELAY.Size = new System.Drawing.Size(157, 20);
            this.IDT_DELAY.TabIndex = 3;
            this.IDT_DELAY.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IDT_DELAY_KeyPress);
            // 
            // lblVolumeCount
            // 
            this.lblVolumeCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblVolumeCount.Location = new System.Drawing.Point(9, 60);
            this.lblVolumeCount.Name = "lblVolumeCount";
            this.lblVolumeCount.Size = new System.Drawing.Size(108, 23);
            this.lblVolumeCount.TabIndex = 11;
            this.lblVolumeCount.Text = "Volumizing count:";
            this.lblVolumeCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // IDT_VOLUMECOUNT
            // 
            this.IDT_VOLUMECOUNT.AccessibleName = "id_txt_chat_count";
            this.IDT_VOLUMECOUNT.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.IDT_VOLUMECOUNT.Location = new System.Drawing.Point(123, 61);
            this.IDT_VOLUMECOUNT.Name = "IDT_VOLUMECOUNT";
            this.IDT_VOLUMECOUNT.Size = new System.Drawing.Size(157, 20);
            this.IDT_VOLUMECOUNT.TabIndex = 2;
            this.IDT_VOLUMECOUNT.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IDT_VOLUMECOUNT_KeyPress);
            // 
            // IDCB_FORCECLOSE
            // 
            this.IDCB_FORCECLOSE.AutoSize = true;
            this.IDCB_FORCECLOSE.Checked = true;
            this.IDCB_FORCECLOSE.CheckState = System.Windows.Forms.CheckState.Checked;
            this.IDCB_FORCECLOSE.Location = new System.Drawing.Point(9, 75);
            this.IDCB_FORCECLOSE.Name = "IDCB_FORCECLOSE";
            this.IDCB_FORCECLOSE.Size = new System.Drawing.Size(81, 17);
            this.IDCB_FORCECLOSE.TabIndex = 5;
            this.IDCB_FORCECLOSE.Text = "Force close";
            this.IDCB_FORCECLOSE.UseVisualStyleBackColor = true;
            this.IDCB_FORCECLOSE.CheckedChanged += new System.EventHandler(this.IDCB_FORCECLOSE_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.IDT_LOG);
            this.groupBox1.Controls.Add(this.IDB_SAVELOG);
            this.groupBox1.Location = new System.Drawing.Point(503, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(549, 576);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Log";
            // 
            // IDT_LOG
            // 
            this.IDT_LOG.Location = new System.Drawing.Point(7, 20);
            this.IDT_LOG.Multiline = true;
            this.IDT_LOG.Name = "IDT_LOG";
            this.IDT_LOG.ReadOnly = true;
            this.IDT_LOG.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.IDT_LOG.Size = new System.Drawing.Size(536, 521);
            this.IDT_LOG.TabIndex = 700;
            // 
            // IDB_SAVELOG
            // 
            this.IDB_SAVELOG.Location = new System.Drawing.Point(239, 547);
            this.IDB_SAVELOG.Name = "IDB_SAVELOG";
            this.IDB_SAVELOG.Size = new System.Drawing.Size(75, 23);
            this.IDB_SAVELOG.TabIndex = 15;
            this.IDB_SAVELOG.Text = "Save log";
            this.IDB_SAVELOG.UseVisualStyleBackColor = true;
            this.IDB_SAVELOG.Click += new System.EventHandler(this.IDB_SAVELOG_Click);
            // 
            // GB_MSG_TYPE
            // 
            this.GB_MSG_TYPE.Controls.Add(this.IDRB_MSGTYPE_XTRAFAT1KB);
            this.GB_MSG_TYPE.Controls.Add(this.IDRB_MSGTYPE_FAT512);
            this.GB_MSG_TYPE.Controls.Add(this.IDRB_MSGTYPE_MINIMAL);
            this.GB_MSG_TYPE.Controls.Add(this.lblVolumeCount);
            this.GB_MSG_TYPE.Controls.Add(this.IDT_VOLUMECOUNT);
            this.GB_MSG_TYPE.Location = new System.Drawing.Point(12, 478);
            this.GB_MSG_TYPE.Name = "GB_MSG_TYPE";
            this.GB_MSG_TYPE.Size = new System.Drawing.Size(485, 110);
            this.GB_MSG_TYPE.TabIndex = 16;
            this.GB_MSG_TYPE.TabStop = false;
            this.GB_MSG_TYPE.Text = "Volumizing message type";
            // 
            // IDRB_MSGTYPE_XTRAFAT1KB
            // 
            this.IDRB_MSGTYPE_XTRAFAT1KB.AutoSize = true;
            this.IDRB_MSGTYPE_XTRAFAT1KB.Location = new System.Drawing.Point(200, 20);
            this.IDRB_MSGTYPE_XTRAFAT1KB.Name = "IDRB_MSGTYPE_XTRAFAT1KB";
            this.IDRB_MSGTYPE_XTRAFAT1KB.Size = new System.Drawing.Size(86, 17);
            this.IDRB_MSGTYPE_XTRAFAT1KB.TabIndex = 12;
            this.IDRB_MSGTYPE_XTRAFAT1KB.Text = "XtraFat (1kb)";
            this.IDRB_MSGTYPE_XTRAFAT1KB.UseVisualStyleBackColor = true;
            this.IDRB_MSGTYPE_XTRAFAT1KB.CheckedChanged += new System.EventHandler(this.IDRB_MSGTYPE_XTRAFAT1MB_CheckedChanged);
            // 
            // IDRB_MSGTYPE_FAT512
            // 
            this.IDRB_MSGTYPE_FAT512.AutoSize = true;
            this.IDRB_MSGTYPE_FAT512.Location = new System.Drawing.Point(94, 20);
            this.IDRB_MSGTYPE_FAT512.Name = "IDRB_MSGTYPE_FAT512";
            this.IDRB_MSGTYPE_FAT512.Size = new System.Drawing.Size(73, 17);
            this.IDRB_MSGTYPE_FAT512.TabIndex = 7;
            this.IDRB_MSGTYPE_FAT512.Text = "Fat (512b)";
            this.IDRB_MSGTYPE_FAT512.UseVisualStyleBackColor = true;
            this.IDRB_MSGTYPE_FAT512.CheckedChanged += new System.EventHandler(this.IDRB_MSGTYPE_FAT512_CheckedChanged);
            // 
            // IDRB_MSGTYPE_MINIMAL
            // 
            this.IDRB_MSGTYPE_MINIMAL.AutoSize = true;
            this.IDRB_MSGTYPE_MINIMAL.Checked = true;
            this.IDRB_MSGTYPE_MINIMAL.Location = new System.Drawing.Point(7, 20);
            this.IDRB_MSGTYPE_MINIMAL.Name = "IDRB_MSGTYPE_MINIMAL";
            this.IDRB_MSGTYPE_MINIMAL.Size = new System.Drawing.Size(60, 17);
            this.IDRB_MSGTYPE_MINIMAL.TabIndex = 6;
            this.IDRB_MSGTYPE_MINIMAL.TabStop = true;
            this.IDRB_MSGTYPE_MINIMAL.Text = "Minimal";
            this.IDRB_MSGTYPE_MINIMAL.UseVisualStyleBackColor = true;
            this.IDRB_MSGTYPE_MINIMAL.CheckedChanged += new System.EventHandler(this.IDRB_MSGTYPE_MINIMAL_CheckedChanged);
            // 
            // GB_LOADPROFILE
            // 
            this.GB_LOADPROFILE.Controls.Add(this.IDRB_LPTYPE_BOOST);
            this.GB_LOADPROFILE.Controls.Add(this.IDRB_LPTYPE_STEADY);
            this.GB_LOADPROFILE.Location = new System.Drawing.Point(12, 189);
            this.GB_LOADPROFILE.Name = "GB_LOADPROFILE";
            this.GB_LOADPROFILE.Size = new System.Drawing.Size(485, 63);
            this.GB_LOADPROFILE.TabIndex = 17;
            this.GB_LOADPROFILE.TabStop = false;
            this.GB_LOADPROFILE.Text = "Load profile";
            // 
            // IDRB_LPTYPE_BOOST
            // 
            this.IDRB_LPTYPE_BOOST.AutoSize = true;
            this.IDRB_LPTYPE_BOOST.Location = new System.Drawing.Point(112, 28);
            this.IDRB_LPTYPE_BOOST.Name = "IDRB_LPTYPE_BOOST";
            this.IDRB_LPTYPE_BOOST.Size = new System.Drawing.Size(65, 17);
            this.IDRB_LPTYPE_BOOST.TabIndex = 1;
            this.IDRB_LPTYPE_BOOST.Text = "BOOST!";
            this.IDRB_LPTYPE_BOOST.UseVisualStyleBackColor = true;
            this.IDRB_LPTYPE_BOOST.CheckedChanged += new System.EventHandler(this.IDRB_LPTYPE_BOOST_CheckedChanged);
            // 
            // IDRB_LPTYPE_STEADY
            // 
            this.IDRB_LPTYPE_STEADY.AutoSize = true;
            this.IDRB_LPTYPE_STEADY.Checked = true;
            this.IDRB_LPTYPE_STEADY.Location = new System.Drawing.Point(6, 28);
            this.IDRB_LPTYPE_STEADY.Name = "IDRB_LPTYPE_STEADY";
            this.IDRB_LPTYPE_STEADY.Size = new System.Drawing.Size(58, 17);
            this.IDRB_LPTYPE_STEADY.TabIndex = 0;
            this.IDRB_LPTYPE_STEADY.TabStop = true;
            this.IDRB_LPTYPE_STEADY.Text = "Steady";
            this.IDRB_LPTYPE_STEADY.UseVisualStyleBackColor = true;
            this.IDRB_LPTYPE_STEADY.CheckedChanged += new System.EventHandler(this.IDRB_LPTYPE_STEADY_CheckedChanged);
            // 
            // GB_STEADY_SETTINGS
            // 
            this.GB_STEADY_SETTINGS.Controls.Add(this.IDT_TIMECOUNT);
            this.GB_STEADY_SETTINGS.Controls.Add(this.IDRB_STEADYLIMIT_TIME);
            this.GB_STEADY_SETTINGS.Controls.Add(this.IDRB_STEADYLIMIT_CHAT);
            this.GB_STEADY_SETTINGS.Controls.Add(this.IDT_CHATCOUNT);
            this.GB_STEADY_SETTINGS.Controls.Add(this.lblDelay);
            this.GB_STEADY_SETTINGS.Controls.Add(this.IDT_DELAY);
            this.GB_STEADY_SETTINGS.Controls.Add(this.lblSteadySettingsHint);
            this.GB_STEADY_SETTINGS.Location = new System.Drawing.Point(12, 259);
            this.GB_STEADY_SETTINGS.Name = "GB_STEADY_SETTINGS";
            this.GB_STEADY_SETTINGS.Size = new System.Drawing.Size(485, 103);
            this.GB_STEADY_SETTINGS.TabIndex = 18;
            this.GB_STEADY_SETTINGS.TabStop = false;
            this.GB_STEADY_SETTINGS.Text = "Steady load settings";
            // 
            // IDT_TIMECOUNT
            // 
            this.IDT_TIMECOUNT.AccessibleName = "id_txt_chat_count";
            this.IDT_TIMECOUNT.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.IDT_TIMECOUNT.Enabled = false;
            this.IDT_TIMECOUNT.Location = new System.Drawing.Point(123, 47);
            this.IDT_TIMECOUNT.Name = "IDT_TIMECOUNT";
            this.IDT_TIMECOUNT.Size = new System.Drawing.Size(157, 20);
            this.IDT_TIMECOUNT.TabIndex = 12;
            this.IDT_TIMECOUNT.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IDT_TIMECOUNT_KeyPress);
            // 
            // IDRB_STEADYLIMIT_TIME
            // 
            this.IDRB_STEADYLIMIT_TIME.AutoSize = true;
            this.IDRB_STEADYLIMIT_TIME.Location = new System.Drawing.Point(6, 48);
            this.IDRB_STEADYLIMIT_TIME.Name = "IDRB_STEADYLIMIT_TIME";
            this.IDRB_STEADYLIMIT_TIME.Size = new System.Drawing.Size(104, 17);
            this.IDRB_STEADYLIMIT_TIME.TabIndex = 11;
            this.IDRB_STEADYLIMIT_TIME.Text = "Limit by time (ms)";
            this.IDRB_STEADYLIMIT_TIME.UseVisualStyleBackColor = true;
            this.IDRB_STEADYLIMIT_TIME.CheckedChanged += new System.EventHandler(this.IDRB_STEADYLIMIT_TIME_CheckedChanged);
            // 
            // IDRB_STEADYLIMIT_CHAT
            // 
            this.IDRB_STEADYLIMIT_CHAT.AutoSize = true;
            this.IDRB_STEADYLIMIT_CHAT.Checked = true;
            this.IDRB_STEADYLIMIT_CHAT.Location = new System.Drawing.Point(6, 25);
            this.IDRB_STEADYLIMIT_CHAT.Name = "IDRB_STEADYLIMIT_CHAT";
            this.IDRB_STEADYLIMIT_CHAT.Size = new System.Drawing.Size(111, 17);
            this.IDRB_STEADYLIMIT_CHAT.TabIndex = 10;
            this.IDRB_STEADYLIMIT_CHAT.TabStop = true;
            this.IDRB_STEADYLIMIT_CHAT.Text = "Limit by # of chats";
            this.IDRB_STEADYLIMIT_CHAT.UseVisualStyleBackColor = true;
            this.IDRB_STEADYLIMIT_CHAT.CheckedChanged += new System.EventHandler(this.IDRB_STEADYLIMIT_CHAT_CheckedChanged);
            // 
            // GB_BOOST_SETTINGS
            // 
            this.GB_BOOST_SETTINGS.Controls.Add(this.lblBoostSettingsHint);
            this.GB_BOOST_SETTINGS.Controls.Add(this.lblBoostLifetime);
            this.GB_BOOST_SETTINGS.Controls.Add(this.IDT_BOOST_LIFETIME);
            this.GB_BOOST_SETTINGS.Controls.Add(this.lblBoostFinish);
            this.GB_BOOST_SETTINGS.Controls.Add(this.IDT_BOOST_FINISH);
            this.GB_BOOST_SETTINGS.Controls.Add(this.lblBoostStart);
            this.GB_BOOST_SETTINGS.Controls.Add(this.IDT_BOOST_START);
            this.GB_BOOST_SETTINGS.Enabled = false;
            this.GB_BOOST_SETTINGS.Location = new System.Drawing.Point(12, 368);
            this.GB_BOOST_SETTINGS.Name = "GB_BOOST_SETTINGS";
            this.GB_BOOST_SETTINGS.Size = new System.Drawing.Size(485, 104);
            this.GB_BOOST_SETTINGS.TabIndex = 2;
            this.GB_BOOST_SETTINGS.TabStop = false;
            this.GB_BOOST_SETTINGS.Text = "BOOST settings";
            // 
            // lblBoostSettingsHint
            // 
            this.lblBoostSettingsHint.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBoostSettingsHint.Location = new System.Drawing.Point(286, 19);
            this.lblBoostSettingsHint.Name = "lblBoostSettingsHint";
            this.lblBoostSettingsHint.Size = new System.Drawing.Size(193, 72);
            this.lblBoostSettingsHint.TabIndex = 13;
            this.lblBoostSettingsHint.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblBoostLifetime
            // 
            this.lblBoostLifetime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBoostLifetime.Location = new System.Drawing.Point(9, 69);
            this.lblBoostLifetime.Name = "lblBoostLifetime";
            this.lblBoostLifetime.Size = new System.Drawing.Size(108, 23);
            this.lblBoostLifetime.TabIndex = 18;
            this.lblBoostLifetime.Text = "Boost duration (ms):";
            this.lblBoostLifetime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // IDT_BOOST_LIFETIME
            // 
            this.IDT_BOOST_LIFETIME.AccessibleName = "id_txt_site_id";
            this.IDT_BOOST_LIFETIME.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.IDT_BOOST_LIFETIME.Location = new System.Drawing.Point(123, 71);
            this.IDT_BOOST_LIFETIME.Name = "IDT_BOOST_LIFETIME";
            this.IDT_BOOST_LIFETIME.Size = new System.Drawing.Size(157, 20);
            this.IDT_BOOST_LIFETIME.TabIndex = 17;
            this.IDT_BOOST_LIFETIME.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IDT_BOOST_LIFETIME_KeyPress);
            // 
            // lblBoostFinish
            // 
            this.lblBoostFinish.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBoostFinish.Location = new System.Drawing.Point(9, 43);
            this.lblBoostFinish.Name = "lblBoostFinish";
            this.lblBoostFinish.Size = new System.Drawing.Size(108, 23);
            this.lblBoostFinish.TabIndex = 16;
            this.lblBoostFinish.Text = "Boost delay to (ms):";
            this.lblBoostFinish.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // IDT_BOOST_FINISH
            // 
            this.IDT_BOOST_FINISH.AccessibleName = "id_txt_site_id";
            this.IDT_BOOST_FINISH.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.IDT_BOOST_FINISH.Location = new System.Drawing.Point(123, 45);
            this.IDT_BOOST_FINISH.Name = "IDT_BOOST_FINISH";
            this.IDT_BOOST_FINISH.Size = new System.Drawing.Size(157, 20);
            this.IDT_BOOST_FINISH.TabIndex = 15;
            this.IDT_BOOST_FINISH.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IDT_BOOST_FINISH_KeyPress);
            // 
            // lblBoostStart
            // 
            this.lblBoostStart.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBoostStart.Location = new System.Drawing.Point(9, 17);
            this.lblBoostStart.Name = "lblBoostStart";
            this.lblBoostStart.Size = new System.Drawing.Size(108, 23);
            this.lblBoostStart.TabIndex = 14;
            this.lblBoostStart.Text = "Initial delay (ms):";
            this.lblBoostStart.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // IDT_BOOST_START
            // 
            this.IDT_BOOST_START.AccessibleName = "id_txt_site_id";
            this.IDT_BOOST_START.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.IDT_BOOST_START.Location = new System.Drawing.Point(123, 19);
            this.IDT_BOOST_START.Name = "IDT_BOOST_START";
            this.IDT_BOOST_START.Size = new System.Drawing.Size(157, 20);
            this.IDT_BOOST_START.TabIndex = 13;
            this.IDT_BOOST_START.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IDT_BOOST_START_KeyPress);
            // 
            // GB_COMMON_SETTINGS
            // 
            this.GB_COMMON_SETTINGS.Controls.Add(this.IDT_WIDGETTITLE);
            this.GB_COMMON_SETTINGS.Controls.Add(this.lblWidgetTitle);
            this.GB_COMMON_SETTINGS.Controls.Add(this.lblSite);
            this.GB_COMMON_SETTINGS.Controls.Add(this.IDT_SITEID);
            this.GB_COMMON_SETTINGS.Controls.Add(this.IDCB_THREADING);
            this.GB_COMMON_SETTINGS.Controls.Add(this.IDCB_FORCECLOSE);
            this.GB_COMMON_SETTINGS.Controls.Add(this.lblCommonSettingsHint);
            this.GB_COMMON_SETTINGS.Location = new System.Drawing.Point(12, 74);
            this.GB_COMMON_SETTINGS.Name = "GB_COMMON_SETTINGS";
            this.GB_COMMON_SETTINGS.Size = new System.Drawing.Size(485, 109);
            this.GB_COMMON_SETTINGS.TabIndex = 19;
            this.GB_COMMON_SETTINGS.TabStop = false;
            this.GB_COMMON_SETTINGS.Text = "Common settings";
            // 
            // lblWidgetTitle
            // 
            this.lblWidgetTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblWidgetTitle.Location = new System.Drawing.Point(9, 46);
            this.lblWidgetTitle.Name = "lblWidgetTitle";
            this.lblWidgetTitle.Size = new System.Drawing.Size(108, 23);
            this.lblWidgetTitle.TabIndex = 9;
            this.lblWidgetTitle.Text = "Widget title:";
            this.lblWidgetTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // IDT_WIDGETTITLE
            // 
            this.IDT_WIDGETTITLE.AccessibleName = "id_txt_site_id";
            this.IDT_WIDGETTITLE.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.IDT_WIDGETTITLE.Location = new System.Drawing.Point(123, 48);
            this.IDT_WIDGETTITLE.Name = "IDT_WIDGETTITLE";
            this.IDT_WIDGETTITLE.Size = new System.Drawing.Size(157, 20);
            this.IDT_WIDGETTITLE.TabIndex = 10;
            // 
            // ChatVolumizer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1063, 605);
            this.Controls.Add(this.GB_COMMON_SETTINGS);
            this.Controls.Add(this.GB_BOOST_SETTINGS);
            this.Controls.Add(this.GB_STEADY_SETTINGS);
            this.Controls.Add(this.GB_LOADPROFILE);
            this.Controls.Add(this.GB_MSG_TYPE);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.IDB_STOP);
            this.Controls.Add(this.IDB_START);
            this.Name = "ChatVolumizer";
            this.Text = "Chat volumizer";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.GB_MSG_TYPE.ResumeLayout(false);
            this.GB_MSG_TYPE.PerformLayout();
            this.GB_LOADPROFILE.ResumeLayout(false);
            this.GB_LOADPROFILE.PerformLayout();
            this.GB_STEADY_SETTINGS.ResumeLayout(false);
            this.GB_STEADY_SETTINGS.PerformLayout();
            this.GB_BOOST_SETTINGS.ResumeLayout(false);
            this.GB_BOOST_SETTINGS.PerformLayout();
            this.GB_COMMON_SETTINGS.ResumeLayout(false);
            this.GB_COMMON_SETTINGS.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox IDT_CHATCOUNT;
        private System.Windows.Forms.Button IDB_START;
        private System.Windows.Forms.Label lblSteadySettingsHint;
        private System.Windows.Forms.Button IDB_STOP;
        private System.Windows.Forms.Label lblSite;
        private System.Windows.Forms.TextBox IDT_SITEID;
        private System.Windows.Forms.CheckBox IDCB_THREADING;
        private System.Windows.Forms.Label lblCommonSettingsHint;
        private System.Windows.Forms.Label lblDelay;
        private System.Windows.Forms.TextBox IDT_DELAY;
        private System.Windows.Forms.Label lblVolumeCount;
        private System.Windows.Forms.TextBox IDT_VOLUMECOUNT;
        private System.Windows.Forms.CheckBox IDCB_FORCECLOSE;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox IDT_LOG;
        private System.Windows.Forms.Button IDB_SAVELOG;
        private System.Windows.Forms.GroupBox GB_MSG_TYPE;
        private System.Windows.Forms.RadioButton IDRB_MSGTYPE_FAT512;
        private System.Windows.Forms.RadioButton IDRB_MSGTYPE_MINIMAL;
        private System.Windows.Forms.GroupBox GB_LOADPROFILE;
        private System.Windows.Forms.RadioButton IDRB_LPTYPE_BOOST;
        private System.Windows.Forms.RadioButton IDRB_LPTYPE_STEADY;
        private System.Windows.Forms.GroupBox GB_STEADY_SETTINGS;
        private System.Windows.Forms.GroupBox GB_BOOST_SETTINGS;
        private System.Windows.Forms.RadioButton IDRB_MSGTYPE_XTRAFAT1KB;
        private System.Windows.Forms.TextBox IDT_TIMECOUNT;
        private System.Windows.Forms.RadioButton IDRB_STEADYLIMIT_TIME;
        private System.Windows.Forms.RadioButton IDRB_STEADYLIMIT_CHAT;
        private System.Windows.Forms.GroupBox GB_COMMON_SETTINGS;
        private System.Windows.Forms.Label lblBoostSettingsHint;
        private System.Windows.Forms.Label lblBoostLifetime;
        private System.Windows.Forms.TextBox IDT_BOOST_LIFETIME;
        private System.Windows.Forms.Label lblBoostFinish;
        private System.Windows.Forms.TextBox IDT_BOOST_FINISH;
        private System.Windows.Forms.Label lblBoostStart;
        private System.Windows.Forms.TextBox IDT_BOOST_START;
        private System.Windows.Forms.TextBox IDT_WIDGETTITLE;
        private System.Windows.Forms.Label lblWidgetTitle;
    }
}

