public class Cycling : Activity
{
    private double _speed; // mph

    public Cycling(string date, int lengthInMinutes, double speed) : base(date, lengthInMinutes)
    {
        _speed = speed;
    }

    public override double GetDistance() => (_speed / 60) * GetLengthInMinutes(); // in miles

    public override double GetSpeed() => _speed; // mph

    public override double GetPace() => 60 / _speed; // min per mile
}
