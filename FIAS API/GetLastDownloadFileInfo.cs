using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
namespace TestAssignmentSitek.FIAS_API
{
    public class GetLastDownloadFileInfo
    {
        private const string FIAS_LastFileInfo = @"https://fias.nalog.ru/WebServices/Public/GetLastDownloadFileInfo";
        public async Task<string> GetSourseLink()
        {
            try
            {

                using (var httpClient = new HttpClient())
                {
                    using (var request = new HttpRequestMessage(new HttpMethod("GET"), FIAS_LastFileInfo))
                    {
                        var response = await httpClient.SendAsync(request);
                        string line = await response.Content.ReadAsStringAsync();
                        FIAS_Model fIAS_Model = JsonConvert.DeserializeObject<FIAS_Model>(line);
                        
                        return fIAS_Model.Kladr47ZUrl;
                    }
                }
            }
            catch(Exception ex) 
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
