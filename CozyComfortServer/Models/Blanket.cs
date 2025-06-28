using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CozyComfortServer.Models
{
    public class Blanket
    {
        public int BlanketId { get; set; }
        public string BlanketName { get; set; }
        public Material Material { get; set; }
        public int ProductionCapacity { get; set; }
        public double Price { get; set; }
    }
}