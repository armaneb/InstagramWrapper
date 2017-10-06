using InstagramWrapper.DataModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace InstagramWrapper.Api
{
    class InstagramApiService<TType>
    {
        public Uri ApiUri { get; set; }

        public InstagramApiService(Uri apiUri)
        {
            ApiUri = apiUri;
        }

        public Envelope<TType> Get()
        {
            using (var client = new HttpClient())
            {
                var json = client.GetStringAsync(ApiUri).Result;
                var result = JsonConvert.DeserializeObject<Envelope<TType>>(json);
                return result;
            }
        }
        public Envelope<TType> Post(params KeyValuePair<string, string>[] contents)
        {
            using (var client = new HttpClient())
            {
                var content = new FormUrlEncodedContent(contents);
                var postRes = client.PostAsync(ApiUri, content).Result;
                var json = postRes.Content.ReadAsStringAsync().Result;
                var result = JsonConvert.DeserializeObject<Envelope<TType>>(json);
                return result;
            }
        }
        public Envelope<TType> Delete()
        {
            using (var client = new HttpClient())
            {
                var deleteRes = client.DeleteAsync(ApiUri).Result;
                var json = deleteRes.Content.ReadAsStringAsync().Result;
                var result = JsonConvert.DeserializeObject<Envelope<TType>>(json);
                return result;
            }
        }
    }
}
