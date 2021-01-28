using Microsoft.EntityFrameworkCore;
using System;


namespace OnlineClearanceCore.Core.Data
{
    public interface IDbContext :IDisposable
    {
        DbContext Instance { get; }
    }
}
