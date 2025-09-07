namespace FirstWebApi.Contracts;
public interface ICancelOperation
{
    Task DoCancel(string code);
}
