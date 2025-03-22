public class Fraction
{
    private int _numerator;
    private int _denominator;

    // Constructors
    public Fraction() { _numerator = 1; _denominator = 1; }
    public Fraction(int numerator) { _numerator = numerator; _denominator = 1; }
    public Fraction(int numerator, int denominator) { _numerator = numerator; _denominator = denominator; }

    // Getters and Setters
    public int GetNumerator() { return _numerator; }
    public void SetNumerator(int numerator) { _numerator = numerator; }

    public int GetDenominator() { return _denominator; }
    public void SetDenominator(int denominator)
    {
        if (denominator != 0)
            _denominator = denominator;
        else
            throw new ArgumentException("Denominator cannot be zero.");
    }

    // Return fraction as a string (e.g., "3/4")
    public string GetFractionString()
    {
        return $"{_numerator}/{_denominator}";
    }

    // Return fraction as a decimal (e.g., 0.75)
    public double GetDecimalValue()
    {
        return (double)_numerator / _denominator;
    }
}
