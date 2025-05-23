public class Texte
{
    public string? Nom { get; set; }

    public Texte(string nom)
    {
        Nom = nom;
    }

    public void PresenterFruits()
    {
        Console.WriteLine("=== Voici la liste des fruits que tu peux planter ===");
        Console.WriteLine("1-Fraise\n2-Pastèque\n3-Pomme");
        Console.WriteLine("Cliques sur le chiffre correspondant au fruit que tu veux planter");
    }

    public void PresenterLegumes()
    {
        Console.WriteLine("=== Voici la liste des légumes que tu peux planter ===");
        Console.WriteLine("1-Aubergine\n2-Carotte\n3-Piment\n4-Salade\n5-Tomate");
        Console.WriteLine("Cliques sur le chiffre correspondant au légume que tu veux planter");
    }

    public void PresenterFleurs()
    {
        Console.WriteLine("=== Voici la liste des fleurs que tu peux planter ===");
        Console.WriteLine("1-Rose\n2-Tournesol\n3-Tulipe");
        Console.WriteLine("Cliques sur le chiffre correspondant à la fleur que tu veux planter");
    }

    public void PresenterAction()
    {
        Console.WriteLine("=== Voici la liste des actions que tu peux effectuer ===");
        Console.WriteLine("1-Arroser\n2-Soigner\n3-Exposer au soleil");
        Console.WriteLine("Cliques sur le chiffre correspondant à l'action que tu veux effectuer");
    }
}