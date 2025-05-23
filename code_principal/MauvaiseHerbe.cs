public class MauvaiseHerbe : Herbe 
{
    public MauvaiseHerbe() : base ("Mauvaise Herbe", "Les 4 météos", TypePlante.Herbe, "Tout terrain",45f, 30f, 8, 3, 30) {}

    public override void AtteindreEtatFinal()
    {
        Terrain.T[PositionX, PositionY] = 20; 
        Console.WriteLine($" Une {Nom} est apparue !");
    }
}