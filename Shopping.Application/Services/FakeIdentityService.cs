﻿using Shopping.Infrastructure.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Application.Services
{
    public class FakeIdentityService : IIdentityService
    {
        public int? GetPrincipialId()
        {
            return 1;
        }
    }
}
