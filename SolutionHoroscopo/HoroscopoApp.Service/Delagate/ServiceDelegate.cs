using System;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net;
using System.Threading.Tasks;
using HoroscopoApp.Utils.Properties;
using HoroscopoApp.Utils.Utils;
using HoroscopoApp.Service.Result;
using HoroscopoApp.Models.Models;

namespace HoroscopoApp.Service.Delagate
{
    /// <summary>
    /// Service delegate.
    /// </summary>
    public class ServiceDelegate
    {
        static ServiceDelegate instance = null;
        static readonly HttpClient client = new HttpClient();

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <value>The instance.</value>
        public static ServiceDelegate Instance
        {
            get
            {
                if (instance == null)
                    instance = new ServiceDelegate();
                return instance;
            }
        }

        /// <summary>
        /// Gets the locales.
        /// </summary>
        /// <returns>The locales.</returns>
        public async Task<ServiceResult> GetHoroscopo()
        {
            string baseUrl = Constante.API_URL_SERVICE;
            ServiceResult result = new ServiceResult();
            if (GetNetworkStatus())
            {
                try
                {
                    var response = await client.GetAsync(baseUrl);
                    var responseString = await response.Content.ReadAsStringAsync();

                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        HoroscopoActual horoscopo = JsonConvert.DeserializeObject<HoroscopoActual>(responseString);
                        result.Success = true;
                        result.Response = horoscopo;
                    }
                    else
                    {
                        result.Success = false;
                        result.Message = response.StatusCode.ToString();
                        result.Response = 999;
                    }
                }
                catch (Exception e)
                {
                    result.Success = false;
                    result.Message = e.Message;
                    result.Response = 999;
                }
            }
            else
            {
                result.Success = false;
                result.Response = 1000;
                result.Message = Constante.NOTCONNECTION;
            }
            return result;
        }

        /// <summary>
        /// Gets the network status.
        /// </summary>
        /// <returns><c>true</c>, if network status was gotten, <c>false</c> otherwise.</returns>
        private bool GetNetworkStatus()
        {
            return ValidationUtils.GetNetworkStatus();
        }
    }
}