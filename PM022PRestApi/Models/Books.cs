﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PM022PRestApi.Models
{
    public class Books
    {
        public int userId { get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public string body { get; set; }
    }

}
