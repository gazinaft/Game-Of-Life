using Godot;
using System;
using System.Collections.Generic;
using System.ComponentModel;

public class GCell : Node2D
{
    private Dictionary<int, Color> _colorMap = new Dictionary<int, Color>
        {
            { 0, Color.ColorN("White") },
            { 1, Color.ColorN("Black") }
        };
    
    private Color _color;

    private Vector2 _size;
    
    public int CellState { get; set; }

    public GCell(Vector2 size, int state)
    {
        _size = size;
        CellState = state;
    }
    
    public override void _Ready()
    {
        _color = Color.Color8(0, 0, 0);
    }

    public override void _Draw()
    {
        DrawRect(new Rect2(Position, _size), _colorMap[CellState]);
    }

    //  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
