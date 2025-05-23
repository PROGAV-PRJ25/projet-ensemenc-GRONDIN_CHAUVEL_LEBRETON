public class Pomme : Fruit
{
    public Pomme() : base("Pomme", "Tempéré", TypePlante.Fruit, "Limoneux", 35f, 23f, 6, 500, 10) {}

      public override void AtteindreEtatFinal()
    {
        Terrain.T[PositionX, PositionY] = 5; 
        Console.WriteLine($"{Nom} a atteint son état final !");
    }
}