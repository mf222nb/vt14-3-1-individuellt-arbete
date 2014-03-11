using Projekt.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Projekt.Pages
{
    public partial class ActorList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IEnumerable<Actor> ActorListView_GetData()
        {
            try
            {
                return Service.GetActors();
            }
            catch
            {
                ModelState.AddModelError(String.Empty, String.Format("Skådespelarna hämtades inte"));
                return null;
            }
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void ActorListView_UpdateItem(int ActorID)
        {
            try
            {
                var actor = Service.GetActor(ActorID);
                // Load the item here, e.g. item = MyDataLayer.Find(id);
                if (actor == null)
                {
                    // The item wasn't found
                    ModelState.AddModelError(String.Empty, String.Format("Skådespelaren med ID {0} hämtades inte", ActorID));
                    return;
                }
                TryUpdateModel(actor);
                if (ModelState.IsValid)
                {
                    // Save changes here, e.g. MyDataLayer.SaveChanges();
                    Service.SaveActor(actor);
                    this.SetTempData("SuccessMessage", "Skådespelaren uppdaterades");
                    Response.RedirectToRoute("Actors");
                }
            }
            catch
            {
                ModelState.AddModelError(String.Empty, String.Format("Skådespelaren med ID {0} hämtades inte", ActorID));
            }
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void ActorListView_DeleteItem(int ActorID)
        {
            try
            {
                Service.DeleteActor(ActorID);
                this.SetTempData("SuccessMessage", "Skådespelaren togs bort");
                Response.RedirectToRoute("Actors");
            }
            catch
            {
                ModelState.AddModelError(String.Empty, String.Format("Skådespelaren med ID {0} gick inte att ta bort", ActorID));
            }
        }

        //Insert actor
        public void ActorListView_InsertItem()
        {
            try
            {
                var actor = new Actor();
                TryUpdateModel(actor);
                if (ModelState.IsValid)
                {
                    // Save changes here
                    Service.SaveActor(actor);
                    this.SetTempData("SuccessMessage", "Skådespelaren lades till");
                    Response.RedirectToRoute("Actors");
                }
            }
            catch
            {
                ModelState.AddModelError(String.Empty, String.Format("Skådespelaren lades inte till"));
            }
        }
    }
}