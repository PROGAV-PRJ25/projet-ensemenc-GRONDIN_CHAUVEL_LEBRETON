using System.Reflection.Metadata;

public class Simulation
{

    public void ChoisirTerrain(Texte t)
    {
        Console.WriteLine("Hello, BIENVENUE AU POTAGER DE L'ENSC !! Pour commencer, il faut que tu choisisses à quoi va ressembler ton terrain.");
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
        Console.WriteLine("C'est parti pour un an d'entretien de ton potager !");


        for (int i = 1; i <= 54; i++)
        {
            Console.WriteLine($"========= SEMAINE {i} =========");
            Console.WriteLine("   ");

            ModeClassique m1 = new ModeClassique();
            m1.LancerPartie(terrainChoisi, t);

            Console.WriteLine("Oh ! Quelques herbes, bonnes et mauvaises, ont poussé dans ton potager.");
            BonneHerbe bh = new BonneHerbe();
            MauvaiseHerbe mh = new MauvaiseHerbe();
            terrainChoisi.AjouterPlante(bh);
            terrainChoisi.AjouterPlante(mh);
            terrainChoisi.AfficherT();


            Console.WriteLine("Attention ! Il est maintenant l'heure de l'apparition de l'obstacle de la semaine !");
            Random randomm = new Random();
            int attention = randomm.Next(1, 5);
            Obstacle? obstacleAleatoire = null;


            switch (attention)
            {
                case 1:
                    Console.WriteLine("C'est la taupe qui dérange ton potager avec ses tas de terre aujourd'hui !");
                    obstacleAleatoire = new Taupe();
                    break;
                case 2:
                    Console.WriteLine("C'est le géant qui, avec ses grands pas, écrase ton potager aujourd'hui !");
                    obstacleAleatoire = new PasDeGeant();
                    break;
                case 3:
                    Console.WriteLine("Oh non ! Tes plantes sont contaminées par la maladie du mildiou !");
                    obstacleAleatoire = new Maladie("mildiou", 3);
                    break;
                case 4:
                    obstacleAleatoire = new Dragon();
                    break;
                default:
                    Console.WriteLine("Action invalide");
                    return;
            }

            if (!(obstacleAleatoire is Dragon))
            {
                obstacleAleatoire.DefinirUnivers(terrainChoisi);
                obstacleAleatoire.Agir();
                terrainChoisi.AfficherT();

                Console.WriteLine("Ouf ! Une bonne fée va pouvoir t'aider !");
                Random randommm = new Random();
                int aide = randomm.Next(1, 5);
                BonneFee? aideAleatoire = null;

                switch (aide)
                {
                    case 1:
                        Console.WriteLine("C'est le petit elfe qui plante ses fleurs magiques, directement à l'état final !");
                        aideAleatoire = new Elfe(terrainChoisi);
                        break;
                    case 2:
                        Console.WriteLine("C'est la poussière de fée qui accélère la pousse de tes plantes !");
                        aideAleatoire = new PoussiereDeFee(terrainChoisi);
                        break;
                    case 3:
                        Console.WriteLine("C'est la nymphe qui soigne tes plantes !");
                        aideAleatoire = new Nymphe(terrainChoisi);
                        break;
                    case 4:
                        Console.WriteLine("C'est la mignonne brebis rose qui mange tes mauvaises herbes !");
                        aideAleatoire = new Brebis(terrainChoisi);
                        break;
                    default:
                        Console.WriteLine("Action invalide");
                        return;
                }
                aideAleatoire.AiderPotager();
                terrainChoisi.AfficherT();
            }
            else
            {
                ModeUrgence m2 = new ModeUrgence(terrainChoisi);
                m2.DeclencherAttaqueDragon();
                m2.ProposerChoixUrgence();
            }

        }

    }


}
