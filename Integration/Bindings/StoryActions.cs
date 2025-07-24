namespace StorySystem.Integration
{
    public abstract class StoryActions : Invokable
    {
        public new void Invoke(string function, string[] args) 
            => base.Invoke(function, args);
    }
}