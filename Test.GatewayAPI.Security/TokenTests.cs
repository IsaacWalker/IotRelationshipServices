using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Web.Iot.APIGatewayService.Security;
using Web.Iot.Models.Device;

namespace Test.GatewayAPI.Security
{
    [TestClass]
    public class TokenTests
    {

        [TestMethod]
        public void Test_ValidToken()
        {
            IJwtTokenService tokenService = new TokenGenerator(null);
            DeviceModel device = CreateDeviceModel();


            TokenParams tokenParams = new TokenParams("TOKEN", "Issuer", "Audience");
            var token = tokenService.Generate(device, tokenParams);

            Assert.IsTrue(tokenService.Validate(token, tokenParams));
        }


        [TestMethod]
        public void Test_InvalidToken()
        {
            IJwtTokenService tokenService = new TokenGenerator(null);

            TokenParams tokenParams = new TokenParams(Guid.NewGuid().ToString(), "ISSUER", "AUDIENCE");
            var token = tokenService.GenerateFakeToken();

            Assert.IsFalse(tokenService.Validate(token, tokenParams));
        }


        private DeviceModel CreateDeviceModel()
        {
            DeviceModel device = new DeviceModel()
            {
                MacAddress = Guid.NewGuid().ToString(),
                Manufacturer = "HMD Global",
                Model = "Nokia 7.2",
                BluetoothName = "Nokia 7.2"
            };

            return device;
        }
    }
}
