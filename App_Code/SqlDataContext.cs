using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Linq;
using System.Configuration;


    public class SqlDataContext : DataContext
    {
        static string connstring;
        static SqlDataContext()
        {
            connstring = ConfigurationManager.ConnectionStrings["lyf"].ConnectionString;
        }
        public SqlDataContext()
            : base(connstring)
        { }

        /// <summary>
        /// 产品表
        /// </summary>
        public Table<ProductEntity> Products
        {
            get { return base.GetTable<ProductEntity>(); }
        }


    }
