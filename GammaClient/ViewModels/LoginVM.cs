using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GammaClient.ViewModels
{
    public class LoginVM
    {
        [DisplayName("Nume de utilizator")]
        public string UserName { get; set; }

        [DisplayName("Parolă")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
