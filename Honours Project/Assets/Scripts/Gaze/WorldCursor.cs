using UnityEngine;

public class WorldCursor : MonoBehaviour
{
    private MeshRenderer meshRenderer;

    // Start is called before the first frame update
    void Start()
    {
        //Grab the mesh renderer
        meshRenderer = this.gameObject.GetComponentInChildren<MeshRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //Raycast into the world based on the user's head position and orientation.
        var headPosition = Camera.main.transform.position;
        var gazeDirection = Camera.main.transform.forward;

        RaycastHit hitInfo;

        if(Physics.Raycast(headPosition, gazeDirection, out hitInfo))
        {
            //If the raycast hits a hologram, display the mesh
            meshRenderer.enabled = true;

            //Move the cursor to the point where the raycast hits.
            this.transform.position = hitInfo.point;

            //Rotate the cursor to hug the surface of the hologram.
            this.transform.rotation = Quaternion.FromToRotation(Vector3.up, hitInfo.normal);
        }
        else
        {
            //If the raycast did not hit a hologram, hide the cursor mesh.
            meshRenderer.enabled = true;
        }
    }
}
