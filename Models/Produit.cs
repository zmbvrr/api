namespace TP1.Models;
public class Produit{
    public int id {get; set;}
    public string Nom {get; set;}
    public string Description {get; set;}
    public double Prix {get; set;}


    public int UserID {get; set;}
    public User? User {get; set;}


    public Produit()
    {
    
    }

    public Produit(string nom, string description, User user)
    {
        this.User = user;
        this.UserID = user.id;
        this.Nom = nom;
        this.Description = description;
        this.User.Produits.Add(this);
    }
}