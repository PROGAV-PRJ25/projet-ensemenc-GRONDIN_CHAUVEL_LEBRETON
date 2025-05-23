public class Carotte : Legume
{
    public Carotte() : base("Carotte Nantaise", "Tempéré", TypePlante.Legume, "Sableux", 50f, 18f, 5, 15, 70) { }
    public override void EtatFinal()
    {
        Terrain.T[PositionX, PositionY] = 11; 
        Console.WriteLine($"{Nom} a atteint son état final !");
    }
}