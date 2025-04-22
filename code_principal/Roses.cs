public class Rose : Fleur
{
    public Rose() : base("Rose d'été", "Eté", TypePlante.Fleur = 2, "Sableux", 85f, 24f, 5, 40, Sante.EnBonneSante = 0, 14) {}

    public override int EtatFinal()
    {
        return ;// faut que le tableau d'emojy soit fini ! 
    }
}