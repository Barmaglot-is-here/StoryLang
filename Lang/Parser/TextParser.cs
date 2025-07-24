using StorySystem.Lang.Lexer;
using StorySystem.Lang.SyntaxTree;
using System;

namespace StorySystem.Lang.Parser
{
    internal partial class Parser
    {
        private Text ParseText(bool isInsertion = false)
        {
            Text text = new();

            text.Content        = CurrentLexem.Content;
            text.IsInsertion    = isInsertion;

            return text;
        }

        private Text ParseInsertion()
        {
            Skip(1); //Skip insertion begin lexem

            Text insertion = ParseText(true);

            if (Next().Type != LexemType.InsertionEnd)
                throw new Exception(CurrentLexem.Type.ToString());

            return insertion;
        }
    }
}