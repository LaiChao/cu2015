using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


    public class PageModel
    {
        /// <summary>
        /// 页面显示商品
        /// </summary>
        public int PageSize { get { return 10; } }
        /// <summary>
        /// 商品数量
        /// </summary>
        public double ProductsCount { get; set; }
        /// <summary>
        /// 页的总数量
        /// </summary>
        public double PageCount
        {
            //get
            //{
            //    double i=Math.Ceiling(ProductsCount/PageSize);
            //    return i;
            //}
            get;
            set;
        }
        /// <summary>
        /// 当前页
        /// </summary>
        public int CurrPage { get; set; }
        /// <summary>
        /// 操作名称
        /// </summary>

    }
