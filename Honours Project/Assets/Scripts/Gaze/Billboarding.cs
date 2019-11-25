using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
public enum Axis
{
    X, Y, Z, XY, XZ, YZ, None
}
public class Billboarding : MonoBehaviour
{
    public Axis axis = Axis.None;
    public Transform target;

    private void OnEnable()
    {
        if(target == null)
        {
            target = Camera.main.transform;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {        
        if (target == null)
            return;

        Vector3 upDir = new Vector3(0, 1, 0);
        Vector3 targetDir = target.position - transform.position;
        Vector3 targetUpVector = Camera.main.transform.up;

        switch(axis)
        {
            case Axis.X:
                targetDir.x = 0.0f;
                targetUpVector = upDir;
                break;
            case Axis.Y:
                targetDir.y = 0.0f;
                targetUpVector = upDir;
                break;
            case Axis.Z:
                targetDir.x = 0.0f;
                targetDir.y = 0.0f;
                break;
            case Axis.XY:
                targetUpVector = upDir;
                break;
            case Axis.XZ:
                targetDir.x = 0.0f;
                break;
            case Axis.YZ:
                targetDir.y = 0.0f;
                break;
        }

        transform.rotation = Quaternion.LookRotation(-targetDir, targetUpVector);
    }
}
*/