using System;

namespace MedAppDataAccess
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = new MedDbContext();
            data.Database.EnsureDeleted();
            data.Database.EnsureCreated();
        }
    }
}
