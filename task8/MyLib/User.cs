namespace MyLib
{
    [TrackingEntity()]
    public class User
    {
        [TrackingProperty("name")]
        public string _name;
        [TrackingProperty("")]
        public int _age;

        [TrackingProperty("nnn")]
        public string Name { get; set; }

        [TrackingProperty("age")]
        public int Age { get; set; }

        public User()
        {

        }

        public User(string name, int age)
        {
            this._name = name;
            this._age = age;
        }
    }
}
