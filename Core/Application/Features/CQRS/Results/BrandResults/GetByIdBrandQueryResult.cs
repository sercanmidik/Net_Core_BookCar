﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CQRS.Results.BrandResults
{
    public class GetByIdBrandQueryResult
    {
        public int BrandId { get; set; }
        public string Name { get; set; }
    }
}
