﻿namespace StorySystem.Lang.SyntaxTree
{
    internal class Function : ISyntaxCounstruction
    {
        public string Name { get; set; }
        public string[] Args { get; set; }
    }
}