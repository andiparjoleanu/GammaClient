using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GammaClient.ViewModels
{
    public class ResultVM
    {
        public Status Status { get; set; }
        public string Message { get; set; }
    }

    public enum Status
    {
        Success, Error
    }
}
