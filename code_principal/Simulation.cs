public class Simulation
{
    public void ChoisirTerrain()
    {
        Console.WriteLine("Choisissez un terrain :");
        Console.WriteLine("1. Terrain Argileux");
        Console.WriteLine("2. Terrain Limoneux");
        Console.WriteLine("3. Terrain Forestier");
        Console.WriteLine("4. Terrain Sableux");

        ConsoleKey clic = Console.ReadKey().Key;
        Console.WriteLine();

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
    }
}
