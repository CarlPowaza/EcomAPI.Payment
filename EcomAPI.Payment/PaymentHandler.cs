﻿using System.Net.Http.Headers;
using System.Text;

namespace EcomAPI.Payment
{
    public class PaymentHandler 
    {
        private  HiddenVar hiddenVar = new HiddenVar();
        public async Task<string> HandlePaymentAsync(String PayersInfo) {
// client.BaseAddress = new System.Uri("https://api-m.sandbox.paypal.com/v1/oauth2/token");

            //TODO - MOVE THIS TO ENV VAR!!
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.AcceptLanguage.Add(new StringWithQualityHeaderValue("en_US"));

                var clientId = "<client_id>";
                var clientSecret = "<client_secret>";
                var bytes = Encoding.UTF8.GetBytes($"{clientId}:{clientSecret}");

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(bytes));

                var keyValues = new List<KeyValuePair<string, string>>();
                keyValues.Add(new KeyValuePair<string, string>("grant_type", "client_credentials"));
                var responseMessage = await client.PostAsync("https://api.sandbox.paypal.com/v1/oauth2/token", new FormUrlEncodedContent(keyValues));
                viewModel.ResponseMessage = await responseMessage.Content.ReadAsStringAsync();
            }

            return hiddenVar.PAYPAL_ID ;

        }



  

    }
}
