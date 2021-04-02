using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quotes.Models
{
    public class EFQuotesRepository : IQuotesRepository
    {
        private QuotesDbContext _context;
        //constructor
        public EFQuotesRepository(QuotesDbContext context)
        {
            _context = context;
        }

        public IQueryable<QuoteByPeople> Quotes => _context.Quotes;

       
    }
}
