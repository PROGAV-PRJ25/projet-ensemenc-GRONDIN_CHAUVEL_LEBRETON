Console.OutputEncoding = System.Text.Encoding.UTF8;

TerrainArgileux t1 = new TerrainArgileux();


Fraise tomatoo = new Fraise();
t1.AjouterPlante(tomatoo);

MauvaiseHerbe mh = new MauvaiseHerbe();
t1.AjouterPlante(mh);

Brebis bew = new Brebis(t1);
bew.AiderPotager();

t1.AfficherT();