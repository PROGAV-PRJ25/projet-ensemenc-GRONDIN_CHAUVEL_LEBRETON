public class Elfe : BonneFee
{
    private Terrain terrain; // instance de terrain où l'elfe agit

    public Elfe(Terrain terrain) : base("petit elfe", "Plante des fleurs en état final", 1)
    {
        this.terrain = terrain;
    }
    public override void AiderPotager()
    {
        Plante fleur;
        int fleurAleatoire = rnd.Next(0, 3);
        switch (fleurAleatoire)
        {
            case 0:
                fleur = new Tulipe();
                break;
            case 1:
                fleur = new Tournesol();
                break;
            default:
                fleur = new Rose();
                break;
        }

        fleur.Terrain = terrain;
        terrain.AjouterPlante(fleur);
        fleur.EtatFinal();
        Console.WriteLine($"Car un {Nom} a planté un.e {fleur.Nom}.");
    }
}
