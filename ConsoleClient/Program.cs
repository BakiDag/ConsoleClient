using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace ConsoleClient
{
    class Program
    {
		private static HttpClient client = new HttpClient();
		private static Uri _BaseAdress = new Uri("http://localhost:10416/");
		private static string endPoint = "api/Persons";
		public static Person person = new Person();
		private static string Id = "5";
		static void Main(string[] args)
        {
			client.BaseAddress = _BaseAdress;
			client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			bool loopMenu = false;
			string answer = "n";
			int switch_on = 0;

			do {
				Console.Clear();
				Console.WriteLine("Choos Request Operation");
				Console.WriteLine("1: Get");
				Console.WriteLine("2: Post");
				Console.WriteLine("3: Put");
				Console.WriteLine("4: Delete");
				switch_on = Convert.ToInt16(Console.ReadLine());
				switch (switch_on) {
					case 1:
						Console.WriteLine("Starting Get Request");
						Get();
						break;
					case 2:
						Console.WriteLine("Starting Post Request");
						Post();
						break;
					case 3:
						Console.WriteLine("Starting Put Request");
						Put();
						break;
					case 4:
						Console.WriteLine("Starting Delete Request");
						Delete();
						break;
					default:
						break;
				}

				Console.WriteLine("Again? y/n");
				answer = Console.ReadLine();
				if (answer == "y")
					loopMenu = true;
				else
					loopMenu = false;

			} while (loopMenu);
			client.Dispose();
		}
		public static void Get() {
			HttpResponseMessage response = client.GetAsync("api/Persons").Result;
			if (response.IsSuccessStatusCode) {
				string returnedContent = response.Content.ReadAsStringAsync().Result;
				Console.WriteLine(returnedContent);
			} else {
				Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
			}

		}

		public static void Post() {
			person.Id = "25";
			person.Name = "John";
			person.Vorname = "Doe";
			Console.WriteLine($"Sending ID: " +
					person.Id
					+ ", Name: " +
					person.Name
					+ ", Vorname: " +
					person.Vorname);
			Console.WriteLine();
			HttpResponseMessage response = client.PostAsJsonAsync("api/Persons", person).Result;
			if (response.IsSuccessStatusCode) {
				string returnedContent = response.Content.ReadAsStringAsync().Result;
				Console.WriteLine("Person added: " + returnedContent);
			} else {
				Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
			}

		}

		public static void Put() {
			person.Id = "85";
			person.Name = "Kellerhan";
			person.Vorname = "David";
			Console.WriteLine($"Sending ID: " +
					person.Id
					+ ", Name: " +
					person.Name
					+ ", Vorname: " +
					person.Vorname);
			Console.WriteLine();
			HttpResponseMessage response = client.PutAsJsonAsync("api/Persons", person).Result;
			if (response.IsSuccessStatusCode) {
				string returnedContent = response.Content.ReadAsStringAsync().Result;
				Console.WriteLine("Person updated: " + returnedContent);
			} else {
				Console.WriteLine("Error");
				Console.WriteLine(response.StatusCode.ToString());
			}

		}
		public static void Delete() {
			person.Id = "85";
			person.Name = "Kellerhan";
			person.Vorname = "David";
			Console.WriteLine($"Sending ID: " +
					person.Id
					+ ", Name: " +
					person.Name
					+ ", Vorname: " +
					person.Vorname);
			Console.WriteLine();
			HttpResponseMessage response = client.PostAsJsonAsync("api/Persons/Delete", person).Result;

			if (response.IsSuccessStatusCode) {
				string returnedContent = response.Content.ReadAsStringAsync().Result;
				Console.WriteLine("Person deleted: " + returnedContent);
			} else {
				Console.WriteLine("Error");
				Console.WriteLine(response.StatusCode.ToString());
			}
		}


	}
    
}
