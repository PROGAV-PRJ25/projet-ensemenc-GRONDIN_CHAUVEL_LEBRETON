public class Aubergine : Legume
{
    public Aubergine() : base("Aubergine", "Chaud", TypePlante.Legume, "Limoneux", 30f, 19f, 7, 150, 5) {}
    public override void EtatFinal()
    {
        Terrain.T[PositionX, PositionY] = 13;
        Console.WriteLine($"{Nom} a atteint son état final !");
    }
}