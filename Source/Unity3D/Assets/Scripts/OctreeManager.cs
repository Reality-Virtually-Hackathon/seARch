using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Academy.HoloToolkit.Unity;


public class OctreeManager : Singleton<OctreeManager> {

    BoundsOctree<GameObject> boundsTree;
    PointOctree<WatchData> pointTree;

    // Use this for initialization
    void Start () {
        // Initial size (metres), initial centre position, minimum node size (metres), looseness
       // boundsTree = new BoundsOctree<GameObject>(15, this.transform.position, 1, 1.25f);
        // Initial size (metres), initial centre position, minimum node size (metres)
        pointTree = new PointOctree<WatchData>(15, this.transform.position, 1);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    //get markers
    public bool GetMarkers(Vector3 head, ref Vector3 A, ref Vector3 B)
    {
        WatchData [] markers = pointTree.GetNearby(new Vector3(head.x, head.y, head.z),4); //4 meters around head
        if (markers.Length > 0)
        {
            A = markers[0].position;
            B = markers[0].position;
            return true;
        }

        return false;
    }

    public void Add(Vector3 vec)
    {
        WatchData data = new WatchData(vec);

        pointTree.Add(data, vec);
     }

    void OnDrawGizmos()
    {
        if (pointTree != null)
        {
          /*  boundsTree.DrawAllBounds(); // Draw node boundaries
            boundsTree.DrawAllObjects(); // Draw object boundaries
            boundsTree.DrawCollisionChecks(); // Draw the last *numCollisionsToSave* collision check boundaries
            */

            pointTree.DrawAllBounds(); // Draw node boundaries
            pointTree.DrawAllObjects(); // Mark object positions

        }
    }

}


