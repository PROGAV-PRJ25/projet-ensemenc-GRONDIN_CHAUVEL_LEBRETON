public class Melon : Fruit
{
    public Melon() : base("Melon", "Eté", TypePlante.Legume = 1, "Limoneux", 35f, 26f, 7, 60, Sante.EnBonneSante = 0, 4) {}
    public override int EtatFinal()
    {
        return 17;
    }
}