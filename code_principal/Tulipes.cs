public class Tulipe : Fleur
{
    public Tulipe() : base("Tulipe", "Tempéré", TypePlante.Fleur, "Argileux", 75f, 15.5f, 6, 50, 10) {}

    public override int EtatFinal()
    {
        return 8;
    }
}