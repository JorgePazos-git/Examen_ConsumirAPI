﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AppExamen.APIConsumer
{
    public class APIConsumer<T>
    {
        public static T[] Select(string apiUrl)
        {
            var api = new System.Net.WebClient();
            api.Headers.Add("content-type", "application/json");
            api.Headers.Add("Accept", "application/json");
            var json = api.DownloadString(apiUrl);
            var datos = Newtonsoft.Json.JsonConvert.DeserializeObject<T[]>(json);
            return datos;
        }

        public static T SelectOne(string apiUrl)
        {
            var api = new System.Net.WebClient();
            api.Headers.Add("content-type", "application/json");
            api.Headers.Add("Accept", "application/json");
            var json = api.DownloadString(apiUrl);
            var datos = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(json);
            return datos;
        }

        public static bool Insert(string apiUrl, T data)
        {
            var api = new System.Net.WebClient();
            api.Headers.Add("content-type", "application/json");
            api.Headers.Add("Accept", "application/json");
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            json = api.UploadString(apiUrl, "POST", json);
            var resultado = Newtonsoft.Json.JsonConvert.DeserializeObject<bool>(json);
            return resultado;
        }

        public static void Update(string apiUrl, T data)
        {
            var api = new System.Net.WebClient();
            api.Headers.Add("content-type", "application/json");
            api.Headers.Add("Accept", "application/json");
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            json = api.UploadString(apiUrl, "PUT", json);
        }

        public static void Delete(string apiUrl)
        {
            var api = new System.Net.WebClient();
            api.Headers.Add("content-type", "application/json");
            api.Headers.Add("Accept", "application/json");
            api.UploadString(apiUrl, "DELETE", "");
        }
    }
}
