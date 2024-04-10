using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asynchrony
{
    internal class Tasks
    {
        public Tasks() { }
        public async Task InitTask()
        {
            await Task.Run(() => 
            {
                Thread.Sleep(1000);
                Console.WriteLine("Empenzado la tarea");
            });
        }

        public Task getTask()
        {
            return new Task(() => 
            {
                Console.WriteLine("www");
            });
        }
    }
}
