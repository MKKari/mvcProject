using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TeamManagment.Classes;
using TeamManagment.Models;

namespace TeamManagment.Controllers
{   [Authorize]
    public class TeamsController : Controller
    {
        private ApplicationDbContext db;
        private ManagmentLogic mngLogic;

        public TeamsController() {
            db = new ApplicationDbContext();
            mngLogic = new ManagmentLogic(db);
        }


        // GET: Teams
        public ActionResult Index()
        {
            var model = new TeamIndexModel
            {
                AvailablePlayers = mngLogic.getAvailablePlayers(),
                Teams = db.Teams.ToList(),
            };

            return View(model);
        }

        // GET: Teams/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Team team = db.Teams.Find(id);
            if (team == null)
            {
                return HttpNotFound();
            }
            ViewBag.TeamPlayers = mngLogic.getTeamPlayers(team);
            return View(team);
        }

        // GET: Teams/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Teams/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] Team team)
        {
            if (ModelState.IsValid)
            {
                if (db.Teams.Any(dbTeam => dbTeam.Name == team.Name))
                {
                    return RedirectToAction("Create");

                }
                db.Teams.Add(team);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(team);
        }

        // GET: Teams/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Team team = db.Teams.Find(id);
            if (team == null)
            {
                return HttpNotFound();
            }
            return View(team);
        }

        // POST: Teams/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] Team team)
        {
            if (ModelState.IsValid)
            {
                db.Entry(team).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(team);
        }

        // GET: Teams/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Team team = db.Teams.Find(id);
            if (team == null)
            {
                return HttpNotFound();
            }
            return View(team);
        }

        // POST: Teams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Team team = db.Teams.Find(id);
            mngLogic.removeTeam(team);
            return RedirectToAction("Index");
        }

        // GET: Teams/RemovePlayerFromTeam/5
        public ActionResult RemovePlayerFromTeam(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Player player = db.Players.Find(id);
            if (player == null)
            {
                return HttpNotFound();
            }
           // ViewBag.PlayersTeam = player.team.Name;
            return View(player);
        }


        // POST: Teams/RemovePlayerFromTeam/5
        [HttpPost, ActionName("RemovePlayerFromTeam")]
        [ValidateAntiForgeryToken]
        public ActionResult RemovePlayerFromTeamConfirmed(int id)
        {
            Player player = db.Players.Find(id);
            mngLogic.removePlayerFromTeam(player);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AddPlayerToTeam(int id)
        {
            ShowTeamsViewModel teams = new ShowTeamsViewModel
            {
                PlayerId = id,
                Teams = mngLogic.GetAvailableTeams(),
            };

            return View(teams);
        }

        [HttpPost]
        public ActionResult AddPlayerToTeam(ShowTeamsViewModel model)
        {
            mngLogic.AddPlayerToTeam(model.PlayerId, model.SelectedTeamId);
            return RedirectToAction("Index");
        }

        //DOESNT WORK
     /*   [HttpPost]
        public JsonResult IsTeamNameAvailable(string TeamName)
        {
            return Json(!db.Teams.Any(team => team.Name == TeamName));
        }*/

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}