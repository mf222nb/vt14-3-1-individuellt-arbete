﻿using Projekt.Model;
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

        public void CreateFormView_InsertItem()
        {
            var item = new Movie();
            TryUpdateModel(item);
            if (ModelState.IsValid)
            {
                // Save changes here
                Service.SaveMovie(item);
                Response.RedirectToRoute("MovieDetails", new { id = item.MovieID });
            }
            
        }

    }
}