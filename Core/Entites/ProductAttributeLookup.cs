using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entites
{

    [Table("ProductAttributeLookup")]
    public class ProductAttributeLookup : BaseEntity
    {
       
       public string AttributeName { get; set; }
      public int ProdCatId { get; set; }
      [ForeignKey("ProdCatId")]  
      public  ProductCategory ProductCategory {get;set;}

    }
}
