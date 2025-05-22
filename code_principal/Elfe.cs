public class Elfe : BonneFee
{
    public Elfe() : base("PetitElfe", "Plante des fleurs en état final", 1) { }
    public void Action()
    {
        Terrain.AjouterPlante()
    }
}
