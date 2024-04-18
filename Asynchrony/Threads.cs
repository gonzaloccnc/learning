using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asynchrony
{
  internal class Threads
  {
    public Threads() { }

    public void Main()
    {
      Console.WriteLine("Executing on the main thread of threads");

      this.ThreadOne();

      Console.WriteLine("Executing again on the main thread of threads");
    }

    public void ThreadOne()
    {
      Thread thread = new(() =>
      {
        Console.WriteLine("Ejecutando fuera del hilo del metodo ThreadOne");
      });

      thread.Start();

      Console.WriteLine("Ejecutando en el hilo del metodo ThreadOne");

    }
  }
}
