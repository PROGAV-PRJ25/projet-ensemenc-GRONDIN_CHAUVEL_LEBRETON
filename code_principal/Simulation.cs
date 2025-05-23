public class Simulation
{
    public void ChoisirTerrain(Texte t)
    {
        Console.WriteLine("Hello, il est maintenant temps de choisir à quoi va ressembler ton terrain.");
        t.DefinirTerrain();

        ConsoleKey clic = Console.ReadKey().Key;

        Terrain terrainChoisi = null;


        switch (clic)
        {
            case ConsoleKey.D1:
                terrainChoisi = new TerrainArgileux();
                break;
            case ConsoleKey.D2:
                terrainChoisi = new TerrainLimoneux();
                break;
            case ConsoleKey.D3:
                terrainChoisi = new TerrainForestier();
                break;
            case ConsoleKey.D4:
                terrainChoisi = new TerrainSableux();
                break;
            default:
                Console.WriteLine("Action invalide");
                return; // on quitte la méthode si la touche est mauvaise
        }
        terrainChoisi.InitialiserT();
        terrainChoisi.AfficherT();

    

        ModeClassique m1 = new ModeClassique();
        m1.LancerPartie(terrainChoisi,t);

    }


}
