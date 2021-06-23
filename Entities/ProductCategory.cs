using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Table("ProductCategory")]
    public  class ProductCategory
    {
        [Key]
        public int ProdCatId { get; set; }
        public string CategoryName { get; set; }
    }
}
