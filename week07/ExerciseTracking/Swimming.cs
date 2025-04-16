public class Swimming : Activity
{
    private int _laps; // number of laps

    public Swimming(string date, int lengthInMinutes, int laps) : base(date, lengthInMinutes)
    {
        _laps = laps;
    }

    public override double GetDistance()
    {
       return (_laps * 50.0) / 1000 * 0.62; // laps in miles
    }

    public override double GetSpeed()
    {
        return (GetDistance() / GetLengthInMinutes()) * 60; // mph
    }

    public override double GetPace()
    {
        return GetLengthInMinutes() / GetDistance(); // min per mile
    }
}
