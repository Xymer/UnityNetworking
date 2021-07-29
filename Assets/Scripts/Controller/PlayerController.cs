using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] LayerMask clickableMask;
    [SerializeField] NavMeshAgent playerAgent = null;
    [SerializeField] Camera playerCamera = null;

    private BoxCollider collider = null;
    private void Awake()
    {
        if (!playerAgent)
        {
            playerAgent = GetComponent<NavMeshAgent>();
        }
        if (!playerCamera)
        {
            playerCamera = GetComponentInChildren<Camera>();
        }
        if (!collider)
        {
            collider = GetComponentInChildren<BoxCollider>();
        }
    }
    private void FixedUpdate()
    {
        SendInputToServer();
    }

    private void SendInputToServer()
    {
        bool[] inputs = new bool[]
        {
            Input.GetKey(KeyCode.Q),
            Input.GetKey(KeyCode.W),
            Input.GetKey(KeyCode.E),
            Input.GetKey(KeyCode.R),
            Input.GetMouseButton(0),
        };
        if (inputs[4])
        {
            Ray mouseClickRay = playerCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit mouseClickHit;
            if (Physics.Raycast(mouseClickRay, out mouseClickHit, 100,clickableMask))
            {
                Vector3 positionToGoTo = mouseClickHit.point;   
                
                ClientSend.PlayerMovement(inputs, positionToGoTo);
            }
        }
        else
        {
            ClientSend.PlayerMovement(inputs);
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Obstacle"))
        {
        ClientSend.StopMoving();
        }
    }
}
