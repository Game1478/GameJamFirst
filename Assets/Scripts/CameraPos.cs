using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPos : MonoBehaviour
{
    public float speedHorizontal, speedVertical;
    private Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pos = transform.position;
        if (Input.GetKey(KeyCode.I))
        {
            pos.y += speedVertical;
        }
        if (Input.GetKey(KeyCode.K))
        {
            pos.y -= speedVertical;
        }
        if (Input.GetKey(KeyCode.J))
        {
            pos.x += speedHorizontal;
        }
        if (Input.GetKey(KeyCode.L))
        {
            pos.x -= speedHorizontal;
        }
        transform.position = pos;
    }
}
