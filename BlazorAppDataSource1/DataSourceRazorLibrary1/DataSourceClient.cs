using System;

namespace DataSourceRazorLibrary1
{
    public class DataSourceClient<TSearch, TViewModel> : DataSourceBase<TSearch, TViewModel>
    {
        public DataSourceClient(TSearch search, BaseService<TSearch, TViewModel> service) 
            : base(search, service, DataSourceType.Client)
        {

        }
    }
}
