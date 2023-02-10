using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TP1.Models;

namespace TP1.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    public static UserContext context = new UserContext();

    public UserController()
    {

    }

    [HttpGet]
    public List<string> Get()
    {
        List<string> temp = context.Users.Include(u => u.Produits).Select(u => u.Nom).ToList();
        return temp;
    }

    [HttpGet]
    [Route("{id}")]
    public IActionResult Get(int id)
    {
        var userTempo = context.Users.Include(u => u.Produits).First(u => u.id == id);

        if (userTempo != null)
        {
            return Ok(userTempo);
        }
        else
        {
            return NotFound($"L'utilisateur avec l'id {id} est introuvable.");
        }
    }

    [HttpPost]
    public List<User> Post([FromBody] User user)
    {
        context.Users.Add(user);
        context.SaveChanges();
        return context.Users.ToList();
    }

    [HttpPut]
    [Route("{id}")]
    public string Put([FromBody] User user)
    {
        try
        {
            User tempo = context.Users.Find(user.id);
            tempo.Nom = user.Nom;
            tempo.Prenom = user.Prenom;
            tempo.Email = user.Email;
            context.SaveChanges();
            return "L'utilisateur a bien été modifié.";
        }
        catch
        {
            return "Identifiant introuvable...";
        }

    }

    [HttpDelete]
    [Route("{id}")]
    public string Delete (int id)
    {
        try
        {
            User tempo = context.Users.Find(id);
            context.Users.Remove(tempo);
            context.SaveChanges();
            return "L'utilisateur a bien été supprimé de la liste.";
        }
        catch
        {
            return "Identifiant introuvable, suppression impossible.";
        }
    }   
}
