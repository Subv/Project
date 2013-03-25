using System;
using System.Collections.Generic;

namespace BitbucketHandler
{
    public partial class IssueComments : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        public IssueComments()
        {
            InitializeComponent();
        }

        //private List<HtmlNode> _comments;
        private int curIndex;
        private int _id;
        Issue issue;
        private void IssueComments_Load(object sender, EventArgs e)
        {
            API.AddIssueCommentsForm(this);
        }

        /*public async void SetData(int id, List<HtmlNode> comments)
        {
            /*_id = id;
            issue = await API.GetIssue(id);
            while (issue.Title == null)
            {
                // Loop to wait until the issue has been loaded
            }
            _comments = comments;
            if (comments.Count >= 1)
            {
                curComment.Text = comments[0].InnerText.Trim();
                curIndex = 0;
            }
            this.Text = "Comments of issue "+issue.Title+" ("+_id+")";
            if (issue.Reporter != null && issue.Reporter.Username != null)
                reporter.Text = issue.Reporter.Username;
            else
                kryptonLabel1.Text = "";
            curI.Text = (curIndex + 1).ToString() + "/" + (_comments.Count).ToString();
        }*/

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            /*try
            {
                if (!(curIndex - 1 > 0))
                    kryptonButton2.Enabled = false;
                else
                    kryptonButton1.Enabled = true;
                if (!(curIndex > 0))
                    return;
                --curIndex;
                curComment.Text = _comments[curIndex].InnerText.Trim();
                curI.Text = (curIndex+1).ToString()+"/"+(_comments.Count).ToString();
            }
            catch(ArgumentOutOfRangeException)
            {
            }*/
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            /*try
            {
                if (!(curIndex + 2 < _comments.Count))
                    kryptonButton1.Enabled = false;
                else
                    kryptonButton2.Enabled = true;
                if (!(curIndex < _comments.Count))
                    return;
                ++curIndex;
                curComment.Text = _comments[curIndex].InnerText.Trim();
                curI.Text = (curIndex + 1).ToString() + "/" + (_comments.Count).ToString();
            }
            catch (ArgumentOutOfRangeException)
            {
            }*/
        }

    }
}