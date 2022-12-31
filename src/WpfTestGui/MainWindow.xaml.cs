using Soukoku.DropboxSignApi;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfTestGui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IApiLog
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void btnChangeKey_Click(object sender, RoutedEventArgs e)
        {
            var key = boxApiKey.Text.Trim();
            if (!string.IsNullOrEmpty(key))
            {
                var client = new DropboxSignClient(key, log: this);
                //newViewRequests.ChangeClient(client);
                //oldViewRequests.ChangeClient(client);

                //client.GetSignatureRequestListAsync();
            }
        }

        void IApiLog.MultipartAdded(string key, string value)
        {
            LogIt($"\t{key}={value}\n");
        }
        void IApiLog.JsonSerialized<TReq>(string json)
        {
            LogIt($"\tSerialized {typeof(TReq).Name} as {json}\n");
        }
        void IApiLog.Requesting(string httpMethod, string apiUrl)
        {
            LogIt($"[{httpMethod}] {apiUrl}\n");
        }
        void IApiLog.ResponseRead<TResp>(string content)
        {
            LogIt($"\tReceived data for {typeof(TResp).Name}:\n{FormatJson(content)}\n\n");
        }

        void LogIt(string message)
        {
            if (!Dispatcher.CheckAccess())
            {
                Dispatcher.Invoke(new Action<string>(LogIt), message);
            }
            else
            {
                boxLog.AppendText(message);
                boxLog.ScrollToEnd();
            }
        }

        private string FormatJson(string content)
        {
            JToken jt = JToken.Parse(content);
            string formatted = jt.ToString(Newtonsoft.Json.Formatting.Indented);
            return formatted;
        }
    }
}
