public abstract class Obstacle 
{
    public string Nom { get; set; }
    public string Type { get; set; } // "animal", "intempérie", "maladie", etc.
    public bool AffecteTerrain { get; set; }
    public string Effet { get; set; }
    public int DureeTours { get; set; }
    public Terrain Univers { get; set; }
    protected static Random rnd = new Random();

    public Obstacle(string nom, string type, string effet, int dureeTours,
                    bool affectePlantes = false, bool affecteTerrain = false)
    {
        Nom = nom;
        Type = type;
        Effet = effet;
        DureeTours = dureeTours;
        AffecteTerrain = affecteTerrain;
    }

    public void DefinirUnivers(Terrain terrain)
    {
        Univers = terrain;
    }

    public abstract void Action();

    public override string ToString()
    {
        return $"{Nom} ({Type}) - Effet : {Effet}, Durée : {DureeTours} tour(s)";
    }
}
