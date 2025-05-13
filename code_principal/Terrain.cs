public abstract class Terrain
{
    public string Nom { get; set; } // pour différencier les différents terrains
    public float Surface { get; set; } // en m²
    public string Meteo { get; set; } // printemps, été, automne, hiver
    public string TypeSol { get; set; } // argileux, sableux, limoneux, forestier.
    public float Humidite { get; set; } // en pourcentage
    public float Precipitations { get; set; } // en mm
    public float Luminosite { get; set; } // en %
    public float Temperature { get; set; } // en °C
    public bool EstProtege { get; set; } // présence d'une serre, d'un filet, etc.
    public List<Plante> PlantesCultivees { get; set; }

    // création du terrain visuel
    public int Lignes {get; set;} 
    
    public int Colonnes {get; set;} 
    public int [,] TerrainVisuel {get; set;}

    public Terrain (string nom, float surface, string meteo, string typeSol, float humidite, float precipitations, float luminosite, float temperature, bool estProtege, int lignes = 15, int colonnes = 15) // constructeur
    {
        Nom = nom;
        Surface = surface;
        Meteo = meteo;
        TypeSol = typeSol;
        Humidite = humidite;
        Precipitations = precipitations;
        Luminosite = luminosite;
        Temperature = temperature;
        EstProtege = estProtege;
        PlantesCultivees = new List<Plante>();
        Lignes = lignes;
        Colonnes = colonnes;
        TerrainVisuel = new int [Lignes, Colonnes]; // déclaration de la matrice de taille "Lignes*Colonnes" qui représente le terrain visuel
    }

    public string[,] InitialiserT() // méthode qui permet d'initialiser le terrain
    {
        T = new string[Lignes, Colonnes]; // déclaration de la matrice de taille "Lignes*Colonnes" qui représente le terrain visuel

        // Types de sol pour les 4 zones
        string[,] zoneTypes = new string[2, 2]
        {
            { "Sableux", "Argileux" },
            { "Limoneux", "Forestier" }
        };

        // Remplir le plateau en fonction des zones
        for (int i = 0; i < Lignes; i++)
        {
            for (int j = 0; j < Colonnes; j++)
            {
                int zoneI = i < Lignes / 2 ? 0 : 1;
                int zoneJ = j < Colonnes / 2 ? 0 : 1;
                T[i, j] = zoneTypes[zoneI, zoneJ];
            }
        }

        // Dimensions visuelles des cases
        int largeurCases = 5;
        int hauteurCases = 2;

        // Affichage du plateau
        for (int i = 0; i < Lignes; i++)
        {
            // Bord supérieur des cases
            for (int j = 0; j < Colonnes; j++)
                Console.Write("+" + new string('─', largeurCases));
            Console.WriteLine("+");

            // Affichage vertical de la case (hauteur)
            for (int h = 0; h < hauteurCases; h++)
            {
                for (int j = 0; j < Colonnes; j++)
                {
                    Console.Write("|");
                    Console.BackgroundColor = GetColor(T[i, j]);
                    Console.Write(new string(' ', largeurCases));
                }

                Console.ResetColor();
            }
            Console.WriteLine("|");
        }

        // Dernière ligne de bas du plateau
        for (int j = 0; j < Colonnes; j++)
            Console.Write("+" + new string('─', largeurCases));
        Console.WriteLine("+");


        // Détermination de la couleur selon le type de sol
        static ConsoleColor GetColor(string type)
        {
            return type switch
            {
                "Sableux" => ConsoleColor.Yellow,
                "Argileux" => ConsoleColor.Gray,
                "Limoneux" => ConsoleColor.DarkRed,
                "Forestier" => ConsoleColor.Green,
                _ => ConsoleColor.Black
            };
        }

        return T;
    }

    public void AfficherT(int[,] T) // méthode qui permet d'afficher le terrain visuel
    {
        if (T == null)
        {
            InitialiserT();
        }

        Console.WriteLine($"Terrain : {Nom} ({TypeSol})");

        for (int i = 0; i < T.GetLength(0); i++) // boucle for permet de parcourir toutes les lignes de la matrice
        {
            Console.Write("│");
            for (int j = 0; j < T.GetLength(1); j++) // boucle for permet de parcourir toutes les colonnes de la matrice
            {
                switch (T[i, j]) // choix d'un switch pour éviter un grand nombre de répétition de if
                {
                    case 0: // terrain vide
                        if (TypeSol == "Sableux") Console.Write(" 🟨 ");
                        else if (TypeSol == "Argileux") Console.Write(" 🟧 ");
                        else if (TypeSol == "Limoneux") Console.Write(" 🟫 ");
                        else Console.Write(" 🟩 ");
                        break;
                    case 1: // semis
                        Console.Write(" 🌱 ");
                        break;
                    case 2: // jeune plante
                        Console.Write(" 🌿 ");
                        break;
                    case 3: // plante mature
                        Console.Write(" 🌳 ");
                        break;
                    case 4: // plante en fleurs
                        Console.Write(" 🌼 ");
                        break;
                    case 5: // plante avec fruits/légumes
                        Console.Write(" 🍎 ");
                        break;
                    case 6: // pas de géant
                        Console.Write(" 👣 ");
                        break;
                    case 7: // tas de terre
                        Console.Write(" 🟤 ");
                        break;
                    case 8: // rocher
                        Console.Write(" 🪨 ");
                        break;
                    case 9: // arbre
                        Console.Write(" 🌲 ");
                        break;
                    default:
                        Console.Write(" · ");
                        break;
                }
            }
            Console.WriteLine("│");
        }
        Console.WriteLine("└" + new string('─', Colonnes * 3) + "┘");
    }

    public virtual bool PeutAccueillir(Plante plante) // méthode qui permet de gérer le nombre de plantes que le terrain peut accueillir
    {
        return plante.EspaceNecessaire <= SurfaceLibre();
    }

    public float SurfaceLibre() // méthode qui permet de gérer l'espace disponible sur le terrain 
    {
        float occupee = 0;
        foreach (var plante in PlantesCultivees) // en parcourant la liste des plantes cultivées
        {
            occupee += plante.EspaceNecessaire;
        }
        return Surface - occupee;
    }

    public void AjouterPlante(Plante plante) // méthode qui permet d'ajouter une plante au terrain
    {
        if (PeutAccueillir(plante)) // vérifie s'il y a assez d'espace pour accueillir une nouvelle plante
        {
            PlantesCultivees.Add(plante); // ajout d'une plante
            plante.Terrain = this;
            PlacerPlanteSurTerrain(plante);
            Console.WriteLine($"Plante {plante.Nom} ajoutée au terrain {Nom}.");
        }
        else Console.WriteLine($"Pas assez de place pour planter {plante.Nom} sur le terrain {Nom}.");
    }

    protected virtual void PlacerPlanteSurTerrain(Plante plante)
    {
        Random random = new Random();
        bool placee = false;

        while (!placee)
        {
            int x = random.Next(0, Lignes);
            int y = random.Next(0, Colonnes);

            if (T[x, y] == 0)
            {
                T[x, y] = 1; // représente un semis
                placee = true;
            }
        }
    }

    // mise à jour de la température en fonction de la météo
    public virtual void MiseAJour()
    {
        switch (Meteo)
        {
            case "Tempéré" :
            Temperature = 15 + new Random().Next(-5,6);
            break;
            case "Chaud" :
            Temperature = 25 + new Random().Next(5,6);
            break;
            case "Nuageux" :
            Temperature = 10 + new Random().Next(-5,6);
            break;
            case "Froid" : 
            Temperature = 0 + new Random().Next(-10,6);
            break;
        }
        // mise à jour de l'humidité (peut varier aléatoirement)
        Humidite += new Random().Next(-10,11);
        Humidite = Math.Max(0,Math.Min(100,Humidite)); // limitation entre 0 et 100%
        Precipitations += new Random().Next(-20,20);
        Humidite = Math.Max(0,Math.Min(100,Precipitations)); // limitation entre 0 et 100mm

        Console.WriteLine($"[{Meteo}] Température : {Temperature}°C, Humdité : {Humidite}%, Précipitations : {Precipitations}mm");
    }

    public override string ToString() // méthode d'affichage textuel des terrains
    {
        string resultat = $"Terrain : {Nom} \n"
                        + $"Surface totale : {Surface} m² \n"
                        + $"Surface libre : {SurfaceLibre()} m²"
                        + $"Humidité : {Humidite}% \n"
                        + $"Luminosité : {Luminosite}% \n"
                        + $"Température : {Temperature}°C \n"
                        + $"Météo : {Meteo}\n"
                        + $"Protégé :" + (EstProtege ? "Oui" : "Non") + "\n"
                        + $"Plantes cultivés : \n";

        if (PlantesCultivees.Count == 0)
        {
            resultat += " -Aucune plante pour le moment.\n";
        }
        else
        {
            foreach (var plante in PlantesCultivees) // parcours la liste des plantes cultivées pour afficher textuellement les plantes qui sont présentes sur le terrain
            {
                resultat += $" -{plante.Nom} \n";
            }
        }
        return resultat;
    }
}




