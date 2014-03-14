using Projekt.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Projekt.Pages
{
    public partial class Create : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //Lägger till en film i databasen och visar ett meddelande när det är gjort, om något går fel visas ett meddelande
        public void CreateFormView_InsertItem()
        {
            try
            {
                var item = new Movie();
                TryUpdateModel(item);
                if (ModelState.IsValid)
                {
                    Service.SaveMovie(item);
                    this.SetTempData("SuccessMessage", "Filmen lades till");
                    Response.RedirectToRoute("MovieDetails", new { id = item.MovieID });
                }
            }
            catch
            {
                ModelState.AddModelError(String.Empty, String.Format("Filmen lades inte till"));
            }
            
        }

    }
}