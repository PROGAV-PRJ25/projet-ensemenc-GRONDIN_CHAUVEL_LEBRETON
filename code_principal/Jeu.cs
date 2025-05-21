public class Jeu
{
    private Terrain terrainActuel;
    private List<Plante> plantesPossedees = new List<Plante>();
    private bool jeuEnCours;
    private int tour = 0;
    private const int ActionsParTour = 3;

    public enum ModeJeu { Classique, Urgence }
    public ModeJeu ModeActuel { get; private set; } = ModeJeu.Classique;

    public void Demarrer()
    {
        Console.WriteLine("========================");
        Console.WriteLine("Bienvenue dans le simulateur de potager");
        Console.WriteLine("========================");


        ExecuterBoucleJeu();
    }

    private void PresenterTerrain()
    {
        Console.WriteLine("\n=================================");
        Console.WriteLine("Choisissez le type de terrain pour votre potager :");
        Console.WriteLine("=================================\n");

        Console.WriteLine("Voici les 4 types de terrains composant votre potager.");

        Console.WriteLine("1. Terrain Sableux (en jaune)");
        Console.WriteLine("   Description: Sol drainant et chaud, idéal pour les plantes méditerranéennes.");
        Console.WriteLine("   Avantages: Bonne croissance pour les plantes qui aiment la chaleur et le sol sec.");
        Console.WriteLine("   Inconvénients: Retient peu l'eau et les nutriments.\n");

        Console.WriteLine("2. Terrain Argileux (en gris)");
        Console.WriteLine("   Description: Sol riche en nutriments mais drainant mal.");
        Console.WriteLine("   Avantages: Riche et fertile, idéal pour les légumes-racines.");
        Console.WriteLine("   Inconvénients: Peut être lourd et compact quand il est mouillé.\n");

        Console.WriteLine("3. Terrain Limoneux (en rouge)");
        Console.WriteLine("   Description: Sol équilibré et fertile, le meilleur pour un potager traditionnel.");
        Console.WriteLine("   Avantages: S'adapte à la plupart des plantes cultivées.");
        Console.WriteLine("   Inconvénients: Peut nécessiter un entretien régulier.\n");

        Console.WriteLine("4. Terrain Forestier (en vert)");
        Console.WriteLine("   Description: Sol ombragé et riche en matière organique.");
        Console.WriteLine("   Avantages: Excellent pour les plantes d'ombre et les baies sauvages.");
        Console.WriteLine("   Inconvénients: Peu de lumière et compétition avec les racines d'arbres.\n");
    }

    private void InitialiserSemences()
    {

        Console.WriteLine("\nAppuyer sur une touche pour commencer à cultiver !");
        Console.ReadKey();
        Console.Clear();
    }
}