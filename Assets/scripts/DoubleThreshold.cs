public class DoubleThreshold
{
    public float Upper { get; private set; }
    public float Lower { get; private set; }
    private bool initial;
    public bool State { get; private set; }

    public DoubleThreshold(float upper, float lower, bool initial = false)
    {
        this.Upper = upper;
        this.Lower = lower;
        this.initial = initial;
        this.State = initial;
    }

    public void Reset()
    {
        this.State = initial;
    }

    public bool Add(float value)
    {
        if (value >= Upper) {
            State = true;
        }
        else if (value <= Lower) {
            State = false;
        }
        return State;
    }
}