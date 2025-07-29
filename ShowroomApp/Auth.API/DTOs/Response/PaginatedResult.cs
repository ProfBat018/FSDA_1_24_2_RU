namespace Auth.API.DTOs.Response;

public class PaginatedResult<T>
{
    public bool IsSuccess { get; }
    public string Message { get; }
    public int StatusCode { get; }
    public IEnumerable<T> Data { get; }
    public int Page { get; }
    public int ContentPerPage { get; }
    public int TotalItems { get; }
    public int TotalPages { get; }

    private PaginatedResult(
        bool isSuccess,
        string message,
        int statusCode,
        IEnumerable<T> data,
        int page,
        int contentPerPage,
        int totalItems)
    {
        IsSuccess = isSuccess;
        Message = message;
        StatusCode = statusCode;
        Data = data;
        Page = page;
        ContentPerPage = contentPerPage;
        TotalItems = totalItems;
        TotalPages = (int)Math.Ceiling((double)totalItems / contentPerPage);
    }

    public static PaginatedResult<T> Success(
        IEnumerable<T> data,
        int totalItems,
        int page = 1,
        int contentPerPage = 15,
        string message = "Success",
        int statusCode = 200)
    {
        return new PaginatedResult<T>(true, message, statusCode, data, page, contentPerPage, totalItems);
    }

    public static PaginatedResult<T> Error(
        string message = "An error occurred",
        int statusCode = 400)
    {
        return new PaginatedResult<T>(false, message, statusCode, Enumerable.Empty<T>(), 1, 15, 0);
    }
}