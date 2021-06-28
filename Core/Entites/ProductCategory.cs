using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entites
{
    [Table("ProductCategory")]
    public class ProductCategory :BaseEntity
    {
      public string CategoryName { get; set; }

    }
}
