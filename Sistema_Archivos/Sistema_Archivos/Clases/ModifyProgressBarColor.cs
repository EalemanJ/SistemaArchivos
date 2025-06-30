using System;
using System.Runtime.InteropServices;

namespace Sistema_Archivos
{
    public static class ModifyProgressBarColor
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        private static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr w, IntPtr l);

        public static void SetState(int state)
        {
            SendMessage(Sesion.ProgressBar.Handle, 1040, (IntPtr)state, IntPtr.Zero);
        }
    }
}