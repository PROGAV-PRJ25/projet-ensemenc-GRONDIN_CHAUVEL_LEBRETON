public class Fraise : Fruit
{
    public Fraise() : base("Fraise", "Eté", TypePlante.Legume = 1, "Limoneux", 40f, 20f, 6, 30, Sante.EnBonneSante = 0, 3) {}
    public override int EtatFinal()
    {
        return 15;
    }
}