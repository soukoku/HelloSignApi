using DropboxSignApi;
using DropboxSignApi.Requests;
using Microsoft.Win32;
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
    public partial class NewRequestsView : UserControl
    {
        public NewRequestsView()
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

        private async void btnNewReq_Click(object sender, RoutedEventArgs e)
        {
            await DoNewRequestAsync();
        }

        private async Task DoNewRequestAsync()
        {
            if (_client != null)
            {
                try
                {
                    SendSignatureRequestRequest req = CreateRequest();

                    var resp = await _client.SendSignatureRequestAsync(req);

                    MessageBox.Show("Request made, check logs for data.", "Request Completed", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Request Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private SendSignatureRequestRequest CreateRequest()
        {
            var req = new SendSignatureRequestRequest();
            req.ClientId = boxClientId.Text;
            req.TestMode = ckTestMode.IsChecked.GetValueOrDefault();
            if (ckLocal.IsChecked.GetValueOrDefault())
            {
                req.Files.Add(new PendingFile(boxLocalFile.Text));
            }
            if (ckRemote.IsChecked.GetValueOrDefault())
            {
                req.FileUrls.Add(new Uri(boxRemoteFile.Text));
            }
            req.Title = boxTitle.Text;
            req.Subject = boxSubject.Text;
            req.Message = boxMessage.Text;

            if (!string.IsNullOrEmpty(boxSigner1.Text))
            {
                req.Signers.Add(new SubSignatureRequestSigner { Email = boxSigner1.Text });
            }
            if (!string.IsNullOrEmpty(boxSigner2.Text))
            {
                req.Signers.Add(new SubSignatureRequestSigner { Email = boxSigner2.Text });
            }

            return req;
        }

        private void btnBrowse_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new OpenFileDialog { Multiselect = false };
            if (dlg.ShowDialog().GetValueOrDefault())
            {
                boxLocalFile.Text = dlg.FileName;
            }
        }
    }
}
