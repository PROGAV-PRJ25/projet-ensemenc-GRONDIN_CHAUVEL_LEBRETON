public class Carottes : Legume
{
    public Carottee() : base("Carotte Nantaise", "Printemps", TypePlante.Legume = 1, "Sableux", 50f, 18f, 5, 15, Sante.EnBonneSante = 0, 70) {}
    public override int EtatFinal()
    {
        return 11;
    }
}