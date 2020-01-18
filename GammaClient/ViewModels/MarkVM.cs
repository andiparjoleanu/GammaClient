using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GammaClient.ViewModels
{
    public class MarkVM
    {
        [DisplayName("Data")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime Date { get; set; }

        [DisplayName("Nota")]
        public int Value { get; set; }

        [DisplayName("Detalii")]
        public string Note { get; set; }
        public string StudentId { get; set; }
        public string CourseId { get; set; }
    }
}
