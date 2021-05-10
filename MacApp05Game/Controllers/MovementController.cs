﻿using MacApp05Game.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace MacApp05Game.Controllers
{
    public class MovementController
    {
        public InputKeys InputKeys { get; set; }
        
        public MovementController()
        {
            InputKeys = new InputKeys()
            {
                // For directions

                Up = Keys.Up,
                Down = Keys.Down,
                Left = Keys.A,
                Right = Keys.D,

                // Rotate and Move

                TurnLeft = Keys.Left,
                TurnRight = Keys.Right,
                Forward = Keys.Up,

            };
        }

        public Vector2 ChangeDirection(KeyboardState keyState)
        {
            Vector2 Direction = Vector2.Zero;

            if (keyState.IsKeyDown(InputKeys.Right))
            {
                Direction = new Vector2(1, 0);
            }

            if (keyState.IsKeyDown(InputKeys.Left))
            {
                Direction = new Vector2(-1, 0);
            }

            if (keyState.IsKeyDown(InputKeys.Up))
            {
                Direction = new Vector2(0, -1);
            }

            if (keyState.IsKeyDown(InputKeys.Down))
            {
                Direction = new Vector2(0, 1);
            }

            return Direction;
        }

    }
}
