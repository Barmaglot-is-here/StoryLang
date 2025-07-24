namespace StorySystem.Lang.SyntaxTree
{
    internal class ConditionalBlock : Block
    {
        public Condition Condition { get; set; }
        public Block Alt { get; set; }
    }
}