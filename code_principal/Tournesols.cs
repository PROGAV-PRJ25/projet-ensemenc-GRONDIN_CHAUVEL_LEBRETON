public class Tournesol : Fleur 
{
    public Tournesol() : base("Tournesol", "Eté", TypePlante.Fleur, "Limoneux", 8f, 10f, 6, 10, 8) {}

    public override int EtatFinal()
    {
        return 7;
    }
}