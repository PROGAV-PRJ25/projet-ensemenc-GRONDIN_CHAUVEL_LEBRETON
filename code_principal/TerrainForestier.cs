public class TerrainForestier : Terrain
{

    public TerrainForestier() : base("Terrain forestier", 225f, "Automne", "Forestier", 65f, 40f, 16f, 12f, false, 15, 15)
    {
        TypeSol = "Forestier";
    }
    public override void InitialiserT()
    {
        base.InitialiserT();
        Random random = new Random();
        int nbArbres = random.Next(Lignes * Colonnes / 20, Lignes * Colonnes / 10);

        for (int i = 0; i < nbArbres; i++)
        {
            int x = random.Next(0, Lignes);
            int y = random.Next(0, Colonnes);
        }
    }
}
