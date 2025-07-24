namespace StorySystem.Lang.Lexer
{
    internal struct Lexem
    {
        public string Content { get; set; }
        public LexemType Type { get; set; }

        public Lexem(string content, LexemType type)
        {
            Content = content;
            Type    = type;
        }
    }
}