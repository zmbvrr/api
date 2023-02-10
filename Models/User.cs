namespace TP1.Models;
public class User{
    public int id {get;set;}
    public string Nom {get;set;}
    public string Prenom {get;set;}
    public string Email {get;set;}


    public List<Produit>? Produits {get; set;}


    public User()
    {

    }

    public User(string nom, string prenom, string email)
    {
        Nom = nom;
        Prenom = prenom;
        Email = email;
    }
}