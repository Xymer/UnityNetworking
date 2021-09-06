using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
   // public User user;
    public int id;
    public string username;
    private Vector3 positionToGoTo;
 

    private float moveSpeed = 5f / Constants.TICKS_PER_SEC;
    bool[] inputs = new bool[5];
    public bool isMoving = false;

    public void Initialize(int id, string username)
    {
        this.id = id;
        this.username = username;
    }

    public void FixedUpdate()
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
            if (Vector3.Distance(transform.position, positionToGoTo) < 0.05f)
            {
                isMoving = !isMoving;
            }
        }
    }

    private void Move(Vector3 positionToGoTo)
    {
        Vector3 direction = Vector3.Normalize(positionToGoTo - transform.position);
        Vector3 movePosition = transform.position + (direction * moveSpeed);
        transform.position = movePosition;

        ServerSend.PlayerPosition(this);
        ServerSend.PlayerRotation(this);
    }
    internal void SetInput(bool[] input, Quaternion rotation)
    {
        inputs = input;
        //positionToGoTo = position;
      
    }
    internal void SetInput(bool[] input, Vector3 positionToGoTo, Quaternion rotation)
    {
        inputs = input;
        this.positionToGoTo = positionToGoTo;
        
    }
}
