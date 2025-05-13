public class BonneHerbe : Herbe 
{
        public BonneHerbe() : base ("Bonne Herbe", "Les 4 saisons", TypePlante.Herbe, "Tout terrain",30f, 35f, 8, 0, 40) {}
        public override int EtatFinal()
    {
        return 20 ; 
    }
}
