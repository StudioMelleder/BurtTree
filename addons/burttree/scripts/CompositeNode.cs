using Godot;
using System.Collections.Generic;

namespace BurtTree
{
    [Icon("res://addons/burttree/icons/node-composite.png")]
    public abstract partial class CompositeNode : BehaviourNode
    {
        protected List<BehaviourNode> Children = new();
        private BehaviourNode _runningChild = null;

        public override void _Ready()
        {
            foreach (Node child in GetChildren())
            {
                if (child is BehaviourNode behaviourNode)
                    Children.Add(behaviourNode);
            }
        }

        public override NodeState Execute()
        {
            if (_runningChild != null)
            {
                NodeState result = _runningChild.Execute();
                if (result != NodeState.Running)
                {
                    _runningChild = null;
                }
                return result;
            }
            foreach (BehaviourNode child in Children)
            {
                NodeState result = child.Execute();
                if (result == NodeState.Running)
                {
                    _runningChild = child;
                    return NodeState.Running;
                }
                else if (result == NodeState.Success)
                {
                    return NodeState.Success;
                }
            }
            return NodeState.Failure;
        }
    }
}
