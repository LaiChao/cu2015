using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data.Linq.Mapping;


    public class ProductModel
    {
        public int ProductID { set; get; }
        public string ProductName { set; get; }
        public int CategoryID { set; get; }
        public decimal UnitPrice { set; get; }
        public string ImagePath { set; get; }
    }
