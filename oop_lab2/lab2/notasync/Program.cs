﻿using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
class Program
{
    static void Main()
    {
        Stopwatch time = new Stopwatch();
        time.Start();
        var client = new HttpClient();
        client.DefaultRequestHeaders.Add("User-Agent", "MyApp");

        HttpResponseMessage response = client.GetAsync("https://api.hh.ru/vacancies?employer_id=3094855").Result;
        string json = response.Content.ReadAsStringAsync().Result;
        File.WriteAllText("vacancies_mgtu_stankin_sync.json", json);

        HttpResponseMessage response1 = client.GetAsync("https://api.hh.ru/vacancies?employer_id=3094855").Result;
        string json1 = response.Content.ReadAsStringAsync().Result;
        File.WriteAllText("vacancies_mgtu_stankin_sync.json", json);

        HttpResponseMessage response2 = client.GetAsync("https://api.hh.ru/vacancies?employer_id=3094855").Result;
        string json2 = response.Content.ReadAsStringAsync().Result;
        File.WriteAllText("vacancies_mgtu_stankin_sync.json", json);
        time.Stop();
        Console.WriteLine("Общее время работы: " + time.ElapsedMilliseconds);
    }
}