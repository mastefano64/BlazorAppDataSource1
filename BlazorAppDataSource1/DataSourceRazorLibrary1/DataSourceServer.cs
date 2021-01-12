using System;

namespace DataSourceRazorLibrary1
{
    public class DataSourceServer<TSearch, TViewModel> : DataSourceBase<TSearch, TViewModel>
    {
        public DataSourceServer(TSearch search, BaseService<TSearch, TViewModel> service)
            : base(search, service, DataSourceType.Server)
        {

        }
    }
}
