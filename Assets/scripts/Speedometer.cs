using UnityEngine;

public class Speedometer
{
    private Vector2[] positions = new Vector2[3];
	private float[] deltas = new float[2];
    private int count = 0;

    public void AddPosition(Vector2 pos, float dt)
    {
        if (count >= 2) 
		{
			positions[2] = positions[1];
		}
        if (count >= 1)
		{
			positions[1] = positions[0];
			deltas[1] = deltas[0]; 
		}
        positions[0] = pos;
		deltas[0] = dt;

        if (count <= 3)
            count++;
    }

    public Vector2? Velocity
    {
        get
        {
            if (count < 2)
            {
                return null;
            }
			else
			{
				return (positions[1] - positions[0]) / deltas[0];
			}
        }
    }

    public Vector2? Acceleration
    {
        get
        {
            if (count < 3)
            {
                return null;
            }
			else
			{
				var meanDelta = (deltas[0] + deltas[1])/2;
				var prevVeloc = (positions[2] - positions[1]) / deltas[1];
				var currVeloc = (positions[1] - positions[0]) / deltas[0];
				return (currVeloc - prevVeloc) / meanDelta;
			}
        }
    }
}
