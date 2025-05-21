public class Piment : Legume
{
    public Piment() : base("Piment", "Chaud", TypePlante.Legume, "Limoneux", 30f, 30f, 7, 45, 80) {}
    public override int EtatFinal()
    {
        return 5;
    }
}