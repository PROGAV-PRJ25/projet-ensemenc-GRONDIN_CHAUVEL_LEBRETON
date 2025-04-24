public class Tomates : Legume
{
    public Tomates() : base("Tomate", "Ete", TypePlante.Legume = 1, "Argileux", 30f, 25f, 7, 60, Sante.EnBonneSante = 0, 6) {}
    public override int EtatFinal()
    {
        return 12;
    }
}