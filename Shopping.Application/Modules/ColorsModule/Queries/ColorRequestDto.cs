using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Application.Modules.ColorsModule.Queries
{
    public class ColorRequestDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string HexCode { get; set; }
    }
}
