using System;
using System.Collections.Generic;
using System.Text;

namespace DataSourceRazorLibrary1
{
    public class ResultData<TViewModel>
    {
        public ResultData()
        {
            Items = new List<TViewModel>();
        }

        public int Page { get; set; }
        public string Url { get; set; }
        public List<TViewModel> Items { get; set; }
        public int Count { get; set; }
    }
}
