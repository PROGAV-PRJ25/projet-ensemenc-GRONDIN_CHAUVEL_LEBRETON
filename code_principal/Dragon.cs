public class Dragon : Obstacle
{
    public Dragon () : base ("Petit dragon", "animal", "Brûle tout", 1)
    {}
    public override void Agir()
    {
        int lignes = Univers.Lignes;
        int colonnes = Univers.Colonnes;

        Console.WriteLine("🔥 Le dragon commence à brûler le terrain...");

        // Brûle les 5 premières lignes
        for (int y = 0; y < 7 && y < lignes; y++)
        {
            for (int x = 0; x < colonnes; x++)
            {
                Univers.T[y, x] = 21; // feu
            }
            Univers.AfficherT();
            Thread.Sleep(300); // petite pause pour effet visuel
        }

        Console.WriteLine("Le feu se propage plus loin...");
        Thread.Sleep(1000); // petite pause entre les deux phases

        // Brûle le reste du terrain
        for (int y = 7; y < lignes; y++)
        {
            for (int x = 0; x < colonnes; x++)
            {
                Univers.T[y, x] = 21 ; // feu
            }
            Univers.AfficherT();
            Thread.Sleep(300); // effet visuel
        }
    }
}
