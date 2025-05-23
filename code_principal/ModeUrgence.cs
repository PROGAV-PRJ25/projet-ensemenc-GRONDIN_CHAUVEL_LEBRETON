// ModeUrgence.cs
public class ModeUrgence
{
    private Terrain terrain;
    private Random random;

    public ModeUrgence(Terrain terrain)
    {
        this.terrain = terrain;
        this.random = new Random();
    }

    public void DeclencherAttaqueDragon()
{
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("🚨 ALERTE URGENCE 🚨");
    Console.WriteLine("Un dragon attaque votre potager !");
    Console.ResetColor();

    Thread.Sleep(2000);

    // Ajouter le dragon au terrain
    var (x, y, ancienneValeur) = AjouterDragonSurTerrain();
    terrain.AfficherT();

    ProposerChoixUrgence();

    // 🔁 Faire disparaître le dragon après l'action
    terrain.T[x, y] = ancienneValeur;

    Console.WriteLine("\n🐉 Le dragon a quitté le terrain...");
    terrain.AfficherT();
}

    private (int x, int y, int ancienneValeur) AjouterDragonSurTerrain()
    {
        int x = random.Next(0, terrain.Lignes);
        int y = random.Next(0, terrain.Colonnes);
        int ancienneValeur = terrain.T[x, y];

        terrain.T[x, y] = 20; // Code pour le dragon
        Console.WriteLine($"🐉 Le dragon apparaît en position ({x}, {y}) !");
        return (x, y, ancienneValeur);
    }

    private void ProposerChoixUrgence()
    {
        if (terrain.PlantesCultivees.Count == 0)
        {
            Console.WriteLine("Heureusement, il n'y a pas de plantes sur le terrain !");
            return;
        }

        Console.WriteLine("\n🔥 Le dragon va attaquer ! Choisissez votre stratégie :");
        Console.WriteLine("1. 🛡️  Protéger toutes les plantes (elles deviennent malades)");
        Console.WriteLine("2. 🏃 Évacuer la moitié des plantes (les autres sont détruites)");
        Console.Write("Votre choix (1 ou 2) : ");

        string choix = Console.ReadLine();

        switch (choix)
        {
            case "1":
                ExecuterProtectionTotale();
                break;
            case "2":
                ExecuterEvacuationPartielle();
                break;
            default:
                Console.WriteLine("Choix invalide ! Évacuation par défaut...");
                ExecuterEvacuationPartielle();
                break;
        }

        // Afficher le terrain après l'attaque
        Console.WriteLine("\nÉtat du terrain après l'attaque :");
        terrain.AfficherT();
    }

    private void ExecuterProtectionTotale()
    {
        Console.WriteLine("\n🛡️ PROTECTION TOTALE ACTIVÉE !");
        Console.WriteLine("Toutes vos plantes sont protégées mais tombent malades...");

        Thread.Sleep(1500);

        // Toutes les plantes deviennent malades
        foreach (var plante in terrain.PlantesCultivees)
        {
            plante.Contaminer("attaque de dragon");
        }

        Console.WriteLine($"✅ {terrain.PlantesCultivees.Count} plantes sauvées (mais malades) !");
        Console.WriteLine("💡 Utilisez des soins pour les guérir.");
    }

    private void ExecuterEvacuationPartielle()
    {
        Console.WriteLine("\n🏃 ÉVACUATION PARTIELLE ACTIVÉE !");

        int nombreTotal = terrain.PlantesCultivees.Count;
        int nombreADetruire = nombreTotal / 2;

        // Sélectionner aléatoirement les plantes à détruire
        var plantesADetruire = terrain.PlantesCultivees
            .OrderBy(x => random.Next())
            .Take(nombreADetruire)
            .ToList();

        Console.WriteLine($"🌱 {nombreTotal - nombreADetruire} plantes évacuées avec succès !");
        Console.WriteLine($"💀 {nombreADetruire} plantes seront détruites...");

        Thread.Sleep(1500);

        // Marquer les positions comme brûlées et retirer les plantes
        foreach (var plante in plantesADetruire)
        {
            terrain.T[plante.PositionX, plante.PositionY] = 21; // feu
        }

        // Retirer les plantes détruites de la liste
        terrain.PlantesCultivees.RemoveAll(p => plantesADetruire.Contains(p));

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"⚖️  BILAN : {nombreTotal - nombreADetruire} sauvées, {nombreADetruire} perdues");
        Console.ResetColor();
    }
}

