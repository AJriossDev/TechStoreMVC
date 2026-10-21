using Microsoft.AspNetCore.Mvc;
using TechStoreMVC.Models;

namespace TechStoreMVC.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly ProdutosDB _produtosDB;
        public ProdutosController()
        {
            _produtosDB = new ProdutosDB();
        }
        // GET: ProdutosContoller

        // Passo 02- Criar a ação
        //uma view depende da ação e vice-versa
        [HttpGet]
        public ActionResult Index()
        {
           List<Produto> produtos =_produtosDB.Listar();
           return View (produtos);
        }
        [HttpGet]
        public IActionResult Details (int id)
        {
            Produto? produto = _produtosDB.buscarPorId(id);
            if (produto is null)
            return NotFound();
            return View (produto);
        }
        [HttpGet]
        public   IActionResult Create ()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create (Produto produto)
        {
            if (!ModelState.IsValid)
            return View (produto);

            _produtosDB.Adicionar(produto);
            TempData["Sucesso"] =
            "Produto cadastrado com sucesso!";
             return RedirectToAction(nameof(Index));
        }

         [HttpGet]
        public IActionResult Edit(int id)
        {
            Produto? produto = _produtosDB.buscarPorId(id);
             if (produto is null)
                return NotFound();
            return View(produto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Produto produto, int id)
        {
            if(id != produto.Id)
            { 
            return BadRequest();
            }
            bool atulizado = _produtosDB.Atualizar(produto);
           
            if (!atulizado)
            {
                return NotFound();
            }
            if(!ModelState.IsValid)
            { 
                return View(produto);
            }
         
            TempData["Sucesso"] = 
                "Produto cadastrado com sucesso!";

            return RedirectToAction(nameof(Index));
            }

            [HttpGet]
        public IActionResult Delete (int id)
        {
            Produto? produto = _produtosDB.buscarPorId(id);
             if (produto is null)
                return NotFound();
            return View(produto);
        }
         [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Produto produto, int id)
        {
            if(id != produto.Id)
            { 
            return BadRequest();
            }
            bool atulizado = _produtosDB.Atualizar(produto);
           
            if (!atulizado)
            {
                return NotFound();
            }
            if(!ModelState.IsValid)
            { 
                return View(produto);
            }
         
            TempData["Sucesso"] = 
                "Produto cadastrado com sucesso!";

            return RedirectToAction(nameof(Index));
            }
    }
}
