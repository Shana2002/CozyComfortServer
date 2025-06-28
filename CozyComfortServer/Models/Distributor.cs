using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CozyComfortServer.Models
{
    public class Distributor:User
    {
        public string DistributorName { get; set; }
        public string DistributorAddress { get; set; }
        public bool DistributorVerification { get; set; }
        public string DistributorEmail { get; set; }
        public string DistributorPhone { get; set; }
    }
}