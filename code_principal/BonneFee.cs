public abstract class BonneFee 
{
    public string Nom { get; set; }
    public string Effet { get; set; }
    public int DureeTours { get; set; }
    protected static Random rnd = new Random();

    public BonneFee(string nom, string effet, int dureeTours)
    {
        Nom = nom;
        Effet = effet;
        DureeTours = dureeTours;
    }


    // À définir dans les classes dérivées (ex: Maladie, Intemperie, etc.)

    public abstract void AiderPotager();

    public override string ToString()
    {
        return $"{Nom} - Effet : {Effet}, Durée : {DureeTours} tour(s)";
    }
}
