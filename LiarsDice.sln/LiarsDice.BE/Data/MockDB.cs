using Microsoft.EntityFrameworkCore;

namespace LiarsDice.BE.Data
{
    public class MockDB : CommonContext
    {
        public MockDB() { }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseInMemoryDatabase("LiarsDiceDB");
        }
    }
}
