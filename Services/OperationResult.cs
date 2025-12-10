namespace frmGiaoVien.Services;

public class OperationResult<T>
{
    public bool Success { get; init; }
    public string Message { get; init; } = string.Empty;
    public T? Data { get; init; }

    public static OperationResult<T> Ok(T? data, string? message = null) =>
        new()
        {
            Success = true,
            Data = data,
            Message = message ?? string.Empty
        };

    public static OperationResult<T> Fail(string message) =>
        new()
        {
            Success = false,
            Message = message
        };
}
