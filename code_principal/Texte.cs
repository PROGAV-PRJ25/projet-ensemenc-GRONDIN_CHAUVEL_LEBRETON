public class Texte
{
    public string? Nom { get; set; }

    public Texte(string nom)
    {
        Nom = nom;
    }

    public void DefinirTerrain()
    {      
        Console.WriteLine("Voici les différents types de terrains possibles :")
        Console.WriteLine("");
        Console.WriteLine("1. Terrain Argileux");
        Console.WriteLine("   Description: Sol riche en nutriments mais drainant mal.");
        Console.WriteLine("   Avantages: Riche et fertile, idéal pour les légumes-racines.");
        Console.WriteLine("   Inconvénients: Peut être lourd et compact quand il est mouillé.\n");
        Console.WriteLine("");  
        Console.WriteLine("2. Terrain Limoneux");
        Console.WriteLine("   Description: Sol équilibré et fertile, le meilleur pour un potager traditionnel.");
        Console.WriteLine("   Avantages: S'adapte à la plupart des plantes cultivées.");
        Console.WriteLine("   Inconvénients: Peut nécessiter un entretien régulier.\n");
        Console.WriteLine("");
        Console.WriteLine("3. Terrain Forestier");
        Console.WriteLine("   Description: Sol ombragé et riche en matière organique.");
        Console.WriteLine("   Avantages: Excellent pour les plantes d'ombre et les baies sauvages.");
        Console.WriteLine("   Inconvénients: Peu de lumière et compétition avec les racines d'arbres.\n");
        Console.WriteLine("");
        Console.WriteLine("4. Terrain Sableux");
        Console.WriteLine("   Description: Sol drainant et chaud, idéal pour les plantes méditerranéennes.");
        Console.WriteLine("   Avantages: Bonne croissance pour les plantes qui aiment la chaleur et le sol sec.");
        Console.WriteLine("   Inconvénients: Retient peu l'eau et les nutriments.\n");
        Console.WriteLine("");
        Console.Write("Cliquez sur le numéro de votre choix (1-4)");
        Console.WriteLine("");
        
    }

    public void PresenterFruits()
    {
        Console.WriteLine("=== Voici la liste des fruits que tu peux planter ===");
        Console.WriteLine("1-Fraise\n2-Pastèque\n3-Pomme");
        Console.WriteLine("Clique sur le chiffre correspondant au fruit que tu veux planter");
        Console.WriteLine("");
    }

    public void PresenterLegumes()
    {
        Console.WriteLine("=== Voici la liste des légumes que tu peux planter ===");
        Console.WriteLine("1-Aubergine\n2-Carotte\n3-Piment\n4-Salade\n5-Tomate");
        Console.WriteLine("Clique sur le chiffre correspondant au légume que tu veux planter");
        Console.WriteLine("");
    }

    public void PresenterFleurs()
    {
        Console.WriteLine("=== Voici la liste des fleurs que tu peux planter ===");
        Console.WriteLine("1-Rose\n2-Tournesol\n3-Tulipe");
        Console.WriteLine("Clique sur le chiffre correspondant à la fleur que tu veux planter");
        Console.WriteLine("");
    }

    public void PresenterAction()
    {
        Console.WriteLine("=== Voici la liste des actions que tu peux effectuer ===");
        Console.WriteLine("1-Arroser\n2-Soigner\n3-Exposer au soleil");
        Console.WriteLine("Clique sur le chiffre correspondant à l'action que tu veux effectuer");
        Console.WriteLine("");
    }
}