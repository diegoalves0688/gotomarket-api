using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace GoToMarket.CieloConnector
{
	public class CieloClient
	{

		/// https://formularios2.cielo.com.br/form1b/api-cielo-convencional/passo-1

		private static readonly string CieloSandboxPostUrl = "https://apisandbox.cieloecommerce.cielo.com.br";

		private static readonly string CieloPostUrl = "https://api.cieloecommerce.cielo.com.br";

		private static readonly string CieloSandboxQueryUrl = "https://apiquerysandbox.cieloecommerce.cielo.com.br";

		private static readonly string CieloQueryUrl = "https://apiquery.cieloecommerce.cielo.com.br";

		public static CieloPaymentResponse PostPayment(Order order)
		{
			using (var cancellationToken = new CancellationTokenSource(TimeSpan.FromMilliseconds(20000)))
			{
				try
				{
					var endpoint = $"{CieloSandboxPostUrl}/1/sales/";

					var request = ParsePaymentRequest(order);

					Console.WriteLine($"Request to: {endpoint}");

					using (var httpClient = new HttpClient())
					{
						httpClient.Timeout = TimeSpan.FromMilliseconds(15000);

						var requestContent = new StringContent(JsonConvert.SerializeObject(request));

						requestContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

						var response = httpClient.PostAsync(endpoint, requestContent, cancellationToken.Token).Result;

						string content = response.Content.ReadAsStringAsync().Result;

						Console.WriteLine($"Response: {content}");

						response.EnsureSuccessStatusCode();

						return JsonConvert.DeserializeObject<CieloPaymentResponse>(content);
					}
				}
				catch (Exception ex)
				{
					var message = $"Error on trying send payment: {ex.Message} InnerException: {ex.InnerException}";
					Console.WriteLine(message);
				}
				return null;
			}
		}

		internal static CieloPaymentRequest ParsePaymentRequest(Order order)
		{
			var buyerName = MysqlClient.GetUserByIdInMysql(order.BuyerId.ToString()).Name;
			var request = new CieloPaymentRequest()
			{
				MerchantOrderId = Guid.NewGuid().ToString(),
				CustomerObj = new CieloPaymentRequest.Customer()
				{
					Name = buyerName
				},
				PaymentObj = new CieloPaymentRequest.Payment()
				{
					Type = "CreditCard",
					Capture = true,
					Amount = order.Value,
					Installments = 1,
					CreditCard = new CieloPaymentRequest.CreditCard()
					{
						CardNumber = order.CardNumber,
						Holder = buyerName,
						ExpirationDate = order.ExpirationDate,
						SecurityCode = order.SecurityCode
					}
				}
			};

			return request;
		}
	}
}
