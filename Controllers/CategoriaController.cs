using Microsoft.AspNetCore.Mvc;
using TechStoreMVC.Models;

namespace TechStoreMVC.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly CategoriasDB _categoriasDB;
        public CategoriaController()
        {
            _categoriasDB = new CategoriasDB();
        }
        // GET: ProdutosContoller

        // Passo 02- Criar a ação
        //uma view depende da ação e vice-versa
        [HttpGet]
        public ActionResult Index()
        {
           List<Categoria> categorias =_categoriasDB.Listar();
           return View (categorias);
        }
        [HttpGet]
        public IActionResult Details (int id)
        {
            Categoria? categoria = _categoriasDB.buscarPorId(id);
            if (categoria is null)
            return NotFound();
            return View (categoria);
        }
        [HttpGet]
        public   IActionResult Create ()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create (Categoria categoria)
        {
            if (!ModelState.IsValid)
            return View (categoria);

            _categoriasDB.Adicionar(categoria);
            TempData["Sucesso"] =
            "Categoria cadastrada com sucesso!";
             return RedirectToAction(nameof(Index));
        }

         [HttpGet]
        public IActionResult Edit(int id)
        {
            Categoria? categoria = _categoriasDB.buscarPorId(id);
             if (categoria is null)
                return NotFound();
            return View(categoria);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Categoria categoria, int id)
        {
            if(id != categoria.Id)
            { 
            return BadRequest();
            }
            bool atulizado = _categoriasDB.Atualizar(categoria);
           
            if (!atulizado)
            {
                return NotFound();
            }
            if(!ModelState.IsValid)
            { 
                return View(categoria);
            }
         
            TempData["Sucesso"] = 
                "Categoria cadastrada com sucesso!";

            return RedirectToAction(nameof(Index));
            }

            [HttpGet]
        public IActionResult Delete (int id)
        {
            Categoria? categoria = _categoriasDB.buscarPorId(id);
             if (categoria is null)
                return NotFound();
            return View(categoria);
        }
         [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Categoria categoria, int id)
        {
            if(id != categoria.Id)
            { 
            return BadRequest();
            }
            bool atulizado = _categoriasDB.Atualizar(categoria);
           
            if (!atulizado)
            {
                return NotFound();
            }
            if(!ModelState.IsValid)
            { 
                return View(categoria);
            }
         
            TempData["Sucesso"] = 
                "Categoria cadastrada com sucesso!";

            return RedirectToAction(nameof(Index));
            }
    }
}
