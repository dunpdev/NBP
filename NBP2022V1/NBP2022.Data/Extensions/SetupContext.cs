using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBP2022.Data.Extensions
{
    public static class SetupDB
    {
        public static void SetupContext(this IServiceCollection service, string connectionString)
        {
            service.AddDbContext<NBPDbContext>(opt => opt.UseSqlServer(connectionString));
        }
    }
}
