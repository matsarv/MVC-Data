﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Data.Models
{
    public class PersonView
    {
        public List<Person> persons = new List<Person>();
        public string SearchString { get; set; }
    }
}
