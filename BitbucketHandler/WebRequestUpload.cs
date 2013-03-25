using System;
using System.IO;
using System.Net;
using System.Text;

namespace BitbucketHandler
{
    public class WebRequestUpload
    {
        private CookieContainer cookies = new CookieContainer();
        private Uri cookies_uri = null;

        public WebRequestUpload()
        {
        }

        /// <summary>
        /// This method logs you into a website. The important stuff is the return value, as it contains
        /// the information you might need for the upload later on.
        /// </summary>
        /// <param name="userid">The user ID</param>
        /// <param name="password">The corresponding password</param>
        /// <param name="loginPage">The login page (e.g. http://www.abc.com/login.php)</param>
        /// <param name="referrerPage">The referrer page (e.g. http://www.abc.com/goHereAfterLogin.php)</param>
        /// <returns>A dictionary (HashMap) of cookie-names and cookie-values</returns>
        public String loginToWebsite(string userid, string password, string loginPage, string referrerPage)
        {
            // loginPage e.g. http://www.abc.com/login.php
            // referrerPage e.g. http://www.abc.com/imguploadsite.php

            String _postData = "next="+string.Empty+"&submit=Log in&csrfmiddlewaretoken=5d15fd29d567e23d19c55f17881de452&username=" + userid + "&password=" + password;

            byte[] _data = new System.Text.ASCIIEncoding().GetBytes(_postData);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(loginPage);
            request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
            request.Referer = referrerPage;
            request.KeepAlive = true;
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = _data.Length;
            request.CookieContainer = cookies;
            request.AllowAutoRedirect = true;
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:5.0) Gecko/20100101 Firefox/5.0";
            ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback((x,y,z,c) => true);

            System.IO.Stream _outStream = request.GetRequestStream();
            _outStream.Write(_data, 0, _data.Length);
            _outStream.Close();

            cookies_uri = request.RequestUri;

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            System.IO.StreamReader sr = new System.IO.StreamReader(response.GetResponseStream());
            String returnValue = sr.ReadToEnd();
            sr.Close();

            foreach (Cookie c in cookies.GetCookies(request.RequestUri))
            {
                Console.WriteLine("Cookie[" + c.Name + "].Value[" + c.Value + "]");
            }

            return returnValue;
        }

        /// <summary>
        /// Upload an image. This method can be modified to work with a number of image uploading services.
        /// However: it was made to work with bitBucket.
        /// Note: you HAVE TO perform loginToWebsite, before uploading to bitBucket.
        /// Otherwise we won't have the necessary uid and pass cookies in order to perform operation.
        /// </summary>
        /// <param name="uploadfile">File to upload (local string)</param>
        /// <param name="url">Url to upload the file to (e.g. http://www.abc.com/bitbucket.php)</param>
        /// <param name="fileFormName">The name of the uploaded file</param>
        /// <param name="loginNeeded">Specifies, whether prior login is needed (in case of bitBucket - true)</param>
        /// <returns></returns>
        public string uploadImage(string uploadfile, string url, string fileFormName, bool loginNeeded)
        {
            if (fileFormName == null || fileFormName.Length == 0)
            {
                fileFormName = "file";
            }

            string contenttype = "application/octet-stream";

            string postdata;
            postdata = "?";
            if (loginNeeded)
            {
                postdata += "uid=" + cookies.GetCookies(cookies_uri)["uid"].Value + "&";
                postdata += "pass=" + cookies.GetCookies(cookies_uri)["pass"].Value;
            }
            Uri uri = new Uri(url + postdata);

            string boundary = "----------" + DateTime.Now.Ticks.ToString("x");
            HttpWebRequest webrequest = (HttpWebRequest)WebRequest.Create(uri);
            webrequest.CookieContainer = cookies;
            webrequest.ContentType = "multipart/form-data; boundary=" + boundary;
            webrequest.Method = "POST";

            // Build up the post message header

            StringBuilder sb = new StringBuilder();
            sb.Append("--");
            sb.Append(boundary);
            sb.Append("\r\n");
            sb.Append("Content-Disposition: form-data; name=\"");
            sb.Append(fileFormName);
            sb.Append("\"; filename=\"");
            sb.Append(Path.GetFileName(uploadfile));
            sb.Append("\"");
            sb.Append("\r\n");
            sb.Append("Content-Type: ");
            sb.Append(contenttype);
            sb.Append("\r\n");
            sb.Append("\r\n");

            string postHeader = sb.ToString();
            byte[] postHeaderBytes = Encoding.UTF8.GetBytes(postHeader);

            // Build the trailing boundary string as a byte array

            // ensuring the boundary appears on a line by itself

            byte[] boundaryBytes =
                   Encoding.ASCII.GetBytes("\r\n--" + boundary + "\r\n");

            FileStream fileStream = new FileStream(uploadfile,
                                        FileMode.Open, FileAccess.Read);
            long length = postHeaderBytes.Length + fileStream.Length +
                                                   boundaryBytes.Length;
            webrequest.ContentLength = length;

            Stream requestStream = webrequest.GetRequestStream();

            // Write out our post header

            requestStream.Write(postHeaderBytes, 0, postHeaderBytes.Length);

            // Write out the file contents

            byte[] buffer = new Byte[checked((uint)Math.Min(4096,
                                     (int)fileStream.Length))];
            int bytesRead = 0;
            while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0)
                requestStream.Write(buffer, 0, bytesRead);

            // Write out the trailing boundary

            requestStream.Write(boundaryBytes, 0, boundaryBytes.Length);
            WebResponse responce = webrequest.GetResponse();
            Stream s = responce.GetResponseStream();
            StreamReader sr = new StreamReader(s);
            String returnValue = sr.ReadToEnd();
            sr.Close();

            return returnValue;
        }
    }
}
