public class Running : Activity
{
    private double _distance; // in miles

    public Running(string date, int lengthInMinutes, double distance) : base(date, lengthInMinutes)
    {
        _distance = distance;
    }

    public override double GetDistance() => _distance;

    public override double GetSpeed() => (_distance / GetLengthInMinutes()) * 60; // mph

    public override double GetPace() => GetLengthInMinutes() / _distance; // min per mile
}
