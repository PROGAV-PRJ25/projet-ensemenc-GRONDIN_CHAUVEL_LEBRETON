public class ModeClassique
{
    private Random ramdom = new Random();

    public void LancerPartie(Terrain terrain)
    {
        Texte.PresenterFleurs();

        ConsoleKey clic = Console.ReadKey().Key;
        Console.WriteLine();

        Plante fleurChoisie = null;

        switch (clic)
        {
            case ConsoleKey.D1:
                fleurChoisie = new Tulipe();
                break;
            case ConsoleKey.D2:
                fleurChoisie = new Rose();
                break;
            case ConsoleKey.D3:
                fleurChoisie = new Tournesol();
                break;
            default:
                Console.WriteLine("Action invalide");
                return;
        }
        terrain.AjouterPlante(fleurChoisie);
        terrain.AfficherT();


        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine("\nChoisissez une action : 1. Arroser  2. Soigner  3. Exposer");
            clic = Console.ReadKey().Key;
            Console.WriteLine();

            switch (clic)
            {
                case ConsoleKey.D1:
                    fleurChoisie.ArroserPlantes();
                    break;
                case ConsoleKey.D2:
                    fleurChoisie.Soigner();
                    break;
                case ConsoleKey.D3:
                    fleurChoisie.ExposerAuSoleil();
                    break;
                default:
                    Console.WriteLine("Action invalide");
                    break;
            }
        }
    }
}
