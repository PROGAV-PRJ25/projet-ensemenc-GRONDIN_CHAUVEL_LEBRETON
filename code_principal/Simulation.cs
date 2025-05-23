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
            Console.WriteLine("Action invalide, réessaie :");
            break; // ou continue;
        }
    
        Console.WriteLine(" ");
        terrainChoisi.InitialiserT();
        terrainChoisi.AfficherT();

        ModeClassique m1 = new ModeClassique();
        m1.LancerPartie(terrainChoisi,t);

        Console.WriteLine("Attention ! Il est maintenant l'heure de l'apparition de l'obstacle de la semaine !");
        Random randomm = new Random();
        int attention = randomm.Next(1, 5);
        Obstacle? obstacleAleatoire = null;

        
        switch (attention)
        {
            case 1:
                obstacleAleatoire = new Taupe();
                break;
            case 2:
                obstacleAleatoire = new PasDeGeant();
                break;
            case 3:
                obstacleAleatoire = new Maladie("mildiou", 3);
                break;
            case 4:
                obstacleAleatoire = new Dragon();
                break;
            default:
                Console.WriteLine("Action invalide");
                return;
        }
        Console.WriteLine($"Obstacle choisi : {obstacleAleatoire?.Nom}");

        if(!(obstacleAleatoire is Dragon))
        {
            obstacleAleatoire.DefinirUnivers(terrainChoisi);
            obstacleAleatoire.Agir();
        }
        else 
        {
            ModeUrgence m2 = new ModeUrgence(terrainChoisi);
            m2.DeclencherAttaqueDragon();
            m2.ProposerChoixUrgence();
        }
       

    }


}
