/*public class Jeu
{
    private Terrain terrainACtuel;
    private List<Plante> plantesPossedees = new List<Plante>();
    private bool jeuEnCours;
    private int tour = 0;
    private const int ActionsParTour = 3;

    public enum ModeJeu {Classique, Urgence}
    public ModeJeu ModeActuel {get; private set;} = ModeJeu.Classique;

    public void Demarrer()
    {
        Console.WriteLine("========================");
        Console.WriteLine("Bienvenue dans le simulateur de potager");
        Console.WriteLine("========================");

        ChoisirTerrain();

        ExecuterBoucleJeu();
    }

    private void ChoisirTerrain()
    {
        Console.WriteLine("\n=================================");
        Console.WriteLine("Choisissez le type de terrain pour votre potager :");
        Console.WriteLine("=================================\n");
        
        Console.WriteLine("1. Terrain Sableux");
        Console.WriteLine("   Description: Sol drainant et chaud, idéal pour les plantes méditerranéennes.");
        Console.WriteLine("   Avantages: Bonne croissance pour les plantes qui aiment la chaleur et le sol sec.");
        Console.WriteLine("   Inconvénients: Retient peu l'eau et les nutriments.\n");
        
        Console.WriteLine("2. Terrain Argileux");
        Console.WriteLine("   Description: Sol riche en nutriments mais drainant mal.");
        Console.WriteLine("   Avantages: Riche et fertile, idéal pour les légumes-racines.");
        Console.WriteLine("   Inconvénients: Peut être lourd et compact quand il est mouillé.\n");
        
        Console.WriteLine("3. Terrain Limoneux");
        Console.WriteLine("   Description: Sol équilibré et fertile, le meilleur pour un potager traditionnel.");
        Console.WriteLine("   Avantages: S'adapte à la plupart des plantes cultivées.");
        Console.WriteLine("   Inconvénients: Peut nécessiter un entretien régulier.\n");
        
        Console.WriteLine("4. Terrain Rocheux");
        Console.WriteLine("   Description: Sol peu profond avec présence de rochers.");
        Console.WriteLine("   Avantages: Bon drainage et chaleur pour herbes aromatiques.");
        Console.WriteLine("   Inconvénients: Difficile pour les plantes qui ont besoin de profondeur.\n");
        
        Console.WriteLine("5. Terrain Forestier");
        Console.WriteLine("   Description: Sol ombragé et riche en matière organique.");
        Console.WriteLine("   Avantages: Excellent pour les plantes d'ombre et les baies sauvages.");
        Console.WriteLine("   Inconvénients: Peu de lumière et compétition avec les racines d'arbres.\n");

        Console.Write("Votre choix (1-5)");
        int choixTerrain = LireChoixUtilisateur(1-5);

        switch (choixTerrain)
        {
            case 1:
                terrainACtuel = new TerrainSableux();
                break;
            case 2:
                terrainACtuel = new TerrainArgileux();
                break;
            case 3:
                terrainACtuel = new TerrainLimoneux();
                break;
            case 4:
                terrainACtuel = new TerrainRocheux();
                break;
            case 5:
                terrainACtuel = new TerrainForestier();
                break;
        }

        terrainACtuel.InitialiserTerrainVisuel();

        Console.WriteLine($"\nVous avez choisi un {terrainACtuel.TypeSol}.");
        Console.WriteLine(terrainACtuel.DescriptionTerrain);
        
        InitialiserSemences();

        Console.WriteLine("\nAppuyer sur une touche pour commencer à cultiver !");
        Console.ReadKey();
        Console.Clear();
    }

    private void InitialiserSemences()
    {

    }
}
*/