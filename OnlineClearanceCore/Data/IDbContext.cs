﻿using Microsoft.EntityFrameworkCore;
using System;


namespace EdoTrafficMgtCore.Core.Data
{
    public interface IDbContext :IDisposable
    {
        DbContext Instance { get; }
    }
}
