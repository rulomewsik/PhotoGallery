using Newtonsoft.Json;
using RestSharp;
using System;

namespace PhotoGallery.Core.Helpers.Extensions
{
    public static class DeserializeExtension
    {
        public static T ConvertTo<T>(this IRestResponse response) where T : new()
        {
            var json = response.Content;
            if (response.StatusCode == System.Net.HttpStatusCode.OK && !string.IsNullOrWhiteSpace(json))
            {
                return JsonConvert.DeserializeObject<T>(json);
            }
            else
            {
                return (T)Activator.CreateInstance(typeof(T));
            }
        }
    }
}