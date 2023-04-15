using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public NavMeshAgent agent;
    public float rotateVelocity;
    public float rotateSpeedMovement = 0.1f;


    void Start()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
    }

     void Update()
    {
        Move();

    }
    public void Move()
    {
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            // when you right click the mouse this will move the player
            if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity))
            {
                if (hit.collider.CompareTag("Ground"))
                {
                    //when clicked the player will go to where the mouse clicked
                    agent.SetDestination(hit.point);
                    agent.stoppingDistance = 0;

                    //for faster rotation speed
                    Quaternion rotation =Quaternion.LookRotation(hit.point - transform.position);
                    float rotationY = Mathf.SmoothDampAngle(transform.eulerAngles.y,rotation.eulerAngles.y,
                        ref rotateVelocity,rotateSpeedMovement * (Time.deltaTime*5));

                    transform.eulerAngles = new Vector3(0,rotationY,0); 
                }
            }
        }
    }
}