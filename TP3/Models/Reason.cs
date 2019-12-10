using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TP3.Models
{
    public class Reason
    {
         public int ReasonID { get; set; }

        public string Label { get; set; }

        public string ReasonCost { get; set; }

        public int duration { get; set; }


    }
}