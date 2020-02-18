﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class SetBlogDataContext : DbContext
    {
        static SetBlogDataContext()
        {
                System.Data.Entity.Database.SetInitializer(new SetBlogDataContextInitializer());
        }
        public SetBlogDataContext() : base()
        {
        }


        public DbSet<Article> Articles { get; set; }
        public  DbSet<RecallData> Recalls { get; set; }

    }
}
        