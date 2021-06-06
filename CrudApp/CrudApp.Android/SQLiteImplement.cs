using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using CrudApp;
using SQLite;
using CrudApp.Data;
using CrudApp.Models;

namespace CrudApp.Droid
{
    class SQLiteImplement : ISQLite
    {
        SQLiteConnection con;

        public SQLiteConnection GetConnectionWithCreateDatabase()
        {
            string filename = "crudproduct.db";
            string documentPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string path = Path.Combine(documentPath, filename);
            con = new SQLiteConnection(path);
            con.CreateTable<Products>();
            return con;
        }
        public List<Products> GetProduct()
        {
            string command = "SELECT * FROM Products";
            List<Products> products = con.Query<Products>(command);
            return products;

        }
      

        public bool SaveProduct(Products product)
        {
            bool res = false;
            try
            {
                con.Insert(product);
                res = true;

            }
            catch(Exception ex)
            {

                res = false;
            }
            return res;
        }


        public bool UpdateProduct(Products product)
        {

            bool res = false;
            try
            {
                string sql = $"UPDATE Employee SET Name='{product.Name}',Description='{product.Description}',Prix='{product.prix}' WHERE Id={ product.Id}";
                con.Execute(sql);
                res = true;
            }
            catch (Exception ex)
            {

            }
            return res;
        }

        public void DeleteProduct(int Id)
        {
            string sql = $"DELETE FROM Products WHERE Id={Id}";
            con.Execute(sql);
        }
    }
}