using Godot;

namespace BurtTree
{
    public abstract partial class BehaviourNode : Node
    {
        public abstract NodeState Execute();
    }
}
