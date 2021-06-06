using System;
using SQLite;
using System.Collections.Generic;
using System.Text;
using CrudApp.Models;

namespace CrudApp.Data
{
    class ProductDatabase
    {

        readonly SQLiteAsyncConnection database;

        public ProductDatabase(string dbpath)
        {

            database = new SQLiteAsyncConnection(dbpath);
            database.CreateTableAsync<Products>().Wait();

        }
    }
}
