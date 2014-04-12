using UnityEngine;
using System.Collections;

public class HorizontalButton : MonoBehaviour {

    public int FocusOrder = 0;
    private bool canSelect = false;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (Input.GetAxis("HorizontalLeft1") < 0.01 && Input.GetAxis("HorizontalLeft1") > -0.01)
        {
            canSelect = true;
        }
        
        if (FocusOrder == MenuItemsLogic.FocusedItem)
        {
            Vector3 trans = transform.position;
            trans.z = (float)System.Math.Sin((float)Time.time * 4.0f) * 2.0f;
            transform.position = trans;

            if (canSelect)
            {
                if (Input.GetAxis("HorizontalLeft1") > 0.1)
                {
                    OnRight();
                    canSelect = false;
                }
                else if (Input.GetAxis("HorizontalLeft1") < -0.1)
                {
                    OnLeft();
                    canSelect = false;
                }
            }
         
        }
        else
        {
            Vector3 trans = transform.position;
            trans.z = 0.0f;
            transform.position = trans;
        }
    }

    protected virtual void OnLeft() { }
    protected virtual void OnRight() { }
}
