using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leglenadjust : MonoBehaviour
{
    //private GameObject leg;
    public KeyCode increasekey;
    public KeyCode decreasekey;
    private Vector3 scaleChange;

    // Start is called before the first frame update
    void Start()
    {
        scaleChange = new Vector3(0.0f, 0.1f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(increasekey))
        {
            this.transform.localScale += scaleChange;
        }

        if (Input.GetKeyDown(decreasekey))
        {
            this.transform.localScale -= scaleChange;
        }


    }
}
