﻿using ManagementOfExams.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManagementOfExams.Repos
{
    public class DetailRepository : Repository
    {
        public DetailRepository(ManagementContext detailContext) : base(detailContext)
        {
        }
    }
}