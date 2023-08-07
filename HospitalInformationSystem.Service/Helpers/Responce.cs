namespace HospitalInformationSystem.Service.Helpers;

public class Responce<T>
{
    public int StatusCode { get; set; }
    public string Message { get; set; }
    public T Data { get; set; }
}
