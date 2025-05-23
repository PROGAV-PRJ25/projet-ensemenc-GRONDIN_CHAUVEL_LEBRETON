public class BonneHerbe : Herbe 
{
    public BonneHerbe() : base ("Bonne Herbe", "toutes les météos", TypePlante.Herbe, "Tout terrain",30f, 35f, 8, 0, 40) {}

    public override void AtteindreEtatFinal()
    {
        Terrain.T[PositionX, PositionY] = 2; 
        Console.WriteLine($" Une {Nom} est apparue !");
    }
}