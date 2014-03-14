using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projekt.Model
{
    public class Movie
    {
        //Egenskaper som är lika som de tabeller är i databasen
        public int MovieID { get; set; }
        [Required(ErrorMessage = "En titel måste anges")]
        [StringLength(50, ErrorMessage = "Titeln kan bara bestå av 20 tecken som max")]
        public string Titel { get; set; }
        [Required(ErrorMessage = "Längden måste anges")]
        public byte Length { get; set; }
    }
}