using Quero2pay.Context;
using Quero2pay.Models;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Quero2pay.Controllers
{
    public class FuncionariosController : Controller
    {
        private DBContext db = new DBContext();

        public ActionResult Index()
        {
            var funcionarios = db.Funcionarios.Include(f => f.Cargo).Include(f => f.Empresa);

            return View(funcionarios.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Funcionario funcionario = db.Funcionarios.Find(id);

            if (funcionario == null)
            {
                return HttpNotFound();
            }

            var cargo = new Cargo();
            var empresa = db.Empresas.Find(funcionario.idEmpresa);
            cargo = db.Cargos.Where(c => c.idCargo == funcionario.idCargo).SingleOrDefault();
            funcionario.Cargo = cargo;

            return View(funcionario);
        }

        public ActionResult Create()
        {
            ViewBag.idCargo = new SelectList(db.Cargos, "idCargo", "nmCargo");
            ViewBag.idEmpresa = new SelectList(db.Empresas, "idEmpresa", "nmEmpresa");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idFuncionario,nome,idEmpresa,idCargo")] Funcionario funcionario)
        {
            if (ModelState.IsValid)
            {
                db.Funcionarios.Add(funcionario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idCargo = new SelectList(db.Cargos, "idCargo", "nmCargo", funcionario.idCargo);
            ViewBag.idEmpresa = new SelectList(db.Empresas, "idEmpresa", "nmEmpresa", funcionario.idEmpresa);
            return View(funcionario);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Funcionario funcionario = db.Funcionarios.Find(id);
            if (funcionario == null)
            {
                return HttpNotFound();
            }
            ViewBag.idCargo = new SelectList(db.Cargos, "idCargo", "nmCargo", funcionario.idCargo);
            ViewBag.idEmpresa = new SelectList(db.Empresas, "idEmpresa", "nmEmpresa", funcionario.idEmpresa);
            return View(funcionario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idFuncionario,nome,idEmpresa,idCargo")] Funcionario funcionario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(funcionario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idCargo = new SelectList(db.Cargos, "idCargo", "nmCargo", funcionario.idCargo);
            ViewBag.idEmpresa = new SelectList(db.Empresas, "idEmpresa", "nmEmpresa", funcionario.idEmpresa);
            return View(funcionario);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Funcionario funcionario = db.Funcionarios.Find(id);
            if (funcionario == null)
            {
                return HttpNotFound();
            }
            return View(funcionario);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Funcionario funcionario = db.Funcionarios.Find(id);
            db.Funcionarios.Remove(funcionario);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

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
