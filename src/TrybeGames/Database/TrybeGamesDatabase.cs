namespace TrybeGames;

public class TrybeGamesDatabase
{
    public List<Game> Games = new List<Game>();

    public List<GameStudio> GameStudios = new List<GameStudio>();

    public List<Player> Players = new List<Player>();

    // 4. Crie a funcionalidade de buscar jogos desenvolvidos por um estúdio de jogos
    public List<Game> GetGamesDevelopedBy(GameStudio gameStudio)
    {
        // implementar
        var getGames = from game in Games
                       where game.DeveloperStudio == gameStudio.Id
                       select game;

        return getGames.ToList();
        // throw new NotImplementedException();
    }

    // 5. Crie a funcionalidade de buscar jogos jogados por uma pessoa jogadora
    public List<Game> GetGamesPlayedBy(Player player)
    {
        // Implementar
        var getGames = from game in Games
                       from gamePlayer in game.Players
                       where gamePlayer == player.Id
                       select game;

        return getGames.ToList();
        // throw new NotImplementedException();  
    }

    // 6. Crie a funcionalidade de buscar jogos comprados por uma pessoa jogadora
    public List<Game> GetGamesOwnedBy(Player playerEntry)
    {
        // Implementar 
        var getGames = from game in Games
                       from gameOwned in playerEntry.GamesOwned
                       where game.Id == gameOwned
                       select game;

        return getGames.ToList();
        // throw new NotImplementedException();
    }


    // 7. Crie a funcionalidade de buscar todos os jogos junto do nome do estúdio desenvolvedor
    public List<GameWithStudio> GetGamesWithStudio()
    {
        // Implementar
        var gameList = from game in Games
                       from studio in GameStudios
                       where game.DeveloperStudio == studio.Id
                       select new GameWithStudio
                       {
                           GameName = game.Name,
                           StudioName = studio.Name,
                           NumberOfPlayers = game.Players.Count(),
                       };

        return gameList.ToList();
        // throw new NotImplementedException();
    }

    // 8. Crie a funcionalidade de buscar todos os diferentes Tipos de jogos dentre os jogos cadastrados
    public List<GameType> GetGameTypes()
    {
        // Implementar
        var typeList = from game in Games
                       group game by game.GameType into gameTypes
                       select gameTypes.Key;

        return typeList.ToList();
        // throw new NotImplementedException();
    }

    // 9. Crie a funcionalidade de buscar todos os estúdios de jogos junto dos seus jogos desenvolvidos com suas pessoas jogadoras
    public List<StudioGamesPlayers> GetStudiosWithGamesAndPlayers()
    {
        // Implementar
        var gamesByStudio = (from studio in GameStudios
                             select new StudioGamesPlayers
                             {
                                 GameStudioName = studio.Name,
                                 Games = (from game in Games
                                          where game.DeveloperStudio == studio.Id
                                          select new GamePlayer
                                          {
                                              GameName = game.Name,
                                              Players = (from idPlayer in game.Players
                                                         join player in Players
                                                         on idPlayer equals player.Id
                                                         select player).ToList()
                                          }).ToList()
                             }).ToList();

        return gamesByStudio;

        // throw new NotImplementedException();
    }

}
