// See https://aka.ms/new-console-template for more information

using POO;

/* 4 pillars in POO: Inheritance, Polymorphism, Abstraction, Encapsulation */

/* INHERITANCE - Encapsulation */

Person person = new("Gonzalo", 21, new DateOnly(2002, 10, 3), "Manco Garcia");
Employee employee = new Employee("Indra", 1300, "Gonzalo", 21, new DateOnly(2002, 10, 3), "Manco Garcia");

Console.WriteLine(person);
Console.WriteLine(employee);

/* POLYMORPHISM - Abstraction */
// Animal animal = new(); // -> Abstraction
Animal pig = new Pig();
Animal dog = new Dog();

// Console.WriteLine(animal.MakeSound());
Console.WriteLine(pig.MakeSound());
Console.WriteLine(dog.MakeSound());

/* NOW WITH INTERFACES  */

IAnimal cat =  new Cat();
IAnimal cow = new Cow();

Console.WriteLine(cat.MakeSound());
Console.WriteLine(cow.MakeSound());