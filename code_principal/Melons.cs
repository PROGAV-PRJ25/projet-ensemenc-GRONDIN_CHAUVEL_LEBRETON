public class Melon : Fruit
{
    public Melon() : base("Melon", "Chaud", TypePlante.Fruit, "Limoneux", 35f, 26f, 7, 60, 4) {}
    public override int EtatFinal()
    {
        return 17;
    }
}