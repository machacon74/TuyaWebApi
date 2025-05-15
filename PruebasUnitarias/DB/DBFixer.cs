using Infrastructure.DB;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebasUnitarias.DB
{
    public class DBFixer
    {
        public AppDbContext DbContext { get; }

        public DBFixer()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase("TestDB")
                .Options;

            DbContext = new AppDbContext(options);
        }
    }

}
