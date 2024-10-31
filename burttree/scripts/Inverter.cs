using Godot;

namespace BurtTree
{
    [Icon("res://addons/burttree/icons/node-inverter.png")]
    public partial class Inverter : DecoratorNode
    {
        public override NodeState Execute()
        {
            if (Child == null)
                return NodeState.Failure;

            NodeState result = Child.Execute();

            switch (result)
            {
                case NodeState.Success:
                    return NodeState.Failure;
                case NodeState.Failure:
                    return NodeState.Success;
                default:
                    return NodeState.Running;
            }
        }
    }
}
