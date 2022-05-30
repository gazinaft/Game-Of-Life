using Godot;
using System;
using GameOfLife.Scripts.Model;

public class GBoard : Node2D
{
    private CA _ca;
    private const int size = 0;
    private IRuleset _rules;
    public override void _Ready()
    {
        _ca = new CA(new int[size,size]{}, new SequentialRuleset());
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
