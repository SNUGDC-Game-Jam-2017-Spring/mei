using UnityEngine;

public class CatAggro : MonoBehaviour
{
    public Collider2D aggroBound;
    public Collider2D neutralBound;

    public float aggroMeter = 0;
    public float aggroThreshold = 5000f;

    public float decayRate = 0.1f; // per second
    public float neutralRate = 0.5f; // per second
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

    float NeutralCoeff(float delta)
    {
        return Mathf.Pow(neutralRate, delta);
    }
	
    void Update()
    {
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var currPos = (Vector2)mousePos;

		speedometer.AddPosition(currPos, Time.deltaTime);

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

        if (neutralBound.OverlapPoint(currPos)) {
            aggroMeter *= NeutralCoeff(Time.deltaTime);
        }
        else {
            aggroMeter *= DecayCoeff(Time.deltaTime);
        }
    }
}
