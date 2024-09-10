using _2TDSPK.Services.CEP;

namespace _2TDSPK.Services.Test.CEP
{
    //A - Arrange (Preparação)
    //A - Action (Ação)
    //A - Assert (Resultado)

    public class CEPServiceTest
    {
        private readonly CEPService _cepService;
        private readonly string cepValid = "08737-250";
        private readonly string cepInvalid = "00000-000";
        private readonly string logradouroExpected = "Rua Maria das Dores da Conceição";

        public CEPServiceTest()
        {
            //A - Arrange
            _cepService = new CEPService();
        }

        [Fact]
        public async Task GetAddressbyCEP_ReturnAddressResponse_WhenCEPIsValid()
        {       
            //A - Action (Ação)
            AddressResponse addressResponse = await _cepService.GetAddressbyCEP(cepValid);

            //A - Assert (Resultado - Verificação)
            Assert.NotNull(addressResponse);
            Assert.Equal(logradouroExpected, addressResponse.Logradouro);

        }

        [Fact]
        public async Task GetAddressbyCEP_ReturnNull_WhenCEPIsInvalid()
        {
            //A - Action (Ação)
            AddressResponse addressResponse = await _cepService.GetAddressbyCEP(cepInvalid);

            //A - Assert (Resultado - Verificação)
            Assert.NotNull(addressResponse);
        }
    }
}
