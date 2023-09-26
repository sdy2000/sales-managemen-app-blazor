using Microsoft.EntityFrameworkCore.ChangeTracking;
using SalesManagement.Core.DTOs;
using SalesManagement.Core.Services.Contracts;
using SalesManagement.Data.Context;
using SalesManagement.Data.Entities;

namespace SalesManagement.Core.Services
{
    public class OrderService : IOrderService
    {
        private SalesManagementDbContext _context;

        public OrderService(SalesManagementDbContext context)
        {
            _context = context;
        }



        public bool SavaChange()
        {
            try
            {
                _context.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public async Task CreateOrder(OrderViewModel orderViewModel)
        {
            try
            {
                Order order = new Order
                {
                    OrderDateTime = orderViewModel.OrderDateTime,
                    ClientId = orderViewModel.ClientId,
                    EmployeeId = 9,
                    Price = orderViewModel.OrderItems.Sum(o=>o.Price),
                    Qty = orderViewModel.OrderItems.Sum(o=>o.Qty)
                };

                EntityEntry<Order> addedOrder = await _context.Orders.AddAsync(order);
                int orderId = addedOrder.Entity.Id;

                List<OrderItem> orderItemsToAdd = ReturnOrderItemsWithOrderId(orderId, orderViewModel.OrderItems);
                await _context.AddRangeAsync(orderItemsToAdd);

                SavaChange();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private List<OrderItem> ReturnOrderItemsWithOrderId(int orderId, List<OrderItem> orderItems)
        {
            return (from oi in orderItems
                    select new OrderItem
                    {
                        OrderId = orderId,
                        Price = oi.Price,
                        Qty = oi.Qty,
                        ProductId = oi.ProductId,
                    }).ToList();
        }
    }
}
