using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Application.Modules.SizesModule.Queries
{
    public class SizeRequestDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SmallName { get; set; }
    }
}
