public class Salade : Legume
{
    public Salade() : base("Salade", "Chaud", TypePlante.Legume, "Argileux", 65f, 20f, 5, 25, 70) { }
    public override void AtteindreEtatFinal()
    {
       Terrain.T[PositionX, PositionY] = 18;
       Console.WriteLine($"{Nom} a atteint son état final !");
    }
}