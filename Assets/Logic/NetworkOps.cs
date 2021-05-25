using PexelsDotNetSDK.Api;

namespace DesktopWallpaper.Logic
{
    public class NetworkOps
    {
        private static IDesktopWallpaper dw;

        public static PexelsClient pexelsClient;

        public static void Init()
        {
            pexelsClient = new PexelsClient("563492ad6f91700001000001abee145ae98747cd8160adfdbcde89a3");
        }

      
    }
}