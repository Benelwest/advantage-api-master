using Advantage.API.Models;
using System.Linq;

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
            }           

            if (!_ctx.Orders.Any())
            {
                SeedOrders(nCustomers);
            }

            if (!_ctx.Servers.Any())
            {
                SeedServers(nCustomers);
            }
            
            _ctx.SaveChanges();
    
        }

        private void SeedCustomers(int n)
        {
            List<Customers> Customer = BuildCustomerList(n);
            
        }
        
    }

}