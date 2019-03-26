using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using ukol9.Models;
using ukol9.DatabaseModels;

namespace ukol9.DataObjects
{
    public class CustomerOrderDO
    {
        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public string EmployeeLastName { get; set; }

        // asynchroní metoda pro načtení objednávek
        public static async Task<List<CustomerOrderDO>> GetOrdersAsync(
               string customerID)
        {
            using (MyCSharpDotNetEntities context =
               new MyCSharpDotNetEntities())
            {

                // return obstarávající select a join tabulek pro získání dat
                return await context.Orders
                    .Where(orders => orders.CustomerID == customerID)
                    .Join(context.Employees,
                                       orders => orders.EmployeeID, // cizí klíč z tab objednávek
                                    employees => employees.EmployeeID, // prim. klíč z tab zaměstnanců
                          (orders, employees) => new CustomerOrderDO()
                          {
                              OrderID = orders.OrderID,
                              OrderDate = (DateTime)orders.OrderDate,
                              EmployeeLastName = employees.LastName,
                          })
                         .ToListAsync();
            }
        }
    }
}