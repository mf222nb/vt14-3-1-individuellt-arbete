using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projekt.Model
{
    public class Actor
    {
        public int ActorID { get; set; }
        [Required(ErrorMessage = "Ett förnamn måste anges")]
        [StringLength(20, ErrorMessage = "Förnamnet kan bara bestå av 20 tecken som max")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Ett efternamn måste anges")]
        [StringLength(25, ErrorMessage = "Efternamnet kan bara bestå av 25 tecken som max")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Ett födelsedatum måste anges")]
        public DateTime Born { get; set; }
        //Slår ihop förnamn och efternamn så att de visas som ett namn med både förnamn och efternamn
        public string Name { get { return String.Format("{0} {1}", FirstName, LastName); } }
    }
}