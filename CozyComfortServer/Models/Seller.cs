using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CozyComfortServer.Models
{
    public class Seller:User
    {
        public string SellerName { get; set; }
        public string SellerAddress { get; set; }
        public string SellerEmail { get; set; }
        public string SellerMobile { get; set; }
        public string SellerStatus { get; set; }
    }
}