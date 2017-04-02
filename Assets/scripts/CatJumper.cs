using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatJumper : MonoBehaviour {
    public CatAggro aggro;

    public float jumpPower1 = 10.0f;
    public float maxXAxisVelocity = 5.0f;
    public float maxYAxisVelocity = 10.0f;

    public Vector3 lastMousePosition;

    public DelayBuffer<Vector3> delayBuffer = null;
    public Vector2 Force=Vector2.zero;

    static public float standing;

    void Start () {
        Debug.Assert(aggro != null);
    }
	
	void Update () { 
        var rb = GetComponent<Rigidbody2D>();

        var velocity = rb.velocity;
        var mousePos = Input.mousePosition;

        //튕기는 Force
        if (Input.GetMouseButtonDown(0))
        {
            delayBuffer = new DelayBuffer<Vector3>(3);
        }
        else if (Input.GetMouseButton(0))
        {
            delayBuffer.Add(mousePos);
        }

        if (Input.GetMouseButtonUp(0) && aggro.aggroMeter > aggro.aggroThreshold && delayBuffer.HasEnoughCount() && standing <= 0.5)
        {
            Vector2 delta = ( mousePos - delayBuffer.Get()) / Time.deltaTime;
            if (delta.y < 0)
            {
                delta = new Vector2(delta.x, 0);
            }

            if (delta.x >= 0)
            {
                rb.AddForce(new Vector2(Mathf.Pow(delta.x, 0.5f), Mathf.Pow(delta.y, 0.5f)) * jumpPower1);
            }
            else if (delta.x < 0)
            {
                rb.AddForce(new Vector2(-Mathf.Pow(-delta.x, 0.5f), Mathf.Pow(delta.y, 0.5f)) * jumpPower1);
            }
        }
        
        //속력 제한
        if(velocity.y >= maxYAxisVelocity)
        {
            rb.velocity = new Vector2(velocity.x, maxYAxisVelocity);
        }
        
        if (velocity.x >= maxXAxisVelocity)
        {
            rb.velocity = new Vector2(maxXAxisVelocity, velocity.y);
        }
        else if(velocity.x <= -maxXAxisVelocity)
        {
            rb.velocity = new Vector2(-maxXAxisVelocity, velocity.y);
        }
    }
}
