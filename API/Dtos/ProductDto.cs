using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string ProdName { get; set; }
        public string ProdDescription { get; set; }
        public string PictureUrl { get; set; }
        public string ProductCategory { get; set; }
         public decimal Price { get; set; }
        public  List<Dictionary<string, string>> Atttributes {get;set;}
    }
}
