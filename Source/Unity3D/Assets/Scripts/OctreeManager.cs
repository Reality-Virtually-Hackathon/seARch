/* This software is under the MIT License
 * Copyright <2017> <Wallace Lages>
 * Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files
 * (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, 
 * publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so,
 * subject to the following conditions: The above copyright notice and this permission notice shall be included in all copies or
 * substantial portions of the Software.
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
 * OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
 * LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR
 * IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Academy.HoloToolkit.Unity;


public class OctreeManager : Singleton<OctreeManager> {
    PointOctree<WatchData> pointTree;

    // Use this for initialization
    void Start () {
        // Initial size (metres), initial centre position, minimum node size (metres), looseness
        // boundsTree = new BoundsOctree<GameObject>(15, this.transform.position, 1, 1.25f);
        // Initial size (metres), initial centre position, minimum node size (metres)
        pointTree = new PointOctree<WatchData>(50, Vector3.zero, 0.5f);// this.transform.position, 1);
    }
	
	// Update is called once per frame
	void Update () {
 

    }

    //get markers
    public bool GetMarkers(Vector3 head, ref Vector3 A, ref Vector3 B)
    {
        WatchData [] markers = pointTree.GetNearby(new Vector3(head.x, head.y, head.z),1); //4 meters around head
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
            pointTree.DrawAllBounds(); // Draw node boundaries
            pointTree.DrawAllObjects(); // Mark object positions

        }
    }

}


