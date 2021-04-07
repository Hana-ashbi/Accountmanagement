using Newtonsoft.Json;
using SharedLib.Model;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SharedLib.Http
{
    public class TransactionService
    {
        public HttpClient Client { get; }
        private string BaseURL = "http://localhost:56756/";
        private string createAccountTransactionURL = "api/transaction";
        private string ListAccountTransactionsURL = "api/transaction/listAccountTransactions";
        public TransactionService(HttpClient client)
        {
            client.BaseAddress = new Uri(BaseURL);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            Client = client;
        }

        public async Task<string> PostAccountTransaction(string contents)
        {
            try
            {
                var response = await Client.PostAsync(
                            createAccountTransactionURL, new StringContent(contents, Encoding.UTF8, "application/json")
                            );

                response.EnsureSuccessStatusCode();

                return await response.Content.ReadAsStringAsync();

            }
            catch (Exception _)
            {
                /*Handle Error*/
            }

            return "";
        }

        public async Task<List<AccountTransaction>> ListAccountsTransactions(string userID, List<string> accountIds)
        {

            try
            {
                string contents = JsonConvert.SerializeObject(new { UserID = userID, Accounts = accountIds });
                var response = await Client.PostAsync(
                            ListAccountTransactionsURL, new StringContent(contents, Encoding.UTF8, "application/json")
                            );

                response.EnsureSuccessStatusCode();

                response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                string content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<AccountTransaction>>(content);
            }
            catch (Exception _)
            {
                /*Handle Error*/
            }

            return null;
        }
    }
}
