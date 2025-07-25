using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;

namespace ZenBlog.Application.Base;

public class BaseResult<T>
{
    public T? Data { get; set; }

    public IEnumerable<object>? Errors { get; set; }

    [JsonIgnore]
    public bool IsSuccess => Errors==null || !Errors.Any();

    [JsonIgnore]
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

    public static BaseResult<T> Fail(IEnumerable<IdentityError> errors)
    {
        return new BaseResult<T>
        {
            Errors = (from error in errors
                select new Error { PropertyName = error.Code, ErrorMessage = error.Description})
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