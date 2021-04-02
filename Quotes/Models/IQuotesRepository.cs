using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quotes.Models
{
    public interface IQuotesRepository
    {
        IQueryable<QuoteByPeople> Quotes { get; }
    }
}
