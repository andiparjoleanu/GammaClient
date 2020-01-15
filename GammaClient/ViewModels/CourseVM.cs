using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace GammaClient.ViewModels
{
    public class CourseVM
    {
        public string CourseId { get; set; }

        [DisplayName("Clasa / An")]
        public int Grade { get; set; }

        [DisplayName("Domeniu de studiu")]
        public string FieldOfStudy { get; set; }

        [DisplayName("Denumire")]
        public string Name { get; set; }

        [DisplayName("Descriere")]
        public string Description { get; set; }

        public string TeacherId { get; set; }
    }
}
