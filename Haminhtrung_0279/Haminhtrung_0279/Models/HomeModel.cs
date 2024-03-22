using Haminhtrung_0279.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Haminhtrung_0279.Models
{
    public class HomeModel
    {
        public List<product> ListProduct { get; set; }
        public List<category> ListCategory { get; set; }
    }

}