using Godot;

namespace BurtTree
{
    [Icon("res://addons/burttree/icons/node-tree.png")]
    public partial class Tree : Node
    {
        private BehaviourNode _root;
        private NodeState _lastState = NodeState.Failure;

        public override void _Ready()
        {
            _root = GetChild(0) as BehaviourNode;
        }

        public override void _Process(double delta)
        {
            if (_root == null)
                return;

            _lastState = _root.Execute();
        }
    }
}
