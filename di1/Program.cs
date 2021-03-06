﻿using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

//NuGet'ten Browse->valuetuple--->System.ValueTuple by Microsoft install

namespace DotNetDesignPatternDemos.SOLID.DependencyInversionPrinciple
{
    // high level modules should not depend on low-level; both should depend on abstractions
    // abstractions should not depend on details; details should depend on abstractions
    // sen abstraction'ini yap, detaylar ona uygun yapilsin

    public enum Relationship
    {
        Parent,
        Child,
        Sibling
    }

    public class Person
    {
        public string Name;
        // public DateTime DateOfBirth;
    }

    public class Relationships // low-level
    {
        private List<(Person, Relationship, Person)> relations
          = new List<(Person, Relationship, Person)>();

        public void AddParentAndChild(Person parent, Person child)
        {
            relations.Add((parent, Relationship.Parent, child));
            relations.Add((child, Relationship.Child, parent));
        }

        // inlines  return relations...
        public List<(Person, Relationship, Person)> Relations => relations;
    }

    public class Research
    {
        public Research(Relationships relationships)
        {
            // Problem:Accesing very low level part of Relationships class, accessing it's data stores, 
            // through a specific definition (private member is defines as public member)

            // high-level: find all of john's children
            var relations = relationships.Relations;
            foreach (var r in relations
              .Where(x => x.Item1.Name == "John"
                          && x.Item2 == Relationship.Parent))
            {
                WriteLine($"John has a child called {r.Item3.Name}");
            }
        }

        static void Main(string[] args)
        {
            var parent = new Person { Name = "John" };
            var child1 = new Person { Name = "Chris" };
            var child2 = new Person { Name = "Matt" };

            // low-level module
            var relationships = new Relationships();
            relationships.AddParentAndChild(parent, child1);
            relationships.AddParentAndChild(parent, child2);

            new Research(relationships);

        }
    }
}
