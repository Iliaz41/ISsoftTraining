namespace task8_2
{
    class Foo
    {
        private int _data;
        private double _info;
        private string _name;

        public int Data
        {
            get => _data;
            set
            {
                _data = value;
            }
        }

        public double Info
        {
            get => _info;
            set
            {
                _info = value;
            }
        }

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
            }
        }

        public Foo()
        {

        }
    }
}
