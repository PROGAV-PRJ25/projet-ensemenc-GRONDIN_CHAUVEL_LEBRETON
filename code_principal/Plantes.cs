public class Plante
{
    public string Nom { get; set; } //pour différencier les différentes plantes 
    public enum Type { Fruit, Legume, Fleur, Herbe, Champignon } //  1 = Fruit, 2 = Légume, 3 = Fleur,..
    public Type TypePlante { get; private set; }
    public string SaisonPref { get; private set; }
    public string TypeSolNeccessaire { get; private set; }
    public float HumiditeNecessaire { get; private set; }
    public float TemperatureNecessaire { get; private set; }
    public int LuminositeNecessaire { get; private set; }
    public int EspaceNecessaire { get; private set; } // Nécessaire permet de mettre en écidence que ce sont des conditions spécifiques à la plante  
    public enum EtatSante {EnBonneSante,Malade,Morte} // pour différencier les différents états de la plante 
    public EtatSante Sante {get; private set;}
    public int EsperanceDeVie { get; private set; }
    public Terrain Terrain { get; private set; } // pas sur ?? List <Terrain>
    public float Croissance {get;private set;}
    private bool EstArrosee = false;

    public Plante(string nom, string saisonPref, Type typePlante, string typeSolNecessaire, float humiditeNecessaire, float temperatureNecessaire, int luminositeNecessaire, int espaceNecessaire, string sante, int esperanceDeVie, float croissance = 0) // utilisation d'une constante t peu importe pour enum
    {
        Nom = nom;
        SaisonPref = saisonPref;
        TypePlante = typePlante;
        TypeSolNeccessaire = typeSolNecessaire;
        HumiditeNecessaire = humiditeNecessaire;
        TemperatureNecessaire = temperatureNecessaire;
        LuminositeNecessaire = luminositeNecessaire;
        EspaceNecessaire = espaceNecessaire;
        Sante = sante;
        EsperanceDeVie = esperanceDeVie;
    }
    
    public float CroissanceSelonConditions(Terrain terrain)
    {
        int nbConditionsTotal = 6;
        int conditionsOk = 0;

        if (terrain.Saison == SaisonPref)
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
        return (float)(conditionsOk/nbConditionsTotal)*100;
    }

    public void MettreAJourCroissance() // sert à faire évoluer la plante à chaque tour en fonction des conditions du terrain et si la plante a été arrosée 
    {
        if (pourcentageConditions < 0.5)
        {
            Sante = "Morte";
            Console.WriteLine($"{Nom} est morte 😢");
        }
        else if (pourcentageConditions < 0.75)
        {
            Croissance += 0.2;
            Console.WriteLine($"{Nom} pousse bien {pourcentageConditions * 100}%");
        }
        else
        {
            Croissance += 0.3;
            Console.WriteLine($"{Nom} pousse VITE !! {pourcentageConditions * 100}%");
        }

        if (EstArrosee)
        {
            Croissance += 0.3;
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

    public void AfficherJauge()
    {
        int totalVies = 10;
        float pourcentageConditions = EvaluerConditions(Terrain);
        int Vies = (int)(pourcentageConditions * totalVies);
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

    public abstract void EtatFinal(){}   

    public void AfficherEvolutionPlantes()
    {
        if (Croissance <= 0.5)
        {
            Console.WriteLine($"{Nom} vient de germer") ; // changer à mettre en lien avec le terrain 
        }
        else if (Croissance < 1.5)
        {
            Console.WriteLine($"{Nom} est en croissance");
        }
        if (Croissance == 1.5)
        {
            Console.WriteLine($"{Nom} est mature");
        }
    }

    public void Contaminer(string cause) // Permet de contaminer une plante à mettre en relation avec les obstacles mais je garde ou bien c'est à mettre dans obstacles.cs ? 
    {
        if (Sante == EtatSante.EnBonneSante)
        {
            Sante==EtatSante.Malade;
            Console.WriteLine($"{Nom} a été contaminée par {cause} !");
        }
    }

     public void Soigner(string cause) // Permet de soigner une plante
    {
        if (Sante == EtatSante.Malade)
        {
            Sante==EtatSante.EnBonneSante;
            Console.WriteLine($"{Nom} a été soigné par {cause} ! Youpiiiii !");
        }
    }

    public void ExposerAuSoleil() // permet d'exposer la plante au soleil (augmente légèrement la croissance)
    {
        Croissance += 0.1f;
        Console.WriteLine($"{Nom} a profité du soleil ☀️!");
    }

    public void Fertiliser() // permet de fertiliser la plante (augmente de façon plus importante la croissance)
    {
    Croissance += 0.2f;
    Console.WriteLine($"{Nom} a été fertilisée 🌱 !");
    }

    public void Tailler() // permet de tailler la plante (réduit un peu la croissance mais améliore sa santé si elle est malade)
    {
        Croissance -= 0.1f;
        if (Sante == EtatSante.Malade)
        {
            Sante = EtatSante.EnBonneSante;
            Console.WriteLine($"{Nom} a été taillée et est maintenant en meilleure santé !");
        }
        else Console.WriteLine($"{Nom} a été taillée pour mieux pousser.");
    }

    public void Recolter() // permet de récolter la plante si elle est mature
    {
        if (Croissance >= 1.5f)
        {
            Console.WriteLine($"{Nom} a été récoltée avec succès !");
            Sante = EtatSante.Morte;
        }
        else Console.WriteLine($"{Nom} n'est pas encore prête à être récoltée.);
    }

    public void VerifierFinDeVie(int age) // permet de vérifier que la plante est en fin de vie
    {
        if (age >= EsperanceDeVie)
        {
            Sante = EtatDeSante.Morte;
            Console.WriteLine($"{Nom} a atteint la fin de sa vie. 🪦");
        }
    }
    public override string ToString()
    {
        return $"Nom : {Nom}, Type : {TypePlante}, Santé : {Sante}, Croissance : {Croissance}";
    }

