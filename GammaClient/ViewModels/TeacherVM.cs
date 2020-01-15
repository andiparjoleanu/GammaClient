using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace GammaClient.ViewModels
{
    public class TeacherVM
    {
        public string MemberId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [DisplayName("Departament")]
        public string Department { get; set; }
        public string SchoolId { get; set; }
        public bool IsSelected { get; set; }
    }
}
