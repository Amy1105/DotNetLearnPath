using AutoMapperDemo.Models;
using AutoMapperDemo.Seed;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace AutoMapperDemo.Services
{
    public class BulkExecute
    {
        private readonly SchoolContext context;
        public BulkExecute(SchoolContext _context)
        {
            context = _context;
        }

        private const int Count = 10000;

        public void InitDB()
        {
            //context.Database.EnsureDeleted();
            //建库
            context.Database.EnsureCreated();
            //初始化数据
            DbInitializer.Initialize(context);
            Console.WriteLine("data init.");
        }

    }
}
