using Godot;

namespace BurtTree
{
    [Icon("res://addons/burttree/icons/node-selector.png")]
    public partial class Selector : CompositeNode
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
                        _currentChildIndex = 0;
                        return NodeState.Success;
                    case NodeState.Running:
                        return NodeState.Running;
                    case NodeState.Failure:
                        _currentChildIndex++;
                        break;
                }
            }
            _currentChildIndex = 0;
            return NodeState.Failure;
        }
    }
}
