using System;
using SQLite;
using System.Collections.Generic;
using System.Text;
using CrudApp.Models;

namespace CrudApp.Data
{
    public interface ISQLite
    {

        SQLiteConnection GetConnectionWithCreateDatabase();

        bool SaveProduct(Products product);

        List<Products> GetProduct();

        bool UpdateProduct(Products product);
        void DeleteProduct(int Id);
    }
}
