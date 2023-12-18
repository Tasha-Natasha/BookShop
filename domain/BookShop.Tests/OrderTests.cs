using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Tests
{
    public class OrderTests
    {
        [Fact]
        public void Order_WithNullItems_ThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new Order(1, null));
        }

        [Fact]
        public void TotalCount_WithEmptyItems_ReturnZero()
        {
            var order = new Order(1, new OrderItem[0]);

            Assert.Equal(0, order.TotalCount);
        }

        [Fact]
        public void TotalPrice_WithEmptyItems_ReturnsZero()
        {
            var order = new Order(1, new OrderItem[0]);

            Assert.Equal(0m, order.TotalCount);
        }

        [Fact]
        public void TotalCount_WithNonEmptyItems_CalculatesTotalCount()
        {
            var order = new Order(1, new[]
            {
                new OrderItem(1, 3, 10m),
                new OrderItem(2, 5, 100m),
            });

            Assert.Equal(3+5, order.TotalCount);
        }

        [Fact]
        public void TotalPrice_WithNonEmptyItems_CalculatesTotalPrice()
        {
            var order = new Order(1, new[]
            {
                new OrderItem(1, 3, 10m),
                new OrderItem(2, 5, 100m),
            });

            Assert.Equal(3 * 10m + 5*100m, order.TotalPrice);
        }

        [Fact]
        public void GetItem_WithExcistingItem_ReturnItem()
        {
            var order = new Order(1, new[]
            {
                new OrderItem(1, 3, 10m),
                new OrderItem(2 ,5, 100m),
            });

            var orderItem = order.GetItem(1);

            Assert.Equal(3, orderItem.Count);
        }

        [Fact]
        public void GetItem_WithNonExcistingItem_ThrowsInvalidOperationException()
        {
            var order = new Order(1, new[]
            {
                new OrderItem(1, 3, 10m),
                new OrderItem(2 ,5, 100m),
            });

            Assert.Throws<InvalidOperationException>(() =>
            {
                order.GetItem(100);
            });   
        }

        [Fact]
        public void AddOrUpdateItem_WithExcistingItem_UptadeCount()
        {
            var order = new Order(1, new[]
            {
                new OrderItem(1, 3, 10m),
                new OrderItem(2 ,5, 100m),
            });

            var book = new Book(1, null, null, null, null, 0m);

            order.AddOrUpdateItem(book, 10);

            Assert.Equal(13, order.GetItem(1).Count);

        }

        [Fact]
        public void AddOrUpdateItem_WithNonExcistingItem_UptadeCount()
        {
            var order = new Order(1, new[]
            {
                new OrderItem(1, 3, 10m),
                new OrderItem(2 ,5, 100m),
            });

            var book = new Book(4, null, null, null, null, 0m);

            order.AddOrUpdateItem(book, 10);

            Assert.Equal(10, order.GetItem(4).Count);

        }

        [Fact]
        public void RemoveItem_WithExcistingItem_Removetem()
        {
            var order = new Order(1, new[]
            {
                new OrderItem(1, 3, 10m),
                new OrderItem(2 ,5, 100m),
            });

            order.RemoveItem(1);

            Assert.Equal(1, order.Items.Count);
        }

        [Fact]
        public void RemoveItem_WithNonExcistingItem_ThrowsInvalidOperationException()
        {
            var order = new Order(1, new[]
            {
                new OrderItem(1, 3, 10m),
                new OrderItem(2 ,5, 100m),
            });

            Assert.Throws<InvalidOperationException>(() =>
            {
                order.RemoveItem(100);
            });
        }

    }
}
