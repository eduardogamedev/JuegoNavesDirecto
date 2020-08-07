using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils 
{
    public enum Axys { x,y,z}


    public static void EnableColliders(Collider[] colliders,bool enabled)
    {
        foreach(Collider collider in colliders)
        {
            collider.enabled = enabled;
        }
    }

    public static void EnableMeshes(MeshRenderer[] meshes, bool enabled)
    {
        foreach (MeshRenderer mesh in meshes)
        {
            mesh.enabled = enabled;
        }
    }

    internal static void SlowLookAt(object speedRotation, object part, object position, Axys y)
    {
        throw new NotImplementedException();
    }

    internal static void InstantiateParticle(GameObject particle,Vector3 normal,Vector3 point,Transform parent)
    {
        Quaternion rotation = Quaternion.FromToRotation(Vector3.forward, normal);
        point.z -= 0.001f;
        GameObject particleClone = GameObject.Instantiate(particle, point, rotation);
        particleClone.transform.localScale = Vector3.one;
        particleClone.transform.parent = parent;
    }

    public static void InstantiateBullet(GameObject bulletPrefab, Transform bulletPos,
        float forceBullet,float timeToDestroy,Vector3 direction)
    {
        Rigidbody bulletClone = GameObject.Instantiate(bulletPrefab, bulletPos.position, bulletPos.rotation).GetComponent<Rigidbody>();
        bulletClone.AddForce(direction * forceBullet, ForceMode.Acceleration);
        GameObject.Destroy(bulletClone, timeToDestroy);
    }

    public static void SlowLookAt(float speedRotation, Transform part, Vector3 position, Axys axys)
    {
        switch (axys)
        {
            case Axys.x:
                Vector3 directionPart = new Vector3(part.position.x, position.y, position.z) - part.transform.position;
                Quaternion partRotation = Quaternion.LookRotation(directionPart);
                part.rotation = Quaternion.RotateTowards(part.rotation, partRotation, speedRotation * Time.deltaTime);
                break;
            case Axys.y:
                directionPart = new Vector3(position.x, part.position.y, position.z) - part.transform.position;
                partRotation = Quaternion.LookRotation(directionPart);
                part.rotation = Quaternion.RotateTowards(part.rotation, partRotation, speedRotation * Time.deltaTime);
                break;
            case Axys.z:
                directionPart = new Vector3(position.x, position.y, part.position.z) - part.transform.position;
                partRotation = Quaternion.LookRotation(directionPart);
                part.rotation = Quaternion.RotateTowards(part.rotation, partRotation, speedRotation * Time.deltaTime);
                break;
        }
       
    }

    public static void SlowLocalLookAt(float speedRotation, Transform part, Vector3 position, Axys axys)
    {
        switch (axys)
        {
            case Axys.x:
                Vector3 directionPart = new Vector3(part.localPosition.x, position.y, position.z) - part.transform.localPosition;
                Quaternion partRotation = Quaternion.LookRotation(directionPart);
                part.localRotation = Quaternion.RotateTowards(part.localRotation, partRotation, speedRotation * Time.deltaTime);
                break;
            case Axys.y:
                directionPart = new Vector3(position.x, part.localPosition.y, position.z) - part.transform.localPosition;
                partRotation = Quaternion.LookRotation(directionPart);
                part.localRotation = Quaternion.RotateTowards(part.localRotation, partRotation, speedRotation * Time.deltaTime);
                break;
            case Axys.z:
                directionPart = new Vector3(position.x, position.y, part.localPosition.z) - part.transform.localPosition;
                partRotation = Quaternion.LookRotation(directionPart);
                part.localRotation = Quaternion.RotateTowards(part.localRotation, partRotation, speedRotation * Time.deltaTime);
                break;
        }

    }

    public static void ResetZ(Transform transform)
    {
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(transform.eulerAngles.x,
            transform.eulerAngles.y, 0), 2);
        Quaternion rotationZ0 = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, 0);
    }
}
