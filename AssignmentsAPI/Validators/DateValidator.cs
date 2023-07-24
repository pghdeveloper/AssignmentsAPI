namespace AssignmentsAPI.Validators;

public static class DateValidator
{
    public static bool IsValid(string date)
    {
        return DateTime.TryParse(date, out _);
    }
}