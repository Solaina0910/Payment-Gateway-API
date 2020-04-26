using Microsoft.EntityFrameworkCore;

namespace PaymentGatewayAPI.Models
{
    public class PaymentGatewayContext : DbContext
    {
        public PaymentGatewayContext(DbContextOptions<PaymentGatewayContext> options) :base(options)
        {

        }

        public DbSet<Merchant> Merchants {get; set;}

        public DbSet<Bank> Banks {get; set;}

        public DbSet<Transaction> Transactions {get; set;}
    }
}