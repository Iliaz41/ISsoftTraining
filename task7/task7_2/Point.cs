namespace task7_2
{
    public class Point
    {
        private string name;
        private double x;
        private double y;
        private double distance;

        public double Distance
        {
            get { return distance; }
            set { distance = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public double X
        {
            get { return x; }
            set { x = value; }
        }

        public double Y
        {
            get { return y; }
            set { y = value; }
        }

        public Point(string name, double x, double y)
        {
            this.name = name;
            this.x = x;
            this.y = y;
        }

        public override string ToString()
        {
            return "name = " + name + " x = " + x + " y = " + y;
        }
    }
}
