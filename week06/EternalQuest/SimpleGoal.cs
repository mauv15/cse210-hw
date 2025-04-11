public class SimpleGoal : Goal
{
    public SimpleGoal(string name, string description, int points)
        : base(name, description, points)
    {
    }

    public override int RecordEvent()
    {
        if (!_isComplete)
        {
            _isComplete = true;
            return _points;
        }
        return 0; // No points if already completed
    }

    public override string GetStatus()
    {
        return $"[{(_isComplete ? "X" : " ")}] {_name} ({_description})";
    }

    public override string GetStringRepresentation()
    {
        return $"SimpleGoal|{_name}|{_description}|{_points}|{_isComplete}";
    }
}
