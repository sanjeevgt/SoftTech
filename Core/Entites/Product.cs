using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entites
{
    [Table("Product")]
    public class Product : BaseEntity 
    {
        
        public string ProdName { get; set; }
        public string ProdDescription { get; set; }
        public int ProdCatId { get; set; }
        public string PictureUrl { get; set; }
        public decimal Price { get; set; }
        [ForeignKey("ProdCatId")]  
        public  ProductCategory ProductCategory {get;set;}
        [NotMapped]
         public  List<Dictionary<string, string>> Atttributes {get;set;}
         

    }
}
