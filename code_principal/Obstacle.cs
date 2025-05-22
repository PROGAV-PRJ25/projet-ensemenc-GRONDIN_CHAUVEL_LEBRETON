public abstract class Obstacle 
{
    public string Nom { get; set; }
    public string Type { get; set; } // "animal", "intempérie", "maladie", etc.
    public bool AffectePlantes { get; set; }
    public bool AffecteTerrain { get; set; }
    public string Effet { get; set; }
    public float Gravite { get; set; } // de 0 à 1
    public int DureeTours { get; set; }
    public Terrain Univers { get; set; }
    protected static Random rnd = new Random();

    public Obstacle(string nom, string type, string effet, float gravite, int dureeTours,
                    bool affectePlantes = false, bool affecteTerrain = false)
    {
        Nom = nom;
        Type = type;
        Effet = effet;
        Gravite = gravite;
        DureeTours = dureeTours;
        AffectePlantes = affectePlantes;
        AffecteTerrain = affecteTerrain;
    }

    public void DefinirUnivers(Terrain terrain)
    {
        Univers = terrain;
    }

    public void AffecterPlantes()
    {
        if (!AffectePlantes) return;

        foreach (var plante in Univers.PlantesCultivees)
        {
            if (rnd.NextDouble() <= Gravite)
            {
                AppliquerEffetSurPlante(plante);
            }
        }
    }

    // À définir dans les classes dérivées (ex: Maladie, Intemperie, etc.)
    public abstract void AppliquerEffetSurPlante(Plante plante);

    public abstract void Action();

    public override string ToString()
    {
        return $"{Nom} ({Type}) - Effet : {Effet}, Gravité : {Gravite * 100}%, Durée : {DureeTours} tour(s)";
    }
}
