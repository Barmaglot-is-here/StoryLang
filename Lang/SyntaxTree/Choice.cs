namespace StorySystem.Lang.SyntaxTree
{
    internal class Choice : ISyntaxCounstruction
    {
        public string Text { get; set; }
        public string Next { get; set; }
        public Block InternalBlock { get; set; }
    }
}