using UnityEngine;

public class CatAggro : MonoBehaviour
{
    public Collider2D aggroBound;
    public Collider2D neutralBound;

    public float upperThreshold = 5000f;
    public float lowerThreshold = 2000f;

    public float decayRate = 0.1f; // per second
    public float neutralRate = 0.5f; // per second
    public float aggroCoeff = 0.1f;

    public float aggroMeter = 0;
    public DoubleThreshold gotAggro;

	private Speedometer speedometer = new Speedometer();

    void Awake()
    {
        this.gotAggro = new DoubleThreshold(upperThreshold, lowerThreshold);
    }
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

        gotAggro.Add(aggroMeter);

        if (gotAggro.State == false) 
        {
            aggroMeter *= DecayCoeff(Time.deltaTime);
        } 
        else
        {
            if (neutralBound.OverlapPoint(currPos) && aggroMeter < gotAggro.Upper) {
                aggroMeter *= NeutralCoeff(Time.deltaTime);
            }
            else {
                aggroMeter *= DecayCoeff(Time.deltaTime);
            }
        }
    }
}
