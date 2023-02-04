namespace CatFact.Helpers
{
    #region Usings

    using CatFact.Model;
    using Newtonsoft.Json;
    using System;
    using System.Configuration;
    using System.IO;
    using System.Net.Http;

    #endregion Usings
    public class CatFactHelper
    {
        #region Properties

        private readonly string fileName;
        private readonly string url;

        #endregion Properties

        #region Constructors

        public CatFactHelper()
        {
            fileName = ConfigurationManager.AppSettings["FileName"];
            url = ConfigurationManager.AppSettings["CatFactUrl"];
        }

        #endregion Constructors

        #region Public Methods

        public void GetSomeFactsAboutCat()
        {
            try
            {
                var httpClientHandler = new HttpClientHandler();
                var httpClient = new HttpClient(httpClientHandler)
                {
                    BaseAddress = new Uri(url)
                };
                using (var response = httpClient.GetAsync(url))
                {
                    string responseBody = response.Result.Content.ReadAsStringAsync().Result;
                    var catFact = DeserializeHappyCatFact(responseBody);
                    WriteSingleLine(catFact);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion Public Methods

        #region Private Methods

        private void WriteSingleLine(HappyCatFact fact)
        {
            try
            {
                using (var streamWriter = File.AppendText(fileName))
                {
                    streamWriter.WriteLine($"Did you know that \"{fact?.Fact}\"? - Length of this fabulous fact: {fact?.Length}.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Unable to write fact to file :(  More Details: {ex.Message}.");
            }
        }

        private HappyCatFact DeserializeHappyCatFact(string fact)
        {
            try
            {
                var catFact = JsonConvert.DeserializeObject<HappyCatFact>(fact);
                return catFact;
            }
            catch (Exception ex)
            {
                throw new Exception($"Unable to deserialize CatFact :(  More Details: {ex.Message}.");
            }
        }

        #endregion Private Methods
    }
}
