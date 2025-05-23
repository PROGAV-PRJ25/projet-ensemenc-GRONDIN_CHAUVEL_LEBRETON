public abstract class Terrain
{
    public string Nom { get; set; } // pour différencier les différents terrains
    public float Surface { get; set; } // en m²
    public string Meteo { get; set; } // printemps, été, automne, hiver ou autre
    public string TypeSol { get; set; } // argileux, sableux, limoneux, forestier.
    public float Humidite { get; set; } // en pourcentage
    public float Precipitations { get; set; } // en mm
    public float Luminosite { get; set; } // en %
    public float Temperature { get; set; } // en °C
    public bool EstProtege { get; set; } // présence d'une serre, d'un filet, etc.
    public List<Plante> PlantesCultivees { get; set; }

    // Dimensions du terrain visuel
    public int Lignes { get; set; }
    public int Colonnes { get; set; }

    // Matrice représentant l’état du terrain (0=vide, 1=semis, ...)
    public int[,] T { get; set; }

    public Terrain(string nom, float surface, string meteo, string typeSol, float humidite, float precipitations, float luminosite, float temperature, bool estProtege, int lignes = 15, int colonnes = 15)
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
        T = new int[Lignes, Colonnes]; // initialise matrice vide
    }

    // Initialiser la matrice T à vide (0)
    public virtual void InitialiserT()
    {
        for (int i = 0; i < Lignes; i++)
        {
            for (int j = 0; j < Colonnes; j++)
            {
                T[i, j] = 0; // 0 signifie case vide
            }
        }
    }

    // Affiche en console le terrain et ses éléments (emojis)
    public void AfficherT()
    {
        for (int i = 0; i < Lignes; i++)
        {
            Console.Write(" ");
            for (int j = 0; j < Colonnes; j++)
            {
                switch (T[i, j])
                {
                    case 0: // vide
                        if (TypeSol == "Sableux") Console.Write(" 🟨 ");
                        else if (TypeSol == "Argileux") Console.Write(" 🟧 ");
                        else if (TypeSol == "Limoneux") Console.Write(" 🟫 ");
                        else Console.Write(" 🟩 ");
                        break;
                    case 1: // semis, jeunes pousses
                        Console.Write(" 🌱 ");
                        break;
                    case 2: // bonne herbe
                        Console.Write(" 🌿 ");
                        break;
                    case 3: // plante mature
                        Console.Write(" 🌳 ");
                        break;
                    case 4: // tulipe
                        Console.Write(" 🌼 ");
                        break;
                    case 5: // pomme
                        Console.Write(" 🍎 ");
                        break;
                    case 6: // pas de géant
                        Console.Write(" 👣 ");
                        break;
                    case 7: // tas de terre de la taupe
                        Console.Write(" 🟤 ");
                        break;
                    case 8: // rocher
                        Console.Write(" 🪨 ");
                        break;
                    case 9: // arbre
                        Console.Write(" 🌲 ");
                        break;
                    case 10: // fraise
                        Console.Write(" 🍓");
                        break;
                    case 11: // carotte
                        Console.Write(" 🥕 ");
                        break;
                    case 12: // champignon
                        Console.Write(" 🍄 ");
                        break;
                    case 13: // aubergine
                        Console.Write(" 🍆 ");
                        break;
                    case 14: // pasteque
                        Console.Write(" 🍉 ");
                        break;
                    case 15: // piment
                        Console.Write(" 🌶️ ");
                        break;
                    case 16: // rose
                        Console.Write(" 🌹 ");
                        break;
                    case 17: // salade
                        Console.Write(" 🥬 ");
                        break;
                    case 18: // tomate
                        Console.Write(" 🍅 ");
                        break;
                    case 19: // tournesol
                        Console.Write(" 🌻 ");
                        break;
                    case 20: // dragon
                        Console.Write(" 🐉 ");
                        break;
                    case 21: // feu
                        Console.Write(" 🔥 ");
                        break;
                    case 22: // mauvaise herbe
                        Console.Write(" 🌾 ");
                        break;
                    case 23:
                        Console.Write("🥀");
                        break;
                    default:
                        Console.Write(" · ");
                        break;
                }
            }
            Console.WriteLine(" ");
        }
        Console.WriteLine(" " + new string(' ', Colonnes * 3) + " ");
    }

    // Méthode qui vérifie si on peut planter
    public virtual bool PeutAccueillir(Plante plante)
    {
        return plante.EspaceNecessaire <= SurfaceLibre();
    }

    public float SurfaceLibre()
    {
        float occupee = 0;
        foreach (var plante in PlantesCultivees)
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
            Console.WriteLine($"\n Plante {plante.Nom} ajoutée au {Nom}.");
        }
        else Console.WriteLine($"Pas assez de place pour planter {plante.Nom} sur le terrain {Nom}.");
    }
    protected virtual void PlacerPlanteSurTerrain(Plante plante) // ajout de l'enregistrement des coordonnées des plantes sur le terrain // permet de modifier précisément la case où la plante a été planté pour état final par exemple 
    {
        Random random = new Random();
        bool placee = false;

        while (!placee)
        {
            int x = random.Next(0, Lignes);
            int y = random.Next(0, Colonnes);

            if (T[x, y] == 0)
            {
                T[x, y] = 1; // semis
                plante.PositionX = x; // on stocke les coordonnées dans la plante
                plante.PositionY = y;
                placee = true;
            }
        }
    }

    // Mise à jour météo et paramètres
    public virtual void MiseAJour()
    {
        Random rnd = new Random();

        switch (Meteo)
        {
            case "Tempéré":
                Temperature = 15 + rnd.Next(-5, 6);
                break;
            case "Chaud":
                Temperature = 25 + rnd.Next(-5, 6);
                break;
            case "Nuageux":
                Temperature = 10 + rnd.Next(-5, 6);
                break;
            case "Froid":
                Temperature = 0 + rnd.Next(-10, 6);
                break;
            default:
                // météo inconnue, température stable
                break;
        }

        Humidite += rnd.Next(-10, 11);
        Humidite = Math.Clamp(Humidite, 0, 100);

        Precipitations += rnd.Next(-20, 21);
        Precipitations = Math.Clamp(Precipitations, 0, 100);

        Console.WriteLine($"[{Meteo}] Température : {Temperature}°C, Humidité : {Humidite}%, Précipitations : {Precipitations}mm");
    }

    public override string ToString()
    {
        string resultat = $"Terrain : {Nom} \n" +
                          $"Surface totale : {Surface} m² \n" +
                          $"Surface libre : {SurfaceLibre()} m²\n" +
                          $"Humidité : {Humidite}% \n" +
                          $"Luminosité : {Luminosite}% \n" +
                          $"Température : {Temperature}°C \n" +
                          $"Météo : {Meteo}\n" +
                          $"Protégé : " + (EstProtege ? "Oui" : "Non") + "\n" +
                          $"Plantes cultivées : \n";

        if (PlantesCultivees.Count == 0)
        {
            resultat += " - Aucune plante pour le moment.\n";
        }
        else
        {
            foreach (var plante in PlantesCultivees)
            {
                resultat += $" - {plante.Nom} \n";
            }
        }
        return resultat;
    }

    public void AfficherPlantesAvecIndex()
    {
        for (int i = 0; i < PlantesCultivees.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {PlantesCultivees[i]}");
        }
    }
    public void ArroserPlanteParIndex(int index)
    {
        if (index >= 0 && index < PlantesCultivees.Count)
        {
            PlantesCultivees[index].ArroserPlantes();
        }
        else
        {
            Console.WriteLine("Index de plante invalide.");
        }
    }

    public int NombrePlantes()
    {
        return PlantesCultivees.Count;
    }


}
