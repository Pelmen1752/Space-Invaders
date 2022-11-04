namespace Space_Invaders
{
    internal class PointsCounter
    {
        private Settings settings;
        public int Points { get; set; }
        public int NumberOfDownedAlliens { get; set; }
        public int RemainingGroundObjects { get; set; }

        private PointsCounter(Settings settings)
        {
            this.settings = settings;
            Points = 0;
            NumberOfDownedAlliens = 0;
            RemainingGroundObjects = settings.GroundRow*settings.GroundColumn;
        }

        public static PointsCounter GetPointsCounter(Settings settings)
        {
            return new PointsCounter(settings);
        }
    }
}
