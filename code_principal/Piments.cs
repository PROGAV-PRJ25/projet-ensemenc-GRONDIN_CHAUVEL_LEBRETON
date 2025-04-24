public class Piment : Legume
{
    public Piment() : base("Piment", "Eté", TypePlante.Legume = 1, "Limoneux", 30f, 30f, 7, 45, Sante.EnBonneSante = 0, 80) {}
    public override int EtatFinal()
    {
        return 14;
    }
}