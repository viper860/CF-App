using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Library;

namespace Models
{
    public class CsvInitializer : DropCreateDatabaseIfModelChanges<CsvContext>
    {

        private static List<Country> LoadCountries()
        {
            CsvManager<Country> countryManager = new CsvManager<Country>(@"D:\Users\s3803\Documents\Visual Studio 2015\Projects\GM.CsvToObj\countrylist.csv", true);
            //countryManager.SetField(x => x.SortOrder, 0);
            countryManager.SetField(x=> x.CommonName,1);
            countryManager.SetField(x => x.FormalName, 2);
            countryManager.SetField(x => x.Type, 3);
            countryManager.SetField(x => x.Subtype, 4);
            countryManager.SetField(x => x.Sovereignty, 5);
            countryManager.SetField(x => x.Capital, 6);
            countryManager.SetField(x => x.ISO_4217_Currency_Code, 7);
            countryManager.SetField(x => x.ISO_4217_Currency_Name, 8);
            countryManager.SetField(x => x.ITU_Phone_Code, 9);
            countryManager.SetField(x => x.ISO_3166_2_Letter_Code, 10);
            countryManager.SetField(x => x.ISO_3166_3_Letter_Code, 11);
            countryManager.SetField(x => x.IANA_Country_Code_TLD, 12);
            var countriesResult = countryManager.GetObjectList();

            return countriesResult;
        }

        private static List<Postcode> LoadPostcodes()
        {
            CsvManager<Postcode> postcodeManager = new CsvManager<Postcode>(@"D:\Users\s3803\Documents\Visual Studio 2015\Projects\GM.CsvToObj\postcodes.csv", true);

            postcodeManager.SetField(x => x.Name, 0);
            postcodeManager.SetField(x => x.Latitute, 1);
            postcodeManager.SetField(x => x.Longitudine, 2);
            postcodeManager.SetField(x => x.Easting, 3);
            postcodeManager.SetField(x => x.Northing, 4);
            postcodeManager.SetField(x => x.Grid, 5);
            postcodeManager.SetField(x => x.Area, 6);
            postcodeManager.SetField(x => x.Region, 7);
            List<Postcode> postcodesResult = postcodeManager.GetObjectList();

            return postcodesResult;
        }

        private static List<UsPresident> LoadUsPresidents()
        {
            CsvManager<UsPresident> presidentsManager = new CsvManager<UsPresident>(@"D:\Users\s3803\Documents\Visual Studio 2015\Projects\GM.CsvToObj\USPresident_Wikipedia.csv", true);
            presidentsManager.SetField(x=>x.PresidencyId, 0);
            presidentsManager.SetField(x => x.President, 1);
            presidentsManager.SetField(x => x.WikipediaEntry, 2);
            presidentsManager.SetField(x => x.TookOffice, 3);
            presidentsManager.SetField(x => x.LeftOffice, 4);
            presidentsManager.SetField(x => x.Party, 5);
            presidentsManager.SetField(x => x.Portrait, 6);
            presidentsManager.SetField(x => x.Thumbnail, 7);
            presidentsManager.SetField(x => x.HomesState, 8);
            List<UsPresident> presidentsResult = presidentsManager.GetObjectList();

            return presidentsResult;
        }


        protected override void Seed(CsvContext context)
        {
            var countries = LoadCountries();
            countries.ForEach(country => context.Countries.Add(country));
            try
            {
                context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
            }
            

            var postcodes = LoadPostcodes();
            postcodes.ForEach(postcode => context.Postcodes.Add(postcode));
            try
            {
                context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
            }

            var presidents = LoadUsPresidents();
            presidents.ForEach(president => context.Presidents.Add(president));
            try
            {
                context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
            }


        }
    }
}
