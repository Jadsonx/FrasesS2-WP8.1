using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace Uniages
{
    class Http
    {
        private string output = "";
        
        public async Task GetString(Uri url)
        {
               

            System.Net.Http.HttpClient Https = new System.Net.Http.HttpClient();
            HttpResponseMessage Response = await Https.GetAsync(url);

            string arz = await Response.Content.ReadAsStringAsync();

            output = arz;
        
        }

        public string GetOutput()
        {
            return output;
        }
          
    }
}
