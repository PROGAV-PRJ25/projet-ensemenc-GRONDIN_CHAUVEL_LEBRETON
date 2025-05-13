public class Rose : Fleur
{
    public Rose() : base("Rose d'été", "Eté", TypePlante.Fleur, "Sableux", 85f, 24f, 5, 40, 14) {}

    public override int EtatFinal()
    {
        return  6; 
    }
}