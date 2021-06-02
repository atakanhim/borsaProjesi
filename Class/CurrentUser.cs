using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace borsaProjesi
{
    public class CurrentUser
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string UserPass { get; set; }
        public string Ad { get; set; }
        public string SoyAd { get; set; }
        public long Tc { get; set; }
        public long Telefon { get; set; }
        public string Adres { get; set; }
        public string Eposta { get; set; }
        public string Unvan { get; set; }
        public double Bakiye { get; set; }
        public double GeciciBakiye { get; set; }
        public string BakiyeOnay { get; set; }
        public string Cinsiyet { get; set; }

        public CurrentUser()
        {

        }
       
    }
}
