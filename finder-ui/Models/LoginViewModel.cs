using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace finder_ui.Models
{
    public class LoginViewModel
    {
        public string username { get; set; }
        public string userPassword { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
    }
}