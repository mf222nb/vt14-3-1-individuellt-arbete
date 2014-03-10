using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projekt.Model
{
    public class Actor
    {
        public int ActorID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Born { get; set; }
        public string Name { get { return String.Format("{0} {1}", FirstName, LastName); } }
    }
}