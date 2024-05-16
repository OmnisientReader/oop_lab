using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

class Program
{
        static async Task Main()
        {

            Stopwatch time = new Stopwatch();
            time.Start();

            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", "MyApp");

            HttpResponseMessage response1 = await client.GetAsync("https://api.hh.ru/vacancies?text=developer");
            string json1 = await response1.Content.ReadAsStringAsync();
            File.WriteAllText("vacancies_developer.json", json1);
            
            HttpResponseMessage response2 = await client.GetAsync("https://api.hh.ru/vacancies?text=designer");
            string json2 = await response2.Content.ReadAsStringAsync();
            File.WriteAllText("vacancies_designer.json", json2);



            HttpResponseMessage response = await client.GetAsync("https://api.hh.ru/vacancies?employer_id=3094855");
            string json = await response.Content.ReadAsStringAsync();
            File.WriteAllText("vacancies_mgtu_stankin.json", json);


            time.Stop();
            Console.WriteLine("Общее время работы: " + time.ElapsedMilliseconds);
        }
}
