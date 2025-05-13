public class Courgette : Legume
{
    public Courgette() : base("Courgette", "Eté", TypePlante.Legume, "Limoneux", 30f, 19f, 7, 150, 5) {}
    public override int EtatFinal()
    {
        return 10;
    }
}