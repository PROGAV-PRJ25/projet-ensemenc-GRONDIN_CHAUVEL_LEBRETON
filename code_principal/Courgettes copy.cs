public class Champignon: Legume
{
    public Champignon() : base("Courgette", "Eté", TypePlante.Legume = 1, "Limoneux", 30f, 19f, 7, 150, Sante.EnBonneSante = 0, 5) {}
    public override int EtatFinal()
    {
        return 10;
    }
}