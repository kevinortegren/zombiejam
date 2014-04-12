using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {

    public int FocusOrder = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
    protected virtual void Update()
    {
        if (FocusOrder == MenuItemsLogic.FocusedItem)
        {
            Vector3 trans = transform.position;
            trans.z = (float)System.Math.Sin((float)Time.time * 4.0f) * 4.0f;
            transform.position = trans;

            if (Input.GetButtonDown("Jump1"))
            {
                print("button down");
                OnClicked();
            }
        }
        else
        {
            Vector3 trans = transform.position;
            trans.z = 0.0f;
            transform.position = trans;
        }
	}

    protected virtual void OnClicked() { }
}
