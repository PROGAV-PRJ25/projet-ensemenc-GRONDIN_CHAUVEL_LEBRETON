public class TerrainArgileux : Terrain
{
    public override string DescriptionTerrain => "Terrain argileux, riche en nutriments mais drainant mal.";

    public TerrainArgileux () : base("Terrain argileux", 225f, "Printemps", "Argileux", 70f, 60f, 18f, false, 15, 15)
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