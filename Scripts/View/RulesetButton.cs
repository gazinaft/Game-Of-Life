using Godot;
using System;

public class RulesetButton : OptionButton
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        AddItem("Sequential", 0);
        AddItem("ParallelFor", 1);
        AddItem("ParallelPool", 2);
        AddItem("ParallelThread", 3);
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
