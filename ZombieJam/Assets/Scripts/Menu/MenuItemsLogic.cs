using UnityEngine;
using System.Collections;



public class MenuItemsLogic : MonoBehaviour {

    public static int FocusedItem = 0;
    public int NumberOfItems = 1;
    private bool canSelect = true;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetAxis("VerticalLeft1") < 0.01 && Input.GetAxis("VerticalLeft1") > -0.01)
        {
            canSelect = true;
        }

        if (canSelect)
        {
            if (Input.GetAxis("VerticalLeft1") > 0.1)
            {
                FocusedItem++;
                if (FocusedItem == NumberOfItems)
                {
                    FocusedItem = 0;
                }
                canSelect = false;
            }
            else if (Input.GetAxis("VerticalLeft1") < -0.1)
            {
                FocusedItem--;

                if (FocusedItem == -1)
                {
                    FocusedItem = NumberOfItems - 1;
                }
                canSelect = false;
            }
        }
	}
}
