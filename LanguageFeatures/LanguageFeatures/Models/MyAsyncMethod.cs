﻿using System.Net.Http;
using System.Threading.Tasks;

namespace LanguageFeatures.Models
{
    public class MyAsyncMethod
    {
        public static Task<long?> GetPageLength()
        {
            HttpClient client = new HttpClient();
            var httpTask = client.GetAsync("http:/apress.com");
            return httpTask.ContinueWith((Task<HttpResponseMessage> antecedent) =>
            { return antecedent.Result.Content.Headers.ContentLength; });
        }
    }

    public class MyAsyncMethodAA
    {
        public async static Task<long?> GetPageLength()
        {
            HttpClient client = new HttpClient();
            var httpMessage = await client.GetAsync("http:/apress.com");
            return httpMessage.Content.Headers.ContentLength;
        }
    }
}