﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UriStore.Infrastructure.Context
{
    public interface ISqlConnectionFactory
    {
        IDbConnection GetOpenConnection();
    }
}
