using System;

Practical practical = new Practical("no description(", "https://www.google.by/", "https://yandex.by/");
Lecture lecture1 = new Lecture("good lecture", "Abstract classes");
Lecture lecture2 = new Lecture("one more good lecture", "Class Object");
Classes[] array = { practical, lecture1 };
Training training = new Training("interesting training", array);
Console.WriteLine(training.ToString());
Console.WriteLine("Adding a new item: ");
training.Add(lecture2);
Console.WriteLine(training.ToString());
Console.WriteLine("Does the training contain only practical classes? " + training.IsPractical());
Console.WriteLine("Let's clone this training! Our new training:\n" + training.Clone().ToString());