/*public class Taupe : Obstacle
{
    private Terrain Univers;
    public Taupe() : base("Taupe", "animal", "Fait des tas de terre et déracine les plantations", 1) { }
    
public override void Agir()
{
    int nbPas = 3;
    int ligne = rnd.Next(0, Univers.Lignes);
    int col = rnd.Next(0, Univers.Colonnes);

    for (int i = 0; i < nbPas; i++)
    {
        // Marquer l'ancienne position avec un trou 🕳️
        Univers.T[ligne, col] = 7;

        // Calculer une nouvelle position voisine
        int newLigne = Math.Max(0, Math.Min(Univers.Lignes - 1, ligne + rnd.Next(-1, 2)));
        int newCol = Math.Max(0, Math.Min(Univers.Colonnes - 1, col + rnd.Next(-1, 2)));

        ligne = newLigne;
        col = newCol;

            // Poser la taupe 
        Univers.T[ligne, col] =6 ;

        // Réafficher tout le terrain
        Console.Clear();
        Console.WriteLine("La taupe est en train de creuser...");
        Univers.AfficherT(); // à adapter à ton code
        Thread.Sleep(800);
    }

    // Laisser un dernier trou à sa position finale
    Univers.T[ligne, col] = 7;
}
}
*/