using Frases_S2.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.ApplicationModel.DataTransfer;
using Windows.ApplicationModel.Email;
using Windows.ApplicationModel.Store;
using Windows.Storage;
using Windows.UI;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;


namespace Frases_S2.View
{
    public sealed partial class Favoritos : Page
    {
        int index = 1;
        int indexTotal;
        string frase, autor;
        List<Frase> categoriasFrase;
      
        public Favoritos()
        {
            this.InitializeComponent();
            this.Loaded += Favoritos_Loaded;         
        }       

        private void Favoritos_Loaded(object sender, RoutedEventArgs e)
        {
            if (tbAutor.Text == ":(")
            {
                BarraComandos.Visibility = Visibility.Collapsed;
            }
            if (tbAutor.Text != ":(")
            {
                BarraComandos.Visibility = Visibility.Visible;
            }
        }

        private async void ExibirAtualizarFrases()
        {
            try
            {
                StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
                StorageFile sampleFile = await storageFolder.GetFileAsync("Favorite.txt");
                string text = await FileIO.ReadTextAsync(sampleFile);

                categoriasFrase = JsonConvert.DeserializeObject<List<Frase>>(text);

                if (categoriasFrase != null)
                {
                    indexTotal = categoriasFrase.Count - 1;
                    tbFrase.Text = categoriasFrase[index].frase;
                    Total_Frase.Text = indexTotal.ToString();
                    Inico_Frase.Text = index.ToString();
                    exibirFrase(index);
                    BarraComandos.Visibility = Visibility.Visible;
                }
                else
                {
                 //   ExibirAtualizarFrases();
                }                                           
            }
            catch
            {
                //Models.Mensagem.ShowMsg(ex.ToString(), "Frases S2 :( ");
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {   
            //Compartilhar dados
            DataTransferManager dataTransferManager = DataTransferManager.GetForCurrentView();
            dataTransferManager.DataRequested += ShareData;
            ExibirAtualizarFrases();
            Verificar_CompraIAPs();           
        }
       
        private void Voltar_Frase_Click(object sender, RoutedEventArgs e)
        {
            retroceder();
        }

        private async void Excluir_Click(object sender, RoutedEventArgs e)
        {           
            try
            {
                MessageDialog BUG = new MessageDialog("Tem certeza que deseja remover dos seus favoritos a frase: " + tbFrase.Text, "Remover dos favoritos!");
                BUG.Commands.Add(new UICommand("Sim"));
                BUG.Commands.Add(new UICommand("Não"));
                var result = await BUG.ShowAsync();
                if (result.Label == "Sim")
                {
                    StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
                    StorageFile sampleFile = await storageFolder.GetFileAsync("Favorite.txt");
                    string text = await FileIO.ReadTextAsync(sampleFile);

                    List<Frase> FrasesClass = JsonConvert.DeserializeObject<List<Frase>>(text);
                    FrasesClass.RemoveAt(index);
                    string Favoritoatualizado = JsonConvert.SerializeObject(FrasesClass);
                    await FileIO.WriteTextAsync(sampleFile, Favoritoatualizado);

                   List<Frase> Atualizado = JsonConvert.DeserializeObject<List<Frase>>(Favoritoatualizado);
                    if (Atualizado != null)
                    {
                        indexTotal = Atualizado.Count - 1;
                        tbFrase.Text = Atualizado[index].frase;
                        Total_Frase.Text = indexTotal.ToString();
                        Inico_Frase.Text = index.ToString();
                        ExibirAtualizarFrases();                       // BarraComandos.Visibility = Visibility.Visible;
                    }
                    //  string LerArquivoAtualizado = await FileIO.ReadTextAsync(sampleFile);

                    //  this.Frame.Navigate(typeof(Favoritos));
                }             
                else
                {
                }
                if (result.Label == "Não")
                {
                }
                else
                {
                }
            }
            catch
            {
            }
        }

        private void Compartilhar_Click(object sender, RoutedEventArgs e)
        {
            DataTransferManager.ShowShareUI();
        }

        private void Avancar_Frase_Click(object sender, RoutedEventArgs e)
        {
            avancar();
        }

        /// <Favoritos>
        /// METODOS
        /// </Favoritos>   
        /// </param>
        private void ShareData(DataTransferManager sender, DataRequestedEventArgs args)
        {
            try
            {
                // Compartilhar a Frase
                DataRequest request = args.Request;
                var deferral = request.GetDeferral();
                request.Data.Properties.Title = "Frases S2";
                request.Data.Properties.Description = tbFrase.Text;
                request.Data.SetText(tbFrase.Text + 
                   Environment.NewLine +
                   Environment.NewLine + " " +
                   Environment.NewLine + "ℹ #FrasesS2" + Environment.NewLine +
                    Environment.NewLine + "⚠ FRASES S2 PARA ANDROID ⚠" +
                    Environment.NewLine + "https://play.google.com/store/apps/details?id=com.companyname.FrasesS2");
                deferral.Complete();
            }
            catch (Exception)
            {
                Mensagem.ShowCatch();
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
                    // Check if user already bought this product
                    if (CurrentApp.LicenseInformation.ProductLicenses["AdBlocker"].IsActive)
                    {
                        // Promocional.Visibility = Visibility.Collapsed;
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

        private void exibirFrase(int index)
        {
            //Exibir Frase atualizada            
            frase = categoriasFrase[index].frase;
            autor = categoriasFrase[index].autor;
            tbFrase.Text = frase;
            tbAutor.Text = autor;                     
        }

        #region Avançar e Voltar Frases
        private void avancar()
        {
            try
            {
                if (index < categoriasFrase.Count - 1)
                {
                    index++;
                }

                else
                {
                    index = 1;
                }
            }
            catch (Exception)
            {
                throw new Exception("Erro ao avançar frase!");
            }           
            //Atualizando o contador
            exibirFrase(index);
            Inico_Frase.Text = index.ToString();
            Image_Categoria.Begin();
        }      

        private void retroceder()
        {
            try
            {
                if (index == 1)
                {
                    index = categoriasFrase.Count - 1;
                }
                else
                {
                    index--;

                }
            }
            catch (Exception)
            {
                throw new Exception("Erro ao voltar frase!");
            }
            //Atualizando o contador          
            exibirFrase(index);
            Inico_Frase.Text = index.ToString();
            Image_Categoria.Begin();
        }
        #endregion
    }
}