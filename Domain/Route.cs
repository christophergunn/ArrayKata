namespace Domain
{
    public class Route
    {
        public Point[] Points;

        public string Origin;
        public string Destination;

        public double Distance;

        public Route(string origin, string desination, Point[] points)
        {
            Origin = origin;
            Destination = desination;
            Points = points;
        }

    }
}
