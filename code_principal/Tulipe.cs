public class Tulipe : Fleur
{
    public Tulipe() : base("Tulipe", "Tempéré", TypePlante.Fleur, "Argileux", 75f, 15.5f, 6, 50, 10) { }

    public override void AtteindreEtatFinal()
    {
        Terrain.T[PositionX, PositionY] = 4;
        Console.WriteLine($"{Nom} a atteint son état final !");
    }
}