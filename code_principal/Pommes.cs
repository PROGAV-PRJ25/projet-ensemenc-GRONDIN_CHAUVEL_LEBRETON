public class Pomme : Fruit
{
    public Pomme() : base("Pomme", "Printemps", TypePlante.Legume = 1, "Limoneux", 35f, 23f, 6, 500, Sante.EnBonneSante = 0, 10) {}
    public override int EtatFinal()
    {
        return 16;
    }
}