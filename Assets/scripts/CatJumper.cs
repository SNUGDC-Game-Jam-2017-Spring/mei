using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatJumper : MonoBehaviour {

    public float jumpPower1 = 30.0f;
    public float xAxisVelocity = 0.0f;
    public float yAxisVelocity = 0.0f;
    public float maxXAxisVelocity = 10.0f;
    public float maxYAxisVelocity = 10.0f;

    public Vector2 delta = Vector2.zero;
    public Vector3 lastMousePosition =Vector2.zero;
    public Vector3 MousePosition = Vector2.zero;
    public static Vector2[] recording = new Vector2[5];
    public Vector2 Force=Vector2.zero;
    public Vector2 ResistForce = Vector2.zero;




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
            rb.AddForce(delta * jumpPower1);
            rb.AddForce(ResistForce);
        }

        Force = delta * jumpPower1;

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

        //저항력
        ResistForce = Vector2.left * xAxisVelocity + Vector2.down * yAxisVelocity * yAxisVelocity;
        if (Mathf.Abs(xAxisVelocity) >= maxYAxisVelocity)
        {
            ResistForce = Vector2.left * Force.x + Vector2.up * Force.y;
        }
        if(yAxisVelocity >= maxYAxisVelocity)
        {
            ResistForce = Vector2.right * Force.x + Vector2.down * Force.y;
        }

        rb.AddForce(Vector2.zero);
    }
}
