namespace BitbucketHandler
{
    using ComponentFactory.Krypton;
    using System.Collections.Generic;
    partial class IssueDetails
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
        private async void InitializeComponent()
        {
            this.content = new ComponentFactory.Krypton.Toolkit.KryptonRichTextBox();
            this.button1 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.status = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.button2 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.asignee = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this._id = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.title = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.status)).BeginInit();
            this.SuspendLayout();
            // 
            // content
            // 
            this.content.Location = new System.Drawing.Point(27, 85);
            this.content.Name = "content";
            this.content.Size = new System.Drawing.Size(241, 208);
            this.content.TabIndex = 1;
            this.content.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(470, 42);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(110, 25);
            this.button1.TabIndex = 4;
            this.button1.Values.Text = "Update";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // status
            // 
            this.status.AutoCompleteCustomSource.AddRange(new string[] {
            "open",
            "closed"});
            this.status.DropDownWidth = 165;
            this.status.FormattingEnabled = true;
            this.status.Items.AddRange(new object[] {
            "new",
            "invalid",
            "on hold",
            "resolved",
            "duplicated",
            "open"});
            this.status.Location = new System.Drawing.Point(331, 15);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(165, 21);
            this.status.TabIndex = 6;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(274, 51);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(54, 25);
            this.button2.TabIndex = 11;
            this.button2.Values.Text = "View Comments";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // asignee
            // 
            this.asignee.Location = new System.Drawing.Point(141, 40);
            this.asignee.Name = "asignee";
            this.asignee.Size = new System.Drawing.Size(127, 20);
            this.asignee.TabIndex = 12;
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(27, 40);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(75, 20);
            this.kryptonLabel1.TabIndex = 13;
            this.kryptonLabel1.Values.Text = "Asigned To:";
            // 
            // _id
            // 
            this._id.Location = new System.Drawing.Point(353, 46);
            this._id.Name = "_id";
            this._id.Size = new System.Drawing.Size(93, 20);
            this._id.TabIndex = 14;
            this._id.TextChanged += new System.EventHandler(this._id_TextChanged);
            // 
            // title
            // 
            this.title.Location = new System.Drawing.Point(31, 8);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(236, 20);
            this.title.TabIndex = 15;
            // 
            // IssueDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 333);
            this.Controls.Add(this.title);
            this.Controls.Add(this._id);
            this.Controls.Add(this.kryptonLabel1);
            this.Controls.Add(this.asignee);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.status);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.content);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "IssueDetails";
            this.Text = "Details";
            this.Load += new System.EventHandler(this.IssueDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.status)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonRichTextBox content;
        private ComponentFactory.Krypton.Toolkit.KryptonButton button1;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox status;
        private ComponentFactory.Krypton.Toolkit.KryptonButton button2;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox asignee;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox _id;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox title;

    }
}