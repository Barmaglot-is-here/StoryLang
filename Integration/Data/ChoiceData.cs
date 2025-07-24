namespace StorySystem.Integration
{
    public struct ChoiceData
    {
        public string Text { get; }
        public string[] Attributes { get; }
        internal string NextBlockPath { get; }

        internal ChoiceData(string text, string[] attributes, string next)
        {
            Text        = text;
            Attributes  = attributes;
            NextBlockPath        = next;
        }
    }
}