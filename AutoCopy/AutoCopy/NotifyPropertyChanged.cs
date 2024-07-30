// Lớp NotifyPropertyChanged: Kiểm tra thay đổi của biến Update lên giao diện, tức là gán một biến bằng value thì giao diện cần phải thay đổi theo
// Tạo view model, thì phải kế thừa cái này
// đây là lớp cha (parrent cho view model), sẽ định nghĩa tiếp cụ thể hơn khi sử dụng
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace WPF.Common
{
    public class NotifyPropertyChanged : INotifyPropertyChanged
    {
        private bool _ischanged = false;
        // kiểm tra chương trình đã gọi OnPropertyChanged chưa
        public bool IsChanged
        {
            get => _ischanged;
            set => _ischanged = value;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
            IsChanged = true;
        }
    }
}
