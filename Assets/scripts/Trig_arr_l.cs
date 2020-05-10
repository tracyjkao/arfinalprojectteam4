using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trig_arr_l : MonoBehaviour
{
    Color ObjectRenderer;
    Color ObjectRenderer2;

    public GameObject leg;

    // change the color of the buttons when collision
    public GameObject button;
    private SpriteRenderer theSR;
    public Sprite defaultImage;
    public Sprite pressedImage;

    public bool l_collided;

    // Start is called before the first frame update
    void Start()
    {
        //Fetch the GameObject's Renderer component
        ObjectRenderer = this.GetComponent<MeshRenderer>().material.color;
        ObjectRenderer2 = leg.GetComponent<MeshRenderer>().material.color;

        theSR = button.GetComponent<SpriteRenderer>();

    }



    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("leg"))
        {
            // arrow becomes semi-trans
            ObjectRenderer.a = 0.5f;
            this.GetComponent<MeshRenderer>().material.color = ObjectRenderer;

            // leg becomes semi-trans
            ObjectRenderer2.a = 0.5f;
            leg.GetComponent<MeshRenderer>().material.color = ObjectRenderer2;

            // 
            theSR.sprite = pressedImage;

            l_collided = true;
        }
    }

    // recover to original state
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("leg"))
        {
            ObjectRenderer.a = 1f;
            this.GetComponent<MeshRenderer>().material.color = ObjectRenderer;

            ObjectRenderer2.a = 1f;
            leg.GetComponent<MeshRenderer>().material.color = ObjectRenderer2;

            theSR.sprite = defaultImage;

            l_collided = false;

        }

    }
}
