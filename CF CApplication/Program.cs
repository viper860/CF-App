using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library;
using Models;

namespace CF_CApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Database.SetInitializer<CsvContext>(new CsvDropInitializer());
            //  Database.SetInitializer(new MigrateDatabaseToLatestVersion<CsvContext, GM.CsvToObj.Models.Migrations.Configuration>());
            CsvContext context = new CsvContext();
            Console.WriteLine("Please wait while GEODB is created and populated");

            context.Database.Initialize(true);
            Console.WriteLine("Complete!   Press any key to exit.");
            Console.ReadLine();
        }
    }
}
