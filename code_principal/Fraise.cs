public class Fraise : Fruit
{
    public Fraise() : base("Fraise", "Chaud", TypePlante.Fruit, "Limoneux", 40f, 20f, 6, 30, 3) {}
    public override void EtatFinal()
    {
        Terrain.T[PositionX, PositionY] = 10; 
        Console.WriteLine($"{Nom} a atteint son état final !");
    }
}