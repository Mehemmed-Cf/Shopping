using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Application.Modules.MaterialsModule.Queries.MaterialGetByIdQuery
{
    public class MaterialGetByIdRequest : IRequest<MaterialRequestDto>
    {
        public int Id { get; set; }
        public bool OnlyAvailable { get; set; } = true;
    }
}
