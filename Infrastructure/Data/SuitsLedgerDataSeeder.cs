using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Infrastructure.Data
{


    public static class SuitsLedgerDataSeeder
    {
        public static async Task SeedAsync(SuitLedgerContext context)
        {
            try
            {
                if (!context.AuthorizedPersons.Any())
                {
                    var authorizedPersonsData = File.ReadAllText("../Infrastructure/Data/Seed/AuthorizedPeople.json");
                    var authorizedPersons = JsonConvert.DeserializeObject<List<AuthorizedPerson>>(authorizedPersonsData, new CustomDateTimeConverter());

                    foreach (var item in authorizedPersons)
                    {
                        context.AuthorizedPersons.Add(item);
                    }
                    await context.SaveChangesAsync();

                }

                if (!context.Suits.Any())
                {
                    var suitsData = File.ReadAllText("../Infrastructure/Data/Seed/Suits.json");
                    var suits = JsonConvert.DeserializeObject<List<Suit>>(suitsData, new CustomDateTimeConverter());

                    foreach (var item in suits)
                    {
                        context.Suits.Add(item);
                    }
                    await context.SaveChangesAsync();

                }

            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }

        }
    }
}