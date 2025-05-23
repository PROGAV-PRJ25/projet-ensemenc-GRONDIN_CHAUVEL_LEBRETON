public class Brebis : BonneFee
{
    private Terrain terrain;

    public Brebis(Terrain terrain) : base("Brebis rose", "Mange 2 mauvaises herbes", 1)
    {
        this.terrain = terrain;
    }

    public override void AiderPotager()
    {
        int mauvaisesHerbesMangees = 0;

        for (int i = terrain.PlantesCultivees.Count - 1; i >= 0 && mauvaisesHerbesMangees < 2; i--)
        {
            if (terrain.PlantesCultivees[i] is MauvaiseHerbe mh)
            {
                // Retirer la mauvaise herbe de la matrice T
                terrain.T[mh.PositionX, mh.PositionY] = 0;

                // Retirer de la liste des plantes
                terrain.PlantesCultivees.RemoveAt(i);

                mauvaisesHerbesMangees++;
                Console.WriteLine($"🐑 La brebis a mangé une mauvaise herbe !");
            }
        }

        if (mauvaisesHerbesMangees == 0)
        {
            Console.WriteLine("🐑 Il n'y avait pas de mauvaises herbes à manger.");
        }
        else if (mauvaisesHerbesMangees < 2)
        {
            Console.WriteLine("🐑 Il n’y avait qu’une seule mauvaise herbe à manger.");
        }
        else
        {
            Console.WriteLine("🐑 La brebis a mangé deux mauvaises herbes !");
        }
    }
}