using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GammaClient.ViewModels
{
    public class SchoolVM
    {
        public string Id { get; set; }

        [DisplayName("Denumire")]
        public string Name { get; set; }

        [DisplayName("Tip de învățământ")]
        public string Type { get; set; }

        [DisplayName("Adresă")]
        public string Address { get; set; }

        [DisplayName("Telefon")]
        public string Phone { get; set; }

        [DisplayName("Mail")]
        public string Mail { get; set; }
    }
}
