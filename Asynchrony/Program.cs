// See https://aka.ms/new-console-template for more information

using Asynchrony;

// when starts the program c# create the main thread that contains all this code bellow
/*
// this create new thread in parallel of main thread
Thread thread = new(() =>
{
    Thread.Sleep(1000);
    Console.WriteLine("Ejecutando en otro hilo");
});

// start the thread we created
thread.Start();

// rest of code is ejecuted in parallel with othres thres that started
Console.WriteLine("Ejecutando en el hilo principal");

// up to here there are only two threads ^^^^^
*/

/*
Threads t1 = new();

t1.Main();

Console.WriteLine("What's happened here?");
*/

/*
var task = new Task(() =>
{
    Thread.Sleep(1000);
    Console.WriteLine("empezando tarea interna");
});

task.Start();

await task;

Console.WriteLine("He terminado la tarea");
*/

var t = new Tasks();
var ts = t.getTask();

ts.Start();

await t.InitTask();

Console.WriteLine("Termine de trabajar");