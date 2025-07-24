using StorySystem.Lang.SyntaxTree;
using StorySystem.Integration;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StorySystem.Lang
{
    internal class Interpritator
    {
        private readonly StoryActions _actions;
        private readonly StoryConditions _conditions;
        private readonly StoryData _gameData;

        public Interpritator(StoryActions actions, StoryConditions conditions, StoryData data)
        {
            _actions    = actions;
            _conditions = conditions;
            _gameData   = data;
        }

        public StoryBlockData Interpritate(TreeRoot syntaxTree)
        {
            StoryBlockData storyBlock   = new();
            storyBlock.Choices          = new();
            storyBlock.Text             = "";

            Interpritate(syntaxTree, ref storyBlock);

            return storyBlock;
        }

        private void Interpritate(TreeRoot syntaxTree, ref StoryBlockData storyBlock)
        {
            foreach (var syntaxConstruction in syntaxTree)
            {
                switch (syntaxConstruction)
                {
                    case ConditionalBlock block:
                        if (CheckCondition(block.Condition))
                            Interpritate(block, ref storyBlock);
                        else if (block.Alt != null)
                            Interpritate(block.Alt, ref storyBlock);

                        break;
                    case Block block:
                        Interpritate(block, ref storyBlock);

                        break;
                    case Text text:
                        if (text.IsInsertion)
                            text.Content = _gameData[text.Content];

                        storyBlock.Text += text.Content;

                        break;
                    case Choice choice:
                        ChoiceData dataChoice = new(choice.Text, new string[0], choice.Next);
                        storyBlock.Choices.Enqueue(dataChoice);

                        if (choice.InternalBlock != null)
                            Interpritate(choice.InternalBlock, ref storyBlock);

                        break;
                    case Function action:
                        _actions.Invoke(action.Name, action.Args);

                        break;
                    default:
                        throw new NotImplementedException(syntaxConstruction.GetType().Name);
                }
            }
        }

        private bool CheckCondition(Condition condition)
        {
            bool result;

            if (condition.Function != null)
                result = _conditions.Check(condition.Function.Name, condition.Function.Args);
            else
                result = CheckConditionGroup(condition);

            if (condition.InvertResult)
                result = !result;

            return result;
        }

        private bool CheckConditionGroup(IEnumerable<Condition> group)
        {
            var groupConditions = group.ToArray();
            bool groupResult    = CheckCondition(groupConditions[0]);
            
            int i = 0;
            while (groupConditions[i].Postfix != ConditionPostfix.None)
            {
                bool next = CheckCondition(groupConditions[++i]);

                groupResult = groupConditions[i].Postfix switch
                {
                    ConditionPostfix.And            => groupResult &= next,
                    ConditionPostfix.Or             => groupResult |= next,
                    ConditionPostfix.ExcludingOr    => groupResult ^= next,
                    _ => throw new NotImplementedException()
                };
            }

            return groupResult;
        }
    }
}