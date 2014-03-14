using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projekt.Model
{
    public class StarringActor : Starring
    {
        //Egenskap som lägger in hela skådespelarnamnet 
        public string ActorName { get; set; }
    }
}