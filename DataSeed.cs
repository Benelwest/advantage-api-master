using Advantage.API.Models;
using System.Linq;
using System;
using System.Collections.Generic;


namespace Advantage.API
{
    public class DataSeed
    {
        private readonly ApiContext _ctx;
        public DataSeed(ApiContext ctx)
        {
            _ctx = ctx;
        }

        public void SeedData(int nCustomers, int nOrders)
        {
            if (!_ctx.Customer.Any())
            {
                SeedCustomers(nCustomers);
                  _ctx.SaveChanges();
            }           

            if (!_ctx.Orders.Any())
            {
                SeedOrders(nOrders);
                  _ctx.SaveChanges();
            }

            if (!_ctx.Servers.Any())
        
            {
                SeedServers();
                  _ctx.SaveChanges();
            }
            
          
    
        }

        private void SeedCustomers(int n)
        {
            List<Customer> customers = BuildCustomerList(n);
            foreach(var customer in customers)
            {
                _ctx.Customer.Add(customer);
            }
            
        }

        private void SeedServers()
        {
            List<Server> servers = BuildServerList();

            foreach (var server in servers)
            {
                _ctx.Servers.Add(server);
            }
        }

        private List<Customer> BuildCustomerList(int nCustomers)
        {
                var customers = new List<Customer>();
                var names = new List<string>();

                for (var i = 1; i <= nCustomers; i++)
                {
                    var name = Helpers.MakeUniqueCustomerName(names);
                    names.Add(name);

                    customers.Add(new Customer{
                        Id = i,
                        Name = name,
                        Email = Helpers.MakeCustomerEmail(name),
                        State = Helpers.GetRandomState()
                    });
                }
                return customers;

        }

        private void SeedOrders(int n)
        {
             List<Order> orders = BuildOrderList(n);
            foreach(var order in orders)
            {
                _ctx.Orders.Add(order);
            }            
        }


         private List<Order> BuildOrderList(int nOrders)
        {
                var orders = new List<Order>();
                var rand = new Random();
   

                for (var i = 1; i <= nOrders; i++)
                {
                    var randCustomerId = rand.Next(1, _ctx.Customer.Count());
                    var placed = Helpers.GetRandomOrderPlaced();
                    var completed = Helpers.GetRandomOrderCompleted(placed);

                    orders.Add(new Order{
                        Id = i,
                        Customer = _ctx.Customer.First(c => c.Id == randCustomerId),
                        OrderTotal = Helpers.GetRandomOrderTotal(),
                        Placed = placed,
                        Completed = completed
                       
                    });
                }
                return orders;

        }
        private List<Server> BuildServerList()
        {
            return new List<Server>()
            {
                new Server{
                    Id = 1,
                    Servername = "Dev-Web",
                    IsOnline = true
                },
                 new Server{
                    Id = 2,
                    Servername = "Dev-Mail",
                    IsOnline = false
                },
                 new Server{
                    Id = 3,
                    Servername = "Dev-Services",
                    IsOnline = true
                },
                new Server{
                    Id = 4,
                    Servername = "QA-Web",
                    IsOnline = true
                },
                 new Server{
                    Id = 5,
                    Servername = "QA-Mail",
                    IsOnline = false
                },
                 new Server{
                    Id = 6,
                    Servername = "QA-Services",
                    IsOnline = true
                },

                new Server{
                    Id = 7,
                    Servername = "Prod-Web",
                    IsOnline = true
                },
                 new Server{
                    Id = 8,
                    Servername = "Prod-Mail",
                    IsOnline = false
                },
                 new Server{
                    Id = 9,
                    Servername = "Prod-Services",
                    IsOnline = true
                }

            };
        }

        
    }

}