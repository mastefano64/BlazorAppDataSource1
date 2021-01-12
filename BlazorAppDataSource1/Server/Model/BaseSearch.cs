using System;

namespace BlazorAppDataSource1.Server.Model
{
    public abstract class BaseSearch
    {
        public int Page { get; set; }

        public int Pagesize { get; set; }

        public string OrderbyColumn { get; set; }

        public string OrderbyDirection { get; set; } = "asc";
    }
}
