using Microsoft.EntityFrameworkCore;

namespace LiarsDice.Data
{
    public class MockDB : CommonContext
    {
        public MockDB(){ }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseInMemoryDatabase("LiarsDiceDB");
        }
    }
}
