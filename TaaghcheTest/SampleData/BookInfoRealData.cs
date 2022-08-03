using System.Collections;
using System.Collections.Generic;
using DomainLayer.AggregatesModels.Books.Models;

namespace TaaghcheTest.SampleData
{
    public class BookInfoRealData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] {103657, new BookInfo() {book = new Book() {id = 103657, price = 60000.0, title = "بهت اصلا نمی آد", numberOfPages = 888}}};
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}