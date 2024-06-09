using MediatR;
using Shopping.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Application.Modules.MaterialsModule.Commands.MaterialEditCommand
{
    public class MaterialEditRequest : IRequest<Material>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
