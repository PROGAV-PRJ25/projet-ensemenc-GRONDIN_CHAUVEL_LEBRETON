public class ModeUrgence
{
    private Terrain terrain;
    private Dragon dragon;
    private Random random;

    public ModeUrgence(Terrain terrain)
    {
        this.terrain = terrain;
        this.dragon = new Dragon { Univers = terrain }; // on lie le dragon au terrain
        this.random = new Random();
    }

    public void DeclencherAttaqueDragon()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("🚨 ALERTE URGENCE : DRAGON EN APPROCHE !");
        Console.ResetColor();

        Console.WriteLine($"🐉 Un dragon attaque le terrain {terrain.Nom} ({terrain.TypeSol}) !");
        Console.WriteLine($"🌡️ Température : {terrain.Temperature}°C | Météo : {terrain.Meteo}");
        Thread.Sleep(1000);

        // Le dragon agit immédiatement : feu visuel sur le terrain
        dragon.Agir(); // Ce qui met le feu (code 21) dans la grille terrain.T

        // Ensuite le joueur choisit la réponse à cette attaque
        ProposerChoixUrgence();

        terrain.AfficherT();
    }

    public void ProposerChoixUrgence()
    {
        if (terrain.PlantesCultivees.Count == 0)
        {
            Console.WriteLine("Il n'y a pas de plantes à sauver !");
            return;
        }

        string? choix;
        Console.WriteLine("\n🔥 Que voulez-vous faire après l'attaque ?");
        Console.WriteLine("1. 🛡️ Tout protéger (les plantes sont malades mais vivantes)");
        Console.WriteLine("2. 🏃 Sauver la moitié (saines), les autres sont perdues");
        Console.Write("Votre choix (1 ou 2) : ");

        choix = Console.ReadLine();
        if (choix == "1") ExecuterProtectionTotale();
        else ExecuterEvacuationPartielle();

        // Affiche le terrain mis à jour après l'action du joueur
        Console.WriteLine("\n🌍 État du terrain après votre action :");
        terrain.AfficherT();
    }

    private void ExecuterProtectionTotale()
    {
        Console.WriteLine("\n🛡️ Bouclier magique : les plantes sont sauvées mais malades.");
        foreach (var plante in terrain.PlantesCultivees)
        {
            plante.Contaminer("fumée du dragon");
        }

        // Nettoyer le feu et replacer toutes les plantes
        NettoyerTerrainEtPlacerPlantes(terrain.PlantesCultivees);

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"✅ {terrain.PlantesCultivees.Count} plantes vivantes mais malades.");
        Console.ResetColor();
    }


    private void ExecuterEvacuationPartielle()
    {
        int total = terrain.PlantesCultivees.Count;
        int àBrûler = total / 2;

        var sacrifiées = terrain.PlantesCultivees.OrderBy(p => random.Next()).Take(àBrûler).ToList();
        var sauvées = terrain.PlantesCultivees.Except(sacrifiées).ToList();

        // Nettoyer tout le feu et replacer uniquement les plantes sauvées
        NettoyerTerrainEtPlacerPlantes(sauvées);

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"✅ {sauvées.Count} plantes sauvées");
        Console.WriteLine($"🔥 {sacrifiées.Count} ont été brûlées par le dragon");
        Console.ResetColor();
    }


    private void NettoyerTerrainEtPlacerPlantes(List<Plante> plantesSauvees)
    {
        int lignes = terrain.T.GetLength(0);
        int colonnes = terrain.T.GetLength(1);

        // Nettoyer tout le feu
        for (int y = 0; y < lignes; y++)
        {
            for (int x = 0; x < colonnes; x++)
            {
                if (terrain.T[y, x] == 21) // si feu
                    terrain.T[y, x] = 0;   // mettre terrain sain (ou vide)
            }
        }

        // Remettre les plantes sauvées sur le terrain
        foreach (var plante in plantesSauvees)
        {
            terrain.T[plante.PositionX, plante.PositionY] = 1; // ou un code pour plante
        }

        // Mettre à jour la liste des plantes cultivées
        terrain.PlantesCultivees = plantesSauvees;
    }

}
