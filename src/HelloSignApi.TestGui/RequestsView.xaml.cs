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

namespace HelloSignApi.TestGui
{
    /// <summary>
    /// Interaction logic for RequestsView.xaml
    /// </summary>
    public partial class RequestsView : UserControl
    {
        public RequestsView()
        {
            InitializeComponent();
            this.IsEnabled = false;
        }

        HelloSignClient _client;

        internal void ChangeClient(HelloSignClient client)
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
                    Requests.NewSignatureRequest req = CreateRequest();

                    var resp = await _client.SendSignatureRequestAsync(req);

                    MessageBox.Show("Request made, check logs for data.", "Request Completed", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Request Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private Requests.NewSignatureRequest CreateRequest()
        {
            var req = new HelloSignApi.Requests.NewSignatureRequest();
            req.ClientId = boxClientId.Text;
            req.TestMode = ckTestMode.IsChecked.Value;
            if (ckLocal.IsChecked.Value)
            {
                req.Files.Add(new Requests.PendingFile(boxLocalFile.Text));
            }
            if (ckRemote.IsChecked.Value)
            {
                req.Files.Add(new Requests.PendingFile(new Uri(boxRemoteFile.Text)));
            }
            req.Title = boxTitle.Text;
            req.Subject = boxSubject.Text;
            req.Message = boxMessage.Text;

            if (!string.IsNullOrEmpty(boxSigner1.Text))
            {
                req.Signers.Add(new Requests.Signer { Email = boxSigner1.Text });
            }
            if (!string.IsNullOrEmpty(boxSigner2.Text))
            {
                req.Signers.Add(new Requests.Signer { Email = boxSigner2.Text });
            }

            return req;
        }

        private void btnBrowse_Click(object sender, RoutedEventArgs e)
        {
            new ModernWpf.Messages.ChooseFileMessage(cb => boxLocalFile.Text = cb.First())
                .HandleWithPlatform(Window.GetWindow(this));
        }
    }
}
