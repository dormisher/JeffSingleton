﻿using System.Data.Entity;
using JeffSingleton.Models;

namespace JeffSingleton.Database
{
    public class JsDatabase : DbContext
    {
        public DbSet<GalleryImage> GalleryImages { get; set; }

        public JsDatabase()
        {
            //System.Data.Entity.Database.SetInitializer<JsDatabase>(new DropCreateDatabaseAlways<JsDatabase>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}