public class Herbe: Plante 
{
    public Herbe() : base ("Bonne Herbe", "Les 4 saisons", TypePlante.Herbe = 4, "Tout terrain",30f, 30f, 8f, 3, Sante.EnBonneSante = 0, 25) {}

public override int EtatFinal()
    {
        return ;
    }
}