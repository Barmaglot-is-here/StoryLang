using StorySystem.Lang.Lexer;
using StorySystem.Lang.Parser;
using StorySystem.Lang;
using System.IO;

namespace StorySystem.Integration
{
    public class StoryLoader
    {
        private readonly Parser _parser;
        private readonly Interpritator _interpritator;

        private string _currentFolder;

        public StoryLoader(StoryActions actions, StoryConditions conditions, StoryData data)
        {
            _parser         = new();
            _interpritator  = new(actions, conditions, data);
        }

        public StoryBlockData Load(string file)
        {
            _currentFolder = Path.GetDirectoryName(file);

            var src     = File.ReadAllText(file);
            var lexems  = Lexer.Process(src);

            var syntaxTree  = _parser.Parse(lexems);

            return _interpritator.Interpritate(syntaxTree);
        }

        public StoryBlockData Next(ChoiceData choice)
        {
            string path = Path.Combine(_currentFolder, choice.NextBlockPath 
                                                     + Config.FILE_EXTENSION);
            
            return Load(path);
        }
    }
}