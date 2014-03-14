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

        //Hämtar alla skådespelare som finns i databasen och presenterar dem
        public IEnumerable<Actor> ActorListView_GetData(int maximumRows, int startRowIndex, out int totalRowCount)
        {
            try
            {
                return Service.GetActorsPageWise(maximumRows, startRowIndex, out totalRowCount);
            }
            catch
            {
                ModelState.AddModelError(String.Empty, String.Format("Skådespelarna hämtades inte"));
                totalRowCount = 0;
                return null;
            }
        }

        // The id parameter name should match the DataKeyNames value set on the control
        //Uppdaterar en skådespelare genom att hämta skådespelaren och sedan ändra den
        public void ActorListView_UpdateItem(int ActorID)
        {
            try
            {
                var actor = Service.GetActor(ActorID);
                if (actor == null)
                {
                    ModelState.AddModelError(String.Empty, String.Format("Skådespelaren med ID {0} hämtades inte", ActorID));
                    return;
                }
                TryUpdateModel(actor);
                if (ModelState.IsValid)
                {
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
        //Tar bort en skådespelare och visar ett meddelande att den har tagits bort
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

        //Lägga till skådespelare i databasen och om något går fel så kommer ett felmeddelande, när skådespelaren har sparats så visas ett rättmeddelande
        public void ActorListView_InsertItem()
        {
            try
            {
                var actor = new Actor();
                TryUpdateModel(actor);
                if (ModelState.IsValid)
                {
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