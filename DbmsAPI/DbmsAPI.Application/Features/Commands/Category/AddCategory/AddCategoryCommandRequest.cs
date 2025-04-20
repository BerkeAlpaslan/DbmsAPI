using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbmsAPI.Application.Features.Commands.Category.AddCategory
{
    public class AddCategoryCommandRequest : IRequest<AddCategoryCommandResponse>
    {
        public string CategoryName { get; set; }
        public string? ParentCategoryId { get; set; }
    }
}
