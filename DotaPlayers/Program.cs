namespace DotaPlayers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DotaPlayer nikita = new DotaPlayer(new NikitaLikesPlayer());

            nikita.FPS();
            nikita.GameStatus();

            DotaPlayer palet = new DotaPlayer(new PaletLikesPlayer());

            palet.FPS();
            palet.GameStatus();

            Console.Beep();
            Console.ReadKey();
        }

        public interface IGameStatus
        {
            public void ShowGameStatus();
        }

        public interface IFPS
        {
            public void ShowFPS();
        }

        class Looser : IGameStatus
        {
            public void ShowGameStatus()
            {
                Console.WriteLine("Dire`s victory");
            }
        }

        class Winner : IGameStatus
        {
            public void ShowGameStatus()
            {
                Console.WriteLine("Radiant`s victory");
            }
        }

        class LowFPS : IFPS
        {
            public void ShowFPS()
            {
                Console.WriteLine("30 FPS");
            }
        }

        class HighFPS : IFPS
        {
            public void ShowFPS()
            {
                Console.WriteLine("***** (mnogo) FPS");
            }
        }

        public interface IDotaPlayerFactory
        {
            public IFPS CreateFPS();
            public IGameStatus CreateGameStatus();
        }

        class NikitaLikesPlayer : IDotaPlayerFactory
        {
            public IFPS CreateFPS()
            {
                return new HighFPS();
            }

            public IGameStatus CreateGameStatus()
            {
                return new Looser();
            }
        }

        class PaletLikesPlayer : IDotaPlayerFactory
        {
            public IFPS CreateFPS()
            {
                return new LowFPS();
            }

            public IGameStatus CreateGameStatus()
            {
                return new Winner();
            }
        }

        public class DotaPlayer
        {
            private IFPS _FPS;
            private IGameStatus _GameStatus;

            public DotaPlayer(IDotaPlayerFactory dotaPlayerFactory)
            {
                _FPS = dotaPlayerFactory.CreateFPS();
                _GameStatus = dotaPlayerFactory.CreateGameStatus();
            }

            public void FPS()
            {
                _FPS.ShowFPS();
            }

            public void GameStatus()
            {
                _GameStatus.ShowGameStatus();
            }
        }
    }
}
