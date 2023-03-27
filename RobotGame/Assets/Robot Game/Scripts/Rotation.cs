using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public float speed = 2;
    void Update()
    {
        transform.Rotate( new Vector3(0,0,360 * speed * Time.deltaTime) );
    }
}
