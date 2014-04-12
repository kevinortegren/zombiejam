using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour {

	public float dampTime = 0.15f;
	private Vector3 velocity = Vector3.zero;
	public Transform target;
	
	// Update is called once per frame
	void Update ()
	{
		if (target)
		{
			Vector3 targetPos = target.position + new Vector3(0, 2, 0);
			Vector3 point = camera.WorldToViewportPoint(targetPos);
			Vector3 delta = targetPos - camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z)); //(new Vector3(0.5, 0.5, point.z));
			Vector3 destination = transform.position + delta;
			transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
		}
		
	}
}