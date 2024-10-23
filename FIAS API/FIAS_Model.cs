using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAssignmentSitek.FIAS_API
{
    class FIAS_Model
    {
        public int VersionId { get; set; }
        public string TextVersion { get; set; }
        public string FiasCompleteDbfUrl { get; set; }
        public string FiasCompleteXmlUrl { get; set; }
        public string FiasDeltaDbfUrl { get; set; }
        public string FiasDeltaXmlUrl { get; set; }
        public string Kladr4ArjUrl { get; set; }
        public string Kladr47ZUrl { get; set; }
        public string GarXMLFullURL { get; set; }
        public string GarXMLDeltaURL { get; set; }
        public DateTime ExpDate { get; set; }
        public string Date { get; set; }
        public FIAS_Model(int versionId, string textVersion, string fiasCompleteDbfUrl, string fiasCompleteXmlUrl, string fiasDeltaDbfUrl, string fiasDeltaXmlUrl, string kladr4ArjUrl, string kladr47ZUrl, string garXMLFullURL, string garXMLDeltaURL, DateTime expDate, string date)
        {
            VersionId = versionId;
            TextVersion = textVersion;
            FiasCompleteDbfUrl = fiasCompleteDbfUrl;
            FiasCompleteXmlUrl = fiasCompleteXmlUrl;
            FiasDeltaDbfUrl = fiasDeltaDbfUrl;
            FiasDeltaXmlUrl = fiasDeltaXmlUrl;
            Kladr4ArjUrl = kladr4ArjUrl;
            Kladr47ZUrl = kladr47ZUrl;
            GarXMLFullURL = garXMLFullURL;
            GarXMLDeltaURL = garXMLDeltaURL;
            ExpDate = expDate;
            Date = date;
        }
    }
}
