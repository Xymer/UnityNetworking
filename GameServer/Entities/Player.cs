using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using GameServer.Users;


namespace GameServer.Entities
{
    class Player
    {
        public User user;
        public int id;
        public string username;
        public Vector3 position;
        private Vector3 positionToGoTo;
        public Quaternion rotation;

        private float moveSpeed = 5f / Constants.TICKS_PER_SEC;
        bool[] inputs = new bool[5];
        public bool isMoving = false;

        public Player(int id, string username, Vector3 spawnPosition)
        {
            this.id = id;
            this.username = username;
            position = spawnPosition;
            positionToGoTo = spawnPosition;
            rotation = Quaternion.Identity;
        }

        public void Update()
        {
            
            if (inputs[0])
            {

            }
            if (inputs[1])
            {

            }
            if (inputs[2])
            {

            }
            if (inputs[3])
            {

            }
            if (inputs[4])
            {
                isMoving = true;
            }
            if (isMoving)
            {
            Move(positionToGoTo);
                if (Vector3.Distance(position,positionToGoTo) < 0.05f)
                {
                    isMoving = !isMoving;
                }
            }
        }

        private void Move(Vector3 positionToGoTo)
        {
            Vector3 forward = Vector3.Transform(new Vector3(0, 0, 1), rotation);
            Vector3 right = Vector3.Normalize(Vector3.Cross(forward, new Vector3(0, 1, 0)));
            Vector3 direction = Vector3.Normalize(positionToGoTo - position);
            Vector3 movePosition = position + (direction * moveSpeed);
            position = movePosition;

            ServerSend.PlayerPosition(this);
            ServerSend.PlayerRotation(this);
        }
        internal void SetInput(bool[] input, Quaternion rotation)
        {
            inputs = input;
            //positionToGoTo = position;
            this.rotation = rotation;
        }
        internal void SetInput(bool[] input, Vector3 positionToGoTo, Quaternion rotation)
        {
            inputs = input;
            this.positionToGoTo = positionToGoTo;
            this.rotation = rotation;
        }
    }
}
