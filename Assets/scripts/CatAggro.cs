using UnityEngine;

public class CatAggro : MonoBehaviour
{
    public Collider2D aggroBound;

    public float aggroMeter = 0;

    public float decayRate = 0.1f; // per second
    public float aggroCoeff = 0.1f;

	private Speedometer speedometer = new Speedometer();

    void Start()
    {
        Debug.Assert(aggroBound != null);
    }

    float DecayCoeff(float delta)
    {
        return Mathf.Pow(decayRate, delta);
    }
	
    void Update()
    {
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var currPos = (Vector2)mousePos;

		speedometer.AddPosition(currPos, Time.deltaTime);
		aggroMeter *= DecayCoeff(Time.deltaTime);

		if (Input.GetMouseButton(0))
        {
            if (aggroBound.OverlapPoint(currPos))
            {
				var accel = speedometer.Acceleration;
				if (accel.HasValue) {
                	aggroMeter += accel.Value.magnitude * aggroCoeff;
				}
            }
		}
    }
}
