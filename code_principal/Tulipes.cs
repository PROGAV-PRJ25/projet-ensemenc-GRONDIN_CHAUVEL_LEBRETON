public class Tulipe : Fleur
{
    public Tulipe() : base("Tulipe", "Printemps", TypePlante.Fleur = 2, "Argileux", 75f, 15.5f, 6, 50, Sante.EnBonneSante = 0, 10) {}

    public override int EtatFinal()
    {
        return ;
    }
}