using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bee.MySQL
{
    internal class QueryTypes
    {
        public enum QueryType
        {
            Select,
            Insert,
            Update,
            Delete,
            Other
        }
    }
}
