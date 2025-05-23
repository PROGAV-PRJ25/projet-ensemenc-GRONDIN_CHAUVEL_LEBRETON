Fraise F1 = new Fraise();
TerrainArgileux T1 = new TerrainArgileux();
T1.AjouterPlante(F1);
T1.AfficherT();
ModeUrgence M1 = new ModeUrgence(T1);
M1.DeclencherAttaqueDragon();
Console.WriteLine(M1);
