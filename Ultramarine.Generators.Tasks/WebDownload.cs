using System.Composition;
using System.Net;
using Ultramarine.Generators.Tasks.Library.Contracts;

namespace Ultramarine.Generators.Tasks
{
    /// <summary>
    /// Downloads data from a specified URL
    /// </summary>
    [Export(typeof(Task))]
    public class WebDownload : Task
    {
        private string _url;
        private string _username;
        private string _password;
        private string _domain;

        /// <summary>
        /// URL to download from
        /// <para>This property supports Variables</para>
        /// </summary>
        public string Url { get => TryGetSettingValue(_url) as string; set => _url = value; }
        /// <summary>
        /// Username for the authentication
        /// <para>This property supports Variables</para>
        /// </summary>
        public string Username { get => TryGetSettingValue(_username) as string; set => _username = value; }
        /// <summary>
        /// Password for the authentication
        /// <para>This property supports Variables</para>
        /// </summary>
        public string Password { get => TryGetSettingValue(_password) as string; set => _password = value; }
        /// <summary>
        /// Domain for the authentication
        /// <para>This property supports Variables</para>
        /// </summary>
        public string Domain { get => TryGetSettingValue(_domain) as string; set => _domain = value; }
        /// <summary>
        /// Use this option if the URL requires security
        /// </summary>
        public bool UseSSL { get; set; }
        /// <summary>
        /// User-agent string to use
        /// </summary>
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
