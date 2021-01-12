using System;
using System.Collections.Generic;

namespace DataSourceRazorLibrary1
{
    public class LoadPaggedDataArgs<TViewModel>
    {
        public int Page { get; set; }

        public int Pagesize { get; set; }

        public string OrderbyColumn { get; set; }

        public string OrderbyDirection { get; set; }

        public List<TViewModel> Items { get; set; }
    }
}
