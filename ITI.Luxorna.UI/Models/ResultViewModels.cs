using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITI.Luxorna.UI
{
    public class ResultViewModels<T>
    {
        public bool Successed { get; set; } = false;
        public T Data { get; set; }
        public string Message { get; set; } = "";
        public string Token { get; set; } = "";

    }
}