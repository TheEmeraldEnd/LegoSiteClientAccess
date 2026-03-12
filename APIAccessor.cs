namespace LegoSiteClientAccess
{
    public static class APIAccessor
    {
        public static string SendGetRequest(string incomingURL)
        {
            string json = "";
            using (var client = new HttpClient())
            {
                var endpoint = new Uri(incomingURL);
                var result = client.GetAsync(endpoint).Result;
                json = result.Content.ReadAsStringAsync().Result;
            }
            return json;
        }
    }
}
