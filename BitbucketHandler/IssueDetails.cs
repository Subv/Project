using System;
using System.Collections.Generic;
using ComponentFactory.Krypton.Toolkit;
//using HtmlAgilityPack;

namespace BitbucketHandler
{
    public partial class IssueDetails : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        public Issue issue;
        public List<ComponentFactory.Krypton.Toolkit.KryptonCheckBox> boxes = new List<ComponentFactory.Krypton.Toolkit.KryptonCheckBox>();
        public void AddCheckBoxes()
        {
            List<string> iLabels = API.GetAllLabels();
            int y = 0;
            int x = 0;
            for (int i = 0; i < iLabels.Count; ++i)
            {
                var box = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
                box.Text = iLabels[i];
                box.Values.Text = iLabels[i];

                box.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl;
                box.Location = new System.Drawing.Point(455 - y, 85 + ((x * 20) - 1));
                box.Name = "kryptonCheckBox" + i;
                box.Size = new System.Drawing.Size(125, 20);
                box.TabIndex = 14;
                foreach (var l in issue.Labels)
                    if (l.Name == box.Text)
                        box.Checked = true;
                ++x;
                if ((x % 12) == 0)
                {
                    y += 186;
                    x = 0;
                }
                Controls.Add(box);
                boxes.Add(box);
            }
        }

        public void Init()
        {
            AddCheckBoxes();
            this.Text = "Details of issue " + issue.Number.ToString();
            title.Text = issue.Title;
            content.Text = issue.Body;
            asignee.Text = issue.Asignee != null ? issue.Asignee.Login : "None";
            status.SelectedItem = issue.State;
            _id.Text = issue.Number.ToString();
        }

        public IssueDetails(Issue _issue)
        {
            issue = _issue;
            InitializeComponent();
            Init();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int _id = int.Parse(this._id.Text);
                string _title = title.Text;
                string _content = content.Text;
                string _asignee = asignee.Text;
                object _status = status.SelectedItem;
                if (_status == null)
                    _status = "";
                List<string> labels = new List<string>();
                foreach (var b in boxes)
                    if (b.Checked)
                        labels.Add(b.Text);
                API.UpdateIssue(_id, _title, _content, _asignee, _status.ToString(), labels);
            }
            catch
            {
                KryptonMessageBox.Show("An error occurred while updating the issue, please fill all the fields");
            }
        }

        private void IssueDetails_Load(object sender, EventArgs e)
        {
            API.AddIssueDetailsForm(this);
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            /*List<HtmlNode> lst = await API.GetAllComments(int.Parse(id.Text));
            if (lst.Count <= 0)
            {
                KryptonMessageBox.Show("This issue does not have any comment");
                return;
            }
            IssueComments frm = new IssueComments();
            if (frm != null)
            {
                frm.SetData(int.Parse(id.Text),lst);
                frm.Show(this);
            }*/
        }

        private void _id_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) ||
                char.IsSymbol(e.KeyChar) ||
                char.IsWhiteSpace(e.KeyChar) ||
                char.IsPunctuation(e.KeyChar))
                e.Handled = true;
        }

        private async void _id_TextChanged(object sender, EventArgs e)
        {
            /*issue = await API.GetIssue(int.Parse(_id.Text));
            foreach (var b in boxes)
                this.Controls.Remove(b);
            Init();*/
        }
    }
}
