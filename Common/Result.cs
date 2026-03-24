namespace apbd_cw2_s33333.Common;

public class Result
{
    public bool IsSuccess { get; }
    public string ErrorMessage { get; }
    
    private Result(bool isSuccess, string errorMessage)
    {
        IsSuccess = isSuccess;
        ErrorMessage = errorMessage;
    }

    public static Result Success() => new Result(true, string.Empty);
    public static Result Failure(string message) => new Result(false, message);
}