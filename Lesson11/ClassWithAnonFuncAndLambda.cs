using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson11
{
    internal class ClassWithAnonFuncAndLambda
    {
        public EventHandler<int> AnonymousFunction { get; private set; }
        public EventHandler<int> LambdaFunction { get; private set; }

        public ClassWithAnonFuncAndLambda()
        {
            AnonymousFunction =
            delegate (object? alarm, int time)
            {
                Console.WriteLine($"Anonymous function was called on time: {time}");
            };
            LambdaFunction = (alarm, time) => Console.WriteLine($"Lambda function was called on time: {time}");

        }
    }
}
