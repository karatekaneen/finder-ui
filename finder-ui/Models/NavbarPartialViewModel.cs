using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace finder_ui.Models
{
    public class NavbarPartialViewModel
    {
        public bool LoggedIn { get; set; }
        public string Username { get; set; }
        public int UserId { get; set; }
        public string UserPicture { get; set; }
    }
}