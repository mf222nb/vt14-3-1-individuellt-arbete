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
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // The id parameter should match the DataKeyNames value set on the control
        // or be decorated with a value provider attribute, e.g. [QueryString]int id
        public Movie MovieFormView_GetItem([RouteData]int id)
        {
            return Service.GetMovie(id);
        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IEnumerable<Actor> ActorListView_GetData([RouteData]int id)
        {
            return Service.GetMovieActor(id);
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void MovieFormView_DeleteItem([RouteData]int id)
        {
            Service.DeleteMovie(id);
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void MovieFormView_UpdateItem([RouteData]int id)
        {
            var movie = Service.GetMovie(id);
            // Load the item here, e.g. item = MyDataLayer.Find(id);
            if (movie == null)
            {
                // The item wasn't found
                ModelState.AddModelError("", String.Format("Ett fel inträffade när filmen med ID {0} skulle hämtas", id));
                return;
            }
            TryUpdateModel(movie);
            if (ModelState.IsValid)
            {
                // Save changes here, e.g. MyDataLayer.SaveChanges();
                Service.SaveMovie(movie);
            }
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void ActorListView_UpdateItem(int ActorID)
        {
            var actor = Service.GetActor(ActorID);
            // Load the item here, e.g. item = MyDataLayer.Find(id);
            if (actor == null)
            {
                // The item wasn't found
                ModelState.AddModelError("", String.Format("Ett fel inträffade när skådespelaren med ID {0} skulle hämtas", ActorID));
                return;
            }
            TryUpdateModel(actor);
            if (ModelState.IsValid)
            {
                // Save changes here, e.g. MyDataLayer.SaveChanges();
                Service.SaveActor(actor);
            }
        }
    }
}