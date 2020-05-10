using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Noteobj_u : MonoBehaviour
{
    public bool CanBePressed;

    public KeyCode keytopress;
    private bool iscollided;
    // public GameObject u_button;
    public GameObject Button;

    public GameObject hitEffect, goodEffect, perfectEffect, missEffect;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // delete object if pressed key in the right time
        if (Input.GetKeyDown(keytopress))
        {
            if (CanBePressed)
            {
                gameObject.SetActive(false);

                // call NoteHit() function in GameManager
                // GameManager.instance.NoteHit();

                if (Mathf.Abs(transform.position.y - Button.transform.position.y) > 0.02f) // distance between arrow's and button's y position(0.2f)
                {
                    Debug.Log("Hit");
                    GameManager.instance.NormalHit();
                    Instantiate(hitEffect, transform.position, hitEffect.transform.rotation);
                }
                else if (Mathf.Abs(transform.position.y - Button.transform.position.y) > 0.01f)
                {
                    Debug.Log("Good");
                    GameManager.instance.GoodHit();
                    Instantiate(goodEffect, transform.position, goodEffect.transform.rotation);
                }
                else
                {
                    Debug.Log("Perfect");
                    GameManager.instance.PerfectHit();
                    Instantiate(perfectEffect, transform.position, perfectEffect.transform.rotation);
                }
            }
        }


        // delete object if leg collide with arrow in the right time
        iscollided = GameObject.Find("UXRARROW_u").GetComponent<Trig_arr_u>().u_collided;


        
        if (iscollided)
        {
            //Debug.Log("is collided");
            if (CanBePressed)
            {
                gameObject.SetActive(false);

                // call NoteHit() function in GameManager
                // GameManager.instance.NoteHit();
               
                if (Mathf.Abs(transform.position.y - Button.transform.position.y) > 0.02f) // normal hit range, 0.966363 is the y position of the button
                {
                    Debug.Log("Hit");
                    GameManager.instance.NormalHit();
                    Instantiate(hitEffect, transform.position, hitEffect.transform.rotation);
                }
                else if (Mathf.Abs(transform.position.y - Button.transform.position.y) > 0.01f)
                {
                    Debug.Log("Good");
                    GameManager.instance.GoodHit();
                    Instantiate(goodEffect, transform.position, goodEffect.transform.rotation);
                }
                else
                {
                    Debug.Log("Perfect");
                    GameManager.instance.PerfectHit();
                    Instantiate(perfectEffect, transform.position, perfectEffect.transform.rotation);
                }

            }
        }
        //else {
        //    Debug.Log("not collided");
        //}

    }

    // test 2d collision
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Activator")
        {
            CanBePressed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Activator")
        {
            CanBePressed = false;

            // call NoteMissed() function in GameManager
            GameManager.instance.NoteMissed();
            Instantiate(missEffect, transform.position, missEffect.transform.rotation);
        }
    }





}

