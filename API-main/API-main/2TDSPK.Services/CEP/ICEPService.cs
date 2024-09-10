namespace _2TDSPK.Services.CEP
{
    public interface ICEPService
    {
        Task<AddressResponse> GetAddressbyCEP(string CEP); /*08738-240*/
    }
}
