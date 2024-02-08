using System.Net;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreWeb.AdminLTE.ProjectTemplates.ViewModels.APIs.v2;

public static class ApiResultFactory
{
    public static IActionResult Create(object data)
    {
        return Create<object>(data);
    }

    public static ApiResult<T> Create<T>(T value)
    {
        return new ApiResult<T>(value);
    }

    public static IActionResult Create(HttpStatusCode code)
    {
        return new ApiResult<object>(null) { HttpStatusCode = code };
    }
}

public class ApiResult<T> : IActionResult
{
    #region // Fields

    private ApiResponse _apiResponse { get; set; }

    private class ApiResponse
    {
        public int Code { get; set; }
        public T Data { get; set; }
        public string Message { get; set; }

        [JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        public Exception Exception { get; set; }

        [JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        public HttpStatusCode HttpStatusCode { get; set; } = HttpStatusCode.OK;
    }

    #endregion

    #region // Ctor

    public ApiResult(T data)
    {
        _apiResponse = new ApiResponse()
        {
            Code = 1000,
            Data = data,
            Message = string.Empty,
            Exception = null,
        };
    }

    public ApiResult(Exception exp)
    {
        _apiResponse = new ApiResponse()
        {
            Code = 1000,
            Data = default(T),
            Message = string.Empty,
            Exception = exp,
        };
    }

    #endregion

    #region // Utilities

    #endregion

    #region // Methods

    public async Task ExecuteResultAsync(ActionContext context)
    {
        if (_apiResponse.Exception != null)
        {
        }

        var objectResult = new ObjectResult(_apiResponse)
        {
            StatusCode = (int)HttpStatusCode.OK,
        };

        switch (_apiResponse.HttpStatusCode)
        {
            case HttpStatusCode.BadRequest:
            case HttpStatusCode.Unauthorized:
            case HttpStatusCode.Forbidden:
                objectResult.StatusCode = (int)_apiResponse.HttpStatusCode;
                break;
            default:
                if (_apiResponse.Data == null)
                {
                    objectResult.StatusCode = (int)HttpStatusCode.NoContent;
                }

                break;
        }

        await objectResult.ExecuteResultAsync(context);
    }

    #endregion

    #region // Properties

    /// <summary>
    /// 詳細資料
    /// </summary>
    public T Data => (_apiResponse == null) ? default(T) : _apiResponse.Data;

    /// <summary>
    /// 資料代碼  用以描述資料屬性(正常為1000)
    /// </summary>
    public int Code => _apiResponse?.Code ?? 1000;

    /// <summary>
    /// 資料訊息
    /// </summary>
    public string Message => (_apiResponse == null) ? string.Empty : _apiResponse.Message;

    /// <summary>
    /// 例外資料(不顯示)
    /// </summary>
    [JsonIgnore]
    [Newtonsoft.Json.JsonIgnore]
    public Exception Exception => _apiResponse?.Exception;

    [JsonIgnore]
    [Newtonsoft.Json.JsonIgnore]
    public HttpStatusCode HttpStatusCode
    {
        get => _apiResponse.HttpStatusCode;
        set => _apiResponse.HttpStatusCode = value;
    }

    #endregion
}