namespace DesktopWallpaper.Logic
{
    public class WindowsOps
    {
        private static IDesktopWallpaper dw;
        /// <summary>
        /// 设置壁纸
        /// </summary>
        /// <param name="path">壁纸路径</param>
        public static void SetWallpaper(string path)
        {
            if (dw == null)
                dw = (new DesktopWallpaperClass()) as IDesktopWallpaper;
            dw.SetWallpaper(dw.GetMonitorDevicePathAt(0), path);
        }
    }
}