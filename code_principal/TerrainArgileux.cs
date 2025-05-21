public class TerrainArgileux : Terrain
{
    public TerrainArgileux () : base("Terrain argileux", 225f, "Printemps", "Argileux", 70f, 3f, 60f, 18f, false, 15, 15)
                            {
                                TypeSol = "Argileux";
                            }

    public override void MiseAJour()
    {
        base.MiseAJour();
        if (Humidite<50)
        {
            Humidite += 5;
        }
    }
}