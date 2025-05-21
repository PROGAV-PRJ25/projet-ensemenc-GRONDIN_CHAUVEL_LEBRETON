public class Tomate : Legume
{
    public Tomate () : base("Tomate", "Ete", TypePlante.Legume, "Argileux", 30f, 25f, 7, 60, 6) {}
    public override int EtatFinal()
    {
        return 12;
    }
    public override string ToString()
{
    return $"{Nom} - Tomate (Croissance : {Croissance}%, Santé : {Sante})";
}
}