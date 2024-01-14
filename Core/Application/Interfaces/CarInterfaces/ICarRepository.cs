using Application.Features.CQRS.Results.CarResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.CarInterfaces
{
    public interface ICarRepository
    {
        IEnumerable<GetCarWithBrandQueryResult> GetCarWithBrandName();
    }
}
