using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using videoStore.Models;

namespace videoStore.Models
{
    public class GenreModel
    {
        public int GenreID { get; set; }
        public string GenreName { get; set; }
    }
}