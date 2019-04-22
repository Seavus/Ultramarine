using System;
using System.Collections.Generic;
using System.Composition;
using System.IO;
using System.Net;
using System.Text;
using Ultramarine.Generators.Tasks.Library.Contracts;

namespace Ultramarine.Generators.Tasks
{
    [Export(typeof(Task))]
    public class WebDownload : Task
    {
        public string Url { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Domain { get; set; }
        public bool UseSSL { get; set; }
        public string UserAgent { get; set; } = "Mozilla/4.0 (Compatible; Windows NT 5.1; MSIE 6.0)";

        protected override object OnExecute()
        {
            using (WebClient client = new WebClient())
            {
                client.Headers.Add("user-agent", UserAgent);

                if (!string.IsNullOrEmpty(Password) && !string.IsNullOrEmpty(Username))
                {
                    client.UseDefaultCredentials = true;
                    client.Credentials = new NetworkCredential(Username, Password, Domain);
                }

                if (UseSSL)
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;

                return client.DownloadData(Url);
            }
        }
    }
}
