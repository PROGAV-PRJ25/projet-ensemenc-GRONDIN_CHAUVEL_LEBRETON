public class Simulation
{
    public void ChoisirTerrain()
    {
        ConsoleWriteLine("Choisis terrain1");
        ConsoleKey clic = Console.ReadKey().Key;
        Console.WriteLine();

        switch (clic)
        {
            case ConsoleKey.D1:
                TerrainArgileux t1 = new TerrainArgileux();
                t1.InitialiserT();
                t1.Afficher();
                break;
            case ConsoleKey.D2:
                TerrainLimoneux t1 = new TerrainLimoneux();
                t1.InitialiserT();
                t1.Afficher();
                break;
            case ConsoleKey.D3:
                TerrainForestier t1 = new TerrainForestier();
                t1.InitialiserT();
                t1.Afficher();
                break;
            case ConsoleKey.D4:
                TerrainSableux t1 = new TerrainSableux();
                t1.InitialiserT();
                t1.Afficher();
                break;
            default:
                Console.WriteLine("Action invalide");
                break;
        }
    }
}

