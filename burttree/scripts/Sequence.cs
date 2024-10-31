using Godot;

namespace BurtTree
{
    [Icon("res://addons/burttree/icons/node-sequence.png")]
    public partial class Sequence : CompositeNode
    {
        private int _currentChildIndex = 0;

        public override NodeState Execute()
        {
            while (_currentChildIndex < Children.Count)
            {
                NodeState result = Children[_currentChildIndex].Execute();
                switch (result)
                {
                    case NodeState.Success:
                        _currentChildIndex++;
                        break;
                    case NodeState.Failure:
                        _currentChildIndex = 0;
                        return NodeState.Failure;
                    case NodeState.Running:
                        return NodeState.Running;
                }
            }
            _currentChildIndex = 0;
            return NodeState.Success;
        }
    }
}
