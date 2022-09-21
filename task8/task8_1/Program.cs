using MyLib;

namespace task8_1
{
    class Program
    {
        static void Main(string[] args)
        {
            User user = new User("iliaz", 20);
            user.Age = 28;
            user.Name = "NNN";
            Logger log = new Logger("file.json");
            log.Track(user);
        }
    }
}
