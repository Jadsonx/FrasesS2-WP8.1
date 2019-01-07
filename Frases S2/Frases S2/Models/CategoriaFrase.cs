using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frases_S2.Models
{
   public class CategoriaFrase
    {   
        public string categoria { get; set; }
        public List<Frase> frases { get; set; }
    }
}
