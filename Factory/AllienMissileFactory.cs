namespace Space_Invaders
{
    internal class AllienMissileFactory : GameObjectFactory
    {
        public AllienMissileFactory(Settings settings) : base(settings)
        {

        }
        public override GameObject CreateGameObject(Coordinate coordinate)
        {
            return new AllienMissile() { Figure = Settings.AllienMissileFigure, Coordinate = coordinate};
        }
    }
}
