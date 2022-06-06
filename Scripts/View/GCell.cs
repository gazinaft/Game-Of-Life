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
    
    private int gridX;
    private int gridY;
    
    private Vector2 _size;
    
    public int CellState { get; set; }

    public GCell(Vector2 size, int state, int x, int y)
    {
        _size = size;
        CellState = state;
        gridX = x;
        gridY = y;
    }

    public GCell()
    {
        _size = new Vector2(10, 10);
        CellState = 0;
        Position = new Vector2(10, 10);
    }
    
    public override void _Ready()
    { }

    public override void _Draw()
    {
        DrawRect(new Rect2(Vector2.Zero, _size), _colorMap[CellState]);
    }

    // public override void _UnhandledInput(InputEvent @event)
    // {
    //     if (@event is InputEventMouseButton mbEvent)
    //     {
    //         if (mbEvent.ButtonIndex == (int)ButtonList.Left && mbEvent.Pressed)
    //         {
    //             var lx = GlobalPosition.x;
    //             var ly = GlobalPosition.y;
    //             var mx = mbEvent.GlobalPosition.x;
    //             var my = mbEvent.GlobalPosition.y;
    //             var tx = lx + _size.x;
    //             var ty = ly + _size.y;
    //             if (lx < mx && ly < my && mx < tx && my < ty)
    //             {
    //                 CellState = CellState == 0 ? 1 : 0;
    //                 EmitSignal(nameof(UpdateCell), gridX, gridY, CellState);
    //                 Update();
    //             }
    //         }
    //     }
    // }

    //  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
