public class ModeClassique : IModeJeu
{
    public void Executer(Jeu jeu)
    {
        Console.Clear();
        Console.WriteLine($"============ TOUR {jeu.Tour} (Mode Classique) ============");
        Console.WriteLine($"Saison: {jeu.DeterminerSaison()}");

        // Mise à jour de la météo et des conditions du terrain
        jeu.TerrainActuel.MiseAJour();

        // Afficher le terrain
        jeu.TerrainActuel.AfficherT(jeu.TerrainActuel.TerrainVisuel);

        // Mettre à jour les plantes
        jeu.MettreAJourPlantes();

        // Mettre à jour les obstacles et bonnes fées actifs
        jeu.MettreAJourObstacles();
        jeu.MettreAJourBonnesFees();

        // Menu d'actions
        while (jeu.ActionsRestantes > 0 && jeu.JeuEnCours)
        {
            AfficherMenu(jeu);
            int choix = jeu.LireChoixUtilisateur(0, 9);
            TraiterChoixUtilisateur(jeu, choix);
        }
    }

    public void AfficherMenu(Jeu jeu)
    {
        Console.WriteLine($"\nActions restantes pour ce tour: {jeu.ActionsRestantes}");
        Console.WriteLine("Que souhaitez-vous faire ?");
        Console.WriteLine("1. Planter une semence");
        Console.WriteLine("2. Arroser une plante");
        Console.WriteLine("3. Désherber le terrain");
        Console.WriteLine("4. Fertiliser une plante");
        Console.WriteLine("5. Tailler une plante");
        Console.WriteLine("6. Exposer une plante au soleil");
        Console.WriteLine("7. Récolter une plante");
        Console.WriteLine("8. Afficher des informations détaillées");
        Console.WriteLine("9. Quitter la partie");
        Console.WriteLine("0. Passer au tour suivant");
        Console.Write("Votre choix: ");
    }

    public void TraiterChoixUtilisateur(Jeu jeu, int choix)
    {
        switch (choix)
        {
            case 0:
                Console.WriteLine("Vous passez au tour suivant.");
                jeu.ActionsRestantes = 0;
                break;
            case 1:
                jeu.PlanteSemence();
                break;
            case 2:
                jeu.ArroserPlante();
                break;
            case 3:
                jeu.Desherber();
                break;
            case 4:
                jeu.FertiliserPlante();
                break;
            case 5:
                jeu.TaillerPlante();
                break;
            case 6:
                jeu.ExposerPlante();
                break;
            case 7:
                jeu.RecolterPlante();
                break;
            case 8:
                jeu.AfficherInfosDetaillees();
                break;
            case 9:
                if (jeu.ConfirmerAction("Êtes-vous sûr de vouloir quitter la partie ? (O/N): "))
                {
                    jeu.JeuEnCours = false;
                    Console.WriteLine("Merci d'avoir joué !");
                }
                break;
        }
    }
}