using System.Collections.Generic;

namespace StorySystem.Integration
{
    public struct StoryBlockData
    {
        public string Text { get; internal set; }
        public Queue<ChoiceData> Choices { get; internal set; }
    }
}