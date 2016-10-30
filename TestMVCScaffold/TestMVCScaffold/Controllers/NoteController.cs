using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestMVCScaffold.Models;

namespace TestMVCScaffold.Controllers
{   
    public class NoteController : Controller
    {
		private readonly ITaskRepository taskRepository;
		private readonly INoteRepository noteRepository;

		// If you are using Dependency Injection, you can delete the following constructor
        public NoteController() : this(new TaskRepository(), new NoteRepository())
        {
        }

        public NoteController(ITaskRepository taskRepository, INoteRepository noteRepository)
        {
			this.taskRepository = taskRepository;
			this.noteRepository = noteRepository;
        }

        //
        // GET: /Note/

        public ViewResult Index()
        {
            return View(noteRepository.All);
        }

        //
        // GET: /Note/Details/5

        public ViewResult Details(int id)
        {
            return View(noteRepository.Find(id));
        }

        //
        // GET: /Note/Create

        public ActionResult Create()
        {
			ViewBag.PossibleTask = taskRepository.All;
            return View();
        } 

        //
        // POST: /Note/Create

        [HttpPost]
        public ActionResult Create(Note note)
        {
            if (ModelState.IsValid) {
                noteRepository.InsertOrUpdate(note);
                noteRepository.Save();
                return RedirectToAction("Index");
            } else {
				ViewBag.PossibleTask = taskRepository.All;
				return View();
			}
        }
        
        //
        // GET: /Note/Edit/5
 
        public ActionResult Edit(int id)
        {
			ViewBag.PossibleTask = taskRepository.All;
             return View(noteRepository.Find(id));
        }

        //
        // POST: /Note/Edit/5

        [HttpPost]
        public ActionResult Edit(Note note)
        {
            if (ModelState.IsValid) {
                noteRepository.InsertOrUpdate(note);
                noteRepository.Save();
                return RedirectToAction("Index");
            } else {
				ViewBag.PossibleTask = taskRepository.All;
				return View();
			}
        }

        //
        // GET: /Note/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View(noteRepository.Find(id));
        }

        //
        // POST: /Note/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            noteRepository.Delete(id);
            noteRepository.Save();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                taskRepository.Dispose();
                noteRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

