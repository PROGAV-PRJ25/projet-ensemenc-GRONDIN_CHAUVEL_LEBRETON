public class Carottes : Legume
{
    public Carottes() : base("Carotte Nantaise", "Tempéré", TypePlante.Legume, "Sableux", 50f, 18f, 5, 15, 70) {}
    public override int EtatFinal()
    {
        return 11;
    }
}