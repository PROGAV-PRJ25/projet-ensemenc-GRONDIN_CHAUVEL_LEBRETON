public class Simulation
{
    public void ChoisirTerrain()
    {
        Console.WriteLine("Hello, il est maintenant temps de choisir à quoi va ressembler ton terrain.")
        Texte.DefinirTerrain();

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

    }

    public void ChoisirFruit()
    {
        Texte.PresenterFruits();

        ConsoleKey click = Console.ReadKey().Key;

        switch (click)
        {
            case ConsoleKey.D1:
                legumeChoisi = new Fraise();
                terrainChoisi.AjouterPlante(legumeChoisi);
                break;
            case ConsoleKey.D2:
                legumeChoisi = new Pastèque();
                terrainChoisi.AjouterPlante(legumeChoisi);
                break;
            case ConsoleKey.D3:
                legumeChoisi = new Pomme();
                terrainChoisi.AjouterPlante(legumeChoisi);
                break;
            default:
                Console.WriteLine("Action invalide");
                return; 
        }
        terrainChoisi.AfficherT();
    }

    public void ChoisirLegumes()
    {
        Texte.PresenterLegumes();

        ConsoleKey click = Console.ReadKey().Key;

        switch (click)
        {
            case ConsoleKey.D1:
                legumeChoisi = new Aubergine();
                terrainChoisi.AjouterPlante(legumeChoisi);
                break;
            case ConsoleKey.D2:
                legumeChoisi = new Carotte();
                terrainChoisi.AjouterPlante(legumeChoisi);
                break;
            case ConsoleKey.D3:
                legumeChoisi = new Piment();
                terrainChoisi.AjouterPlante(legumeChoisi);
                break;
            case ConsoleKey.D4:
                legumeChoisi = new Salade();
                terrainChoisi.AjouterPlante(legumeChoisi);
                break;
            case ConsoleKey.D5:
                legumeChoisi = new Tomate();
                terrainChoisi.AjouterPlante(legumeChoisi);
                break;
            default:
                Console.WriteLine("Action invalide");
                return; 
        }
        terrainChoisi.AfficherT();
    }



}
