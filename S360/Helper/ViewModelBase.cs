using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace S360
{
    public class ViewModelBase : DependencyObject, INotifyPropertyChanged
    {
        /// <summary>
        /// Property Change Event
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Idle Timer
        /// </summary>
        private static DispatcherTimer idleTimer;

        /// <summary>
        /// GetLast InputInfo
        /// </summary>
        /// <param name="dummy">Parameter Object</param>
        /// <returns>Return Value</returns>
        [DllImport("User32.dll")]
        private static extern bool GetLastInputInfo(ref LASTINPUTINFO dummy);

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModelBase"/> class.
        /// </summary>
        public ViewModelBase()
        {
            this.TimeOutTrigger();
        }

        /// <summary>
        /// Property Change Method
        /// </summary>
        /// <param name="prop">Property Name</param>
        internal void RaisePropertyChanged(string prop)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }

        private void TimeOutTrigger()
        {
            if (idleTimer == null)
            {
                idleTimer = new DispatcherTimer();
                idleTimer.Interval = TimeSpan.FromSeconds(10);
                idleTimer.Tick += this.OnTimerTick;
                idleTimer.Start();
            }
            else
            {
                idleTimer.Start();
            }
        }
        private void OnTimerTick(object sender, EventArgs e)
        {
            uint idleTime = this.GetIdleTime();
            this.ClearUnUsedMemory();
            int AppTimeOut = Properties.Settings.Default.ApplicationTimeOut;
            if (idleTime > AppTimeOut)
            {
                Application.Current.Shutdown();
            }
        }

        /// <summary>
        /// Clear un used memory
        /// </summary>
        private void ClearUnUsedMemory()
        {
            try
            {
                MemoryManagement.FlushMemory();
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// GetIdle Time
        /// </summary>
        /// <returns>Return Value</returns>
        private uint GetIdleTime()
        {
            LASTINPUTINFO lastUserAction = new LASTINPUTINFO();
            lastUserAction.CbSize = (uint)System.Runtime.InteropServices.Marshal.SizeOf(lastUserAction);
            GetLastInputInfo(ref lastUserAction);
            return (uint)Environment.TickCount - lastUserAction.DwTime;
        }
    }
}
