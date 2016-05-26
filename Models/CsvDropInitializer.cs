﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Library;

namespace Models
{
    public class CsvDropInitializer : DropCreateDatabaseAlways<CsvContext>
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

        private static List<Athlete> LoadAthletes()
        {
            CsvManager<Athlete> athletesManager = new CsvManager<Athlete>(@"D:\Users\s3803\Downloads\athletes3.csv", true);
            //athletesManager.SetField(x => x.AthleteId, 0);
            athletesManager.SetField(x => x.CfId, 0);
            athletesManager.SetField(x => x.Name, 1);
            athletesManager.SetField(x => x.Region, 2);
            athletesManager.SetField(x => x.Team, 3);
            athletesManager.SetField(x => x.Affiliate, 4);
            athletesManager.SetField(x => x.Gender, 5);
            athletesManager.SetField(x => x.Age, 6);
            athletesManager.SetField(x => x.Height, 7);
            athletesManager.SetField(x => x.Weight, 8);
            athletesManager.SetField(x => x.Fran, 9);
            athletesManager.SetField(x => x.Helen, 10);
            athletesManager.SetField(x => x.Grace, 11);
            athletesManager.SetField(x => x.Filthy50, 12);
            athletesManager.SetField(x => x.Fgonebad, 13);
            athletesManager.SetField(x => x.Run400, 14);
            athletesManager.SetField(x => x.Run5k, 15);
            athletesManager.SetField(x => x.Candj, 16);
            athletesManager.SetField(x => x.Snatch, 17);
            athletesManager.SetField(x => x.Deadlift, 18);
            athletesManager.SetField(x => x.Backsq, 19);
            athletesManager.SetField(x => x.Pullups, 20);
            athletesManager.SetField(x => x.Eat, 21);
            athletesManager.SetField(x => x.Train, 22);
            athletesManager.SetField(x => x.Background, 23);
            athletesManager.SetField(x => x.Experience, 24);
            athletesManager.SetField(x => x.Schedule, 25);
            athletesManager.SetField(x => x.Howlong, 26);
            athletesManager.SetField(x => x.RetrievedDatetime, 27);
            List<Athlete> athletesResult = athletesManager.GetObjectList();

            return athletesResult;
        }

        private static List<Affiliate> LoadAffiliates()
        {
            CsvManager<Affiliate> affiliatesManager = new CsvManager<Affiliate>(@"D:\Users\s3803\Downloads\affiliates.csv", true);
            //athletesManager.SetField(x => x.AthleteId, 0);
            affiliatesManager.SetField(x => x.CfAffiliateId, 0);
            affiliatesManager.SetField(x => x.Name, 1);
            affiliatesManager.SetField(x => x.Address, 2);
            affiliatesManager.SetField(x => x.Phone, 3);
            affiliatesManager.SetField(x => x.Url, 4);
            affiliatesManager.SetField(x => x.Latitude, 5);
            affiliatesManager.SetField(x => x.Longitude, 6);
            affiliatesManager.SetField(x => x.Cfkids, 7);
            List<Affiliate> affiliatesResult = affiliatesManager.GetObjectList();

            return affiliatesResult;
        }

        private static List<LeaderboardThirteen> LoadLeaderboardThirteens()
        {
            CsvManager<LeaderboardThirteen> leaderboardThirteensManager = new CsvManager<LeaderboardThirteen>(@"D:\Users\s3803\Downloads\individual_men_open_2013.csv", true);
            //athletesManager.SetField(x => x.AthleteId, 0);
            leaderboardThirteensManager.SetField(x => x.OverallRank, 0);
            leaderboardThirteensManager.SetField(x => x.OverallScore, 1);
            leaderboardThirteensManager.SetField(x => x.CfId, 2);
            leaderboardThirteensManager.SetField(x => x.Name, 3);
            leaderboardThirteensManager.SetField(x => x.Workout01Rank, 4);
            leaderboardThirteensManager.SetField(x => x.Workout02Rank, 5);
            leaderboardThirteensManager.SetField(x => x.Workout03Rank, 6);
            leaderboardThirteensManager.SetField(x => x.Workout04Rank, 7);
            leaderboardThirteensManager.SetField(x => x.Workout05Rank, 8);
            leaderboardThirteensManager.SetField(x => x.Workout01Score, 9);
            leaderboardThirteensManager.SetField(x => x.Workout02Score, 10);
            leaderboardThirteensManager.SetField(x => x.Workout03Score, 11);
            leaderboardThirteensManager.SetField(x => x.Workout04Score, 12);
            leaderboardThirteensManager.SetField(x => x.Workout05Score, 13);
            List<LeaderboardThirteen> leaderboardThirteensResult = leaderboardThirteensManager.GetObjectList();
                    
            return leaderboardThirteensResult;
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

            var athletes = LoadAthletes();
            athletes.ForEach(athlete => context.Athletes.Add(athlete));
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

            var affiliates = LoadAffiliates();
            affiliates.ForEach(affiliate => context.Affiliates.Add(affiliate));
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

            var leaderboardThirteens = LoadLeaderboardThirteens();
            leaderboardThirteens.ForEach(leaderboardThirteen => context.LeaderboardThirteens.Add(leaderboardThirteen));
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
