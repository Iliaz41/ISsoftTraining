namespace task7_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Helper helper = new Helper();
            helper.ReadFile();
            helper.ShowAverageDuration();
            helper.ShowAverageEmployeeDuration();
            helper.SaveJson();
        }
    }
}
