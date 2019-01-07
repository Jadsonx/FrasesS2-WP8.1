using Frases_S2.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace Frases_S2.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Pesquisa : Page
    {      
        int index = 1;
        string frase, autor;
        List<Frase> frasesFiltradas;
        public Pesquisa()
        {
            this.InitializeComponent();          
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
          
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
        //    if (!string.IsNullOrEmpty(Pesquisar.Text) || (!string.IsNullOrWhiteSpace(Pesquisar.Text)))
        //    {
        //        string texto;
        //        try
        //        {
        //            StorageFile file = await StorageFile.GetFileFromApplicationUriAsync(new Uri(@"ms-appx:///Categorias/Frases.txt"));

        //            using (StreamReader sRead = new StreamReader(await file.OpenStreamForReadAsync()))
        //                texto = await sRead.ReadToEndAsync();

        //            Consultarfrase = JsonConvert.DeserializeObject<List<CategoriaFrase>>(texto);
        //            foreach (CategoriaFrase frase in Consultarfrase)
        //            {
        //                Mensagem.ShowMsg(frase.frases.ToString(), "");

        //                ///VOU FECHAR QUANDO VC VOLTAR ME AVISA BLZ...
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            Mensagem.ShowMsg(ex.ToString(), "");
        //        }

        //        if (Consultarfrase != null)
        //        {
        //            string query = "amor";// null;
        //            List<string> lst = new List<string>();
        //            foreach (CategoriaFrase frase in Consultarfrase)
        //            //{
        //            //    if (frase.frases.ToArray().Contains(query) == true) { //aparentemente é aqui
        //            //        lst.Add(frase.frases.ToArray());
        //            //    }
        //            }
        //            //cass.ItemsSource = lst;

        //            //Adicionando a busca em uma lista de objetos do tipo Frase
        //            //var frasesFiltradasss = Consultarfrase[index].frases.Where(f => f.frase.Contains(Pesquisar.Text.ToLower())).ToList();
        //            ////var consulta = from lv in Consultarfrase select new { lv.frase};

        //            ////consulta = consulta.Where(livro => livro.frase.Contains("amor"));
                  
        //            ////cass.ItemsSource = consulta.ToList();
                    

        //            // // 3. Query execution.
        //            // foreach (var num in frasesFiltradasss)
        //            // {
        //            //     List<string> sdad = new List<string>();

        //            //     sdad.Add(num.frase.ToString());

        //            //     cass.ItemsSource = sdad;
        //            // }


        //            // Mensagem.ShowMsg("asd", sdad.ToString());

        //            //if (frasesFiltradas != null)
        //            //{

        //            //    int indexTotal = frasesFiltradas.Count() - 1;

        //            //    //Atribuindo a frase pesquisada a interface de usuario
        //            //    tbFrase.Text = frasesFiltradas[index].frase.ToString();
        //            //    tbAutor.Text = frasesFiltradas[index].autor.ToString();
        //            //    Total_Frase.Text = indexTotal.ToString();
        //            //    Inico_Frase.Text = index.ToString();

        //            //    exibirFrase(index);
        //            //    //Chamando o Método para ocultar a barra de comandos            
        //            //    ocultarBarraDecomandos();

        //            //    //Limpando os dados
        //            //    Pesquisar.Text = "";
        //            //}
        //            //else
        //            //{
        //            //    tbFrase.Text = "Não encontramos nenhuma frase com a palavra: " + Pesquisar.Text + " Tente outras palavras como:";
        //            //    tbAutor.Text = "amor, amizade, vida, Deus, filmes...";
        //            //}
        //        }

        //        else
        //        {
        //            Mensagem.ShowCatch();
        //        }                                                   
        //    }
        //    else
        //    {

        //        Mensagem.ShowMsg("Não esqueça de digitar uma palavra para realizar a pesquisa!", "ATENÇÃO");
        //   }
        }

        private void ocultarBarraDecomandos()
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
        
    
        private void exibirFrase(int index)
        {
            //Exibir Frase atualizada            
            frase = frasesFiltradas[index].frase.ToString();
            autor = frasesFiltradas[index].autor.ToString();
            Total_Frase.Text = frasesFiltradas.Count().ToString();
            tbFrase.Text = frase;
            tbAutor.Text = autor;
        }      

        private void Voltar_Frase_Click(object sender, RoutedEventArgs e)
        {
            retroceder();
        }

        private void Avancar_Frase_Click(object sender, RoutedEventArgs e)
        {
            avancar();
        }

        #region Avançar e Voltar Frases
        private void avancar()
        {
            if (index < frasesFiltradas.Count() - 1)
            {
                index++;
            }

            else
            {
                index = 1;
            }
            exibirFrase(index);
            
        }

        private void Pesquisar_Tapped(object sender, TappedRoutedEventArgs e)
        {
          //  index = 1;
            tbFrase.Text = "";
        }

        private void retroceder()
        {
            if (index == 1)
            {
                index = frasesFiltradas.Count() - 1;
            }
            else
            {
                index--;

            }
            exibirFrase(index);

          
        }
        #endregion
    }
}
