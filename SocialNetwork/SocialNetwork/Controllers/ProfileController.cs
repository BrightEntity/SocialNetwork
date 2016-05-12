using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SocialNetwork.Models;
using Microsoft.AspNet.Identity;
using SocialNetwork;
using Microsoft.AspNet.Identity.EntityFramework;

namespace SocialNetwork.Controllers
{
    public class ProfileController : Controller
    {
        ApplicationUserManager manager = new ApplicationUserManager(new UserStore<ApplicationUser>(new ApplicationDbContext()));

        // GET: Profile
        public ActionResult Index(string id = null)
        {
            Profile profile = null;
            if (id == null)
            {
                profile = User.GetApplicationUser().SocialProfile;
            }
            else
            {
                
                try
                {
                    var ctx = new ApplicationDbContext();
                    profile = ctx.Profiles.Find(new { Id = Convert.ToInt32(id) });
                    if (profile == null)
                    {
                        return HttpNotFound("Profil introuvable.");
                    }
                    /*
                     //TODO: A implémenter côté modèle : URL customisée du profil
                    profile = ctx.Profiles.Find(new { Url = id });
                    if (profile == null)
                    {
                        return HttpNotFound("Profil introuvable.");
                    }
                    */

                    //TODO: Si le profil requiert une authentification pour être vu, renvoyer une erreur 404 si l'utilisateur est anonyme.

                    //TODO: Si le profil a bloqué l'utilisateur en cours, renvoyer une erreur 404


                }
                catch (Exception)
                {
                    return HttpNotFound("Erreur dans la recherche du profil.");
                }
            }
            
            return View("Profile", model: profile);
        }

        // GET: Profile/Details/5
        public ActionResult Details(string id)
        {
            try
            {
                var profile = manager.FindById(id).SocialProfile;
                return View("Profile", model: profile);
            }
            catch (Exception)
            {
                return HttpNotFound("Utilisateur introuvable");
            }
            
            
        }

        // GET: Profile/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Profile/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Profile/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Profile/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Profile/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Profile/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
