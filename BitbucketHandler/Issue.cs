using System;
using System.Threading;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using RestSharp;
using BitbucketHandler;

namespace BitbucketHandler
{
    public class Error
    {
        public string Resource;
        public string Field;
        public string Code;
    }

    public class IssueMetaData
    {
        public string Kind {get;set;}
        public string Version {get;set;}
        public string Component {get;set;}
        public string Milestone {get;set;}
        
        public IssueMetaData(string _kind, string _version, string _component, string _milestone)
        {
            _kind = _kind.Replace("\"", "");
            _version = _version.Replace("\"", "");
            _component = _component.Replace("\"", "");
            _milestone = _milestone.Replace("\"", "");
            Kind = _kind;
            Version = _version;
            Component = _component;
            Milestone = _milestone;
        }
    }
    
    /*public class Issue
    {
        public string Status { get; set; }
        public string Title { get; set; }
        public string Reported_by { get; set; }
        public string responsible { get; set; }
        public User Reporter { get; set; }
        public User _Responsible { get; set; }
        public int CommentCount { get; set; }
        public string Content { get; set; }
        public DateTime CreatedOn { get; set; }
        public int LocalId { get; set; }
        public string metadata { get; set; }
        public IssueMetaData _MetaData { get; set; }
        public string ResourceURI {get; set; }
        public bool IsSpam {get; set; }
        
        public Issue(string placeholder)
        {
            KryptonMessageBox.Show("Showing placeholder: "+placeholder,"Information");
        }

        public Issue()
        {
        }
    }*/
    
    
    
    public class Comment
    {
    }

    public class CommentList
    {
        public List<Comment> comments { get; set; }
    }

    public static class Extensions
    {
        public static bool ContainsCaseInsensitive(this string source, string value)
        {
            return string.Compare(source, value, true) == 0; //Ignoring cases

        }
    }
    
    public class API
    {
        public static IssueDetails issuedetailsform;
        public static Form1 frm1;
        public static bool cancel = false;
        public static List<Issue> Issues = null;

        public static async Task<string> Post_request(string url, string data, string method)
        {

            System.IO.StreamReader reader = default(System.IO.StreamReader);
            System.IO.StreamWriter writer = default(System.IO.StreamWriter);

            try
            {
                HttpWebRequest hwebrequest = (HttpWebRequest)WebRequest.Create(url);

                hwebrequest.Host = "bitbucket.org";
                
                hwebrequest.Method = method;

                hwebrequest.ContentType = "application/x-www-form-urlencoded";

                //hwebrequest.Credentials = new NetworkCredential("Subv", "sebas2112");

                //hwebrequest.ContentLength = data.Length;

                hwebrequest.Referer = url;

                /*writer = new System.IO.StreamWriter(hwebrequest.GetRequestStream());

                writer.Write(data);

                writer.Close();*/

                System.Net.WebResponse hwebresponse = await TaskEx.Run(() => hwebrequest.GetResponse());

                reader = new System.IO.StreamReader(hwebresponse.GetResponseStream());

                String r = reader.ReadToEnd();

                reader.Close();
                writer.Close();
                reader = null;
                writer = null;
                hwebrequest = null;
                hwebresponse = null;
                return r;
            }
            catch
            {

                try
                {
                    writer.Close();
                    reader.Close();
                    reader = null;
                    writer = null;
                }
                catch 
                {
                    reader = null;
                    writer = null;
                }
                return "";

            }
        }
        
        // Sync method
        public static Issue _GetIssue(int id)
        {
            foreach (var i in Issues)
                if (i.Number == id)
                    return i;
            return null;
        }
        // Async method
        public static async Task<Issue> GetIssue(int id)
        {
            return await TaskEx.Run(() => _GetIssue(id));
        }

