using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camFollow : MonoBehaviour
{
    [SerializeField]
    private float followSpeed = 100f;
    public Transform target;

    void Update()
    {
        Vector3 newPosition = target.position;
        newPosition.z -=3 ;
        newPosition.y += 3;
        transform.position = Vector3.Slerp(transform.position, newPosition, followSpeed * Time.deltaTime);
    }
}
