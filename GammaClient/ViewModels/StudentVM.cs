using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace GammaClient.ViewModels
{
    public class StudentVM
    {
        public string MemberId { get; set; }
        
        [DisplayName("Clasă / An")]
        public int Grade { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [DisplayName("Domeniu de studiu")]
        public string FieldOfStudy { get; set; }
        public string SchoolId { get; set; }
        public bool IsSelected { get; set; }
    }
}