        public static async Task<List<string>> _GetAllLabels()
        {
            List<string> _ret = new List<string>();
            RestClient client = new RestClient();
            // BB: https://api.bitbucket.org/1.0 GH: https://api.github.com
            client.BaseUrl = "https://api.github.com";
            client.Authenticator = new HttpBasicAuthenticator(GetForm1().username.Text, GetForm1().password.Text);

            var request = new RestRequest("/repos/TrinityCore/TrinityCore/labels");

            var response = await TaskEx.Run(() => client.Execute<List<Label>>(request));
            if (response.Data == null)
                return null;

            TaskEx.Run(() =>
            {
                foreach (var i in response.Data)
                    _ret.Add(i.Name);
            });
            
            return _ret;
        }
        public static List<string> _labels;
        public static List<string> GetAllLabels()
        {
            return _labels;
        }
        public static async Task<List<Issue>> Search(string searchstr)
        {
            List<Issue> _ret = new List<Issue>();
            await TaskEx.Run(() =>
            {
                foreach (var i in Issues)
                    if (i.Body.ContainsCaseInsensitive(searchstr) || i.Title.ContainsCaseInsensitive(searchstr))
                        _ret.Add(i);
            });
            return _ret;
        }
        
        public class UpdatedIssue
        {
            public string title { get; set; }
            public string body { get; set; }
            public string assignee { get; set; }
            public string state { get; set; }
            public List<string> labels { get; set; }
            public UpdatedIssue(string _title, string _body, string _assignee, string _state, List<string> _labels)
            {
                title = _title;
                body = _body;
                assignee = _assignee;
                state = _state;
                labels = _labels;
            }
        }

