using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.ApplicationModel.DataTransfer;
using Windows.ApplicationModel.Email;
using Windows.ApplicationModel.Store;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;


namespace Frases_S2.View
{  
    public sealed partial class Sobre : Page
    {
        public Sobre()
        {
            this.InitializeComponent();
        }

     
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var version = Package.Current.Id.Version;
            string appVersion = String.Format("{0}.{1}.{2}.{3}",
            version.Major, version.Minor, version.Build, version.Revision);
            Versao.Text = "Versão: " + appVersion;
            var arzLocal = ApplicationData.Current.LocalSettings;
            DataTransferManager dataTransferManager = DataTransferManager.GetForCurrentView();
            dataTransferManager.DataRequested += ShareData;

        }
     
        private async void Instagram_Click(object sender, RoutedEventArgs e)
        {
            await Launcher.LaunchUriAsync(new Uri("https://www.instagram.com/jadsonxsantos/"));
        }

        private void ShareData(DataTransferManager sender, DataRequestedEventArgs e)
        {
            try
            {
                DataPackage requestData = e.Request.Data;
                requestData.Properties.Title = "Frases S2";
                requestData.Properties.Description = "Frases S2 - Windows Phone";
                requestData.SetText("⚠ BAIXE O FRASES S2 PARA ANDROID ⚠ " +
                    Environment.NewLine + "https://play.google.com/store/apps/details?id=com.companyname.FrasesS2");
            }
            catch (Exception)
            {
                Models.Mensagem.ShowCatch();
            }
        }
        private void Facebook_Click(object sender, RoutedEventArgs e)
        {
            DataTransferManager.ShowShareUI();
        }

        private async void WhatsApp_Group_Click(object sender, RoutedEventArgs e)
        {
            await Launcher.LaunchUriAsync(new Uri("https://api.whatsapp.com/send?phone=5579998682289&text=Olá,%20Quero%20participar%20do%20grupo%20Frases%20S2!"));
        }

        private async void Contato_Click(object sender, RoutedEventArgs e)
        {
            var arzLocal = Windows.Storage.ApplicationData.Current.LocalSettings;
            if (arzLocal.Values.ContainsKey("Nome"))
            {
                EmailMessage email = new EmailMessage();
                email.Subject = "Frases S2 - SOBRE: " + arzLocal.Values["Nome"].ToString();
                email.Body = "" + Environment.NewLine + "" + Environment.NewLine + Environment.NewLine;
                email.To.Add(new EmailRecipient("Jadson0102@live.com", "Jadson Santos"));
                await EmailManager.ShowComposeNewEmailAsync(email);
            }
            else
            {
                EmailMessage email = new EmailMessage();
                email.Subject = "Frases S2 - SOBRE";
                email.Body = "" + Environment.NewLine + "" + Environment.NewLine + Environment.NewLine;
                email.To.Add(new EmailRecipient("Jadson0102@live.com", "Jadson Santos"));
                await EmailManager.ShowComposeNewEmailAsync(email);

            }
        }
    }
}
