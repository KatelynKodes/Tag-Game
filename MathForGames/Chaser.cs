using System;
using System.Collections.Generic;
using System.Text;
using Raylib_cs;
using MathLibrary;

namespace MathForGames
{
    class Chaser: Actor
    {
        private float _speed;
        private Vector2 _velocity;
        private Actor _chasee;

        public float Speed
        {
            get { return _speed; }
            set { _speed = value; }
        }

        public Vector2 Velocity
        {
            get { return _velocity; }
            set { _velocity = value; }
        }

        public Chaser(char icon, float x, float y, float speed, Color IconColor, string name, Actor Chasee) : 
            base(icon, x, y, IconColor, name)
        {
            _speed = speed;
            _chasee = Chasee;
        }

        /// <summary>
        /// Updates the chasers movement every frame 
        /// </summary>
        /// <param name="deltaTime"></param>
        public override void Update(float deltaTime)
        {
            //Finds the intended direction
            Vector2 IntendedDirection = _chasee.GetPosition - this.GetPosition;

            //Normalizes the intended direction and multiplies it by speed and time
            Velocity = IntendedDirection.Normalized * Speed * deltaTime;

            //Adds the velocity to the position
            this.GetPosition += Velocity;
        }


    }
}
