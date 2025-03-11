#if TOOLS
using Godot;
using System.Collections.Generic;

[Tool]
public partial class BurtTreePlugin : EditorPlugin
{
	List<string> registeredTypesList = new List<string>();

	public override void _EnterTree()
	{
		var registerCustomType = (string name, string script, string icon) =>
		{
			AddCustomType(
				name, "Node",
				GD.Load<Script>($"res://addons/burttree/scripts/{script}.cs"),
				GD.Load<Texture2D>($"res://addons/burttree/icons/{icon}.png")
			);
			registeredTypesList.Add(name);
		};

		registerCustomType("BurtTree", "Tree", "node-tree");
		registerCustomType("BurtTreeActionNode", "ActionNode", "node-action");
		registerCustomType("BurtTreeSelectorNode", "Selector", "node-selector");
		registerCustomType("BurtTreeSequenceNode", "Sequence", "node-sequence");
		registerCustomType("BurtTreeInverterNode", "Inverter", "node-inverter");
		registerCustomType("BurtTreeRepeaterNode", "Repeater", "node-repeater");
		registerCustomType("BurtTreeRepeaterUntilFailureNode", "RepeaterUntilFailure", "node-repeater");
	}

	public override void _ExitTree()
	{
		foreach (var name in registeredTypesList)
			RemoveCustomType(name);
	}
}
#endif
