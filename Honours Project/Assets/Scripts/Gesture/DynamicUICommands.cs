using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicUICommands : MonoBehaviour
{
    bool placing = false;

    //Called by GazeGestureManager when the user preforms a select gesture.
    void OnSelect()
    {
        //On each select gesture, toggle whether the user is in placing mode.
        placing = !placing;

        //If the user is in placing mode, display the spatial mapping mesh.
        if(placing)
        {
            //Spatialmapping ON
        }
        else
        {
            //SpatialMapping OFF
        }
    }

    // Update is called once per frame
    void Update()
    {
        //If the user is in placing mode, update the placement to match the user's gaze.

        if(placing)
        {
            //Do a raycast into the world that will only hit the spactial mapping mesh.
            var headPosition = Camera.main.transform.position;
            var gazeDirection = Camera.main.transform.forward;

            this.transform.position = gazeDirection;
            
        }
    }
}
