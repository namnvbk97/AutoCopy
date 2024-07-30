using CsAutoGui;
using SW.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using WPF.Common;

namespace AutoCopy
{
    public class MainContext: NotifyPropertyChanged
    {
        KeyboardHook hook = new KeyboardHook();
        public MainContext() 
        { 
            
            hook.Install();
            hook.KeyDown += KeyDown;
        }
        bool m_break = false;
        private string _text = string.Empty;
        public string Text
        {
            get => _text; set { _text = value; OnPropertyChanged(); }
        }
        private void KeyDown(KeyboardHook.VKeys key)
        {
            if (key == KeyboardHook.VKeys.F10)
            {
                m_break = false;
                AutoGui aaa = new AutoGui();
                Thread thread = new Thread(() =>
                {
                    while (m_break == false)
                    {
                        aaa.HotKey(Keys.ControlKey, Keys.A);
                        aaa.HotKey(Keys.ControlKey, Keys.C);
                        
                        DispatcherService.Invoke(() =>
                        {
                            string textFromClipboard = System.Windows.Clipboard.GetText();
                            Text += textFromClipboard;
                        });
                        Thread.Sleep(50);
                        aaa.KeyDown(new System.Windows.Forms.Keys[1] { System.Windows.Forms.Keys.Down });
                    }
                   
                });
                thread.IsBackground = true;
                thread.Start();
            }
            if(key == KeyboardHook.VKeys.F9)
            {
                hook.Uninstall();
                m_break = true;
            }
        }
    }
}
