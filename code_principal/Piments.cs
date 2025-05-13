public class Piment : Legume
{
    public Piment() : base("Piment", "Eté", TypePlante.Legume, "Limoneux", 30f, 30f, 7, 45, 80) {}
    public override int EtatFinal()
    {
        return 14;
    }
}