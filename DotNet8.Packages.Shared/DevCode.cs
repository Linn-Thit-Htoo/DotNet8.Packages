using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8.Packages.Shared
{
    public static class DevCode
    {
        public static IQueryable<TSource> Paginate<TSource>(this IQueryable<TSource> source, int pageNo, int pageSize)
        {
            return source.Skip((pageNo - 1) * pageSize).Take(pageSize);
        }
    }
}
