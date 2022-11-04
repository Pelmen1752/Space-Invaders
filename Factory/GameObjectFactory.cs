namespace Space_Invaders
{
    abstract class GameObjectFactory
    {
        public Settings Settings { get; set; }

        public abstract GameObject CreateGameObject(Coordinate coordinate);
        public GameObjectFactory(Settings settings)
        {
            Settings = settings;
        }
    }
}
