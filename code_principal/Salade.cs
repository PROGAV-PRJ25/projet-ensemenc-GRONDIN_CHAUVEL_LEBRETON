public class Salades : Legume
{
    public Salades() : base("Salade", "Ete", TypePlante.Legume, "Argileux", 65f, 20f, 5, 25, 70) {}
    public override int EtatFinal()
    {
        return 13;
    }
}