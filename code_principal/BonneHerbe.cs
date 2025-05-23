public class BonneHerbe : Herbe 
{
        public BonneHerbe() : base ("Bonne Herbe", "Les météos", TypePlante.Herbe, "Tout terrain",30f, 35f, 8, 0, 40) {}
        public override int Etat()
    {
        Terrain.T[PositionX, PositionY] = ;
    }
}