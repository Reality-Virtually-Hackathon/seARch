using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnlyServer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (!AppStateManager.Instance.isCommandCenter)
            this.gameObject.SetActive(false);
        else
            this.gameObject.SetActive(true);

    }
}
