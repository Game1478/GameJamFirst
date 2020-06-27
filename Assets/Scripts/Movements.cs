using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movements : MonoBehaviour
{
    public Color startColor;

    private bool set = false;
    private Renderer renderer;
    public Color redColor, blueColor;
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.layer = 0;
        renderer = gameObject.GetComponent<Renderer>();
        renderer.material.color = startColor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!set)
        {
            if (collision.gameObject.tag == "PlayerBlue")
            {
                this.gameObject.layer = 10;
                renderer.material.color = blueColor;
                set = true;
            }
            else if (collision.gameObject.tag == "PlayerRed")
            {
                this.gameObject.layer = 11;
                renderer.material.color = redColor;
                set = true;
            }
        }
    }
}
