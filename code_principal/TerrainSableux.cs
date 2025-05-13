public class TerrainSableux : Terrain
{
    public TerrainSableux () : base("Terrain sableux", 225f, "Eté", "Sableux", 30f, 20f, 80f, 22f, false, 15, 15)
                            {
                                TypeSol = "Sableux";
                            }
    
    //plantes qui nécessite beaucoup d'eau ne sont pas idéales pour ce type de sol
    public override bool PeutAccueillir(Plante plante)
    {
        if (plante.HumiditeNecessaire>70)
        {
            Console.WriteLine($"Attention : {plante.Nom} nécessite beaucoup d'eau pour croître et pourrait souffrir dans un sol sableux.");
        }
        return base.PeutAccueillir (plante);
    }
} 