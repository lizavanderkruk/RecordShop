using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RecordShop.Models
{
    public class ProductenModel
    {
        public string Naam { get; set; }
        public string ReleaseDate { get; set; }
        public string Artiest { get; set; }
        public string Genre { get; set; }

        [DataType(DataType.Currency)]
        public decimal Prijs { get; set; }
        public int ProductID { get; set; }
        public bool Populair { get; set; }
        public int TotaleVoorraad { get; set; }
    }
}
