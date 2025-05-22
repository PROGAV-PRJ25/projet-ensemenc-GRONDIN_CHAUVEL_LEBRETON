/*public class TerrainRocheux : Terrain
{
    public override string DescriptionTerrain => "Terrain rocheux avec peu de terre";

    public TerrainRocheux () : base("Terrain rocheux", 225f, "Eté", "Rocheux", 40f, 85f, 15f, false, 15, 15)
                            {
                                TypeSol = "Rocheux";
                            }

    public override bool PeutAccueillir(Plante plante)
    {
        if (plante.EspaceNecessaire > Surface*0.1f) // plantes nécessitant beaucoup d'espace ont du mal à croître sur ce type de sol
        {
            Console.WriteLine ($"Attention : {plante.Nom} nécessite beaucoup d'espace et pourrait mal se développer dans un sol rocheux.");
            return false;
        }
        return base.PeutAccueillir (plante);
    }

    public new int[,] InitialiserTerrainVisuel() // ajout de rochers sur le terrain visuel
    {
        TerrainVisuel = base.InitialiserTerrainVisuel;

        Random random = new Random();
        int nbRochers = random.Next(Lignes*Colonnes/10, Lignes*Colonnes/5);
        for (int i = 0; i<nbRochers, i++)
        {
            int x = random.Next(0,Lignes);
            int y = random.Next(0,Colonnes);
            TerrainVisuel[x,y] = 8;
        }
        return TerrainVisuel;
    }
}
*/