using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbmsAPI.Application.Features.Queries.Category.GetAllCategories
{
    public class GetAllCategoriesQueryResponse
    {
        public string Id { get; set; }
        public string CategoryName { get; set; }
        public string? ParentCategoryId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
