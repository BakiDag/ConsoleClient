using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace ConsoleClient
{
    class Program
    {
		private static HttpClient client = new HttpClient();
		private static Uri _BaseAdress = new Uri("http://localhost:10416/");
		//private static Uri endPoint = new Uri("api/Numbers");
		private static string Id = "5";
		static void Main(string[] args)
        {		
			client.BaseAddress = _BaseAdress;
			client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

			Console.WriteLine("Start Get");
			Get();
			Console.WriteLine();
			Console.WriteLine("Start Post");
			Post();
			Console.WriteLine();
			Console.WriteLine("Start Put");
			Put();
			Console.WriteLine();
			Console.WriteLine("Start Delete");
			Delete();
			Console.ReadKey();
			client.Dispose();
		}
		public static void Get() {
			HttpResponseMessage response = client.GetAsync("api/Numbers").Result;

			if (response.IsSuccessStatusCode) {
				string returnedContent = response.Content.ReadAsStringAsync().Result;
				Console.WriteLine(returnedContent);
			} else {
				Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
			}

		}

		public static void Post() {
			string _id = "323";
			HttpResponseMessage response = client.PostAsJsonAsync("api/Numbers", _id).Result;
			Console.WriteLine("Sending " + _id);

			if (response.IsSuccessStatusCode) {
				string returnedContent = response.Content.ReadAsStringAsync().Result;
				Console.WriteLine(returnedContent);
			} else {
				Console.WriteLine("Error");
				Console.WriteLine(response.StatusCode.ToString());
			}

		}

		public static void Put() {
			string _id = "323";
			HttpResponseMessage response = client.PutAsJsonAsync("api/Numbers", _id).Result;
			Console.WriteLine("Sending " + _id);

			if (response.IsSuccessStatusCode) {
				string returnedContent = response.Content.ReadAsStringAsync().Result;
				Console.WriteLine(returnedContent);
			} else {
				Console.WriteLine("Error");
				Console.WriteLine(response.StatusCode.ToString());
			}

		}
		public static void Delete() {
			string _id = Id;
			HttpResponseMessage response = client.PostAsJsonAsync("api/Numbers/Delete", _id).Result;

			Console.WriteLine("Sending " + _id);
			if (response.IsSuccessStatusCode) {
				string returnedContent = response.Content.ReadAsStringAsync().Result;
				Console.WriteLine(returnedContent);
			} else {
				Console.WriteLine("Error");
				Console.WriteLine(response.StatusCode.ToString());
			}
		}

	}
    
}
