using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataSourceRazorLibrary1
{
    public abstract class DataSourceBase<TSearch, TViewModel> : IDataSource
    {
        public string PagingUrl;

        private TSearch _search;
        private BaseService<TSearch, TViewModel> _service;
        private DataSourceType _mode;

        private int currPage;
        private int currPagesize;
        private string currOrderbydirection;
        private string currOrderbycolumn;

        private int count;
        private int minpage;
        private int maxpage;
        private List<TViewModel> allresult;
        private List<TViewModel> result;

        public event EventHandler<LoadPaggedDataArgs<TViewModel>> LoadPaggedDataCompleted;

        public event EventHandler<NavigationArgs> NavigationChanging;

        public event EventHandler<NavigationArgs> NavigationChanged;

        public int PageSize { get; set; }

        public DataSourceBase(TSearch search, BaseService<TSearch, TViewModel> service, DataSourceType mode)
        {
            _search = search;
            _service = service;
            _mode = mode;
            allresult = new List<TViewModel>();
            result = new List<TViewModel>();
        }

        public List<TViewModel> Result
        {
            get
            {
                return result;
            }
        }

        public int Count
        {
            get
            {
                return result.Count;
            }
        }

        public int Page
        {
            get
            {
                return currPage;
            }
        }

        public int MinPage
        {
            get
            {
                return minpage;
            }
        }

        public int MaxPage
        {
            get
            {
                return maxpage;
            }
        }

        public int Pagesize
        {
            get
            {
                return Pagesize;
            }
        }
        public string OrderbyColumn
        {
            get
            {
                return currOrderbycolumn;
            }
        }

        public string OrderbyDirection
        {
            get
            {
                return currOrderbydirection;
            }
        }

        public bool HasFirstPage
        {
            get
            {
                bool value = false;
                if (currPage != minpage)
                    value = true;
                return value;
            }
        }

        public bool HasPrevPage
        {
            get
            {
                bool value = false;
                if (minpage != -1 && currPage > minpage)
                    value = true;
                return value;
            }
        }

        public bool HasNextPage
        {
            get
            {
                bool value = false;
                if (maxpage != -1 && currPage < maxpage)
                    value = true;
                return value;
            }
        }

        public bool HasLastPage
        {
            get
            {
                bool value = false;
                if (currPage != maxpage)
                    value = true;
                return value;
            }
        }

        public int FirstPage
        {
            get
            {
                return minpage;
            }
        }

        public int PrevPage
        {
            get
            {
                int value = -1;
                if (minpage != -1 && currPage > minpage)
                    value = currPage - 1;
                return value;
            }
        }

        public int NextPage
        {
            get
            {
                int value = -1;
                if (maxpage != -1 && currPage < maxpage)
                    value = currPage + 1;
                return value;
            }
        }

        public int LastPage
        {
            get
            {
                return maxpage;
            }
        }

        public async Task LoadPaggedData(int page, int pagesize, string orderbycolumn, string orderbydirection = "asc")
        {
            currPage = page;
            currPagesize = pagesize;
            currOrderbydirection = orderbydirection;
            currOrderbycolumn = orderbycolumn;

            DispatchChanging();

            ResultData<TViewModel> response = await _service.FetchData(PagingUrl, _search,
                  currPage, currPagesize, currOrderbycolumn, currOrderbydirection);
           
            SetPageCount(response.Count);
            allresult = response.Items;

            if (_mode == DataSourceType.Client)
            {
                int skip = (currPage - 1) * currPagesize;
                result = response.Items.Skip(skip).Take(currPagesize).ToList();
            }
            else
            {
                result = response.Items;
            }

            DispatchLoadCompleted();
            DispatchChanged();
        }

        public async Task<bool> GotoPage(int page)
        {
            if (page < minpage || page > maxpage)
                return false;

            currPage = page;
            if (_mode == DataSourceType.Server)
            {
                await LoadPaggedData(currPage, currPagesize, currOrderbycolumn, currOrderbydirection);
            }
            else
            {
                DispatchChanging();
                int skip = (currPage - 1) * currPagesize;
                result = allresult.Skip(skip).Take(currPagesize).ToList();
                DispatchLoadCompleted();
                DispatchChanged();
            }

            return true;
        }

        public async Task<bool> GotoFirstPage()
        {
            if (HasFirstPage == false)
                return false;

            currPage = minpage;
            if (_mode == DataSourceType.Server)
            {
                await LoadPaggedData(currPage, currPagesize, currOrderbycolumn, currOrderbydirection);               
            }
            else
            {
                DispatchChanging();
                int skip = (currPage - 1) * currPagesize;
                result = allresult.Skip(skip).Take(currPagesize).ToList();
                DispatchLoadCompleted();
                DispatchChanged();
            }
            
            return true;
        }

        public async Task<bool> GotoPrevPage()
        {
            if (HasPrevPage == false)
                return false;

            currPage = currPage - 1;
            if (_mode == DataSourceType.Server)
            {
                await LoadPaggedData(currPage, currPagesize, currOrderbycolumn, currOrderbydirection);
            }
            else
            {
                DispatchChanging();
                int skip = (currPage - 1) * currPagesize;
                result = allresult.Skip(skip).Take(currPagesize).ToList();
                DispatchLoadCompleted();
                DispatchChanged();
            }

            return true;
        }

        public async Task<bool> GotoNextPage()
        {
            if (HasNextPage == false)
                return false;

            currPage = currPage + 1;
            if (_mode == DataSourceType.Server)
            {
                await LoadPaggedData(currPage, currPagesize, currOrderbycolumn, currOrderbydirection);
            }
            else
            {
                DispatchChanging();
                int skip = (currPage - 1) * currPagesize;
                result = allresult.Skip(skip).Take(currPagesize).ToList();
                DispatchLoadCompleted();
                DispatchChanged();
            }

            return true;
        }

        public async Task<bool> GotoLastPage()
        {
            if (HasLastPage == false)
                return false;

            currPage = maxpage;
            if (_mode == DataSourceType.Server)
            {
                await LoadPaggedData(currPage, currPagesize, currOrderbycolumn, currOrderbydirection);
            }
            else
            {
                DispatchChanging();
                int skip = (currPage - 1) * currPagesize;
                result = allresult.Skip(skip).Take(currPagesize).ToList();
                DispatchLoadCompleted();
                DispatchChanged();
            }

            return true;
        }

        public async Task<bool> SortByColumn(string column, string direction = "asc")
        {
            if (minpage == -1 && maxpage == -1)
                return false;

            currPage = 1;
            currOrderbydirection = direction;
            currOrderbycolumn = column;
            await LoadPaggedData(currPage, currPagesize, currOrderbycolumn, currOrderbydirection);

            return true;
        }

        public async Task<bool> Refresh()
        {
            if (minpage == -1 && maxpage == -1)
                return false;

            await LoadPaggedData(currPage, currPagesize, currOrderbycolumn, currOrderbydirection);

            return true;
        }       

        private void SetPageCount(int cnt)
        {
            if (cnt == 0)
            {
                count = 0;           
                maxpage = 0;
                minpage = 0;
                return;
            }
            count = cnt;
            double value = this.count / currPagesize;
            maxpage = (int)Math.Ceiling(value);
            minpage = 1;
        }

        private void DispatchLoadCompleted()
        {
            LoadPaggedDataArgs<TViewModel> args = new LoadPaggedDataArgs<TViewModel>();
            args.Page = currPage;
            args.Pagesize = currPagesize;
            args.OrderbyColumn = currOrderbycolumn;
            args.OrderbyDirection = currOrderbydirection;
            args.Items = result;
            LoadPaggedDataCompleted?.Invoke(this, args);           
        }

        private void DispatchChanging()
        {
            NavigationArgs args = new NavigationArgs();
            args.Page = currPage;
            args.Pagesize = currPagesize;
            args.OrderbyColumn = currOrderbycolumn;
            args.OrderbyDirection = currOrderbydirection;
            NavigationChanging?.Invoke(this, args);
        }

        private void DispatchChanged()
        {
            NavigationArgs args = new NavigationArgs();
            args.Page = currPage;
            args.Pagesize = currPagesize;
            args.OrderbyColumn = currOrderbycolumn;
            args.OrderbyDirection = currOrderbydirection;
            NavigationChanged?.Invoke(this, args);
        }
    }
}
