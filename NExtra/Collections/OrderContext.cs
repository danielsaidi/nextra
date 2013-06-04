using System.Collections.Generic;
using System.Linq;
using NExtra.Extensions;

namespace NExtra.Collections
{
    public class OrderContext<T> : IOrderContext<T>
    {
        public OrderContext(IEnumerable<T> collection, string orderByPropertyName, bool descending)
        {
            Collection = collection;
            OrderByPropertyName = orderByPropertyName;
            Descending = descending;
        }


        public IEnumerable<T> Collection { get; set; }

        public bool Descending { get;  set; }

        public string OrderByPropertyName { get; set; }


        public IEnumerable<T> GetOrderedResult()
        {
            var result = Collection.OrderBy(OrderByPropertyName).ToList();
            if (Descending)
                result.Reverse();
            return result;
        }
    }
}