public class TerrainForestier : Terrain
{
     public override string DescriptionTerrain => "Terrain forestier, ombragé et riche en matières organiques.";

     public TerrainForestier () : base("Terrain forestier", 225f, "Automne", "Forestier", 65f, 40f, 16f, false, 15, 15)
                            {
                                TypeSol = "Forestier";
                            }

    public override void MiseAJour()
    {
        base.MiseAJour();
        Temperature = Math.Max(5, Math.Min(22, Temperature)); // température plus stable
        Luminosite = Math.Min(50, Luminosite); // luminosité plus réduite
    }

    public new int[,] InitialiserTerrainVisuel()
    {
        TerrainVisuel = base.InitialiserTerrainVisuel();
        Random random = new Random();
        int nbArbres = random.Next(Lignes*Colonnes / 20, Lignes*Colonnes/10);

        for (int i = 0; i<nbArbres; i++)
        {
            int x = random.Next(0,Lignes);
            int y = random.Next(0,Colonnes);
        }
        return TerrainVisuel;
    }
}