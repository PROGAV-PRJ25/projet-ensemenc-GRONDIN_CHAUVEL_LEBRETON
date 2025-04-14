public class Plante
{
    public string Nom { get; set; } //pour différencier les différentes plantes 
    public enum Type { Fruit, Legume, Fleur, PlanteOriginale, Herbe } //  1 = Fruit, 2 = Légume, 3 = Fleur,..
    public Type TypePlante { get; set; }
    public string SaisonPref { get; private set; }
    public string TypeSolNeccessaire { get; set; }
    public float HumiditeNecessaire { get; set; }
    public float TemperatureNecessaire { get; set; }
    public float LuminositeNecessaire { get; set; }
    public int EspaceNecessaire { get; private set; } // Nécessaire permet de mettre en écidence que ce sont des conditions spécifiques à la plante  
    public string Sante { get; private set; } // pour différencier les différents états de la plante 
    public int EsperanceDeVie { get; private set; }
    public Terrain Terrain { get; set; } // pas sur ?? List <Terrain>
    public float Croissance {get;set;}

    public Plante(string nom, string saisonPref, Type typePlante, Terrain terrain, string typeSolNecessaire, float humiditeNecessaire, float temperatureNecessaire, float luminositeNecessaire, int espaceNecessaire, string sante, int esperanceDeVie, float croissance = 0) // utilisation d'une constante t peu importe pour enum
    {
        Nom = nom;
        SaisonPref = saisonPref;
        TypePlante = typePlante;
        TypeSolNeccessaire = typeSolNecessaire;
        HumiditeNecessaire = humiditeNecessaire;
        TemperatureNecessaire = temperatureNecessaire;
        LuminositeNecessaire = luminositeNecessaire;
        Terrain = terrain;
        EspaceNecessaire = espaceNecessaire;
        Sante = sante;
        EsperanceDeVie = esperanceDeVie;
        Croissance = croissance;

    }

    public float CroissanceSelonConditions(Terrain terrain)
    {
        int nbConditionsTotal = 6;
        float conditionsOk = 0;
        float pourcentageConditions = conditionsOk / nbConditionsTotal;

        if (terrain.Saison == SaisonPref)
        {
            conditionsOk++;
        }
        if (terrain.TypeSol == TypeSolNeccessaire)
        {
            conditionsOk++;
        }
        if (Math.Abs(terrain.Humidite - HumiditeNecessaire) > 3) // fonction qui renvoie la valeur absolue avec une marge de +/-3
        {
            conditionsOk++;
        }
        if (Math.Abs(terrain.Luminosite - LuminositeNecessaire) > 3)
        {
            conditionsOk++;
        }
        if (Math.Abs(terrain.Temperature - TemperatureNecessaire) > 5)
        {
            conditionsOk++;
        }
        if (terrain.Surface >= EspaceNecessaire)
        {
            conditionsOk++;
        }
        if (pourcentageConditions < 0.5)
        {
            Console.WriteLine($"{Nom} est morte 😢");
        }

        if ((pourcentageConditions > 0.5) && (pourcentageConditions < 0.75))
        {
            Croissance = 0.2;
            Console.WriteLine($"{Nom} pousse bien {pourcentageConditions * 100}%");
        }
        if ((pourcentageConditions > 0.75) && (pourcentageConditions < 1))
        {
            Croissance = 0.3;
            Console.WriteLine($"{Nom} pousse VITE !! {pourcentageConditions * 100}%");
        }
        return Croissance;
    }

    public void AfficherJauge(float pourcentageConditions)
    {
        int totalVies = 10;
        int Vies = (int)pourcentageConditions * totalVies;
        string jauge = "";

        for (int i = 0; i < totalVies; i++)
        {
            if (i < Vies)
            {
                jauge += "❤️";
            }
            else
            {
                jauge += "░";
            }
        }
        Console.WriteLine($"Sante : {jauge} {pourcentageConditions * 100}");
    }

    public void ArroserPlantes(int planteArrosée)
    {
        planteArrosée = 1;
        Console.WriteLine("Plante arrosée 💧 !!");
    }

    public float EvolutionPlantes()
    {
            if (Croissance >= 1.5)
        {    
            if (CroissanceSelonConditions(Terrain) == 0.2)
            {
                Croissance += 0.2;
            }
            if (CroissanceSelonConditions(Terrain) == 0.3)
            {
                Croissance += 0.3;
            }
            if (ArroserPlantes(planteArrosée) == 1)
            {
                Croissance += 0.3;
            }
        }
        return Croissance;  
    }

    public void AfficherEvolutionPlantes()
    {
        if (Croissance <= 0.5)
        {

        }
        if ((Croissance > 0.5) && (Croissance < 1.5))
        {

        }
        if (Croissance = 1.5)
        {

        }
    }

    //faire sous classe pour les différentes plantes avec les conditions précises => héritage ! 
}
