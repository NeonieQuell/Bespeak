using Microsoft.EntityFrameworkCore;

namespace Bespeak.DataAccess.Context
{
    public class BespeakDbContext : DbContext
    {
        public BespeakDbContext(DbContextOptions<BespeakDbContext> options) : base(options)
        {

        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<string>().HaveColumnType("varchar");
        }
    }
}
