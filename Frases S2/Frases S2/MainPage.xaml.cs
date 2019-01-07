using Frases_S2.Models;
using Microsoft.AdMediator.Core.Events;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using Uniages;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Email;
using Windows.ApplicationModel.Store;
using Windows.Networking.Connectivity;
using Windows.Storage;
using Windows.System;
using Windows.UI;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;


namespace Frases_S2
{

    public sealed partial class MainPage : Page
    {       
        public MainPage()
        {
            this.InitializeComponent();         
            this.Loaded += MainPage_Loaded;
            GetOnlineFrases();
            Verificar_CompraIAPs();           
            this.NavigationCacheMode = NavigationCacheMode.Required;
        }      

        private void Home_ADS_AdMediatorError(object sender, Microsoft.AdMediator.Core.Events.AdMediatorFailedEventArgs e)
        {
            if (e.ErrorCode == AdMediatorErrorCode.NoAdAvailable & (CurrentApp.LicenseInformation.ProductLicenses["AdBlocker"].IsActive))
                Home_ADS.Visibility = Visibility.Collapsed;
            else
                Home_ADS.Visibility = Visibility.Visible;
        }
      
        private async void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            var statusBar = Windows.UI.ViewManagement.StatusBar.GetForCurrentView();
            statusBar.BackgroundColor = Color.FromArgb(255, 30, 144, 255);
            statusBar.BackgroundOpacity = 100;            
            await statusBar.ShowAsync();        
            CarrgarImagens();
            Verificar_CompraIAPs();         
        }     

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {          
            Verificar_CompraIAPs();

            try
            {
                //Pegando o Objeto que foi armazenado
                var arzLocal = ApplicationData.Current.LocalSettings;
                if (arzLocal.Values.ContainsKey("Nome"))
                {
                    //Se já existir algum dado Exibi-lo!
                    Visitante.Text = "Olá, " + arzLocal.Values["Nome"] + " " + arzLocal.Values["Sobrenome"];
               
                }
                else
                {
                    Visitante.Text = "Olá, Visitante!";
                   
                }
            }
            catch (Exception ex)
            {
                Mensagem.ShowMsg("Algo não funcionou corretamente!", ex.ToString());
            }
         
        }    

