using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSourceRazorLibrary1
{
    public interface IDataSource
    {
        int Page { get; }

        int MinPage { get; }

        int MaxPage { get; }

        int Pagesize { get; }

        string OrderbyColumn { get; }

        string OrderbyDirection { get; }       

        bool HasFirstPage { get; }

        bool HasPrevPage { get; }

        bool HasNextPage { get; }

        bool HasLastPage { get; }

        int FirstPage { get; }

        int PrevPage { get; }

        int NextPage { get; }

        int LastPage { get; }

        int Count { get; }

        Task<bool> GotoPage(int page);

        Task<bool> GotoFirstPage();

        Task<bool> GotoPrevPage();

        Task<bool> GotoNextPage();

        Task<bool> GotoLastPage();

        Task<bool> SortByColumn(string column, string direction = "asc");

        Task<bool> Refresh();

        event EventHandler<NavigationArgs> NavigationChanging;

        event EventHandler<NavigationArgs> NavigationChanged;
    }
}
