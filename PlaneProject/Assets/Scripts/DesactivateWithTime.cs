using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesactivateWithTime : MonoBehaviour
{
    [SerializeField]
    private float timeToDesactive = 0.10f;

    private void OnEnable()
    {
        StartCoroutine(Desactive());
    }

    IEnumerator Desactive()
    {
        yield return new WaitForSeconds(timeToDesactive);
        gameObject.SetActive(false);
    }
}
