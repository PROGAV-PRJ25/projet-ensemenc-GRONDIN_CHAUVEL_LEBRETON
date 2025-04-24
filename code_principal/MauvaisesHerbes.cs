public class MauvaiseHerbe : Herbe 
{
    public MauvaiseHerbe() : base ("Mauvaise Herbe", "Les 4 saisons", TypePlante.Herbe = 3, "Tout terrain",45f, 30f, 8f, 3, Sante.EnBonneSante = 0, 30) {}
public override int EtatFinal()
    {
        return ; //à définir
    }
}
   