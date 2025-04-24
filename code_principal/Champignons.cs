public class Champignon: Legume
{
    public Champignon() : base("Champignon", "Automne", TypePlante.Legume = 1, "Forestier", 80f, 18f, 1, 4, Sante.EnBonneSante = 0, 6) {}
    public override int EtatFinal()
    {
        return ;
    }
}