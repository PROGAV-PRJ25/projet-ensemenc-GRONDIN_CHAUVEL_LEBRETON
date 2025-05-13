public class Tomates : Legume
{
    public Tomates() : base("Tomate", "Ete", TypePlante.Legume, "Argileux", 30f, 25f, 7, 60, 6) {}
    public override int EtatFinal()
    {
        return 12;
    }
}