        //Navegar pelas categorias de acordo com os Nomes!
        private async void listitem_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //string NomeRepublica = (listitem.SelectedItem as CtgImagem).ImgCategorias.ToString();
            if (listitem.SelectedIndex == 0)
            {
                await Launcher.LaunchUriAsync(new Uri("https://api.whatsapp.com/send?phone=5579998682289&text=Olá,%20Quero%20participar%20do%20grupo%20Frases%20S2!"));
            }
            if (listitem.SelectedIndex == 1)
            {                            
                NavegarCategoriasOnline("Mensagens de Amizade");                                            
            }
            if (listitem.SelectedIndex == 2)
            {
                NavegarCategoriasOnline("Mensagens de Amor");
            }
            if (listitem.SelectedIndex == 3)
            {
                NavegarCategoriasOnline("Mensagens de Aniversário");
            }
            if (listitem.SelectedIndex == 4)
            {
                NavegarCategoriasOnline("Mensagens de Ano Novo");
            }
            if (listitem.SelectedIndex == 5)
            {
                await Launcher.LaunchUriAsync(new Uri("https://www.instagram.com/jadsonxsantos/"));
            }
            if (listitem.SelectedIndex == 6)
            {
                NavegarCategoriasOnline("Mensagens de Boa Noite");
            }
            if (listitem.SelectedIndex == 7)
            {
                NavegarCategoriasOnline("Mensagens de Boa Tarde");
            }
            if (listitem.SelectedIndex == 8)
            {
                NavegarCategoriasOnline("Mensagens de Bom Dia");
            }
            if (listitem.SelectedIndex == 9)
            {
                await Launcher.LaunchUriAsync(new Uri("https://api.whatsapp.com/send?phone=5579998682289&text=Olá,%20Quero%20participar%20do%20grupo%20Frases%20S2!"));
            }
            if (listitem.SelectedIndex == 10)
            {
                NavegarCategoriasOnline("Mensagens de Ciúmes");
            }
            if (listitem.SelectedIndex == 11)
            {
                NavegarCategoriasOnline("Mensagens de Decepção");
            }
            if (listitem.SelectedIndex == 12)
            {
                NavegarCategoriasOnline("Mensagens de Desculpas");
            }
            if (listitem.SelectedIndex == 13)
            {
                NavegarCategoriasOnline("Mensagens de Deus");
            }
            if (listitem.SelectedIndex == 14)
            {
                await Launcher.LaunchUriAsync(new Uri("https://www.instagram.com/jadsonxsantos/"));             
            }
            if (listitem.SelectedIndex == 15)
            {
                NavegarCategoriasOnline("Mensagens de Dia das Mães");
            }
            if (listitem.SelectedIndex == 16)
            {
                NavegarCategoriasOnline("Mensagens de Dia dos Pais");
            }
            if (listitem.SelectedIndex == 17)
            {
                NavegarCategoriasOnline("Mensagens Engraçadas");
            }
            if (listitem.SelectedIndex == 18)
            {
                NavegarCategoriasOnline("Mensagens de Natal");
            }
            if (listitem.SelectedIndex == 19)
            {
                NavegarCategoriasOnline("Mensagens de Filmes");
            }
            if (listitem.SelectedIndex == 20)
            {
                await Launcher.LaunchUriAsync(new Uri("https://api.whatsapp.com/send?phone=5579998682289&text=Olá,%20Quero%20participar%20do%20grupo%20Frases%20S2!"));          
            }
            if (listitem.SelectedIndex == 21)
            {
                NavegarCategoriasOnline("Mensagens de Indiretas");
            }
            if (listitem.SelectedIndex == 22)
            {
                NavegarCategoriasOnline("Mensagens de Livros");
            }
            if (listitem.SelectedIndex == 23)
            {
                NavegarCategoriasOnline("Mensagens de Motivação");
            }
            if (listitem.SelectedIndex == 24)
            {
                NavegarCategoriasOnline("Mensagens de Músicas");
            }
            if (listitem.SelectedIndex == 25)
            {
                NavegarCategoriasOnline("Mensagens de Reflexão");
            }
            if (listitem.SelectedIndex == 26)
            {
                NavegarCategoriasOnline("Mensagens de Saudades");
            }
            if (listitem.SelectedIndex == 27)
            {
                NavegarCategoriasOnline("Mensagens de Tristeza");
            }
        }

        private void Pesquisar_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(View.Pesquisa));
        }

        private void MenuIcone_Tapped(object sender, TappedRoutedEventArgs e)
        {
            BarraComandos.ClosedDisplayMode = AppBarClosedDisplayMode.Compact;
        }

        private void Sobre_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(View.Sobre));
        }

        private void Favoritos_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(View.Favoritos));
        }

        private void Configuracoes_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(View.Configs));
        }

        private async void FeedBack_Click(object sender, RoutedEventArgs e)
        {
            var version = Package.Current.Id.Version;

            string appVersion = String.Format("{0}.{1}.{2}.{3}", version.Major, version.Minor, version.Build, version.Revision);

            var arzLocal = ApplicationData.Current.LocalSettings;
            if (arzLocal.Values.ContainsKey("Nome"))
            {
                EmailMessage email = new EmailMessage();
                email.Subject = "Frases S2 - FeedBack : " + arzLocal.Values["Nome"].ToString();
                email.Body = "FS2: " + appVersion + Environment.NewLine + Environment.NewLine + " " + Environment.NewLine + Environment.NewLine;
                email.To.Add(new EmailRecipient("Jadson0102@live.com", "Jadson Santos"));

                await EmailManager.ShowComposeNewEmailAsync(email);
            }
            else
            {
                EmailMessage email = new EmailMessage();
                email.Subject = "Frases S2 - FeedBack";
                email.Body = "FS2: " + appVersion + Environment.NewLine + Environment.NewLine + " " + Environment.NewLine + "" + Environment.NewLine;
                email.To.Add(new EmailRecipient("Jadson0102@live.com", "Jadson Santos"));

                await EmailManager.ShowComposeNewEmailAsync(email);

            }
        }

        private void Remove_ADS_Click(object sender, RoutedEventArgs e)
        {
            removerAnuncios();
        }

        private async void Avaliar_Click(object sender, RoutedEventArgs e)
        {
            await Windows.System.Launcher.LaunchUriAsync(new Uri("ms-windows-store:reviewapp?appid=" + CurrentApp.AppId));
        }

        //Metodo Carregar as Categorias
        private void CarrgarImagens()
        {
            List<CtgImagem> lista = new List<CtgImagem>();
            lista.Add(new CtgImagem { ImgCategorias = "Assets/Image/Categorias/Whatsapp.jpg" });
            lista.Add(new CtgImagem { ImgCategorias = "Assets/Image/Categorias/Inicio-amizade-bloco.jpg" });
            lista.Add(new CtgImagem { ImgCategorias = "Assets/Image/Categorias/Inicio-amor-bloco.jpg" });
            lista.Add(new CtgImagem { ImgCategorias = "Assets/Image/Categorias/Inicio-aniversario-bloco.jpg" });
            lista.Add(new CtgImagem { ImgCategorias = "Assets/Image/Categorias/Inicio-ano-novo-bloco.jpg" });
            lista.Add(new CtgImagem { ImgCategorias = "Assets/Image/Categorias/enviarfrase.jpg" });
            lista.Add(new CtgImagem { ImgCategorias = "Assets/Image/Categorias/Inicio-boa-noite-bloco.jpg" });
            lista.Add(new CtgImagem { ImgCategorias = "Assets/Image/Categorias/Inicio-boa-tarde-bloco.jpg" });
            lista.Add(new CtgImagem { ImgCategorias = "Assets/Image/Categorias/Inicio-bom-dia-bloco.jpg" });
            lista.Add(new CtgImagem { ImgCategorias = "Assets/Image/Categorias/Whatsapp.jpg" });
            lista.Add(new CtgImagem { ImgCategorias = "Assets/Image/Categorias/Inicio-ciumes-bloco.jpg" });
            lista.Add(new CtgImagem { ImgCategorias = "Assets/Image/Categorias/Inicio-decepcao-bloco.jpg" });
            lista.Add(new CtgImagem { ImgCategorias = "Assets/Image/Categorias/Inicio-desculpas-bloco.jpg" });
            lista.Add(new CtgImagem { ImgCategorias = "Assets/Image/Categorias/Inicio-deus-bloco.jpg" });
            lista.Add(new CtgImagem { ImgCategorias = "Assets/Image/Categorias/enviarfrase.jpg" });
            lista.Add(new CtgImagem { ImgCategorias = "Assets/Image/Categorias/Inicio-dia-das-maes-bloco.jpg" });
            lista.Add(new CtgImagem { ImgCategorias = "Assets/Image/Categorias/Inicio-dia-dos-pais-bloco.jpg" });
            lista.Add(new CtgImagem { ImgCategorias = "Assets/Image/Categorias/Inicio-engracadas-bloco.jpg" });
            lista.Add(new CtgImagem { ImgCategorias = "Assets/Image/Categorias/Inicio-feliz-natal-bloco.jpg" });
            lista.Add(new CtgImagem { ImgCategorias = "Assets/Image/Categorias/Inicio-filmes-bloco.jpg" });
            lista.Add(new CtgImagem { ImgCategorias = "Assets/Image/Categorias/Whatsapp.jpg" });
            lista.Add(new CtgImagem { ImgCategorias = "Assets/Image/Categorias/Inicio-indiretas-bloco.jpg" });
            lista.Add(new CtgImagem { ImgCategorias = "Assets/Image/Categorias/Inicio-livros-bloco.jpg" });
            lista.Add(new CtgImagem { ImgCategorias = "Assets/Image/Categorias/Inicio-motivacao-bloco.jpg" });
            lista.Add(new CtgImagem { ImgCategorias = "Assets/Image/Categorias/Inicio-musica-bloco.jpg" });
            lista.Add(new CtgImagem { ImgCategorias = "Assets/Image/Categorias/Inicio-reflexao-bloco.jpg" });
            lista.Add(new CtgImagem { ImgCategorias = "Assets/Image/Categorias/Inicio-saudades-bloco.jpg" });
            lista.Add(new CtgImagem { ImgCategorias = "Assets/Image/Categorias/Inicio-tristeza-bloco.jpg" });
            lista.Add(new CtgImagem { ImgCategorias = "" });
            listitem.ItemsSource = lista;
        }
        //Metodo para verificara compra de IAP
        public async void Verificar_CompraIAPs()
        {
            try
            {
                var listing = await CurrentApp.LoadListingInformationAsync();
                // Select the right product, use the information that we used when submitting the in-app purchase to the store
                var product = listing.ProductListings.FirstOrDefault(p => p.Value.ProductId == "AdBlocker" && p.Value.ProductType == ProductType.Durable);
                try
                {
                    // Verifica se o produto já foi comprado!
                    if (CurrentApp.LicenseInformation.ProductLicenses["AdBlocker"].IsActive)
                    {
                        Home_ADS.Visibility = Visibility.Collapsed;

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
        //Metodo para remover os Anuncios Caso a compra tenha sido feita
        public async void removerAnuncios()
        {
            try
            {
                var listing = await CurrentApp.LoadListingInformationAsync();
                // Select the right product, use the information that we used when submitting the in-app purchase to the store
                var product = listing.ProductListings.FirstOrDefault(p => p.Value.ProductId == "AdBlocker" && p.Value.ProductType == ProductType.Durable);
                try
                {
                    // Verificando se o roduto já foi comprado!
                    if (CurrentApp.LicenseInformation.ProductLicenses["AdBlocker"].IsActive)
                    {
                        //Compra já foi realizada
                        Mensagem.ShowMsg("Você já comprou este produto!", "Compra já realizada!");

                        Home_ADS.Visibility = Visibility.Collapsed;

                    }
                    else
                    {
                        //Compra realizada com sucesso!
                        await CurrentApp.RequestProductPurchaseAsync("AdBlocker");
                        Home_ADS.Visibility = Visibility.Collapsed;

                        Mensagem.ShowMsg("Você Comprou o Produto! Os Anúncios foram removidos! OBRIGADO", "Removemos os Anúncios!");
                    }
                }
                catch (Exception)
                {
                    Models.Mensagem.ShowCatch();
                }
            }
            catch (Exception)
            {
                Models.Mensagem.ShowCatch();
            }


        }

        private async void NavegarCategoriasOnline(string Categoria)
        {
            string texto;

            try
            {
                StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
                StorageFile sampleFile = await storageFolder.GetFileAsync("MinhasFrases.txt");
                 texto = await FileIO.ReadTextAsync(sampleFile);

                List<CategoriaFrase> categoriasFrase = JsonConvert.DeserializeObject<List<CategoriaFrase>>(texto);

                // Selecionar o objeto.
                CategoriaFrase categoriaFrase = categoriasFrase.FirstOrDefault(cf => cf.categoria.Equals(Categoria));

                if (categoriaFrase != null)
                {
                    // Abre tela e envia os parâmetros.                                 
                    this.Frame.Navigate(typeof(Visualizar), categoriaFrase);
                }
            }
            catch
            {
                Mensagem.ShowMsg("Para ter acesso as frases atualizadas, você precisa conectar a internet e abrir o aplicativo uma única vez!", "Sem Conexão com a Internet");
            }
        }

        private async void NavegarCategorias(string Categoria)
        {
            string texto;

            try
            {
                StorageFile file = await StorageFile.GetFileFromApplicationUriAsync(new Uri(@"ms-appx:///Categorias/Frases.txt"));

                using (StreamReader sRead = new StreamReader(await file.OpenStreamForReadAsync()))
                    texto = await sRead.ReadToEndAsync();

                List<CategoriaFrase> categoriasFrase = JsonConvert.DeserializeObject<List<CategoriaFrase>>(texto);

                // Selecionar o objeto.
                CategoriaFrase categoriaFrase = categoriasFrase.FirstOrDefault(cf => cf.categoria.Equals(Categoria));

                if (categoriaFrase != null)
                {
                    // Abre tela e envia os parâmetros.                                 
                    this.Frame.Navigate(typeof(Visualizar), categoriaFrase);
                }
            }
            catch
            {
                Mensagem.ShowCatch();
            }
        }

        private async void GetOnlineFrases()
        {
            string MyFile;
         
            try
            {
                //Criando arquivo de Frases
                StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
                StorageFile sampleFile = await storageFolder.CreateFileAsync("MinhasFrases.txt", CreationCollisionOption.OpenIfExists);
                MyFile = await FileIO.ReadTextAsync(sampleFile);

                if (MyFile != null)
                {
                    // Pegando as frases Online. 
                    HttpClient http = new System.Net.Http.HttpClient();
                    HttpResponseMessage response = await http.GetAsync("https://frasess2-1533075044133.firebaseio.com/.json/");
                    string respos = await response.Content.ReadAsStringAsync();    
                    if(response.IsSuccessStatusCode)
                    {
                        //Reescrever as Frases no arquivo!
                        await FileIO.WriteTextAsync(sampleFile, respos);                     
                    }  
                    else
                    {

                    }                                   
                }                                        
            }
            catch(Exception)
            {                                         
            }
        }
      
    }
}

           