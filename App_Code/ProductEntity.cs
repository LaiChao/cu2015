using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data.Linq.Mapping;


    //实体类，对应数据库的"Products"表
    [Table(Name="Products")]
    public class ProductEntity
    {
        [Column(IsPrimaryKey=true,IsDbGenerated=true,AutoSync=AutoSync.OnInsert)]
        public int ProductID { set; get; }
        [Column()]
        public string ProductName { set; get; }
        [Column()]
        public int CategoryID { set; get; }
        [Column()]
        public decimal UnitPrice { set; get; }
        [Column()]
        public string ImagePath { set; get; }
    }
