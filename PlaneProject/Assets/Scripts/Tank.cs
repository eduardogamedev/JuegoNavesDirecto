using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Tank : Enemy
{
    [SerializeField]
    private PathList pathList;
    [SerializeField]
    private float dectectionDistanceMax = 10;
    [SerializeField]
    private float dectectionDistanceMin = 10;
    [Header("TANK")]
    [SerializeField]
    private Transform Part;
    [SerializeField]
    private Transform VerticalRotateCanion;
    [SerializeField]
    private Transform canion;
    [SerializeField]
    private float angleMinLimit = -90;
    [SerializeField]
    private float angleMaxLimit = 60;
    [SerializeField]
    private float speedRotation = 10;
    

    private Transform currentPath;
    private NavMeshAgent agent;
    private List<Transform> listPath = new List<Transform>();
    

    private void Start()
    {
        currentPath = SelectPath();
        agent = GetComponent<NavMeshAgent>();
        listPath.AddRange(pathList.paths);
        player = GameObject.FindGameObjectWithTag("Player");
    }


    private void Update()
    {
        if (life > 0)
        {
            if (Vector3.Distance(player.transform.position, transform.position) <= dectectionDistanceMax &&
                Vector3.Distance(player.transform.position, transform.position) >= dectectionDistanceMin)
            {
                agent.isStopped = true;

                TankLookAt(player.transform.position);
                Shoot();
            }
            else
            {
                agent.isStopped = false;
                if (currentPath != null)
                {
                    agent.SetDestination(currentPath.position);
                    if (Vector3.Distance(transform.position, currentPath.position) <= 6)
                    {
                        currentPath = SelectPath();
                    }
                    TankLookAt(currentPath.transform.position);
                }
                else
                {
                    currentPath = SelectPath();
                }
            }
        }
        else
        {
            Dead();
        }
        
    }

    

    private void TankLookAt(Vector3 position)
    {
        /*Part.LookAt(new Vector3(position.x, Part.position.y, position.z));
        canion.LookAt(new Vector3(canion.position.x, position.y, position.z));*/

        
        Utils.SlowLookAt(speedRotation, Part, position,Utils.Axys.y);
        Utils.SlowLookAt(speedRotation, canion, position,Utils.Axys.x);

        Vector3 eulerCanionAngles = canion.localEulerAngles;
        eulerCanionAngles.x = Mathf.Clamp(eulerCanionAngles.x, angleMinLimit, angleMaxLimit);
        eulerCanionAngles.y= 0.0f;
        eulerCanionAngles.z = 0.0f;
        canion.localEulerAngles = eulerCanionAngles;
    }

    private Transform SelectPath()
    {
        Transform trSelected = null;
        if (listPath.Count.Equals(0))
        {
            listPath.AddRange(pathList.paths);
            trSelected = SelectPath();
        }
        else
        {
            int posList = UnityEngine.Random.Range(0, listPath.Count);
            trSelected = listPath[posList];
            listPath.RemoveAt(posList);
        }


        return trSelected;
    }

    private float DistancePlayerTank()
    {
        Vector3 vectorTank = new Vector3(transform.position.x,0,transform.position.z);
        Vector3 vectorPlayer = new Vector3(player.transform.position.x, 0, player.transform.position.z);
        return Vector3.Distance(vectorPlayer,vectorTank);
    }
   
}
