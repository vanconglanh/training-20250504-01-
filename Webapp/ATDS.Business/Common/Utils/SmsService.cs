
using ATDS.Business.Interfaces;
using Microsoft.Extensions.Options;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace ATDS.Business
{
    public class SmsService : ISmsService
    {
        private readonly SmsSettings _smsSettings;

        public SmsService(IOptions<SmsSettings> options)
        {
            _smsSettings = options.Value;

        }
        public async Task SendMessage(string phoneNumber)
        {

            var smsSetting = new SmsSettings
            {
                ApiUrl = "https://cloudsms.vietguys.biz:4438/api/index.php",
                From = "ATDS",
                U = "ATDS",
                Pwd = "v1x4z12341",
                Sms = "ATDS "
            };
            if (string.IsNullOrEmpty(phoneNumber)) { return; }
            phoneNumber = this.GetFormatedPhoneNumber(phoneNumber);
            var requestObject = new
            {
                from = smsSetting.From,
                u = smsSetting.U,
                pwd = smsSetting.Pwd,
                phone = phoneNumber,
                sms = string.Format(smsSetting.Sms, phoneNumber),
                json = 1
            };

          
            var content = new StringContent(JsonSerializer.Serialize(requestObject), Encoding.UTF8, "application/json");

            var result = await this.SendPostRequest(content, smsSetting);
        }
        private async Task<string> SendPostRequest(StringContent content, SmsSettings smsSettings)
        {
            
            try
            {
                using (var client = new HttpClient())
                {
                
                    var response = await client.PostAsync(smsSettings.ApiUrl, content);
                    if (response.IsSuccessStatusCode)
                        return await response.Content.ReadAsStringAsync();
                    else
                        throw new Exception("Remote server returns error code: " + response.StatusCode);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private  string GetFormatedPhoneNumber(string phoneNumber)
        {
            if (string.IsNullOrEmpty(phoneNumber))
            {
                return null;
            }

            var value = phoneNumber.Replace("-", string.Empty);

            if (value.StartsWith("0"))
            {
                var regex = new Regex("0");

                return regex.Replace(value, "+84", 1);
            }

            if (!value.StartsWith("+84"))
            {
                return "+84" + value;
            }

            return value;
        }
    }
}
