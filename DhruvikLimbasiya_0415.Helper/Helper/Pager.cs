using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DhruvikLimbasiya_0415.Helper.Helper
{
    public class Pager<T> : List<T>
    {
        public static int totalCount;
        public static int page;
        public static int pageSize;
        public static int totalPage;


        public static List<T> Pagination(List<T> _list, int page)
        {
            int pageSize = 5;

            int totalCount = _list.Count();
            int totalPage = (int)Math.Ceiling((decimal)totalCount / pageSize);

            var DetailsPerPage = _list.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            Pager<T>.totalCount = totalCount;
            Pager<T>.page = page;
            Pager<T>.pageSize = pageSize;
            Pager<T>.totalPage = totalPage;
            return DetailsPerPage;
        }
    }
}
