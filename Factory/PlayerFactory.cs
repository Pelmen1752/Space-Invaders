namespace Space_Invaders
{
    internal class PlayerFactory : GameObjectFactory
    {
        public PlayerFactory(Settings settings) : base(settings)
        {

        }
        public override GameObject CreateGameObject(Coordinate coordinate)
        {
            return new Ground() { Figure = Settings.PlayerFigure, Coordinate = coordinate };
        }
    }
}
