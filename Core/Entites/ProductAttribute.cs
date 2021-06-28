using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entites
{
    [Table("ProductAttribute")]
    public class ProductAttribute : BaseEntity
    {
       
        public int AttributeId { get; set; }
        public string AttributeValue {get; set;}
        [ForeignKey("AttributeId")]
        public ProductAttributeLookup ProductAttributeLookup {get;set;}
    }
}
