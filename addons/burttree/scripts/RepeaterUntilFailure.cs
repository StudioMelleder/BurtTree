using Godot;
using System;

namespace BurtTree
{
    [Icon("res://addons/burttree/icons/node-repeater.png")]
    public partial class RepeaterUntilFailure : DecoratorNode
    {
        [Export] public int MaxRepeats { get; set; } = -1;

        private int _repeatCount = 0;

        public override NodeState Execute()
        {
            if (Child == null)
            {
                GD.PrintErr("RepeaterUntilFailure must have a child node.");
                return NodeState.Failure;
            }

            NodeState result = Child.Execute();

            if (result == NodeState.Failure)
                return NodeState.Success;

            if (result == NodeState.Success)
            {
                _repeatCount++;

                if (MaxRepeats > 0 && _repeatCount >= MaxRepeats)
                {
                    _repeatCount = 0;
                    return result;
                }
                else
                {
                    return NodeState.Running;
                }
            }
            return NodeState.Running;
        }
    }
}