        public static async void UpdateIssue(int id, string title, string content, string responsible, string status, List<string> labels)
        {
            try
            {
                Issue i = await GetIssue(id);

                if (title.Trim().Equals(""))
                    title = i.Title;

                if (content.Trim().Equals(""))
                    content = i.Body;

                if (status.Trim().Equals(""))
                    status = i.State;

                title = title.Trim();
                content = content.Trim();
                status = status.Trim();

                var client = new RestClient();
                client.BaseUrl = "https://api.github.com";
                client.Authenticator = new HttpBasicAuthenticator(GetForm1().username.Text, GetForm1().password.Text);

                var request = new RestRequest("/repos/TrinityCore/TrinityCore/issues/" + id.ToString(), Method.PATCH);
                request.RequestFormat = DataFormat.Json;
                request.JsonSerializer = new CustomJsonSerializer();

                /*request.AddParameter("title", title);

                request.AddParameter("body", content);

                request.AddParameter("assignee", responsible);

                request.AddParameter("state", status);
                for (int j = 0; j < labels.Count; ++j)
                    request.AddParameter("labels"+j, labels[j]);*/
                request.AddBody(new UpdatedIssue(title, content, responsible, status, labels));

                RestResponse response = (RestResponse)(await TaskEx.Run(() => client.Execute(request)));
                
                var Rcontent = response.Content;
                if (response.ResponseStatus != ResponseStatus.Completed)
                {
                    if (response.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        KryptonMessageBox.Show("You have not specified your correct username/password or you are not authorized to make this operation");
                    }
                    else
                        KryptonMessageBox.Show("A not handled error occurred while updating the issue: " + response.StatusCode.ToString() + "\nResponse Status: " + response.ResponseStatus.ToString(),"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
                else
                {
                    KryptonMessageBox.Show("Issue updated succesfully!", "Information");
                }
            }
            catch { }
        }

        public static void AddIssueDetailsForm(IssueDetails frm)
        {
            issuedetailsform = frm;
        }

        public static void AddForm1(Form1 frm)
        {
            frm1 = frm;
        }

        public static IssueDetails GetIssueDetailsForm()
        {
            return issuedetailsform;
        }

        public static Form1 GetForm1()
        {
            return frm1;
        }

        public static IssueComments issuecommentsfrm;

        public static void AddIssueCommentsForm(IssueComments f)
        {
            issuecommentsfrm = f;
        }

        /*public static async Task<List<int>> GetAllComments(int id)
        {
            //List<Comment> _ret = new List<Comment>();
            string data = await Post_request("https://bitbucket.org/maczuga/cataproject-4.0.6a/issue/" + id.ToString(), "","GET");
            
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(data);

            //var comments = doc.DocumentNode.Descendants("ol").Where(x=> x.Id.Equals("issues-comments"));

            var comments = doc.DocumentNode.Descendants("div");
            List<HtmlNode> aa = new List<HtmlNode>();
            
            foreach(HtmlNode a in comments)
            {
                if (a.Attributes["class"] != null)
                {
                    if (a.Attributes["class"].Value.Equals("issues-comment edit-comment"))
                        aa.Add(a);
                    else
                        System.Diagnostics.Debug.WriteLine("No: {0}",a.Attributes["class"].Value);
                }
                else
                    System.Diagnostics.Debug.WriteLine("Its null");
            }

            KryptonMessageBox.Show("Comments Count: "+aa);
            //string resp = await Post_request("https://bitbucket.org/account/signin/", "username=Subv&password=sebas2112&next&csrfmiddlewaretoken=5d15fd29d567e23d19c55f17881de452", "POST");
            //KryptonMessageBox.Show(resp);
            return aa;
            //return _ret;
        }*/

        public static void CancelRequest()
        {
            cancel = true;
        }

        public static void SetIssues(List<Issue> list)
        {
            Issues = list;
        }

        public static async Task<int> GetTotalIssues()
        {
            RestClient client = new RestClient();
            client.BaseUrl = "https://api.bitbucket.org/1.0";
            client.Authenticator = new HttpBasicAuthenticator(GetForm1().username.Text, GetForm1().password.Text);
            var request = new RestRequest(string.Format("repositories/maczuga/cataproject-4.0.6a/issues/?status=open&status=new&title=~spell&title=~talent&title=~mastery&title=~quest&title=~system&title=~instance"));
            request.RequestFormat = DataFormat.Json;

            var response = await TaskEx.Run(() => client.Execute<List<Issue>>(request));
            
            /*if (response.Data != null)
            {
                return response.Data.Count;
            }*/
            return 50;
        }

        public static async Task<bool> IsInternetConnected()
        {
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            IAsyncResult result = TaskEx.Run<IAsyncResult>(() => socket.BeginConnect("www.google.com", 80, null, null));
            bool success = result.AsyncWaitHandle.WaitOne(500, true);

            if (!success)
            {
                socket.Close();
                socket = null;
                return false;
            }
            socket.Close();
            return true;
        }
        public static object _lk = new object();
        public static void AddIssueToList(Issue iss)
        {
            string[] labels = new string[iss.Labels.Count];
            for (int i = 0; i < iss.Labels.Count; ++i)
                labels[i] = iss.Labels[i].Name;
            lock (_lk)
            {
                frm1.issues.Rows.Add(iss.Number, iss.Title, iss.User.Login, iss.State, iss.Asignee != null ? iss.Asignee.Login : "None", iss.Comments, String.Join(" | ", labels));
            }
            if (frm1.issues.CurrentCell == null)
                frm1.issues.CurrentCell = frm1.issues.Rows[0].Cells[0];
        }

        public static async Task<List<Issue>> GetAllIssues(int limit = 50)
        {
            List<Issue> _ret = new List<Issue>();
            RestClient client = new RestClient();
            // BB: https://api.bitbucket.org/1.0 GH: https://api.github.com
            client.BaseUrl = "https://api.github.com";
            client.Authenticator = new HttpBasicAuthenticator(GetForm1().username.Text, GetForm1().password.Text);
            int start = 0;
            int currents = 0;
            //while ((currents < limit))
            {
                var x = await API.IsInternetConnected();
                if (!x)
                {
                    KryptonMessageBox.Show("Could not connect to the internet, please make sure you have a working connection");
                    _ret = null;
                    client = null;
                    return null;
                }

                var request = new RestRequest(string.Format("/repos/TrinityCore/TrinityCore/issues"));
                request.RequestFormat = DataFormat.Json;

                var response = await TaskEx.Run(() => client.Execute<List<Issue>>(request));

                if (response.Data != null)
                {
                    var issues = response.Data;
                    await TaskEx.Run(() => {
                        for (int i = 0; i < issues.Count; ++i)
                        {
                            Issue iss = issues[i];
                            _ret.Add(iss);
                            AddIssueToList(iss);
                            currents++;
                        }
                    });
                    start = _ret.Count;
                }
                request = null;
                response = null;
            }
            frm1.button1.Enabled = true;
            frm1.textBox1.Enabled = true;
            _labels = await _GetAllLabels();
            return _ret;
        }
    }
}
