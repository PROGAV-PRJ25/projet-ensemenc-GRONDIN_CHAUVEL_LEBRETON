public class Terrain
{
    public string Nom { get; set; } // pour différencier les différents terrains
    public float Surface { get; set; } // en m²
    public string TypeSol { get; set; } // argileux, sableux, limoneux, etc.
    public float Humidite { get; set; } // en pourcentage
    public float Luminosite { get; set; } // en %
    public bool EstProtege { get; set; } // présence d'une serre, d'un filet, etc.
    public List<Plante> PlantesCultivees { get; set; }
    // création du terrain visuel
    public int Lignes {get;protected set;} 
    
    public int Colonnes {get;protected set;} 
    public int [,] TerrainVisuel {get; set;}

    public Terrain (string nom, float surface, string typeSol, float humidite, float luminosite, bool estProtege, int lignes = 15, int colonnes = 15) // constructeur
    {
        Nom = nom;
        Surface = surface;
        TypeSol = typeSol;
        Humidite = humidite;
        Luminosite = luminosite;
        EstProtege = estProtege;
        PlantesCultivees = new List<Plante> ();
        Lignes = lignes;
        Colonnes = colonnes;
    }

    public int[,] InitialiserTerrainVisuel() // méthode qui permet d'initialiser le terrain
    {
        TerrainVisuel = new int [Lignes,Colonnes]; // déclaration de la matrice de taille "Lignes*Colonnes" qui représente le terrain visuel
        for (int i = 0; i < Lignes; i++) // utilisation d'une boucle for pour parcourir toute la matrice
        {
            for(int j = 0; j < Colonnes; j++)
            {
                TerrainVisuel[i, j] = 0; // le terrain est rempli par des 0
            }
        }
        return TerrainVisuel; // retour d'une matrice 2D remplie de 0
    }

    public void AfficherTerrainVisuel(int[,] terrainVisuel) // méthode qui permet d'afficher le terrain visuel
    {
        for (int i = 0; i < terrainVisuel.GetLength(0); i++) // boucle for permet de parcourir toutes les lignes de la matrice
        {
            for (int j = 0; j < terrainVisuel.GetLength(1); j++) // boucle for permet de parcourir toutes les colonnes de la matrice
            {
                switch (terrainVisuel[i, j]) // choix d'un switch pour éviter un grand nombre de répétition de if
                {
                    case 0: // si la case de la matrice a pour valeur 0 alors on affiche un carré "🟩"
                    Console.Write(" 🟩 ");
                    break;
                }
            }
            Console.WriteLine();
        }
        Console.WriteLine();
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
            occupee += PlantesCultivees.EspaceNecessaire;
        }
        return Surface - occupee;
    }
    
    public void AjouterPlante (Plante plante) // méthode qui permet d'ajouter une plante au terrain
    {
        if (PeutAccueillir(plante)) // vérifie s'il y a assez d'espace pour accueillir une nouvelle plante
        {
            PlantesCultivees.Add(plante); // ajout d'une plante
            Console.WriteLine($"Plante {plante.Nom} ajoutée au terrain {Nom}.");
        }
        else Console.WriteLine($"Pas assez de place pour planter {plante.Nom} sur le terrain {Nom}.");
    }

    public override string ToString() // méthode d'affichage textuel des terrains
    {
        string resultat = $"Terrain : {Nom} \n"
                        + $"Type de sol : {TypeSol} \n"
                        + $"Surface totale : {Surface} m² \n"
                        + $"Surface libre : {SurfaceLibre()} m²"
                        + $"Humidité : {Humidite}% \n"
                        + $"Luminosité : {Luminosite}% \n"
                        + $"Protégé :" + (EstProtege? "Oui" : "Non") + "\n"
                        + $"Plantes cultivés : \n";

        if (PlantesCultivees.Count == 0) 
        {
        resultat += " -Aucune plante pour le moment.\n";
        }
        else
        {
            foreach (var plante in PlantesCultivees) // parcours la liste des plantes cultivées pour afficher textuellement les plantes qui sont présentes sur le terrain
            {
                resultat += $" -{plante} \n";
            }
        }
        return resultat;
    }
}