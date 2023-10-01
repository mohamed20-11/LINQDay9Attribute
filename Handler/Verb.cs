
using System;
public class Verb  : Attribute
{
    public string Name { get; set; }
    public Verb(string name)
    {
        this.Name = name;
    }
}