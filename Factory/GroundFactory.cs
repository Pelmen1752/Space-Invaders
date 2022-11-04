using System.Collections.Generic;

namespace Space_Invaders
{
    internal class GroundFactory : GameObjectFactory
    {
        public GroundFactory(Settings settings) : base(settings)
        {

        }
        public override GameObject CreateGameObject(Coordinate coordinate)
        {
            return new Ground() { Figure = Settings.GroundFigure, Coordinate = coordinate };
        }
        public List<GameObject> CreateGround()
        {
            List<GameObject> ground = new List<GameObject>();
            for (int y = 0; y < Settings.GroundRow; y++)
            {
                for (int x = 0; x < Settings.GroundColumn; x++)
                {
                    GameObject groundElem = CreateGameObject(new Coordinate() { X = Settings.GroundStartCoordinateX + x, Y = Settings.GroundStartCoordinateY + y });
                    ground.Add(groundElem);
                }
            }
            return ground;
        }
    }
}
