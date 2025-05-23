public class Tournesol : Fleur 
{
    public Tournesol() : base("Tournesol", "Chaud", TypePlante.Fleur, "Limoneux", 8f, 10f, 6, 10, 8) {}

    public override void AtteindreEtatFinal()
    {
        Terrain.T[PositionX, PositionY] = 19;
        Console.WriteLine($"{Nom} a atteint son état final !");
    }
}