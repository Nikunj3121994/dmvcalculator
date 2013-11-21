using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ps.dmv.common.Helpers
{
    /// <summary>
    /// WebPageParser
    /// </summary>
    public class WebPageParser
    {
        private List<string> _webPageParsed = null;

        /// <summary>
        /// Parses the web page.
        /// </summary>
        /// <param name="webPage">The web page.</param>
        public async Task ParseWebPage(string url)
        {
            string webPageContent = await this.GetWebPageContent(url);

            _webPageParsed = webPageContent.Split('<').ToList();
        }

        /// <summary>
        /// Gets the web page node.
        /// </summary>
        /// <param name="elementId">The element identifier.</param>
        /// <returns></returns>
        public string GetWebPageNode(string elementId)
        {
            return this.GetWebPageNode(elementId, 0);
        }

        /// <summary>
        /// Gets the web page node.
        /// </summary>
        /// <param name="elementId">The element identifier.</param>
        /// <returns></returns>
        public string GetWebPageNode(string elementId, int inAdvanceNodes)
        {
            string element = _webPageParsed.Where(node => node.Contains(elementId)).AsParallel().FirstOrDefault();

            return element;
        }

        /// <summary>
        /// Gets the content of the web page node.
        /// </summary>
        /// <param name="webPageNode">The web page node.</param>
        /// <returns></returns>
        public string GetWebPageNodeNumericContent(string webPageNode)
        {
            int indexOfCloseAnglebracket = webPageNode.IndexOf('>');

            string valueNode = webPageNode.Substring(indexOfCloseAnglebracket + 1).Replace(",", String.Empty).Replace(".", String.Empty);//TODO improve globalization parsing
             
            string resultString = Regex.Match(valueNode, @"\d+").Value;

            return resultString;
        }

        /// <summary>
        /// Gets the content of the web page node string.
        /// </summary>
        /// <param name="webPageNode">The web page node.</param>
        /// <returns></returns>
        public string GetWebPageNodeStringContent(string webPageNode)
        {
            int indexOfCloseAnglebracket = webPageNode.IndexOf('>');

            string valueNode = webPageNode.Substring(indexOfCloseAnglebracket + 1);

            string resultString = valueNode.Trim().Trim('\r', '\n', 't');

            return resultString;
        }

        public string GetWebPageAttributeStringContent(string webPageNode, string attribute)
        {
            int indexOfStartOfAttributeValue = webPageNode.IndexOf(attribute + "=\"");

            string attributeDataLarge = webPageNode.Substring(indexOfStartOfAttributeValue);

            string attributeDataTrim = attributeDataLarge.Split('"').Skip(1).FirstOrDefault();

            string resultString = attributeDataTrim.Trim().Trim('\r', '\n', 't');

            return resultString;
        }

        /// <summary>
        /// Gets the content of the web page.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception">Web exception, status:  + status</exception>
        private async Task<string> GetWebPageContent(string url)
        {
            WebRequest webRequest = WebRequest.Create(url);

            string responseFromServer = null;

            using (WebResponse webResponse = await webRequest.GetResponseAsync())
            {
                string status = ((HttpWebResponse)webResponse).StatusDescription;

                if (status == "OK")
                {
                    using (Stream dataStream = webResponse.GetResponseStream())
                    {
                        StreamReader reader = new StreamReader(dataStream);

                        responseFromServer = reader.ReadToEnd();
                    }
                }
                else
                {
                    throw new Exception("Web exception, status: " + status);
                }
            }

            return responseFromServer;
        }
    }
}
