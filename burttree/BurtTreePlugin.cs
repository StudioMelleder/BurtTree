#if TOOLS
using Godot;

[Tool]
public partial class BurtTreePlugin : EditorPlugin
{
    public override void _EnterTree()
    {
        // Tree Node
        Texture2D treeIcon = GD.Load<Texture2D>("res://addons/burttree/icons/node-tree.png");
        Script treeScript = GD.Load<Script>("res://addons/burttree/scripts/Tree.cs");
        AddCustomType("BurtTree", "Node", treeScript, treeIcon);

        // Action Node
        Texture2D actionIcon = GD.Load<Texture2D>("res://addons/burttree/icons/node-action.png");
        Script actionScript = GD.Load<Script>("res://addons/burttree/scripts/ActionNode.cs");
        AddCustomType("BurtTreeActionNode", "Node", actionScript, actionIcon);

        // Selector Node
        Texture2D selectorIcon = GD.Load<Texture2D>("res://addons/burttree/icons/node-selector.png");
        Script selectorScript = GD.Load<Script>("res://addons/burttree/scripts/Selector.cs");
        AddCustomType("BurtTreeSelectorNode", "Node", selectorScript, selectorIcon);

        // Sequence Node
        Texture2D sequenceIcon = GD.Load<Texture2D>("res://addons/burttree/icons/node-sequence.png");
        Script sequenceScript = GD.Load<Script>("res://addons/burttree/scripts/Sequence.cs");
        AddCustomType("BurtTreeSequenceNode", "Node", sequenceScript, sequenceIcon);

        // Inverter Node
        Texture2D inverterIcon = GD.Load<Texture2D>("res://addons/burttree/icons/node-inverter.png");
        Script inverterScript = GD.Load<Script>("res://addons/burttree/scripts/Inverter.cs");
        AddCustomType("BurtTreeInverterNode", "Node", inverterScript, inverterIcon);

        // Repeater Node
        Texture2D repeaterIcon = GD.Load<Texture2D>("res://addons/burttree/icons/node-repeater.png");
        Script repeaterScript = GD.Load<Script>("res://addons/burttree/scripts/Repeater.cs");
        AddCustomType("BurtTreeRepeaterNode", "Node", repeaterScript, repeaterIcon);
    }

    public override void _ExitTree()
    {
        RemoveCustomType("BurtTree");
        RemoveCustomType("Action");
        RemoveCustomType("Selector");
        RemoveCustomType("Sequence");
        RemoveCustomType("Inverter");
        RemoveCustomType("Repeater");
    }
}
#endif
