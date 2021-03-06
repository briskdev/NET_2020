﻿using System;
using System.Collections.Generic;

namespace WebCatalog.Database
{
    public partial class Items
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Location { get; set; }
        public int CategoryId { get; set; }
    }
}
