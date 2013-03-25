using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using System.Collections.Generic;

namespace BitbucketHandler
{
    public partial class Form1 : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }
        
        

        private void Form1_Load(object sender, EventArgs e)
        {
            API.AddForm1(this);
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var x = await API.IsInternetConnected();
            if (!x)
            {
                KryptonMessageBox.Show("Could not connect to the internet, please make sure you have a working connection");
                return;
            }
            button1.Enabled = false;
            textBox1.Enabled = false;
            button2.Enabled = false;
            issues.Rows.Clear();
            int limit = 25;
            if (!textBox1.Text.Equals(""))
                limit = int.Parse(textBox1.Text);
            /*if (limit > await API.GetTotalIssues())
                limit = await API.GetTotalIssues();*/
            var _issues = await API.GetAllIssues(limit);
            API.SetIssues(_issues);
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            Issue issue = await API.GetIssue(int.Parse(issues.SelectedRows[0].Cells[0].Value.ToString()));
            if (issue == null)
                return;
            IssueDetails issueDetailsForm = new IssueDetails(issue);
            issueDetailsForm.Show();
            issue = null;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) ||
                char.IsSymbol(e.KeyChar) ||
                char.IsWhiteSpace(e.KeyChar) ||
                char.IsPunctuation(e.KeyChar))
                e.Handled = true;
        }

        private void issues_SelectionChanged(object sender, EventArgs e)
        {
            if (issues.SelectedRows.Count >= 1)
                button2.Enabled = true;
        }
    }
}
