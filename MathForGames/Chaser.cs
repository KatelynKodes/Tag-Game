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
        private Vector2 _forwardDir = new Vector2(1,0);

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

        public Vector2 ForwardDir
        {
            get { return _forwardDir; }
            set { _forwardDir = value; }
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

            if (GetTargetInSight())
            {
                //Adds the velocity to the position
                this.GetPosition += Velocity;
            }
        }

        /// <summary>
        /// Checks whether target is in range
        /// </summary>
        /// <returns> bool depending on if the targets dotproduct is less than 0 and if the distance between the chaser is
        /// less than or equal to a specified distance</returns>
        public bool GetTargetInSight()
        {
            Vector2 TargetDir = (_chasee.GetPosition - this.GetPosition).Normalized;
            float Angle = MathF.Acos(Vector2.DotProduct(TargetDir, ForwardDir));
            float Distance = Vector2.Distance(GetPosition, _chasee.GetPosition);
            return Vector2.DotProduct(TargetDir, ForwardDir) > 0 && Angle < 1 && Distance <= 150f;
        }

    }
}
