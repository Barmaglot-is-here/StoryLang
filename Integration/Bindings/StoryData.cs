namespace StorySystem.Integration
{
    public abstract class StoryData
    {
        public string this[string key] => Get(key);
        protected abstract string Get(string key);
    }
}