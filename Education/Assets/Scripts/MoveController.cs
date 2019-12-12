using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    Rigidbody rb;
    bool top, down;
    float positiveAxisY = -0.4f;
    float negativeAxisY = 0.4f;
    public float speed, axisXSpeed, axisYSpeed = 1;
    Vector3 LastMousePosition;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotationZ;
    }

    public void CheckAxis()
    {
        transform.Rotate(Input.GetAxis("Mouse Y") * -axisYSpeed, Input.GetAxis("Mouse X") * axisXSpeed, 0);
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y,0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if(Input.GetAxis("Mouse Y") > 0 && !top)
            {
                Debug.Log("top" + transform.rotation);
                if (down)
                {
                    down = false;
                }
                if(transform.rotation.x <= positiveAxisY)
                {
                    top = true;
                }
            }
            if (Input.GetAxis("Mouse Y") < 0 && !down)
            {
                Debug.Log("down" + transform.rotation);
                if (top)
                {
                    top = false;
                }
                if (transform.rotation.x >= negativeAxisY)
                {
                    down = true;
                }
            }
            if (top || down)
                axisYSpeed = 0;
            else
                axisYSpeed = 1;
            CheckAxis();
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back* Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * Time.deltaTime);
        }
    }

    public void GetMouseAxis(float x, int a)
    {
        if (a == 0)
        {
            Debug.Log("Hor: " + x);
        }
        else
        {
            Debug.Log("Ver: " + x);
        }
    }
}
