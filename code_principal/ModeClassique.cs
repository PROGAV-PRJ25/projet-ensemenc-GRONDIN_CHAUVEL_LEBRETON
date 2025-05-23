public class ModeClassique
{
    private Random ramdom = new Random();

    public void LancerPartie(Terrain terrain, Texte t)
    {
        t.PresenterFleurs();
        ConsoleKey clic = Console.ReadKey().Key;
        Console.WriteLine();

        Plante? fleurChoisie = null;

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
        Console.WriteLine(" ");
        terrain.AjouterPlante(fleurChoisie);
        terrain.AfficherT();


        t.PresenterFruits();
        ConsoleKey click = Console.ReadKey().Key;
        Plante? fruitChoisi = null;

        switch (click)
        {
            case ConsoleKey.D1:
                fruitChoisi = new Fraise();
                break;
            case ConsoleKey.D2:
                fruitChoisi = new Pasteque();
                break;
            case ConsoleKey.D3:
                fruitChoisi = new Pomme();
                break;
            default:
                Console.WriteLine("Action invalide");
                return;
        }
        Console.WriteLine(" ");
        terrain.AjouterPlante(fruitChoisi);
        terrain.AfficherT();


        t.PresenterLegumes();
        ConsoleKey clicky = Console.ReadKey().Key;
        Plante? legumeChoisi = null;

        switch (clicky)
        {
            case ConsoleKey.D1:
                legumeChoisi = new Aubergine();
                break;
            case ConsoleKey.D2:
                legumeChoisi = new Carotte();
                break;
            case ConsoleKey.D3:
                legumeChoisi = new Piment();
                break;
            case ConsoleKey.D4:
                legumeChoisi = new Salade();
                break;
            case ConsoleKey.D5:
                legumeChoisi = new Tomate();
                break;
            default:
                Console.WriteLine("Action invalide");
                return;
        }
        Console.WriteLine(" ");
        terrain.AjouterPlante(legumeChoisi);
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
