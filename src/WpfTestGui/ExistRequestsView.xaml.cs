using Soukoku.DropboxSignApi;
using Newtonsoft.Json;
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
    /// Interaction logic for RequestsView.xaml
    /// </summary>
    public partial class ExistRequestsView : UserControl
    {
        public ExistRequestsView()
        {
            InitializeComponent();
            this.IsEnabled = false;
        }

        DropboxSignClient? _client;

        internal void ChangeClient(DropboxSignClient client)
        {
            _client = client;
            this.IsEnabled = client != null;
        }

        private async void btnGetReq_Click(object sender, RoutedEventArgs e)
        {
            await DoNewRequestAsync();
        }

        private async Task DoNewRequestAsync()
        {
            if (_client != null)
            {
                try
                {
                    var resp = await _client.GetSignatureRequestAsync(boxReqId.Text);
                    if (resp.Error != null)
                    {
                        MessageBox.Show(resp.Error.Message, "Get Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        //var json = JsonConvert.SerializeObject(resp.SignatureRequest);
                        MessageBox.Show("Request retrieved, check logs for data.", "Request Received", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Get Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

    }
}
