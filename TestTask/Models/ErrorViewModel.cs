namespace TestTask.Models;

public class ErrorViewModel
{
    public Exception E { get; set; }

    public ErrorViewModel(Exception e)
    {
        E = e;
    }
}