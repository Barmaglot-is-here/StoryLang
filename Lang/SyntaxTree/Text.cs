﻿namespace StorySystem.Lang.SyntaxTree
{
    internal class Text : ISyntaxCounstruction
    {
        public string Content { get; set; }
        public bool IsInsertion { get; set; }
    }
}