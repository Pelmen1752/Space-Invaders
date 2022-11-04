namespace Space_Invaders
{
    internal class PlayersMissileFactory : GameObjectFactory
    {
        public PlayersMissileFactory(Settings settings) : base(settings)
        {

        }
        public override GameObject CreateGameObject(Coordinate coordinate)
        {
            return new PlayerMissile() { Figure = Settings.PlayerMissileFigure, Coordinate = coordinate };
        }
    }
}
