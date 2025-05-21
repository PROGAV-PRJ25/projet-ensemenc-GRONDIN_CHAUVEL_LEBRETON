public class ModeClassique : ModeJeu
{
    public ModeClassique(Terrain terrain) : base(terrain){}
    public override void LancerTour()
    {
        Console.WriteLine("\n -- Mode Classique -- \n");

        // 1. Mise à jour du terrain (croissance des plantes, météo, humidité)
        terrain.MiseAJour();

        // 2. Affichage du terrain
        terrain.AfficherTerrainVisuel(terrain.TerrainVisuel);

        // 3. Pause entre les tours pour lisibilité
        System.Threading.Thread.Sleep(1000);
    }
}