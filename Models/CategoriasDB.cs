namespace TechStoreMVC.Models;

public class CategoriasDB
{
    private static readonly List <Categoria> categorias= new()
    {
                new Categoria(1,"Mouse Gamer","Categoria destinada ao Mouse Gamer"),
                new Categoria(2,"Teclado mecânico", "249.9m,5"),
                new Categoria(3,"Monitor 24 polegadas", "899.9m,8"),
                new Categoria(4,"Headset Gamer", "179.9m,15")  
    };
    public List<Categoria> Listar()
    {
        return categorias;
    }

    public Categoria? buscarPorId(int id)
    {
        return categorias.FirstOrDefault(
            categoria=> categoria.Id == id
        );
    }
    public void Adicionar ( Categoria categoria)
    {
    categoria.Id = categorias.Count + 1;
    categorias.Add(categoria);
    }
    public bool Atualizar (Categoria CategoriaAtualizada)
    {
        Categoria? categoriaExistente=
        buscarPorId (CategoriaAtualizada.Id);
        
        if (categoriaExistente is null)
        return false;

        categoriaExistente.Nome= CategoriaAtualizada.Nome;
        categoriaExistente.Descricao= CategoriaAtualizada.Descricao;
        // categoriaExistente.Ativa=CategoriaAtualizada.Ativa;

        return true;
    }

    public bool Excluir(int id)
    {
        Categoria? categoria = buscarPorId (id);
        if(categoria is null)
        return false;
        categorias.Remove (categoria);
        return true;
    }
}