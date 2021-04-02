using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quotes.Models.View_Model
{
    public class QuoteList
    {
        //make quote into a list
        public IEnumerable<QuoteByPeople> Quotes { get; set; }
    }
}
