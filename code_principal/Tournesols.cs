public class Tournesol : Fleur 
{
    public Tournesol() : base("Tournesol", "Eté", TypePlante.Fleur = 2, "Limoneux", 8f, 10f, 6, 10, Sante.EnBonneSante = 0, 8) {}

    public override int EtatFinal()
    {
        return 7;
    }
}