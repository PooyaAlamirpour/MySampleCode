using System.Collections;
using System.Collections.Generic;
using DomainLayer.AggregatesModels.Books.Models;

namespace TaaghcheTest.SampleData
{
    public class BookInfoFakeData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] {1234, new BookInfo() {book = new Book() {id = 1234, title = "SampleTitle 1"}}};
            yield return new object[] {1034, new BookInfo() {book = new Book() {id = 1034, title = "SampleTitle 2"}}};
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}