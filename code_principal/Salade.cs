public class Salades : Legume
{
    public Salades() : base("Salade", "Ete", TypePlante.Legume = 1, "Argileux", 65f, 20f, 5, 25, Sante.EnBonneSante = 0, 70) {}
    public override int EtatFinal()
    {
        return 13;
    }
}