Console.OutputEncoding = System.Text.Encoding.UTF8;

TerrainArgileux t1 = new TerrainArgileux();
t1.InitialiserT();


Fraise f1 = new Fraise();
t1.AjouterPlante(f1);

Elfe Youpi = new Elfe(t1);
Youpi.Action();

t1.AfficherT();
