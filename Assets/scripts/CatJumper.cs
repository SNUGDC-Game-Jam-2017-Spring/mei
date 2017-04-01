using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatJumper : MonoBehaviour {

    public float jumpPower1 = 10.0f;
    public float xAxisVelocity = 0.0f;
    public float yAxisVelocity = 0.0f;
    public float maxXAxisVelocity = 5.0f;
    public float maxYAxisVelocity = 10.0f;


    public Vector2 delta = Vector2.zero;
    public Vector3 lastMousePosition =Vector2.zero;
    public Vector3 MousePosition = Vector2.zero;
    public static Vector2[] recording = new Vector2[5];
    public Vector2 Force=Vector2.zero;
    public Vector2 catPosition = Vector2.zero;




    void Start () {
        for (int i = 0; i < 5; i++)
        {
            recording[i] = Vector2.zero;
        }
    }
	
	// Update is called once per frame
	void Update () {

        //변수 설정
        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        xAxisVelocity = rb.velocity.x;
        yAxisVelocity = rb.velocity.y;

        MousePosition = Input.mousePosition;

        for (int i = 0; i < 4; i++)
        {
            recording[i] = recording[i + 1];
        }

        catPosition = rb.position;

        //튕기는 Force
        if (Input.GetMouseButtonDown(0))
        {
            lastMousePosition = MousePosition;
        }

        else if (Input.GetMouseButton(0))
        {
            recording[4] = MousePosition;
            lastMousePosition = recording[2];
        }

        if (Input.GetMouseButtonUp(0))
        {
            delta = ( MousePosition - lastMousePosition)/Time.deltaTime;
            if (delta.y < 0)
            {
                delta = Vector2.down * delta.y + delta;
            }
            if (delta.x >= 0)
            {
                rb.AddForce((Vector2.right * Mathf.Pow((delta.x), 0.5f) + Vector2.up * Mathf.Pow((delta.y), 0.5f)) * jumpPower1);
            }
            else if (delta.x < 0)
            {
                rb.AddForce((-Vector2.right * Mathf.Pow((-delta.x), 0.5f) + Vector2.up * Mathf.Pow((delta.y), 0.5f)) * jumpPower1);
            }
            
        }
        

        //속력 제한
        if(yAxisVelocity >= maxYAxisVelocity)
        {
            rb.velocity = Vector2.right * rb.velocity.x + Vector2.up * maxYAxisVelocity;
        }
        if (xAxisVelocity >= maxXAxisVelocity)
        {
            rb.velocity = Vector2.right * maxXAxisVelocity + Vector2.up * rb.velocity.y;
        }
        else if(xAxisVelocity <= -maxXAxisVelocity)
        {
            rb.velocity = Vector2.left * maxXAxisVelocity + Vector2.up * rb.velocity.y;
        }


    }
}
