public class Pomme : Fruit
{
    public Pomme() : base("Pomme", "Tempéré", TypePlante.Fruit, "Limoneux", 35f, 23f, 6, 500, 10) {}
    public override int EtatFinal()
    {
        return 16;
    }
}