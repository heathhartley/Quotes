using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quotes.Models
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder application)
        {
            QuotesDbContext context = application.ApplicationServices.CreateScope().
                ServiceProvider.GetRequiredService<QuotesDbContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();

            }
            if (!context.Quotes.Any())
            {
                context.Quotes.AddRange(
                    new QuoteByPeople
                    {
                        QId = 1,

                        QuotesNote = "When in doubt go for it",
                        AuthorFirst = "Heath",
                        AuthorLast = "Hartley",

                        Subject = "Biography",
                        Date = new DateTime(2021, 04, 01),


                    },

                    new QuoteByPeople
                    {
                        QId = 2,

                        QuotesNote = "Go for it",
                        AuthorFirst = "Heath",
                        AuthorLast = "Hartley",

                        Subject = "Sports",
                        Date = new DateTime(2021, 03, 01),
                        Citation = "Heath's Book"
                    },
                    new QuoteByPeople
                    {
                        QId = 3,
                        QuotesNote = "This class is the best",
                        AuthorFirst = "Smitty",
                        AuthorLast = "Hartley",

                        Subject = "Education",
                        Date = new DateTime(2021, 02, 01),
                        Citation = "Heath's Life"


                    },

                    new QuoteByPeople
                    {
                        QId = 4,

                        QuotesNote = "Give me 100%",
                        AuthorFirst = "Every Student at BYU",
                        AuthorLast = " ",

                        Subject = "Education",
                        Date = new DateTime(2021, 03, 01),
                        Citation = "Every Students Mouth"

                    }

                    ); 

                context.SaveChanges();
            }
        }
    }
}
