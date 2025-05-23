public class Rose: Fleur
{
    public Rose(): base("Rose d'été", "Chaud", TypePlante.Fleur, "Sableux", 85f, 24f, 5, 40, 14) {}

    public override void AtteindreEtatFinal()
    {
        Terrain.T[PositionX, PositionY] = 16;
        Console.WriteLine($"{Nom} a atteint son état final !");
    }
}