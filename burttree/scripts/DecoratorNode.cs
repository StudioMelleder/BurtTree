using Godot;

namespace BurtTree
{
    [Icon("res://addons/burttree/icons/node-decorator.png")]
    public abstract partial class DecoratorNode : BehaviourNode
    {
        protected BehaviourNode Child;

        public override void _Ready()
        {
            if (GetChildCount() > 0 && GetChild(0) is BehaviourNode childNode)
            {
                Child = childNode;
            }
        }
    }
}
