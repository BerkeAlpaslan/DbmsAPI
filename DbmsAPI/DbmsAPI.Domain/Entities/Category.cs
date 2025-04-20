using DbmsAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbmsAPI.Domain.Entities
{
    public class Category : BaseEntity
    {
        public Guid? ParentCategoryId { get; set; }
        public Category ParentCategory { get; set; }
        public ICollection<Product> Products { get; set; }
        public string CategoryName { get; set; }
    }
}
