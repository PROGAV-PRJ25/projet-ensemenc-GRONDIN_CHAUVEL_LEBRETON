public abstract class Plante
{
    public string Nom { get; set; } //pour différencier les différentes plantes 
    public enum TypePlante { Fruit, Legume, Fleur, Herbe, Champignon } //  0 = Fruit, 1 = Légume, 2 = Fleur,..
    public TypePlante Type { get; set; }
    public string MeteoPref { get; private set; }
    public string TypeSolNeccessaire { get; private set; }
    public float HumiditeNecessaire { get; private set; }
    public float TemperatureNecessaire { get; private set; }
    public int LuminositeNecessaire { get; private set; }
    public int EspaceNecessaire { get; private set; } // "Necessaire" permet de mettre en évidence que ce sont des conditions spécifiques à la plante  
    public enum EtatSante { EnBonneSante, Malade, Morte } // pour différencier les différents états de la plante 
    public EtatSante Sante { get; set; }
    public int EsperanceDeVie { get; private set; }
    public Terrain? Terrain { get; set; } // association avec le terrain où est plantée la plante
    public float Croissance { get; set; }
    public bool EstArrosee = false;
    public int PositionX { get; set; }
    public int PositionY { get; set; }

    public Plante(string nom, string meteoPref, TypePlante type, string typeSolNecessaire, float humiditeNecessaire, float temperatureNecessaire, int luminositeNecessaire, int espaceNecessaire, int esperanceDeVie, float croissance = 0) // utilisation d'une constante t peu importe pour enum
    {
        Nom = nom;
        MeteoPref = meteoPref;
        Type = type;
        TypeSolNeccessaire = typeSolNecessaire;
        HumiditeNecessaire = humiditeNecessaire;
        TemperatureNecessaire = temperatureNecessaire;
        LuminositeNecessaire = luminositeNecessaire;
        EspaceNecessaire = espaceNecessaire;
        Croissance = croissance;
        Sante = EtatSante.EnBonneSante;
        EsperanceDeVie = esperanceDeVie;
    }

    public float CroissanceSelonConditions(Terrain terrain)
    {
        int nbConditionsTotal = 6;
        int conditionsOk = 0;
        if (terrain.Meteo == MeteoPref)
        {
            conditionsOk++;
        }
        if (terrain.TypeSol == TypeSolNeccessaire)
        {
            conditionsOk++;
        }
        if (Math.Abs(terrain.Humidite - HumiditeNecessaire) <= 3) // fonction qui renvoie la valeur absolue avec une marge de +/-3
        {
            conditionsOk++;
        }
        if (Math.Abs(terrain.Luminosite - LuminositeNecessaire) <= 3)
        {
            conditionsOk++;
        }
        if (Math.Abs(terrain.Temperature - TemperatureNecessaire) <= 5)
        {
            conditionsOk++;
        }
        if (terrain.Surface >= EspaceNecessaire)
        {
            conditionsOk++;
        }
        return (float)(conditionsOk / (double)nbConditionsTotal) * 100;
    }

    public void MettreAJourCroissance() // sert à faire évoluer la plante à chaque tour en fonction des conditions du terrain et si la plante a été arrosée 
    {
        if (Terrain == null)
        {
            Console.WriteLine($"{Nom} n'est pas plantée dans un terrain.");
            return;
        }

        float pourcentageConditions = CroissanceSelonConditions(Terrain);
        if (pourcentageConditions < 50)
        {
            Sante = EtatSante.Morte;
            Console.WriteLine($"{Nom} est morte 😢");
        }
        else if (pourcentageConditions < 75)
        {
            Croissance += 0.2f;
            Console.WriteLine($"{Nom} pousse bien {pourcentageConditions}%");
        }
        else
        {
            Croissance += 0.3f;
            Console.WriteLine($"{Nom} pousse VITE !! {pourcentageConditions}%");
        }
        if (EstArrosee)
        {
            Croissance += 0.3f;
            EstArrosee = false;
        }

        if (Sante == EtatSante.Malade)
        {
            Console.WriteLine($"{Nom} est malade, elle ne pousse pas aujourd'hui !");
        }
    }

    public void ArroserPlantes() //Sert à arroser une plante une seule fois 
    {
        if (!EstArrosee)// si non arrosée => on veut qu'elle soit arrosée
        {
            EstArrosee = true;
            Console.WriteLine("Plante arrosée 💧 !!");
        }
        else
        {
            Console.WriteLine("Cette plante a déjà été arrosée récemment"); // si arrosée est true alors on ne peut pas arroser une nouvelle fois 
        }
    }

    public abstract void AtteindreEtatFinal();

    public void AfficherEvolutionPlantes()
    {
        if (Croissance <= 0.5f)
        {
            Console.WriteLine($"{Nom} vient de germer"); // changer à mettre en lien avec le terrain 
        }
        else if (Croissance < 1.5f)
        {
            Console.WriteLine($"{Nom} est en croissance");
        }
        if (Croissance >= 1.5f)
        {
            Console.WriteLine($"{Nom} est mature");
        }
    }

    public void Contaminer(string cause) // Permet de contaminer une plante à mettre en relation avec les obstacles mais je garde ou bien c'est à mettre dans obstacles.cs ? 
    {
        if (Sante == EtatSante.EnBonneSante)
        {
            Sante = EtatSante.Malade;
            Console.WriteLine($"{Nom} a été contaminée par {cause} !");
        }
    }

    public void Soigner(string cause) // Permet de soigner une plante
    {
        if (Sante == EtatSante.Malade)
        {
            Sante = EtatSante.EnBonneSante;
            Console.WriteLine($"{Nom} a été soigné.e par {cause} ! Youpiiiii !");
        }
    }

    public void ExposerAuSoleil() // permet d'exposer la plante au soleil (augmente légèrement la croissance)
    {
        Croissance += 0.1f;
        Console.WriteLine($"{Nom} a profité du soleil ☀️!");
    }
    public override string ToString()
    {
        return $"Nom : {Nom}, Type : {Type}, Santé : {Sante}, Croissance : {Croissance}";
    }
}