using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using BookShop.Data;

namespace BookShop.Tests
{
    public class OrderItemCollectionTests
    {
        [Fact]
        public void Get_WithExcistingItem_ReturnItem()
        {
            var order = CreateTestOrder();

            var orderItem = order.Items.Get(1);

            Assert.Equal(3, orderItem.Count);
        }

        private static Order CreateTestOrder()
        {
            return new Order(new OrderDto
            {
                Id = 1,
                Items = new List<OrderItemDto>
                {
                    new OrderItemDto { BookId = 1, Price = 10m, Count = 3},
                    new OrderItemDto { BookId = 2, Price = 100m, Count = 5},

                }
            });
        }

        [Fact]
        public void Get_WithNonExcistingItem_ThrowsInvalidOperationException()
        {
            var order = CreateTestOrder();

            Assert.Throws<InvalidOperationException>(() =>
            {
                order.Items.Add(1, 10, 10m);
            });
        }

        [Fact]
        public void Add_WithNewItem_SetsCount()
        {
            var order = CreateTestOrder();

            order.Items.Add(4, 10, 30m);

            Assert.Equal(10, order.Items.Get(4).Count);
        }

        [Fact]
        public void Remove_WithExcistingItem_Removetem()
        {
            var order = CreateTestOrder();

            order.Items.Remove(1);

            Assert.Collection(order.Items,
                               item => Assert.Equal(2, item.BookId));
        }

        [Fact]
        public void Remove_WithNonExcistingItem_ThrowsInvalidOperationException()
        {
            var order = CreateTestOrder();

            Assert.Throws<InvalidOperationException>(() =>
            {
                order.Items.Remove(100);
            });
        }
    }
}
