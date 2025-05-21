public class ModeUrgence : ModeJeu
{
    private List<Obstacle> obstaclesPossibles;
    private Random rng = new Random();
    private int toursEvenement = 0;
    private int tousLesCombien = 2; //tous les deux tours il y a un évènement

    public ModeUrgence(Terrain terrain) : base (terrain)
    {
        obstaclesPossibles = new List<Obstacle>()
        {
            new Corbeau(),
            new Dragon(),
            new PasDeGeant(),
            new Taupe(),
        };
    }
    public override void LancerTour()
    {
        terrain.MiseAJour();

        // 2. Affichage du terrain
        terrain.AfficherTerrainVisuel(terrain.TerrainVisuel);

        // 3. On compte le nombre de tours depuis la dernière urgence
        toursEvenement++;

        // 4. Si on atteint un certain nombre de tours, on peut lancer une urgence
        if (toursEvenement >= tousLesCombien)
        {
            Console.WriteLine("\n🚨 Une urgence est en train d'arriver !");
            LancerUrgence(); // méthode pour créer l'événement
            toursEvenement = 0; // on remet le compteur à zéro
        }
        
        // 5. Pause pour simuler du temps réel
        System.Threading.Thread.Sleep(1000); // 1 seconde d’attente
    }

    private void LancerUrgence()
    {
        // Choisir un obstacle au hasard
        int choixObastacles = random.Next(obstaclesPossibles.Count);
        Obstacle O = obstaclesPossibles[choixObastacles];

        // Lier l'obstacle au terrain actuel
        O.DefinirUnivers(terrain);

        // Afficher le message
        Console.WriteLine($"\n⚠️ {O.Nom} apparaît ! Type : {O.Type} — Effet : {O.Effet}");

        // Déclencher l'action de l’obstacle
        O.Action();

        // Afficher le terrain mis à jour après l’événement
        terrain.AfficherTerrainVisuel(terrain.TerrainVisuel);
    }
}