namespace Lesson11
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Alarm alarm = new Alarm(300);
            Console.WriteLine($"Speed is {alarm.SpeedPerSecond / 1000.0} per 1 second");

            Person person = new Person("John", "Hi");
            MessagePrinter printer = new MessagePrinter();
            ClassWithAnonFuncAndLambda anlClass = new ClassWithAnonFuncAndLambda();

            alarm.SubscribeOnTime(person, 4);
            alarm.Subscribe(printer);
            alarm.Subscribe(anlClass.AnonymousFunction);
            alarm.Subscribe(anlClass.LambdaFunction);

            foreach (int i in new int[] { 2, 8, 16 })
            {
                alarm.RegisterTimepoint(i);
            }

            alarm.BeginClock();
        }
    }
}