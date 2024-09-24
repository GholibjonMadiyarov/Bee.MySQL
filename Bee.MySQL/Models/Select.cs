﻿using System.Collections.Generic;

namespace Bee.MySQL.Models
{
    public class Select
    {
        public bool execute { get; set; }
        public string message { get; set; }
        public List<Dictionary<string, object>> data { get; set; }

        public Select() 
        {
            execute = false;
            message = null;
            data = new List<Dictionary<string, object>>();
        }
    }
}
