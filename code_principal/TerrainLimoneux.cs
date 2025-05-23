public class TerrainLimoneux : Terrain
{
        public TerrainLimoneux() : base("Terrain limoneux", 225f, "Printemps", "Limoneux", 60f, 70f, 20f, 10f, false, 15, 15)
    {
        TypeSol = "Limoneux";
    }
        
    public override bool PeutAccueillir(Plante plante)
    {
        if (plante.HumiditeNecessaire > 70)
        {
            Console.WriteLine($"Attention : {plante.Nom} nécessite beaucoup d'eau pour croître et pourrait souffrir dans un sol sableux.");
        }
        return base.PeutAccueillir(plante);
    }

}
