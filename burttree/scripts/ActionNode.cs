using Godot;

namespace BurtTree
{
    [Icon("res://addons/burttree/icons/node-action.png")]
    public partial class ActionNode : BehaviourNode
    {
        public override NodeState Execute()
        {
            // Run Action function since it can be overriden by non-abstract classes
            // since that is required for godot to allow placing nodes in the scene tree.
            return Action();
        }

        public virtual NodeState Action()
        {
            // Return Failure if derived class doesn't override this method.
            return NodeState.Failure;
        }
    }
}
