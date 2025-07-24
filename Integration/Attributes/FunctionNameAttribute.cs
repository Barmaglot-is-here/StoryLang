using System;

namespace StorySystem.Integration
{
    [AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = true)]
    public class FunctionNameAttribute : Attribute
    {
        public string Name { get; }

        public FunctionNameAttribute(string name)
        {
            Name = name;
        }
    }
}