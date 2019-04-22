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
        public string DownloadLink { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool UseSSL { get; set; }

        protected override object OnExecute()
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    client.Headers.Add("user-agent", "Mozilla/4.0 (Compatible; Windows NT 5.1; MSIE 6.0)");

                    if (!string.IsNullOrEmpty(Password) || !string.IsNullOrEmpty(Username))
                    {
                        client.UseDefaultCredentials = true;
                        client.Credentials = new NetworkCredential(Username, Password);
                    }

                    if (UseSSL)
                        ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;

                    MemoryStream stream;
                    stream = new MemoryStream(client.DownloadData(DownloadLink));
                    
                        return stream;
                    
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
