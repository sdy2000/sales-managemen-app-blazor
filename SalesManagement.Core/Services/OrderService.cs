using Microsoft.EntityFrameworkCore;
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
                    OrderDateTime = DateTime.Now,
                    ClientId = orderViewModel.ClientId,
                    EmployeeId = 9,
                    Price = orderViewModel.OrderItems.Sum(o => o.Price),
                    Qty = orderViewModel.OrderItems.Sum(o => o.Qty)
                };

                EntityEntry<Order> addedOrder = await _context.Orders.AddAsync(order);
                SavaChange();

                int orderId = addedOrder.Entity.Id;

                List<OrderItem> orderItemsToAdd = ReturnOrderItemsWithOrderId(orderId, orderViewModel.OrderItems);
                await _context.AddRangeAsync(orderItemsToAdd);

                SavaChange();

                UpdateSalesOrderReportsTable(orderId, order);

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

        private async Task UpdateSalesOrderReportsTable(int orderId, Order order)
        {
            try
            {
                List<SalesOrderReport> srItems = await (from oi in _context.OrderItems
                                                        where oi.OrderId == orderId
                                                        select new SalesOrderReport
                                                        {
                                                            OrderId = orderId,
                                                            OrderDateTime = order.OrderDateTime,
                                                            OrderPrice = order.Price,
                                                            OrderQty = order.Qty,
                                                            OrderItemId = oi.Id,
                                                            OrderItemPrice = oi.Price,
                                                            OrderItemQty = oi.Qty,
                                                            EmployeeId = order.EmployeeId,
                                                            EmployeeFirstName = _context.Employees.FirstOrDefault(e => e.Id == order.EmployeeId).FirstName,
                                                            EmployeeLastName = _context.Employees.FirstOrDefault(e => e.Id == order.EmployeeId).LastName,
                                                            ProductId = oi.ProductId,
                                                            ProductName = _context.Products.FirstOrDefault(p => p.Id == oi.ProductId).Name,
                                                            ProductCategoryId = _context.Products.FirstOrDefault(p => p.Id == oi.ProductId).CategoryId,
                                                            ProductCategoryName = _context.ProductCategories.FirstOrDefault(c => c.Id == _context.Products.FirstOrDefault(p => p.Id == oi.ProductId).CategoryId).Name,
                                                            ClientId = order.ClientId,
                                                            ClientFirstName = _context.Clients.FirstOrDefault(c => c.Id == order.ClientId).FirstName,
                                                            ClientLastName = _context.Clients.FirstOrDefault(c => c.Id == order.ClientId).LastName,
                                                            RetailOutletId = _context.Clients.FirstOrDefault(c => c.Id == order.ClientId).RetailOutletId,
                                                            RetailOutletLocation = _context.RetailOutlets.FirstOrDefault(r => r.Id == _context.Clients.FirstOrDefault(c => c.Id == order.ClientId).RetailOutletId).Location
                                                        }).ToListAsync();

                await _context.AddRangeAsync(srItems);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
