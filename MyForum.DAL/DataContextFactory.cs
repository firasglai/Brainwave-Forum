using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;


namespace MyForum.DAL
{
    public class DataContextFactory : IDesignTimeDbContextFactory<MyForumDbContext>
    {
        public MyForumDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MyForumDbContext>();

            optionsBuilder.UseSqlServer("Data Source=DESKTOP-G3783LI;Initial Catalog=MyForumDb;Trusted_Connection=True;MultipleActiveResultSets=true");
       return new MyForumDbContext(optionsBuilder.Options);
        }




    }
}
