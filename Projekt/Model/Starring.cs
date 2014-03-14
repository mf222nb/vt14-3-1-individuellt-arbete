using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projekt.Model
{
    public class Starring
    {
        //Egenskaper som är lika som de tabeller är i databasen
        public int StarringID { get; set; }
        public int MovieID { get; set; }
        public int ActorID { get; set; }
        [Required(ErrorMessage = "En roll måste anges")]
        [StringLength(40, ErrorMessage = "Rollen kan bara bestå av 40 tecken som max")]
        public string Character { get; set; }
    }
}