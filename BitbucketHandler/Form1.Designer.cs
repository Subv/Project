namespace BitbucketHandler
{
    using ComponentFactory.Krypton.Toolkit;
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button1 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kryptonDataGridViewTextBoxColumn8 = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.kryptonDataGridViewTextBoxColumn9 = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kryptonDataGridViewTextBoxColumn10 = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button2 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.textBox1 = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.label1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonManager1 = new ComponentFactory.Krypton.Toolkit.KryptonManager(this.components);
            this.settings = new System.Windows.Forms.TabPage();
            this.password = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.label3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.username = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.label2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.issues = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.Id = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.Title = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.User = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.State = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Asignee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Comments = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Labels = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kryptonDataGridViewTextBoxColumn7 = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kryptonDataGridViewTextBoxColumn6 = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.kryptonDataGridViewTextBoxColumn5 = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kryptonDataGridViewTextBoxColumn4 = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kryptonDataGridViewTextBoxColumn3 = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.kryptonDataGridViewTextBoxColumn2 = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.Reporter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kryptonDataGridViewTextBoxColumn1 = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.settings.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.issues)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.Location = new System.Drawing.Point(18, 294);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 30);
            this.button1.TabIndex = 1;
            this.button1.Values.Text = "Get Issues";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // kryptonDataGridViewTextBoxColumn8
            // 
            this.kryptonDataGridViewTextBoxColumn8.HeaderText = "Id";
            this.kryptonDataGridViewTextBoxColumn8.Name = "kryptonDataGridViewTextBoxColumn8";
            this.kryptonDataGridViewTextBoxColumn8.ReadOnly = true;
            this.kryptonDataGridViewTextBoxColumn8.Width = 100;
            // 
            // kryptonDataGridViewTextBoxColumn9
            // 
            this.kryptonDataGridViewTextBoxColumn9.HeaderText = "Title";
            this.kryptonDataGridViewTextBoxColumn9.Name = "kryptonDataGridViewTextBoxColumn9";
            this.kryptonDataGridViewTextBoxColumn9.Width = 100;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "Number of Comments";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // kryptonDataGridViewTextBoxColumn10
            // 
            this.kryptonDataGridViewTextBoxColumn10.HeaderText = "Status";
            this.kryptonDataGridViewTextBoxColumn10.Name = "kryptonDataGridViewTextBoxColumn10";
            this.kryptonDataGridViewTextBoxColumn10.Width = 100;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.HeaderText = "Reporter";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(166, 294);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(144, 30);
            this.button2.TabIndex = 3;
            this.button2.Values.Text = "Details";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(495, 301);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(67, 20);
            this.textBox1.TabIndex = 4;
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.ItalicPanel;
            this.label1.Location = new System.Drawing.Point(448, 300);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 20);
            this.label1.TabIndex = 5;
            this.label1.Values.Text = "Limit:";
            // 
            // settings
            // 
            this.settings.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.settings.Controls.Add(this.password);
            this.settings.Controls.Add(this.label3);
            this.settings.Controls.Add(this.username);
            this.settings.Controls.Add(this.label2);
            this.settings.Location = new System.Drawing.Point(4, 22);
            this.settings.Name = "settings";
            this.settings.Size = new System.Drawing.Size(497, 258);
            this.settings.TabIndex = 2;
            this.settings.Text = "Settings";
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(103, 54);
            this.password.Name = "password";
            this.password.PasswordChar = '●';
            this.password.Size = new System.Drawing.Size(117, 20);
            this.password.TabIndex = 3;
            this.password.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Red;
            this.label3.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.label3.Location = new System.Drawing.Point(24, 53);
            this.label3.Name = "label3";
            this.label3.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Black;
            this.label3.Size = new System.Drawing.Size(69, 20);
            this.label3.TabIndex = 2;
            this.label3.Values.Text = "Password:";
            // 
            // username
            // 
            this.username.Location = new System.Drawing.Point(102, 12);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(119, 20);
            this.username.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.label2.Location = new System.Drawing.Point(21, 11);
            this.label2.Name = "label2";
            this.label2.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Black;
            this.label2.Size = new System.Drawing.Size(72, 20);
            this.label2.TabIndex = 0;
            this.label2.Values.Text = "Username:";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.issues);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(537, 258);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Spell Issues";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // issues
            // 
            this.issues.AllowUserToAddRows = false;
            this.issues.AllowUserToDeleteRows = false;
            this.issues.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.issues.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Title,
            this.User,
            this.State,
            this.Asignee,
            this.Comments,
            this.Labels});
            this.issues.Location = new System.Drawing.Point(-4, 0);
            this.issues.MultiSelect = false;
            this.issues.Name = "issues";
            this.issues.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.issues.Size = new System.Drawing.Size(541, 262);
            this.issues.TabIndex = 2;
            this.issues.SelectionChanged += new System.EventHandler(issues_SelectionChanged);
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Width = 100;
            // 
            // Title
            // 
            this.Title.HeaderText = "Title";
            this.Title.Name = "Title";
            this.Title.ReadOnly = true;
            this.Title.Width = 100;
            // 
            // User
            // 
            this.User.HeaderText = "User";
            this.User.Name = "User";
            this.User.ReadOnly = true;
            // 
            // State
            // 
            this.State.HeaderText = "State";
            this.State.Name = "State";
            this.State.ReadOnly = true;
            // 
            // Asignee
            // 
            this.Asignee.HeaderText = "Asignee";
            this.Asignee.Name = "Asignee";
            this.Asignee.ReadOnly = true;
            // 
            // Comments
            // 
            this.Comments.HeaderText = "comments";
            this.Comments.Name = "Comments";
            this.Comments.ReadOnly = true;
            // 
            // Labels
            // 
            this.Labels.HeaderText = "Labels";
            this.Labels.Name = "Labels";
            this.Labels.ReadOnly = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.settings);
            this.tabControl1.Location = new System.Drawing.Point(18, 8);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(545, 284);
            this.tabControl1.TabIndex = 2;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.HeaderText = "Reporter";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            // 
            // kryptonDataGridViewTextBoxColumn7
            // 
            this.kryptonDataGridViewTextBoxColumn7.HeaderText = "Status";
            this.kryptonDataGridViewTextBoxColumn7.Name = "kryptonDataGridViewTextBoxColumn7";
            this.kryptonDataGridViewTextBoxColumn7.Width = 100;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Number of Comments";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // kryptonDataGridViewTextBoxColumn6
            // 
            this.kryptonDataGridViewTextBoxColumn6.HeaderText = "Title";
            this.kryptonDataGridViewTextBoxColumn6.Name = "kryptonDataGridViewTextBoxColumn6";
            this.kryptonDataGridViewTextBoxColumn6.Width = 100;
            // 
            // kryptonDataGridViewTextBoxColumn5
            // 
            this.kryptonDataGridViewTextBoxColumn5.HeaderText = "Id";
            this.kryptonDataGridViewTextBoxColumn5.Name = "kryptonDataGridViewTextBoxColumn5";
            this.kryptonDataGridViewTextBoxColumn5.ReadOnly = true;
            this.kryptonDataGridViewTextBoxColumn5.Width = 100;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.HeaderText = "Reporter";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            // 
            // kryptonDataGridViewTextBoxColumn4
            // 
            this.kryptonDataGridViewTextBoxColumn4.HeaderText = "Status";
            this.kryptonDataGridViewTextBoxColumn4.Name = "kryptonDataGridViewTextBoxColumn4";
            this.kryptonDataGridViewTextBoxColumn4.Width = 100;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Number of Comments";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // kryptonDataGridViewTextBoxColumn3
            // 
            this.kryptonDataGridViewTextBoxColumn3.HeaderText = "Title";
            this.kryptonDataGridViewTextBoxColumn3.Name = "kryptonDataGridViewTextBoxColumn3";
            this.kryptonDataGridViewTextBoxColumn3.Width = 100;
            // 
            // kryptonDataGridViewTextBoxColumn2
            // 
            this.kryptonDataGridViewTextBoxColumn2.HeaderText = "Id";
            this.kryptonDataGridViewTextBoxColumn2.Name = "kryptonDataGridViewTextBoxColumn2";
            this.kryptonDataGridViewTextBoxColumn2.ReadOnly = true;
            this.kryptonDataGridViewTextBoxColumn2.Width = 100;
            // 
            // Reporter
            // 
            this.Reporter.HeaderText = "Reporter";
            this.Reporter.Name = "Reporter";
            // 
            // kryptonDataGridViewTextBoxColumn1
            // 
            this.kryptonDataGridViewTextBoxColumn1.HeaderText = "Status";
            this.kryptonDataGridViewTextBoxColumn1.Name = "kryptonDataGridViewTextBoxColumn1";
            this.kryptonDataGridViewTextBoxColumn1.Width = 100;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Number of Comments";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Title";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 100;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Id";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 100;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 331);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Issue list";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.settings.ResumeLayout(false);
            this.settings.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.issues)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonButton button2;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel label1;
        public KryptonTextBox textBox1;
        public KryptonButton button1;
        private KryptonManager kryptonManager1;
        public KryptonDataGridView noLabelIssues;
        private KryptonDataGridViewTextBoxColumn kryptonDataGridViewTextBoxColumn8;
        private KryptonDataGridViewTextBoxColumn kryptonDataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private KryptonDataGridViewTextBoxColumn kryptonDataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.TabPage settings;
        public KryptonTextBox password;
        private KryptonLabel label3;
        public KryptonTextBox username;
        private KryptonLabel label2;
        private System.Windows.Forms.TabPage tabPage1;
        public KryptonDataGridView issues;
        public System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private KryptonDataGridViewTextBoxColumn kryptonDataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private KryptonDataGridViewTextBoxColumn kryptonDataGridViewTextBoxColumn6;
        private KryptonDataGridViewTextBoxColumn kryptonDataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private KryptonDataGridViewTextBoxColumn kryptonDataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private KryptonDataGridViewTextBoxColumn kryptonDataGridViewTextBoxColumn3;
        private KryptonDataGridViewTextBoxColumn kryptonDataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Reporter;
        private KryptonDataGridViewTextBoxColumn kryptonDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private KryptonDataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private KryptonDataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private KryptonDataGridViewTextBoxColumn Id;
        private KryptonDataGridViewTextBoxColumn Title;
        private System.Windows.Forms.DataGridViewTextBoxColumn User;
        private System.Windows.Forms.DataGridViewTextBoxColumn State;
        private System.Windows.Forms.DataGridViewTextBoxColumn Asignee;
        private System.Windows.Forms.DataGridViewTextBoxColumn Comments;
        private System.Windows.Forms.DataGridViewTextBoxColumn Labels;
    }
}

