﻿Tomate tomate = new Tomate();
Console.WriteLine("=== Test de la plante Tomate ===");
Console.WriteLine(tomate); // appelle ToString

tomate.ExposerAuSoleil(); // hérité de Plante
tomate.Fertiliser();      // hérité de Plante

Console.WriteLine("Après soleil et fertilisation :");
Console.WriteLine(tomate);

// tester une méthode propre à Plante
tomate.ArroserPlantes();
tomate.MettreAJourCroissance();
tomate.AfficherJauge();

 Console.WriteLine("=== Fin du test ===");