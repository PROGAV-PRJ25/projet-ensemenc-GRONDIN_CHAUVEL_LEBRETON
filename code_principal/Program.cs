Console.OutputEncoding = System.Text.Encoding.UTF8;

TerrainArgileux t1 = new TerrainArgileux();
t1.InitialiserT();

for (int i = 0; i < 3; i++)
{
    Fraise f1 = new Fraise();
    t1.AjouterPlante(f1);

    Elfe Youpi = new Elfe(t1);
    Youpi.AiderPotager();

    PoussiereDeFee magique = new PoussiereDeFee(t1);
    magique.AiderPotager();

}

t1.AfficherT();