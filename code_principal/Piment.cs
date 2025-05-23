public class Piment : Legume
{
    public Piment() : base("Piment", "Chaud", TypePlante.Legume, "Limoneux", 30f, 30f, 7, 45, 80) {}
    public override void EtatFinal()
    {
        if (Croissance >= 1.5f)
        {
            Terrain.T[PositionX, PositionY] = 15;
            Console.WriteLine($"{Nom} a atteint son état final !");
        }
    }
}