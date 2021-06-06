using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrudApp.Models
{
    public  class Products
    {
        //using SqlLite
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double prix { get; set; }

    }
}
