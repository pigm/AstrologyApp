using System;
using Plugin.Connectivity;

namespace HoroscopoApp.Utils.Utils
{
    /// <summary>
    /// Validation utils.
    /// </summary>
    public static class ValidationUtils
    {
        /// <summary>
        /// Gets the network status.
        /// </summary>
        /// <returns><c>true</c>, if network status was gotten, <c>false</c> otherwise.</returns>
        public static bool GetNetworkStatus()
        {
            return CrossConnectivity.Current.IsConnected;
        }
    }
}