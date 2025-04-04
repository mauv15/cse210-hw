public class Job
{
    // Member variables
    private string _jobTitle;
    private string _company;
    private int _startYear;
    private int _endYear;

    // Constructor to initialize the job details
    public Job(string jobTitle, string company, int startYear, int endYear)
    {
        _jobTitle = jobTitle;
        _company = company;
        _startYear = startYear;
        _endYear = endYear;
    }

    // Method to display job details
    public void DisplayJobDetails()
    {
        Console.WriteLine($"{_jobTitle} ({_company}) {_startYear}-{_endYear}");
    }
}
