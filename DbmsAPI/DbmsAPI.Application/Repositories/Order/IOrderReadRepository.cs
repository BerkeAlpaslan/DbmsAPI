﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbmsAPI.Application.Repositories.Order
{
    public interface IOrderReadRepository : IReadRepository<Domain.Entities.Order>
    {
    }
}
