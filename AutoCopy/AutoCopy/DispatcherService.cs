// DispatcherService.cs: file hỗ trợ gọi Dispatcher.
// dùng cho WPF, check nếu cần mới invoke
// Sử dụng khi chạy Thread muốn thực thi 1 đoạn code Thread khác. 

using System.Windows;
using System.Windows.Threading;

namespace WPF.Common
{
    // Hàm hỗ trợ gọi Dispatcher
    public static class DispatcherService
    {
        public static void Invoke(System.Action action)
        {
            if (Application.Current != null)
            {
                Dispatcher dispatcher = Application.Current.Dispatcher;
                if (dispatcher?.CheckAccess() ?? true)
                {
                    action();
                }
                else
                {
                    dispatcher.Invoke(action);
                }
            }
        }
        public static void BeginInvoke(System.Action action)
        {
            if (Application.Current != null)
            {
                Dispatcher dispatcher = Application.Current.Dispatcher;
                if (dispatcher?.CheckAccess() ?? true)
                {
                    action();
                }
                else
                {
                    dispatcher.BeginInvoke(action);
                }
            }
        }
    }
}

