public abstract class Terrain
{
    public string Nom { get; set; } // pour différencier les différents terrains
    public float Surface { get; set; } // en m²
    public string TypeSol { get; set; } // argileux, sableux, limoneux, etc.
    public float Humidite { get; set; } // en pourcentage
    public float Luminosite { get; set; } // en %
    public bool EstProtege { get; set; } // présence d'une serre, d'un filet, etc.
    public List<Plante> PlantesCultivees { get; set; }

    public Terrain (string nom, float surface, string typeSol, float humidite, float luminosite, bool estProtege) // constructeur
    {
        Nom = nom;
        Surface = surface;
        TypeSol = typeSol;
        Humidite = humidite;
        Luminosite = luminosite;
        EstProtege = estProtege;
        PlantesCultivees = new List<Plante> ();
    }

    public virtual bool PeutAccueillir(Plante plante)
    {
        return plante.EspaceNecessaire <= SurfaceLibre();
    }

    public float SurfaceLibre()
    {
        float occupee = 0;
        foreach (var pante in PlantesCultivees)
        {
            occupee += PlantesCultivees.EspaceNecessaire;
        }
        return Surface - occupee;
    }

    public void AjouterPlante (Plante plante)
    {
        if (PeutAccueillir(plante))
        {
            PlantesCultivees.Add(plante);
            Console.WriteLine($"Plante {plante.Nom} ajoutée au terrain {Nom}.");
        }
        else Console.WriteLine($"Pas assez de place pour planter {plante.Nom} sur le terrain {Nom}.");
    }

    public override string ToString()
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
            foreach (var plante in PlantesCultivees)
            {
                resultat += $" -{plante} \n";
            }
        }
        return resultat;
    }
}