using System.Collections.Generic;

namespace Space_Invaders
{
    internal class AllienShipFactory : GameObjectFactory
    {
        public AllienShipFactory(Settings settings) : base(settings)
        {

        }
        public override GameObject CreateGameObject(Coordinate coordinate)
        {
            return new AllienShip() { Figure = Settings.AlienFigure, Coordinate = coordinate };
        }
        public List<GameObject> CreateAllienShips()
        {
            List<GameObject> ships = new List<GameObject>();
            for (int y = 0; y < Settings.AlienShipRow; y++)
            {
                for (int x = 0; x < Settings.AlienShipColumn; x++)
                {
                    GameObject ship = CreateGameObject(new Coordinate() { X = Settings.AliensStartCoordinateX + x, Y = Settings.AliensStartCoordinateY + y });
                    ships.Add(ship);
                }
            }
            return ships;
        }
    }
}
