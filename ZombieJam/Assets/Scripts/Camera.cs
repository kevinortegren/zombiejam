using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour {

    public GameObject back;
    public GameObject front;
    public float diff;

	public float dampTime = 0.15f;
	private Vector3 velocity = Vector3.zero;
	public Transform target;
	
	// Update is called once per frame
	void Update ()
	{
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

        GameObject bottom = null;

        float maxX = -1000000000.0f;
        float minX = 1000000000.0f;
        float maxY = -1000000000.0f;
        float minY = 1000000000.0f;

        foreach (GameObject p in players)
        {
            if (p.transform.position.x > maxX)
            {
                maxX = p.transform.position.x;
                front = p;
            }

            if (p.transform.position.x < minX)
            {
                minX = p.transform.position.x;
                back = p;
            }

            if (p.transform.position.y > maxY)
            {
                maxY = p.transform.position.y;
            }

            if (p.transform.position.y < minY)
            {
                minY = p.transform.position.y;
                bottom = p;
            }
        }

        diff = maxX - minX;
        float diffY = maxY - minY;
        //print("MinX: " + minX + " MaxX: " + maxX + " Diff: " + diff);
       // print("MinY: " + minY + " MaxY: " + maxY + " Diff: " + diffY);

        if (back.transform && bottom.transform)
        {
            Vector3 targetPos = new Vector3();
            targetPos.x = back.transform.position.x + diff / 2;
            targetPos.y = bottom.transform.position.y + diffY / 2 + 2;
            targetPos.z = back.transform.position.z;

            //targetPos = back.transform.position + new Vector3(diff / 2, 2, 0);

            Vector3 point = camera.WorldToViewportPoint(targetPos);
            Vector3 delta = targetPos - camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z)); //(new Vector3(0.5, 0.5, point.z));
            Vector3 destination = transform.position + delta;
            transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
        }
        else
        {
            print("Error");
        }
		
	}
}