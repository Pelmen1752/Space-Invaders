namespace Space_Invaders
{
    internal class Settings
    {
        public int Width { get; set; } = 80;
        public int Height { get; set; } = 30;

        public int AlienShipRow { get; set; } = 2;
        public int AlienShipColumn { get; set; } = 60;

        public int AliensStartCoordinateX { get; set; } = 10;
        public int AliensStartCoordinateY { get; set; } = 2;
        public char AlienFigure { get; set; } = 'M';
        public int AlienSpeed { get; set; } = 20;

        public int PlayerStartCoordinateX { get; set; } = 40;
        public int PlayerStartCoordinateY { get; set; } = 19;
        public char PlayerFigure { get; set; } = 'W';

        public int GroundStartCoordinateX { get; set; } = 1;
        public int GroundStartCoordinateY { get; set; } = 20;
        public char GroundFigure { get; set; } = '-';
        public int GroundRow { get; set; } = 1;
        public int GroundColumn { get; set; } = 80;

        public char PlayerMissileFigure { get; set; } = '|';
        public int MissileSpeed { get; set; } = 5;
        public char AllienMissileFigure { get; set; } = 'o';
        public int AllienMissileFrequency { get; set; } = 30;
        public int GameSpeed { get; set; } = 100;
    }
}
