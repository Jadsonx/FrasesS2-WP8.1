using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Email;
using Windows.UI.Popups;
using Windows.UI.Xaml;

namespace Frases_S2.Models
{
    class Mensagem
    {
        public async static void ShowMsg(string Texto, string titulo)
        {
            MessageDialog msgs = new MessageDialog(Texto.ToString(), titulo.ToString());
            await msgs.ShowAsync();
        }

        public async static void ShowCatch()
        {
            MessageDialog msgs = new MessageDialog("Estamos trabalhando para corrigir.", "Desculpe, algo não esta funcionando corretamente!");
            await msgs.ShowAsync();
        }
       
        public async static void ShowLOG(string exLOG)
        {
            
                MessageDialog BUG = new MessageDialog("Estamos trabalhando para corrigir!", "Algo esta acontecendo...");
                BUG.Commands.Add(new UICommand("OK"));
                BUG.Commands.Add(new UICommand("Enviar LOG"));
                var result = await BUG.ShowAsync();
               
                if (result.Label == "Enviar LOG")
                {
                    var arzLocal = Windows.Storage.ApplicationData.Current.LocalSettings;
                    if (arzLocal.Values.ContainsKey("Nome"))
                    {
                   
                    EmailMessage email = new EmailMessage();
                        email.Subject = "Frases S2 - LOG : " + arzLocal.Values["Nome"].ToString();
                        email.Body = "" + exLOG.ToString() + ":" + Environment.NewLine  + "" + Environment.NewLine + Environment.NewLine;
                        email.To.Add(new EmailRecipient("Jadson0102@live.com", "Jadson Santos"));

                        await EmailManager.ShowComposeNewEmailAsync(email);
                    }
                    else
                    {
                        EmailMessage email = new EmailMessage();
                        email.Subject = "Frases S2 - LOG";
                        email.Body = "" + exLOG.ToString()+ " -- " + Environment.NewLine + "" + Environment.NewLine + Environment.NewLine;
                        email.To.Add(new EmailRecipient("Jadson0102@live.com", "Jadson Santos"));

                        await EmailManager.ShowComposeNewEmailAsync(email);

                    }
                }

                else
                {

                }                     
        }
    }
}