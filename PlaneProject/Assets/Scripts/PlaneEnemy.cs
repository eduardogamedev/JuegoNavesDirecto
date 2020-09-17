using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneEnemy : Enemy
{
    [SerializeField]
    private UnityStandardAssets.Utility.WaypointCircuit waypointCircuit;
    [SerializeField]
    private float speed = 100f;
    [SerializeField]
    private float speedRotation = 15f;
    [SerializeField]
    private float rotationAngle = 15f;

    private Transform[] wayPoints;
    private int idWayPoints = 0;
    private Transform destination;

    private Quaternion targetRotation;

    // Start is called before the first frame update
    void Start()
    {
        wayPoints = waypointCircuit.Waypoints;
        GenerateDestination();

        targetRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position,destination.position,
        speed*Time.deltaTime);
        float distance = Vector3.Distance(transform.position,destination.position);

        Quaternion rotation = Quaternion.LookRotation(destination.position - transform.position);
        //float yRotationDirection = (Quaternion.Inverse(targetRotation) * transform.rotation).eulerAngles.y;

        Vector3 targetDir = destination.position - transform.position;
        Vector3 forward = transform.forward;
        
        float angle = Vector3.Angle(targetDir, forward);
        rotation = rotation* Quaternion.Euler(Vector3.forward*angle);

        transform.rotation = Quaternion.Slerp(transform.rotation,rotation,Time.deltaTime*speedRotation);
        
        //Debug.Log(Vector3.Distance(transform.position,destination.position));
        if(distance<=0.5f){
            GenerateDestination();
        }
 
        if(targetRotation != transform.rotation){
            targetRotation = transform.rotation;
        }
    }

    private void GenerateDestination(){
        destination = wayPoints[idWayPoints];
        idWayPoints++;
        if(idWayPoints >= wayPoints.Length){
            idWayPoints = 0;
        }
    }
    
}
