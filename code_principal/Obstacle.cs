public abstract class Obstacle
{
    public string Nom { get; set; }
    public string Type { get; set; } // "animal", "intempérie", "maladie", etc.
    public string Effet { get; set; }
    public int DureeTours { get; set; }
    protected static Random rnd = new Random();

    public Obstacle(string nom, string type, string effet, int dureeTours)
    {
        Nom = nom;
        Type = type;
        Effet = effet;
        DureeTours = dureeTours;

    }

    public abstract void Action(Plante plante);

    public override string ToString()
    {
        return $"{Nom} ({Type}) - Effet : {Effet}, Durée : {DureeTours} tour(s)";
    }
}