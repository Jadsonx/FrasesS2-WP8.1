using Frases_S2.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Uniages;
using Windows.ApplicationModel.Store;
using Windows.Data.Xml.Dom;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Notifications;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Windows.Storage;

namespace Frases_S2.View
{
    public sealed partial class Configs : Page
    {
      

        public Configs()
        {
            this.InitializeComponent();
        }
       
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {           
            //Pegando o Objeto que foi armazenado e Exibindo ao abrir a Pagina;
            var arzLocal = ApplicationData.Current.LocalSettings;
         
            //Verificando se Já Contem algum Conteudo dentro do Objeto;
            if (arzLocal.Values.ContainsKey("Nome") && arzLocal.Values.ContainsKey("Sobrenome") && arzLocal.Values.ContainsKey("Idade"))
            {
                Usuario_Nome.Text = arzLocal.Values["Nome"].ToString();
                Usuario_SobreNome.Text = arzLocal.Values["Sobrenome"].ToString();
                Usuario_Idade.Text = arzLocal.Values["Idade"].ToString();
            }
            else
            {
                Usuario_Nome.PlaceholderText = "Ex.: Jadson";
                Usuario_SobreNome.PlaceholderText = "Ex.: Santos";
                Usuario_Idade.PlaceholderText = "00";
            }
        }
        

        private void Salvar_Configs_Click(object sender, RoutedEventArgs e)
        {

            if (!string.IsNullOrEmpty(Usuario_Nome.Text) && (!string.IsNullOrEmpty(Usuario_SobreNome.Text) && (!string.IsNullOrEmpty(Usuario_Idade.Text))))
            {
                var arzLocal = ApplicationData.Current.LocalSettings;
                if (Usuario_Nome.Text == "")
                {
                    arzLocal.Values["Nome"] = "Visitante";
                }
                else
                {
                    arzLocal.Values["Nome"] = Usuario_Nome.Text;
                    arzLocal.Values["Sobrenome"] = Usuario_SobreNome.Text;
                    arzLocal.Values["Idade"] = Usuario_Idade.Text;
                }

                Mensagem.ShowMsg("Configurações Salvas! Você verá as alterações ao sair dessa página.", "Olá, " + arzLocal.Values["Nome"] + " "+ arzLocal.Values["Sobrenome"]);
            }
            else
            {
                var arzLocal = ApplicationData.Current.LocalSettings;
                Mensagem.ShowMsg("Preencha todos os campos e depois toque em salvar alterações!", "Olá, " + arzLocal.Values["Nome"] + " " + arzLocal.Values["Sobrenome"]);

            }
        }                
    }
}