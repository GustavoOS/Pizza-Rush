using UnityEngine;
using System.Collections;

public class DungeonCamera : MonoBehaviour {
    public GameObject target;
    Vector3 offset;
	// Use this for initialization
	void Start () {
        offset = transform.position - target.transform.position;
	}
	
	// Update is called once per frame
    void LateUpdate()
    {
        Vector3 desiredPosition = target.transform.position;
        desiredPosition += offset;
        Vector3 dPosition=new Vector3(desiredPosition.x,desiredPosition.y,-1000);
        transform.position = dPosition;
    }
}
