﻿using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace DungeonsAndDragonsApp.Model
{
    public static class API
    {
        public static T Get<T>(string webAddress)
        {
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(webAddress);
            httpWebRequest.Method = "GET";
            try
            {
                HttpWebResponse httpWebResponse =  (HttpWebResponse)httpWebRequest.GetResponse();
                string text = new StreamReader(httpWebResponse.GetResponseStream()).ReadToEnd();
                return JsonConvert.DeserializeObject<T>(text);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to GET API route '" + webAddress + "', " + ex.Message);
            }
        }
    }

    //public static async Task<T> GetAsync<T>(string webAddress)
    //{
    //    HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(webAddress);
    //    httpWebRequest.Method = "GET";
    //    try
    //    {
    //        HttpWebResponse httpWebResponse = await (HttpWebResponse)httpWebRequest.GetResponseAsync();
    //        string text = new StreamReader(httpWebResponse.GetResponseStream()).ReadToEnd();
    //        return JsonConvert.DeserializeObject<T>(text);
    //    }
    //    catch (Exception ex)
    //    {
    //        throw new Exception("Failed to GET API route '" + webAddress + "', " + ex.Message);
    //    }
    //}
}

