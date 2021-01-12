using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorAppDataSource1.Server.Model
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
