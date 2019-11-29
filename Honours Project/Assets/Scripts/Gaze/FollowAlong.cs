using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowAlong : MonoBehaviour
{
    bool placing = false;

    /* There was a bug where the UI would collide with it's self causing it to move
     * towards the camera. I am using the following to disable the UI from 
     * colliding with itself.
     */
    public bool applyToBaseObject = false;
    void Awake()
    {
        if (applyToBaseObject == true)
        {
            Collider collider = GetComponent<Collider>();
            if (collider != null)
            {
                foreach (Transform child in transform)
                {
                    Collider secondCollider = child.GetComponent<Collider>();
                    if (secondCollider == null)
                    {
                        continue;
                    }
                    else
                    {
                        Physics.IgnoreCollision(collider, secondCollider);
                    }
                }
            }
        }

        foreach(Transform child in transform)
        {
            Collider collider = child.GetComponent<Collider>();
            if (collider == null)
                continue;
            else
            {
                foreach(Transform secondChild in transform)
                {
                    Collider secondCollider = secondChild.GetComponent<Collider>();
                    if(secondCollider == null)
                    {
                        continue;
                    }
                    else
                    {
                        Physics.IgnoreCollision(collider, secondCollider);
                    }
                }
            }
        }
    }

    void OnSelect()
    {
        // On each Select gesture, toggle whether the user is in placing mode.
        placing = !placing;

        // If the user is in placing mode, display the spatial mapping mesh.
        if (placing)
        {
            SpatialMapping.Instance.DrawVisualMeshes = true;
        }
        // If the user is not in placing mode, hide the spatial mapping mesh.
        else
        {
            SpatialMapping.Instance.DrawVisualMeshes = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (placing)
        {
            var headPosition = Camera.main.transform.position;
            var gazeDirection = Camera.main.transform.forward;

            Ray ray = new Ray(headPosition, gazeDirection);
            RaycastHit hitInfo;

            if (Physics.Raycast(headPosition, gazeDirection, out hitInfo, 10f, SpatialMapping.PhysicsRaycastMask))
            {
                //RaycastHit[] Allhits = Physics.RaycastAll(ray, 100f);
                //foreach (RaycastHit hit in Allhits)
                //{
                    //if (!hit.transform.IsChildOf(this.transform))
                    //{
                        if (gameObject != this)
                        {
                            this.transform.parent.position = new Vector3(
                            hitInfo.point.x,
                            hitInfo.point.y,
                            hitInfo.point.z
                            );

                            //this.transform.parent.position = this.transform.parent.position - gazeDirection;

                            Quaternion toQuat = Camera.main.transform.localRotation;
                            this.transform.parent.rotation = toQuat;

                        }
                    //}
                //}
            }
        }
        
        
    }
}
