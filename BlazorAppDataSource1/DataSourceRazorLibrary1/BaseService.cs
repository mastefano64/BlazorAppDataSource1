using System;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataSourceRazorLibrary1
{
    public abstract class BaseService<TSearch, TViewModel>
    {
        public BaseService()
        {

        }

        public string CreateQueryString(TSearch search, int page, int pagesize, string orderbycolumn, string orderbydirection)
        {
            StringBuilder sb = new StringBuilder();

            Type type = search.GetType();
            PropertyInfo[] properties = type.GetProperties();

            sb.Append($"&page={page.ToString()}");
            sb.Append($"&pagesize={pagesize.ToString()}");
            sb.Append($"&orderbycolumn={orderbycolumn}");
            sb.Append($"&orderbydirection={orderbydirection}");

            foreach (PropertyInfo property in properties)
            {
                if (property.GetCustomAttributes(typeof(FieldSearchableAttribute)).Any() == true)
                {
                    string name = property.Name;
                    if (property.PropertyType == typeof(DateTime?) || property.PropertyType == typeof(DateTime))
                    {
                        if (property.PropertyType == typeof(DateTime?))
                        {
                            DateTime? value = (DateTime?)property.GetValue(search, null);
                            string ymd = (value.HasValue == true) ? value.Value.ToString("yyyy/MM/dd") : "";
                            sb.Append($"&{name}={ymd}");
                        }
                        if (property.PropertyType == typeof(DateTime))
                        {
                            DateTime value = (DateTime)property.GetValue(search, null);
                            string ymd = (value == DateTime.MinValue) ? value.ToString("yyyy/MM/dd") : "";
                            sb.Append($"&{name}={ymd}");
                        }
                    }
                    else
                    {
                        object obj = property.GetValue(search, null);
                        string str = (obj != null) ? obj.ToString() : "";
                        sb.Append($"&{name}={str}");
                    }
                }
            }

            return sb.ToString();
        }

        public virtual async Task<ResultData<TViewModel>> FetchData(string url, TSearch search, int page,
                          int pagesize, string orderbycolumn, string orderbydirection)
        {
            throw new NotImplementedException();
        }
    }
}
