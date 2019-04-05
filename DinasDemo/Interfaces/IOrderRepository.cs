using DinasDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DinasDemo.Interfaces
{
    public interface IOrderRepository
    {
        void CreateOrder(Order order);
        ICollection<Order> GetOrders();
    }
}
