using RestSharp;
using System;
using System.Configuration;
using System.Threading.Tasks;


namespace _2c2pConsoleAPI
{
    class Program
    {
        static Task Main(string[] args)
        {
            string userInput;
            do
            {
                Console.WriteLine("Getting Bearer token from API ");
                string token = GetToken();
                Console.WriteLine(token);

                Console.WriteLine("Executing External API Post endpoint ");
                ExecuteExternalAPI(token);
                // Execute your method or logic here
                Console.WriteLine("Method executed!");
                // Prompt the user to continue
                Console.Write("Do you want to execute the method again? (y/n): ");
                userInput = Console.ReadLine();

            } while (userInput.Equals("y", StringComparison.OrdinalIgnoreCase));

            Console.WriteLine("Program ended.");
            return Task.CompletedTask;
        }


        /// <summary>
        /// Method to call API endpoint to processing multiple payments 
        /// </summary>
        /// <param name="bearerToken"></param>
        private static void ExecuteExternalAPI(string bearerToken)
        {
            try
            {
                string apiUrl = ConfigurationManager.AppSettings.Get("URLPayment");
                var options = new RestClientOptions(apiUrl);

                var client = new RestClient(options);
                var request = new RestRequest("");
                request.AddHeader("accept", "application/json");
                request.AddHeader("Authorization", "Bearer " + bearerToken);
                request.AddHeader("Content-type", "application/json");
                request.AddHeader("My-Custom-Header", "foobar");
                var response = client.Post(request);
                Console.WriteLine("response from API!" + response.Content);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        /// <summary>
        /// Method to generate bearer token to acces api
        /// </summary>
        /// <returns></returns>
        static string GetToken()
        {
            string urlLogin = ConfigurationManager.AppSettings.Get("URLLogin");

            var options = new RestClientOptions(urlLogin);
            var client = new RestClient(options);
            string jsonString = "{\r\n  \"email\": \"admin.admin\",\r\n  \"password\": \"3Sixty@2024\",\r\n  \"twoFactorCode\": \"N\",\r\n  \"twoFactorRecoveryCode\": \"N\"\r\n}";

            var request = new RestRequest("");
            request.AddJsonBody(jsonString, false);
            var response = client.Post(request);
            return response.Content;
        }

    }
}
