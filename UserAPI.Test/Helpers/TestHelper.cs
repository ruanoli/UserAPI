﻿using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserAPI.Test.Helpers
{
    public class TestHelper
    {
        //criando um objeto para executar chamadas para a API.
        public static HttpClient CreateClient()
        {
            var factory = new WebApplicationFactory<Program>();
            var client = factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                BaseAddress = new Uri("http://localhost:5134") // Define a url e porta manualmente
            });

            return client;
        }

        //serializando os dados para o formato JSon
        public static StringContent CreateContent(object obj)
        {
            return new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
        }

        //método para ler e deserializar o retorno da API após a execução de uma chamada.
        public static T ReadResponse<T>(HttpResponseMessage message)
        {
            var result = JsonConvert.DeserializeObject<T>(message.Content.ReadAsStringAsync().Result);
            return result;
        }

        public static List<T> ReadResponseList<T>(HttpResponseMessage message, string listPropertyName = null)
        {
            var jsonString = message.Content.ReadAsStringAsync().Result;

            // Desserializa para um JObject para acessar a propriedade da lista
            var jsonObject = JsonConvert.DeserializeObject<JObject>(jsonString);

            if (jsonObject == null || !jsonObject.ContainsKey(listPropertyName))
            {
                throw new JsonSerializationException($"A propriedade '{listPropertyName}' não foi encontrada na resposta.");
            }

            var jsonArray = jsonObject[listPropertyName];

            return jsonArray?.ToObject<List<T>>() ?? new List<T>();
        }
    }
}
