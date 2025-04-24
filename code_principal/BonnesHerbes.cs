public class BonneHerbe : Herbe 
{
        public BonneHerbe() : base ("Bonne Herbe", "Les 4 saisons", TypePlante.Herbe = 3, "Tout terrain",30f, 35f, 8f, 0, Sante.EnBonneSante = 0, 40) {}
        public override int EtatFinal()
    {
        return ; // à définir
    }
}
