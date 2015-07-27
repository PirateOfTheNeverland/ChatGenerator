namespace ChatGenerator
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
            this.label1 = new System.Windows.Forms.Label();
            this.IDB_START = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // IDT_CHATCOUNT
            // 
            this.IDT_CHATCOUNT.AccessibleName = "id_txt_chatcount";
            this.IDT_CHATCOUNT.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.IDT_CHATCOUNT.Location = new System.Drawing.Point(177, 12);
            this.IDT_CHATCOUNT.Name = "IDT_CHATCOUNT";
            this.IDT_CHATCOUNT.Size = new System.Drawing.Size(77, 20);
            this.IDT_CHATCOUNT.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Location = new System.Drawing.Point(5, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Number of concurrent chats:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // IDB_START
            // 
            this.IDB_START.Location = new System.Drawing.Point(283, 10);
            this.IDB_START.Name = "IDB_START";
            this.IDB_START.Size = new System.Drawing.Size(75, 23);
            this.IDB_START.TabIndex = 2;
            this.IDB_START.Text = "Rock on!";
            this.IDB_START.UseVisualStyleBackColor = true;
            this.IDB_START.Click += new System.EventHandler(this.IDB_START_Click);
            // 
            // ChatVolumizer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 43);
            this.Controls.Add(this.IDB_START);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.IDT_CHATCOUNT);
            this.Name = "ChatVolumizer";
            this.Text = "ChatVolumizer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox IDT_CHATCOUNT;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button IDB_START;
    }
}