using Godot;
using System;
using System.Threading;
using GameOfLife.Scripts.Model;
using System.Collections.Generic;

public class GBoard : Node2D
{
    private CA _ca;
    [Export] public int BoardX { get; set; }
    [Export] public int BoardY { get; set; }
    [Export] public int TileSize { get; set; }
    [Export] public int TileGap { get; set; }
    private GCell[,] cells;
    public bool IsPaused = true;
    public int GenerationsPerTick = 1;
    private IRuleset _rules;
    public override void _Ready()
    {
        _ca = new CA(new int[BoardX,BoardY], new SequentialRuleset());
        var tileSizeVector = new Vector2(TileSize, TileSize);
        cells = new GCell[BoardX, BoardY];
        for (int i = 0; i < BoardX; ++i)
        {
            for (int j = 0; j < BoardY; j++)
            {
                var cell = new GCell(tileSizeVector, 0, i, j);
                cell.Position = new Vector2(i * (TileSize + TileGap) + TileGap, j * (TileSize + TileGap) + TileGap);
                cells[i, j] = cell;
                AddChild(cell);
            }
        }
    }

    private void UpdateBoard(int steps)
    {
        _ca.MakeNSteps(steps);
        for (int i = 0; i < BoardX; i++)
        {
            for (int j = 0; j < BoardY; j++)
            {
                cells[i, j].CellState = _ca.Cells[i, j];
                cells[i, j].Update();
            }
        }
    }
    
    public override void _UnhandledInput(InputEvent @event)
    {
        if (@event is InputEventMouseButton mbEvent)
        {
            if (mbEvent.ButtonIndex == (int)ButtonList.Left && mbEvent.Pressed)
            {
                var startX = GlobalPosition.x;
                var startY = GlobalPosition.y;
                var mx = mbEvent.GlobalPosition.x;
                var my = mbEvent.GlobalPosition.y;
                var relativeX = mx - startX - TileGap;
                var relativeY = my - startY - TileGap;
                var x = (int) relativeX / (TileGap + TileSize);
                var y = (int) relativeY / (TileGap + TileSize);
                if (x > BoardX || y > BoardY) return;
                {
                    var cell = cells[x, y];
                    var c = cell.CellState == 0 ? 1 : 0;
                    cell.CellState = c;
                    _ca.Cells[x, y] = c;
                    GD.Print(_ca.Cells[x, y]);
                    cell.Update();
                }
            }
        }
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
    [Export] public float GAnimationTime = 0.5f;
    private float _animTimer = 0f;
    public override void _Process(float delta)
    {
      if (IsPaused) return;
      if (GAnimationTime < delta)
      {
          GD.Print("Can't handle animation rate at " + GAnimationTime +
                   " seconds per frame, " + GenerationsPerTick + " generations per tick and rules " +
                   _ca.Rules.GetType());
      }
      if (_animTimer <= 0f)
      {
          UpdateBoard(GenerationsPerTick);
          _animTimer = GAnimationTime;
          return;
      }
      _animTimer -= delta;
    }

    public void PauseGBoard()
    {
        IsPaused = !IsPaused;
    }

    public void SetGenerations(float gens)
    {
        GenerationsPerTick = (int)gens;
    }

    public void SetInterval(float interval)
    {
        GAnimationTime = interval;
    }

    private Dictionary<int, IRuleset> _rulesets = new Dictionary<int, IRuleset>()
    {
        {0, new SequentialRuleset()},
        {1, new ParallelForRuleset()},
        {2, new ParallelThreadPoolRuleset()},
        {3, new ParallelThreadRuleset()}
    };

    public void SetRuleset(int rulesetIndex)
    {
        _ca.Rules = _rulesets[rulesetIndex];
    }
}
