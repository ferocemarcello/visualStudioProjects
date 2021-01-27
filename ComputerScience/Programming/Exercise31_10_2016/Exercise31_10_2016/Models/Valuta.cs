using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Exercise31_10_2016.Models
{
    public class Valuta
    {
        public string ISO { get; set; }
        public double ExRate { get; set; }
        public Valuta(string ISO, double ExRate)
        {
            this.ISO = ISO;
            this.ExRate = ExRate;
        }
    }
}