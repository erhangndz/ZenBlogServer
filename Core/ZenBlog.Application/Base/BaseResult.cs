namespace ZenBlog.Application.Base;

public class BaseResult<T>
{
    public T? Data { get; set; }

    public IEnumerable<Error>? Errors { get; set; }

    public bool IsSuccess => Errors==null || !Errors.Any();

    public bool IsFailure => !IsSuccess;


    public static BaseResult<T> Success(T data)
    {
        return new BaseResult<T>
        {
            Data = data
        };
    }

    public static BaseResult<T> Fail(string error)
    {
        return new BaseResult<T>
        {
            Errors = [new Error{ErrorMessage = error}]
        };
    }

    public static BaseResult<T> Fail()
    {
        return new BaseResult<T>
        {
            Errors = [new Error { ErrorMessage = "an Unexpected Error Occured" }]
        };
    }

    public static BaseResult<T> Fail(IEnumerable<string> errors)
    {
        return new BaseResult<T>
        {
            Errors = (from error in errors 
                    select new Error{ErrorMessage = error})
        };
    }

    public static BaseResult<T> NotFound(string message)
    {
        return new BaseResult<T>
        {
           Errors = [new Error{ErrorMessage = message}]
        };
    }







}





public class Error
{
    public string? PropertyName { get; set; }
    public string ErrorMessage { get; set; }

}