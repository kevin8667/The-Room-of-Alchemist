using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    [SerializeField] float _zAngle;


    // Update is called once per frame
    void Update()
    {
       gameObject.transform.Rotate(0, 0, _zAngle, Space.Self);

    }
}
