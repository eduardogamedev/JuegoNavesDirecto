using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneEnemy : Enemy
{

    public UnityStandardAssets.Utility.WaypointCircuit waypointCircuit;
    public float speed = 100f;
    public float speedRotation = 15f;

    private Transform[] wayPoints;
    private List<Transform> wayPointsList = new List<Transform>();
    private Transform destination;

    // Start is called before the first frame update
    void Start()
    {
        wayPoints = waypointCircuit.Waypoints;
        GenerateDestination();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position,destination.position,
        speed*Time.deltaTime);

        Quaternion rotation = Quaternion.LookRotation(destination.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation,rotation,Time.deltaTime*speedRotation);
        //Vector3 direction = (destination.position - transform.position).normalized;
        

        //Debug.Log(Vector3.Distance(transform.position,destination.position));
        if(Vector3.Distance(transform.position,destination.position)<=0.5f){
            GenerateDestination();
        }
    }

    private void GenerateDestination(){
        if(wayPointsList.Count==0){
            wayPointsList.AddRange(wayPoints);
        }
        int id = Random.Range(0,wayPointsList.Count);
        destination = wayPointsList[id];
        wayPointsList.RemoveAt(id);
    }
    
}
