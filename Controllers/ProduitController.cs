using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TP1.Models;

namespace TP1.Controllers;

[ApiController]
[Route("[controller]")]
public class ProduitController : ControllerBase
{
    
    public static UserContext context = new UserContext();

    public ProduitController()
    {

    }

    [HttpGet]
    public List<string> Get()
    {
        return context.Produits.Select(p => p.Nom).ToList();
    }

    [HttpPost]
    public List<Produit> Post([FromBody] Produit Produit)
    {
        context.Produits.Add(Produit);
        context.SaveChanges();
        return context.Produits.ToList();
    }

    [HttpPut]
    [Route("{id}")]
    public string Put([FromBody] Produit Produit)
    {
        Produit tempo = context.Produits.Find(Produit.id);
        tempo.Nom = Produit.Nom;
        tempo.Description = Produit.Description;
        tempo.Prix = Produit.Prix;
        context.SaveChanges();
        return "Le produit a bien été modifié.";
    }

    [HttpDelete]
    [Route("{id}")]
    public string Delete (int id)
    {
        Produit tempo = context.Produits.Find(id);
        context.Produits.Remove(tempo);
        context.SaveChanges();
        return "Le produit a bien été supprimé de la liste.";
    }   
}
