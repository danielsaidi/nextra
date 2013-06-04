using System.Collections.Generic;

namespace NExtra.Collections
{
    public interface IOrderContext<T>
    {
        IEnumerable<T> Collection { get; set; }
        bool Descending { get; set; }
        string OrderByPropertyName { get; set; }

        IEnumerable<T> GetOrderedResult();
    }
}