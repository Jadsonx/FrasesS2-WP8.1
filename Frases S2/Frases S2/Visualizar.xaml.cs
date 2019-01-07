using Frases_S2.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using Windows.ApplicationModel.DataTransfer;
using Windows.ApplicationModel.Email;
using Windows.Media.SpeechSynthesis;
using Windows.Storage;
using Windows.UI;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Store;
using Microsoft.AdMediator.Core.Events;

namespace Frases_S2
{
    public sealed partial class Visualizar : Page
    {

        int index = 1;
        int indextotal;
        CategoriaFrase cf;

        public Visualizar()
        {
            this.InitializeComponent();
            Image_Categoria.Begin();
            this.Loaded += Visualizar_Loaded;
        }
        #region Mudar imagem de acordo com a categoria;
        private async void Visualizar_Loaded(object sender, RoutedEventArgs e)
        {
            // ao clicar na categoria, identifica o nome dela e exibirar uma mensagem correspondente a categoria
            if (Categoria_Nome.Text.Contains("Mensagens de Amizade"))
            {
              var amizade =  image.Source = new BitmapImage(new Uri("ms-appx:///Assets/Image/Visualizar/amizade.jpg"));
                var statusBar = Windows.UI.ViewManagement.StatusBar.GetForCurrentView();
                statusBar.BackgroundColor = Color.FromArgb(255, 98, 149, 120);
                statusBar.BackgroundOpacity = 100;
                await statusBar.ShowAsync();
                BarraComandos.Background = new SolidColorBrush(Color.FromArgb(255, 98, 149, 120));
                BarraComandos.Foreground = new SolidColorBrush(Colors.White);
                de.Foreground = new SolidColorBrush(Color.FromArgb(255, 98, 149, 120));
                Categoria_Nome.Foreground = new SolidColorBrush(Color.FromArgb(255, 98, 149, 120));
            }
            if (Categoria_Nome.Text == "Mensagens de Amor")
            {
                image.Source = new BitmapImage(new Uri("ms-appx:///Assets/Image/Visualizar/amor.jpg"));
                var statusBar = Windows.UI.ViewManagement.StatusBar.GetForCurrentView();
                statusBar.BackgroundColor = Color.FromArgb(255,224, 54, 38);
                statusBar.BackgroundOpacity = 100;
                await statusBar.ShowAsync();
                BarraComandos.Background = new SolidColorBrush(Color.FromArgb(255, 224, 54, 38));
                BarraComandos.Foreground = new SolidColorBrush(Colors.White);
                de.Foreground = new SolidColorBrush(Color.FromArgb(255, 224, 54, 38));
                Categoria_Nome.Foreground = new SolidColorBrush(Color.FromArgb(255, 224, 54, 38));
            }
            else if (Categoria_Nome.Text == "Mensagens de Aniversário")
            {
                image.Source = new BitmapImage(new Uri("ms-appx:///Assets/Image/Visualizar/aniversario.jpg"));
                var statusBar = Windows.UI.ViewManagement.StatusBar.GetForCurrentView();             
                statusBar.BackgroundColor = Color.FromArgb(255, 160, 98, 84);
                statusBar.BackgroundOpacity = 100;
                await statusBar.ShowAsync();
                BarraComandos.Background = new SolidColorBrush(Color.FromArgb(255,160, 98, 84));
                BarraComandos.Foreground = new SolidColorBrush(Colors.White);
                de.Foreground = new SolidColorBrush(Color.FromArgb(255, 160, 98, 84));
                Categoria_Nome.Foreground = new SolidColorBrush(Color.FromArgb(255, 160, 98, 84));
            }
            else if (Categoria_Nome.Text == "Mensagens de Ano Novo")
            {
                image.Source = new BitmapImage(new Uri("ms-appx:///Assets/Image/Visualizar/Ano-novo.jpg"));
                var statusBar = Windows.UI.ViewManagement.StatusBar.GetForCurrentView();
                statusBar.BackgroundColor = Color.FromArgb(255, 54, 45, 102);
                statusBar.BackgroundOpacity = 100;
                await statusBar.ShowAsync();
                BarraComandos.Background = new SolidColorBrush(Color.FromArgb(255, 54, 45, 102));
                BarraComandos.Foreground = new SolidColorBrush(Colors.White);
                de.Foreground = new SolidColorBrush(Color.FromArgb(255, 54, 45, 102));
                Categoria_Nome.Foreground = new SolidColorBrush(Color.FromArgb(255, 54, 45, 102));
            }
            else if (Categoria_Nome.Text == "Mensagens de Boa Noite")
            {
                image.Source = new BitmapImage(new Uri("ms-appx:///Assets/Image/Visualizar/boa-noite.jpg"));
                var statusBar = Windows.UI.ViewManagement.StatusBar.GetForCurrentView();               
                statusBar.BackgroundColor = Color.FromArgb(255, 56, 59, 76);
                statusBar.BackgroundOpacity = 100;
                await statusBar.ShowAsync();
                BarraComandos.Background = new SolidColorBrush(Color.FromArgb(255, 56, 59, 76));
                BarraComandos.Foreground = new SolidColorBrush(Colors.White);
                de.Foreground = new SolidColorBrush(Color.FromArgb(255, 56, 59, 76));
                Categoria_Nome.Foreground = new SolidColorBrush(Color.FromArgb(255, 56, 59, 76));
            }
            else if (Categoria_Nome.Text == "Mensagens de Boa Tarde")
            {
                
                image.Source = new BitmapImage(new Uri("ms-appx:///Assets/Image/Visualizar/boa-tarde.jpg"));
                var statusBar = Windows.UI.ViewManagement.StatusBar.GetForCurrentView();
                statusBar.BackgroundColor = Color.FromArgb(255, 196, 140, 37);
                statusBar.BackgroundOpacity = 100;
                await statusBar.ShowAsync();
                BarraComandos.Background = new SolidColorBrush(Color.FromArgb(255, 196, 140, 37));
                BarraComandos.Foreground = new SolidColorBrush(Colors.White);
                de.Foreground = new SolidColorBrush(Color.FromArgb(255, 196, 140, 37));
                Categoria_Nome.Foreground = new SolidColorBrush(Color.FromArgb(255, 196, 140, 37));
            }
            else if (Categoria_Nome.Text == "Mensagens de Bom Dia")
            {
                image.Source = new BitmapImage(new Uri("ms-appx:///Assets/Image/Visualizar/bom-dia.jpg"));
              //image.Source = new BitmapImage(new Uri("ms-appx:///Assets/Image/Visualizar/boa-tarde.jpg"));
                var statusBar = Windows.UI.ViewManagement.StatusBar.GetForCurrentView();
                statusBar.BackgroundColor = Color.FromArgb(255, 154, 115, 86);
                statusBar.BackgroundOpacity = 100;
                await statusBar.ShowAsync();
                BarraComandos.Background = new SolidColorBrush(Color.FromArgb(255, 154, 115, 86));
                BarraComandos.Foreground = new SolidColorBrush(Colors.White);
                de.Foreground = new SolidColorBrush(Color.FromArgb(255, 154, 115, 86));
                Categoria_Nome.Foreground = new SolidColorBrush(Color.FromArgb(255, 154, 115, 86));
          
        }
            else if (Categoria_Nome.Text == "Mensagens de Ciúmes")
            {
              
                image.Source = new BitmapImage(new Uri("ms-appx:///Assets/Image/Visualizar/ciumes.jpg"));
                var statusBar = Windows.UI.ViewManagement.StatusBar.GetForCurrentView();
                statusBar.BackgroundColor = Color.FromArgb(255, 51, 120, 91);
                statusBar.BackgroundOpacity = 100;
                await statusBar.ShowAsync();
                BarraComandos.Background = new SolidColorBrush(Color.FromArgb(255, 51, 120, 91));
                BarraComandos.Foreground = new SolidColorBrush(Colors.White);
                de.Foreground = new SolidColorBrush(Color.FromArgb(255, 51, 120, 91));
                Categoria_Nome.Foreground = new SolidColorBrush(Color.FromArgb(255, 51, 120, 91));

            }
            else if (Categoria_Nome.Text == "Mensagens de Decepção")
            {
                
                image.Source = new BitmapImage(new Uri("ms-appx:///Assets/Image/Visualizar/decepcao.jpg"));
                var statusBar = Windows.UI.ViewManagement.StatusBar.GetForCurrentView();
                statusBar.BackgroundColor = Color.FromArgb(255, 130, 101, 71);
                statusBar.BackgroundOpacity = 100;
                await statusBar.ShowAsync();
                BarraComandos.Background = new SolidColorBrush(Color.FromArgb(255, 130, 101, 71));
                BarraComandos.Foreground = new SolidColorBrush(Colors.White);
                de.Foreground = new SolidColorBrush(Color.FromArgb(255, 130, 101, 71));
                Categoria_Nome.Foreground = new SolidColorBrush(Color.FromArgb(255, 130, 101, 71));
            }
            else if (Categoria_Nome.Text == "Mensagens de Desculpas")
            {
                image.Source = new BitmapImage(new Uri("ms-appx:///Assets/Image/Visualizar/desculpas.jpg")); 
                var statusBar = Windows.UI.ViewManagement.StatusBar.GetForCurrentView();
                statusBar.BackgroundColor = Color.FromArgb(255, 130, 74, 59);
                statusBar.BackgroundOpacity = 100;
                await statusBar.ShowAsync();
                BarraComandos.Background = new SolidColorBrush(Color.FromArgb(255, 130, 74, 59));
                BarraComandos.Foreground = new SolidColorBrush(Colors.White);
                de.Foreground = new SolidColorBrush(Color.FromArgb(255, 130, 74, 59));
                Categoria_Nome.Foreground = new SolidColorBrush(Color.FromArgb(255, 130, 74, 59));
            }
            else if (Categoria_Nome.Text == "Mensagens de Deus")
            {
                image.Source = new BitmapImage(new Uri("ms-appx:///Assets/Image/Visualizar/deus.jpg"));
                var statusBar = Windows.UI.ViewManagement.StatusBar.GetForCurrentView();
                statusBar.BackgroundColor = Color.FromArgb(255, 59, 134, 155);
                statusBar.BackgroundOpacity = 100;
                await statusBar.ShowAsync();
                BarraComandos.Background = new SolidColorBrush(Color.FromArgb(255, 59, 134, 155));
                BarraComandos.Foreground = new SolidColorBrush(Colors.White);
                de.Foreground = new SolidColorBrush(Color.FromArgb(255, 59, 134, 155)); 
                Categoria_Nome.Foreground = new SolidColorBrush(Color.FromArgb(255, 59, 134, 155));
            }
            else if (Categoria_Nome.Text == "Mensagens de Dia das Mães")
            {
                image.Source = new BitmapImage(new Uri("ms-appx:///Assets/Image/Visualizar/dia-das-maes.jpg"));
                var statusBar = Windows.UI.ViewManagement.StatusBar.GetForCurrentView();
                statusBar.BackgroundColor = Color.FromArgb(255, 229, 45, 135);
                statusBar.BackgroundOpacity = 100;
                await statusBar.ShowAsync();
                BarraComandos.Background = new SolidColorBrush(Color.FromArgb(255, 229, 45, 135));
                BarraComandos.Foreground = new SolidColorBrush(Colors.White);
                de.Foreground = new SolidColorBrush(Color.FromArgb(255, 229, 45, 135));
                Categoria_Nome.Foreground = new SolidColorBrush(Color.FromArgb(255, 229, 45, 135));
            }
            else if (Categoria_Nome.Text == "Mensagens de Dia dos Pais")
            {
                image.Source = new BitmapImage(new Uri("ms-appx:///Assets/Image/Visualizar/dia-dos-pais.jpg"));
                var statusBar = Windows.UI.ViewManagement.StatusBar.GetForCurrentView();
                statusBar.BackgroundColor = Color.FromArgb(255, 0, 89, 93);
                statusBar.BackgroundOpacity = 100;
                await statusBar.ShowAsync();
                BarraComandos.Background = new SolidColorBrush(Color.FromArgb(255, 0, 89, 93));
                BarraComandos.Foreground = new SolidColorBrush(Colors.White);
                de.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 89, 93));
                Categoria_Nome.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 89, 93));
            }
            else if (Categoria_Nome.Text == "Mensagens Engraçadas")
            {
                image.Source = new BitmapImage(new Uri("ms-appx:///Assets/Image/Visualizar/engracado.jpg"));
                var statusBar = Windows.UI.ViewManagement.StatusBar.GetForCurrentView();
                statusBar.BackgroundColor = Color.FromArgb(255, 148, 75, 92);
                statusBar.BackgroundOpacity = 100;
                await statusBar.ShowAsync();
                BarraComandos.Background = new SolidColorBrush(Color.FromArgb(255, 148, 75, 92));
                BarraComandos.Foreground = new SolidColorBrush(Colors.White);
                de.Foreground = new SolidColorBrush(Color.FromArgb(255, 148, 75, 92));
                Categoria_Nome.Foreground = new SolidColorBrush(Color.FromArgb(255, 148, 75, 92));
            }
            else if (Categoria_Nome.Text == "Mensagens de Natal")
            {
                image.Source = new BitmapImage(new Uri("ms-appx:///Assets/Image/Visualizar/feliz-natal.jpg"));
                var statusBar = Windows.UI.ViewManagement.StatusBar.GetForCurrentView();
                statusBar.BackgroundColor = Color.FromArgb(255, 43, 33, 8);
                statusBar.BackgroundOpacity = 100;
                await statusBar.ShowAsync();
                BarraComandos.Background = new SolidColorBrush(Color.FromArgb(255, 43, 33, 8));
                BarraComandos.Foreground = new SolidColorBrush(Colors.White);
                de.Foreground = new SolidColorBrush(Color.FromArgb(255, 43, 33, 8));
                Categoria_Nome.Foreground = new SolidColorBrush(Color.FromArgb(255, 43, 33, 8));
            }
            else if (Categoria_Nome.Text == "Mensagens de Filmes")
            {
                image.Source = new BitmapImage(new Uri("ms-appx:///Assets/Image/Visualizar/Filmes.jpg"));
                var statusBar = Windows.UI.ViewManagement.StatusBar.GetForCurrentView();
                statusBar.BackgroundColor = Color.FromArgb(255, 19, 12, 28); 
                statusBar.BackgroundOpacity = 100;
                await statusBar.ShowAsync();
                BarraComandos.Background = new SolidColorBrush(Color.FromArgb(255, 19, 12, 28));
                BarraComandos.Foreground = new SolidColorBrush(Colors.White);
                de.Foreground = new SolidColorBrush(Color.FromArgb(255, 19, 12, 28));
                Categoria_Nome.Foreground = new SolidColorBrush(Color.FromArgb(255, 19, 12, 28));
            }
            else if (Categoria_Nome.Text == "Mensagens de Indiretas")
            {
                image.Source = new BitmapImage(new Uri("ms-appx:///Assets/Image/Visualizar/indiretas.jpg"));
                var statusBar = Windows.UI.ViewManagement.StatusBar.GetForCurrentView();
                statusBar.BackgroundColor = Color.FromArgb(255, 100, 94, 92);
                statusBar.BackgroundOpacity = 100;
                await statusBar.ShowAsync();
                BarraComandos.Background = new SolidColorBrush(Color.FromArgb(255, 0, 94, 93));
                BarraComandos.Foreground = new SolidColorBrush(Colors.White);
                de.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 94, 93));
                Categoria_Nome.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 94, 93));
            }
            else if (Categoria_Nome.Text == "Mensagens de Livros")
            {
                image.Source = new BitmapImage(new Uri("ms-appx:///Assets/Image/Visualizar/Livros.jpg"));
                var statusBar = Windows.UI.ViewManagement.StatusBar.GetForCurrentView();
                statusBar.BackgroundColor = Color.FromArgb(255, 98, 179, 120);
                statusBar.BackgroundOpacity = 100;
                await statusBar.ShowAsync();
                BarraComandos.Background = new SolidColorBrush(Color.FromArgb(255, 98, 179, 120));
                BarraComandos.Foreground = new SolidColorBrush(Colors.White);
                de.Foreground = new SolidColorBrush(Color.FromArgb(255, 98, 179, 120));
                Categoria_Nome.Foreground = new SolidColorBrush(Color.FromArgb(255, 98, 179, 120));
            }
            else if (Categoria_Nome.Text == "Mensagens de Motivação")
            {
                image.Source = new BitmapImage(new Uri("ms-appx:///Assets/Image/Visualizar/motivacao.jpg"));
                var statusBar = Windows.UI.ViewManagement.StatusBar.GetForCurrentView();
                statusBar.BackgroundColor = Color.FromArgb(255, 98, 99, 164);
                statusBar.BackgroundOpacity = 100;
                await statusBar.ShowAsync();
                BarraComandos.Background = new SolidColorBrush(Color.FromArgb(255, 98, 99, 164));
                BarraComandos.Foreground = new SolidColorBrush(Colors.White);
                de.Foreground = new SolidColorBrush(Color.FromArgb(255, 98, 99, 164));
                Categoria_Nome.Foreground = new SolidColorBrush(Color.FromArgb(255, 98, 99, 164));
            }
            else if (Categoria_Nome.Text == "Mensagens de Músicas")
            {
                image.Source = new BitmapImage(new Uri("ms-appx:///Assets/Image/Visualizar/musicas.jpg"));
                var statusBar = Windows.UI.ViewManagement.StatusBar.GetForCurrentView();
                statusBar.BackgroundColor = Color.FromArgb(255, 73, 0, 43);
                statusBar.BackgroundOpacity = 100;
                await statusBar.ShowAsync();
                BarraComandos.Background = new SolidColorBrush(Color.FromArgb(255, 73, 0, 43));
                BarraComandos.Foreground = new SolidColorBrush(Colors.White);
                de.Foreground = new SolidColorBrush(Color.FromArgb(255, 73, 0, 43));
                Categoria_Nome.Foreground = new SolidColorBrush(Color.FromArgb(255, 73, 0, 43));
            }
            else if (Categoria_Nome.Text == "Mensagens de Reflexão")
            {
                image.Source = new BitmapImage(new Uri("ms-appx:///Assets/Image/Visualizar/Reflexao.jpg"));
                var statusBar = Windows.UI.ViewManagement.StatusBar.GetForCurrentView();
                statusBar.BackgroundColor = Color.FromArgb(255, 92, 129, 181);
                statusBar.BackgroundOpacity = 100;
                await statusBar.ShowAsync();
                BarraComandos.Background = new SolidColorBrush(Color.FromArgb(255, 92, 129, 181));
                BarraComandos.Foreground = new SolidColorBrush(Colors.White);
                de.Foreground = new SolidColorBrush(Color.FromArgb(255, 92, 129, 181));
                Categoria_Nome.Foreground = new SolidColorBrush(Color.FromArgb(255, 92, 129, 181));
            }
            else if (Categoria_Nome.Text == "Mensagens de Saudades")
            {
                image.Source = new BitmapImage(new Uri("ms-appx:///Assets/Image/Visualizar/saudades.jpg"));
                var statusBar = Windows.UI.ViewManagement.StatusBar.GetForCurrentView();
                statusBar.BackgroundColor = Color.FromArgb(255, 88, 83, 103);
                statusBar.BackgroundOpacity = 100;
                await statusBar.ShowAsync();
                BarraComandos.Background = new SolidColorBrush(Color.FromArgb(255, 88, 83, 103));
                BarraComandos.Foreground = new SolidColorBrush(Colors.White);
                de.Foreground = new SolidColorBrush(Color.FromArgb(255, 88, 83, 103));
                Categoria_Nome.Foreground = new SolidColorBrush(Color.FromArgb(255, 88, 83, 103));
            }
            else if (Categoria_Nome.Text == "Mensagens de Tristeza")
            {
                image.Source = new BitmapImage(new Uri("ms-appx:///Assets/Image/Visualizar/tristeza.jpg"));
                var statusBar = Windows.UI.ViewManagement.StatusBar.GetForCurrentView();
                statusBar.BackgroundColor = Color.FromArgb(255, 32, 32, 32);
                statusBar.BackgroundOpacity = 100;
                await statusBar.ShowAsync();
                BarraComandos.Background = new SolidColorBrush(Color.FromArgb(255, 32, 32, 32));
                BarraComandos.Foreground = new SolidColorBrush(Colors.White);
                de.Foreground = new SolidColorBrush(Color.FromArgb(255, 32, 32, 32));
                Categoria_Nome.Foreground = new SolidColorBrush(Color.FromArgb(255, 32, 32, 32));
            }
        }
        #endregion
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Verificar_CompraIAPs();
            // Receber os parâmetros.
            cf = (CategoriaFrase)e.Parameter;
            indextotal = cf.frases.Count - 1;
            Total_Frase.Text = indextotal.ToString();
            Inico_Frase.Text = index.ToString();
            exibirFrase(index);
            //compartilhar dados
            DataTransferManager dataTransferManager = DataTransferManager.GetForCurrentView();
            dataTransferManager.DataRequested += ShareData;
        }

        private void ShareData(DataTransferManager sender, DataRequestedEventArgs e)
        {
            try
            {
                DataPackage requestData = e.Request.Data;
                requestData.Properties.Title = "Frases S2";
                requestData.Properties.Description = "Frases S2 - Windows Phone";
                requestData.SetText(tbFrase.Text.Trim() +
                    Environment.NewLine + "(" + 
                    tbAutor.Text.Trim() + ")" + 
                    Environment.NewLine + " " + 
                    Environment.NewLine + "ℹ #FrasesS2"
                    + Environment.NewLine + 
                    Environment.NewLine + "⚠ FRASES S2 PARA ANDROID ⚠" +
                    Environment.NewLine + "https://play.google.com/store/apps/details?id=com.companyname.FrasesS2");              
            }
            catch (Exception)
            {
                Models.Mensagem.ShowCatch();
            }
        }     

        string frase, autor, categoria;
        private void exibirFrase(int index)
        {
            frase = cf.frases[index].frase;
            autor = cf.frases[index].autor;
            categoria = cf.categoria;
            // Setar dados nos componentes.
            tbFrase.Text = frase;
            tbAutor.Text = autor;
            Categoria_Nome.Text = categoria;
        }
        #region Avançar e Voltar Frases
        private void avancar()
        {
            if (index < cf.frases.Count - 1)
            {
                index++;
            }

            else
            {
                index = 1;
            }
            exibirFrase(index);
            Inico_Frase.Text = "" + index;
        }

        private void retroceder()
        {
            if (index == 1)
            {
                index = cf.frases.Count - 1;
            }
            else
            {
                index--;

            }
            exibirFrase(index);

            Inico_Frase.Text = "" + index;
        }
        #endregion
        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            avancar();
        }

        private void AppBarButton_Click_1(object sender, RoutedEventArgs e)
        {
            retroceder();
        }

        private async void Ouvir_Frase_Click(object sender, RoutedEventArgs e)
        {
            try
            {              
                using (var speech = new SpeechSynthesizer())
                {
                    var mediaElement = new MediaElement();
                    var voiceStream = await speech.SynthesizeTextToStreamAsync(tbFrase.Text);
                    mediaElement.SetSource(voiceStream, voiceStream.ContentType);
                    mediaElement.Play();
                }
            }
            catch (Exception exLOG)
            {
                Models.Mensagem.ShowLOG(exLOG.ToString());
            }
        }

        private void Compartilhar_Click(object sender, RoutedEventArgs e)
        {
            DataTransferManager.ShowShareUI();
        }
      
        private void Copiar_Click(object sender, RoutedEventArgs e)
        {          
            Mensagem.ShowMsg("Para copiar a frase, basta você tocar no texto e seleciona-lo!","Selecione o texto para copiar!");                     
        }                

        private async void Bug_Click(object sender, RoutedEventArgs e)
        {
            var version = Package.Current.Id.Version;
            string appVersion = String.Format("{0}.{1}.{2}.{3}",
            version.Major, version.Minor, version.Build, version.Revision);
            try
            {
                MessageDialog BUG = new MessageDialog(tbFrase.Text, "Algum problema com a frase?");
                BUG.Commands.Add(new UICommand("Ortografia"));
                BUG.Commands.Add(new UICommand("Repetição"));
                var result = await BUG.ShowAsync();
                if (result.Label == "Ortografia")
                {
                    var arzLocal = Windows.Storage.ApplicationData.Current.LocalSettings;
                    if (arzLocal.Values.ContainsKey("Nome"))
                    {
                        EmailMessage email = new EmailMessage();
                        email.Subject = "Frases S2 - CORRIGIR ORTOGRÁFIA : " + arzLocal.Values["Nome"] + " " + arzLocal.Values["Sobrenome"];
                        email.Body = "FS2: " + appVersion + Environment.NewLine + Categoria_Nome.Text + " -- " + Inico_Frase.Text + ":" + Environment.NewLine + " " + Environment.NewLine + tbFrase.Text + Environment.NewLine + " ";
                        email.To.Add(new EmailRecipient("Jadson0102@live.com", "Jadson Santos"));

                        await EmailManager.ShowComposeNewEmailAsync(email);
                    }
                    else
                    {
                        EmailMessage email = new EmailMessage();
                        email.Subject = "Frases S2 - CORRIGIR ORTOGRÁFIA";
                        email.Body = "FS2: " + appVersion + Environment.NewLine + Categoria_Nome.Text + " -- " + Inico_Frase.Text + ":" + Environment.NewLine + " " + Environment.NewLine + tbFrase.Text + Environment.NewLine + " ";
                        email.To.Add(new EmailRecipient("Jadson0102@live.com", "Jadson Santos"));
                        await EmailManager.ShowComposeNewEmailAsync(email);
                    }
                }
                else
                {

                }

                if (result.Label == "Repetição")
                {
                    var arzLocal = Windows.Storage.ApplicationData.Current.LocalSettings;
                    if (arzLocal.Values.ContainsKey("Nome"))
                    {
                        EmailMessage email = new EmailMessage();
                        email.Subject = "Frases S2 - CORRIGIR REPETIÇÃO : " + arzLocal.Values["Nome"] + " " + arzLocal.Values["Sobrenome"];
                        email.Body = "FS2: " + appVersion + Environment.NewLine + Categoria_Nome.Text + " -- " + Inico_Frase.Text + ":" + Environment.NewLine + " " + Environment.NewLine + tbFrase.Text + Environment.NewLine + " ";
                        email.To.Add(new EmailRecipient("Jadson0102@live.com", "Jadson Santos"));
                        await EmailManager.ShowComposeNewEmailAsync(email);
                    }
                    else
                    {
                        EmailMessage email = new EmailMessage();
                        email.Subject = "Frases S2 - CORRIGIR REPETIÇÃO";
                        email.Body = "FS2: " + appVersion + Environment.NewLine + Categoria_Nome.Text + " -- " + Inico_Frase.Text + ":" + Environment.NewLine + " " + Environment.NewLine + tbFrase.Text + Environment.NewLine + " ";
                        email.To.Add(new EmailRecipient("Jadson0102@live.com", "Jadson Santos"));
                        await EmailManager.ShowComposeNewEmailAsync(email);
                    }
                }

                else
                {

                }
            }
            catch (Exception)
            {               
            }
        }

        private void Visualizar_ADS_AdMediatorError(object sender, Microsoft.AdMediator.Core.Events.AdMediatorFailedEventArgs e)
        {
            if (e.ErrorCode == AdMediatorErrorCode.NoAdAvailable & (CurrentApp.LicenseInformation.ProductLicenses["AdBlocker"].IsActive))
                Visualizar_ADS.Visibility = Visibility.Collapsed;
            else
                Visualizar_ADS.Visibility = Visibility.Visible;
        }

        private async void Gostei_Click(object sender, RoutedEventArgs e)
        {       
            try
            {
                StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
                StorageFile sampleFile = await storageFolder.CreateFileAsync("Favorite.txt", CreationCollisionOption.OpenIfExists);
                string text = await FileIO.ReadTextAsync(sampleFile);

                List<Frase> frasesFavoritas = JsonConvert.DeserializeObject<List<Frase>>(text);

                if (frasesFavoritas == null)
                {
                    frasesFavoritas = new List<Frase>();
                }             
                               
                // Obtém a frase favoritada.
                Frase setdados = new Frase();
                setdados.frase = tbFrase.Text;
                setdados.autor = tbAutor.Text;

                Frase Verif_Frase = frasesFavoritas.FirstOrDefault(cf => cf.frase.Equals(tbFrase.Text));
             
                //Não encontrou nenhum conteudo então adiciona a frase
                if (Verif_Frase == null) // Não encontrou nenhuma frase na lista.
                {
                    if (frasesFavoritas.Count == 0)
                    {
                        frasesFavoritas.Add(setdados);                       
                        frasesFavoritas.Add(setdados);
                        Mensagem.ShowMsg(tbFrase.Text, "Adicionamos a frase aos favoritos!");
                    }
                    else
                    {
                        frasesFavoritas.Add(setdados);
                        Mensagem.ShowMsg(tbFrase.Text, "Adicionamos a frase aos favoritos!");
                    }
                    
                }
                else
                {
                    Mensagem.ShowMsg("Ops, você já tem essa frase em seus favoritos!", "Favoritos: Atenção!");
                }
              
                // Gerar JSON.
                string jsonFrasesF = JsonConvert.SerializeObject(frasesFavoritas);

                // Reescrever no arquivo.               
                await FileIO.WriteTextAsync(sampleFile, jsonFrasesF);
            }
            catch (Exception)
            {
                Models.Mensagem.ShowCatch();
            }
        }

        public async void Verificar_CompraIAPs()
        {
            try
            {
                var listing = await CurrentApp.LoadListingInformationAsync();
                // Select the right product, use the information that we used when submitting the in-app purchase to the store
                var product = listing.ProductListings.FirstOrDefault(p => p.Value.ProductId == "AdBlocker" && p.Value.ProductType == ProductType.Durable);
                try
                {
                    // Checando se o produto já foi comprado!
                    if (CurrentApp.LicenseInformation.ProductLicenses["AdBlocker"].IsActive)
                    {
                        //Deixando o anuncio invisivel caso já tenha comprado!
                        Visualizar_ADS.Visibility = Visibility.Collapsed;

                    }
                    else
                    {

                    }
                }
                catch
                {
                }
            }
            catch
            {
            }
        }
    }
}