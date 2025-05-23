public class Tomate : Legume
{
    public Tomate() : base("Tomate", "Chaud", TypePlante.Legume, "Argileux", 30f, 25f, 7, 60, 6) { }
    public override void AtteindreEtatFinal()
    {
       Terrain.T[PositionX, PositionY] = 18;
       Console.WriteLine($"{Nom} a atteint son état final !");
    }
}