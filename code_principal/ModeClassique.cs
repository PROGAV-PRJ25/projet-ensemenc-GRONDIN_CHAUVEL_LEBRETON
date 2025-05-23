// public class ModeClassique : Mode
// {
//     private Random ramdom = new Random();

//     public override void LancerPartie(Terrain terrain)
//     {
//         Console.WriteLine("== Mode Classique ==");
        


//         // 3 actions après avoir planté les plantes 

//         for (int i = 0; i < 3; i++)
//         {
//             Console.WriteLine("\n Choisissez une action : 1.Arroser 2. Soigner 3.Exposer");
//             ConsoleKey clic = Console.ReadKey().Key;
//             Console.WriteLine();

//             switch (clic)
//             {
//                 case ConsoleKey.D1 :
//                     plante.ArroserPlantes();
//                     break;
//                 case ConsoleKey.D2 :
//                     plante.Soigner();
//                     break;
//                 case ConsoleKey.D3 :
//                     plante.ExposerAuSoleil()
//                     break;
//                 default:
//                     Console.WriteLine("Action invalide");
//                     break;
//             }
//         }
//     }
// }