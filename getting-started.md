---
# Getting Started with BurtTree

An overview of how to use BurtTree and all of it's Built-In Nodes.

---

## System Overview

The BurtTree plugin is composed of various node types that can be combined to create complex behaviors for game AI.

### Node States
Node States are defined as an enum called NodeState and has three different values that correspond to the result of an executed node.

- `NodeState.Running`: Signifies that the node is still running and therefore keeps executing every frame until it returns Success and then the tree keeps traversing.
- `NodeState.Success`: Signifies that the node successfully executed.
- `NodeState.Failure`: Signifies that the node failed its execution. 

### Core Node Types

- **BurtTree**: The base node of a behaviour tree. Can only have one child that will be automatically designated as root and executed when scene is ready.
  
- **BurtTreeActionNode**: Represents a single action (e.g., attacking player, moving to a location). Needs to be extended with C# code to actually perform any actions.
  This node type can not have any children and as such represents a leaf node in the behaviour tree.
  
- **CompositeNode**: Manages and executes multiple child nodes.
   - `BurtTreeSequenceNode`: Executes each child in order until one fails.
     
   - `BurtTreeSelectorNode`: Executes each child until one succeeds.
    
- **DecoratorNode**: Manages or modifies a single child node's behavior.
   - `BurtTreeInverterNode`: Executes child node and inverts it's NodeState (e.g., If node returns Success the Inverter will return Failure)
     
   - `BurtTreeRepeaterNode`: Executes child node a specified amount of times.

---

## Example of extending ActionNode

`ActionNode` is the base class for creating actions. You create custom action nodes by inheriting from `ActionNode` and implementing the `Action()` method. 
To create a action node in your tree simply add a BurtTreeActionNode and attach a custom script with the afformentioned inheritance and overrides.

**Example: `PrintHello` Action Node**

```csharp
using Godot;
using BurtTree;

public partial class PrintHello : ActionNode
{
    public override NodeState Action()
    {
        GD.Print("Hello");
        return NodeState.Success
    }
}
```

In this example, `PrintHello` will print "Hello" to Godot's output console and return `NodeState.Success`, signifing that the action was completed successfully.

## Building a Behavior Tree

### Creating a Tree in Godot

1. **Add the `BurtTree` node to your scene.**
2. **Attach composite, action, or decorator nodes** as children of `BurtTree` to build the tree structure. As previously stated the BurtTree node itself must only have one child node that acts as the entry point.

Here’s a simple tree setup in the Godot Scene tree:

```
BehaviourTree (BurtTree)
└── Sequence (BurtTreeNode)
    ├── Action (BurtTreeActionNode) (Extended with custom script)
    └── Repeater (BurtTreeRepeaterNode)
        └── AnotherAction (BurtTreeActionNode) (Extended with custom script)
```

## Examples

### Composite Node Usage

This example uses `BurtTreeSequenceNode` to run two actions sequentially. If the first succeeds, the second runs; if either fails, the sequence fails.

#### Scene Tree Structure

```
Behaviour Tree (BurtTree)
└── Sequence (BurtTreeSequenceNode)
    ├── PrintHello (BurtTreeActionNode) (Extended with custom script)
    └── SomeOtherActionNode (BurtTreeActionNode) (Extended with custom script)
```

### Repeater Decorator Example

To repeat an action node 5 times, use `BurtTreeRepeaterNode` as a parent and set `Max Repeats` in the inspector to 5. (A value of -1 will repeat infinitely)

#### Scene Tree Structure

```
Behaviour Tree (BurtTree)
└── Repeater (BurtTreeRepeaterNode)
    └── PrintHello (BurtTreeActionNode) (Extended with custom script)
```

This configuration will repeat `PrintHello` 5 times. When `PrintHello` has successfully been executed 5 times, the tree will continue to traverse down to the subsequent nodes.

---
