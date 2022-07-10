using System;
using System.Collections.Generic;
using System.Text;

namespace BitheroesBot.Base
{
    public class FromTo
    {
        public string From { get; set; } = string.Empty;
        public string To { get; set; } = string.Empty;
        public FromTo(string from, string to)
        {
            From = from;
            To = to;
        }
    }
}
