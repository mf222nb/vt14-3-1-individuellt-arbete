using Projekt.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Projekt.Pages
{
    public partial class MovieDetails : System.Web.UI.Page
    {
        public int MovieID { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // The id parameter should match the DataKeyNames value set on the control
        // or be decorated with a value provider attribute, e.g. [QueryString]int id
        public Movie MovieFormView_GetItem([RouteData]int id)
        {
            try
            {
                MovieID = id;
                return Service.GetMovie(id);
            }
            catch
            {
                ModelState.AddModelError(String.Empty, String.Format("Det gick inte att hämta filmerna"));
                return null;
            }
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void MovieFormView_DeleteItem([RouteData]int id)
        {
            try
            {
                Service.DeleteMovie(id);
                this.SetTempData("SuccessMessage", "Filmen har tagits bort");
                Response.RedirectToRoute("Movies");
            }
            catch
            {
                ModelState.AddModelError(String.Empty, String.Format("Det gick inte att ta bort filmen"));
            }
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void MovieFormView_UpdateItem([RouteData]int id)
        {
            try
            {
                var movie = Service.GetMovie(id);
                // Load the item here, e.g. item = MyDataLayer.Find(id);
                if (movie == null)
                {
                    // The item wasn't found
                    ModelState.AddModelError(String.Empty, String.Format("Ett fel inträffade när filmen med ID {0} skulle hämtas", id));
                    return;
                }
                TryUpdateModel(movie);
                if (ModelState.IsValid)
                {
                    // Save changes here, e.g. MyDataLayer.SaveChanges();
                    Service.SaveMovie(movie);
                    this.SetTempData("SuccessMessage", "Filmen uppdaterades");
                    Response.RedirectToRoute("Movies");
                }
            }
            catch
            {
                ModelState.AddModelError(String.Empty, String.Format("Ett fel inträffade när filmen med ID {0} skulle hämtas", id));
            }
        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IEnumerable<Starring> ActorListView_GetData([RouteData]int id)
        {
            try
            {
                return Service.GetMovieCharacters(id);
            }
            catch
            {
                ModelState.AddModelError(String.Empty, String.Format("Ett fel inträffade när rollerna med ID {0} skulle hämtas", id));
                return null;
            }
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void ActorListView_UpdateItem(int StarringID)
        {
            try
            {
                var character = Service.GetCharacter(StarringID);
                // Load the item here, e.g. item = MyDataLayer.Find(id);
                if (character == null)
                {
                    // The item wasn't found
                    ModelState.AddModelError(String.Empty, String.Format("Ett fel inträffade när rollen med ID {0} skulle hämtas", StarringID));
                    return;
                }
                TryUpdateModel(character);
                if (ModelState.IsValid)
                {
                    // Save changes here, e.g. MyDataLayer.SaveChanges();
                    Service.SaveStarring(character);
                    this.SetTempData("SuccessMessage", "Rollen uppdaterades");
                    Response.RedirectToRoute("MovieDetails");
                }
            }
            catch
            {
                ModelState.AddModelError(String.Empty, String.Format("Ett fel inträffade när rollen med ID {0} skulle hämtas", StarringID));
            }
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void ActorListView_DeleteItem(int StarringID)
        {
            try
            {
                Service.DeleteStarring(StarringID);
                this.SetTempData("SuccessMessage", "Rollen togs bort");
                Response.RedirectToRoute("MovieDetails");
            }
            catch
            {
                ModelState.AddModelError(String.Empty, String.Format("Ett fel inträffade när rollen med ID {0} skulle tas bort", StarringID));
            }
        }

        //Anropar metod för att hämta ut en lista med alla skådespelare och presentera dem i en droopdown lista
        public IEnumerable<Actor> ActorDropDownList_GetData()
        {
            try
            {
                return Service.GetActors();
            }
            catch
            {
                ModelState.AddModelError(String.Empty, String.Format("Det gick inte att hämta skådespelarna"));
                return null;
            }
        }

        //Anropar en metod för att lägga till en ny roll
        public void ActorListView_InsertItem()
        {
            try
            {
                var item = new Starring();
                TryUpdateModel(item);
                if (ModelState.IsValid)
                {
                    // Save changes here
                    item.MovieID = MovieID;
                    Service.SaveStarring(item);
                    this.SetTempData("SuccessMessage", "Rollen lades till");
                    Response.RedirectToRoute("MovieDetails");
                }
            }
            catch
            {
                ModelState.AddModelError(String.Empty, String.Format("Ett fel inträffade när rollen skulle läggas till"));
            }
        }
    }
}