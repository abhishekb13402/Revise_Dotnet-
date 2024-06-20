using System;

namespace BasicPracticeOf_C_Sharp.OOP
{
    public class OOP_Animal
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public OOP_Animal(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public virtual void MakeSound()
        {
            Console.WriteLine("Animal makes a sound");
        }
    }

    public class Dog : OOP_Animal
    {
        public string Breed { get; set; }

        public Dog(string name, int age, string breed) : base(name, age)
        {
            Breed = breed;
        }

        public override void MakeSound()
        {
            Console.WriteLine("Dog barks");
        }
        public void WhichBreed()
        {
            Console.WriteLine($"Dog Breed is:{Breed}");
        }
    }
    public class Cat : OOP_Animal
    {
        public bool IsLazy { get; set; }

        public Cat(string name, int age, bool isLazy) : base(name, age)
        {
            IsLazy = isLazy;
        }

        public override void MakeSound()
        {
            Console.WriteLine("Cat meows");
        }
        public void IsItLazy()
        {
            Console.WriteLine($"Cat is: {IsLazy}");
        }
    }

}
