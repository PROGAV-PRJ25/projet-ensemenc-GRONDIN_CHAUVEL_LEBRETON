public class Pasteque : Fruit
{
    public Pasteque() : base("Pasteque", "Chaud", TypePlante.Fruit, "Limoneux", 35f, 26f, 7, 60, 4) {}

     public override void AtteindreEtatFinal()
    {
        Terrain.T[PositionX, PositionY] = 14;
        Console.WriteLine($"{Nom} a atteint son état final !");
    }
}