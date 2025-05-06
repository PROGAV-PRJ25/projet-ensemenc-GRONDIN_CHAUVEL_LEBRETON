public class Champignon: Legume
{
    public Champignon() : base("Champignon", "Automne", TypePlante.Champignon, "Forestier", 80f, 18f, 1, 4, 6) {}
    public override int EtatFinal()
    {
        return 9 ;
    }
}