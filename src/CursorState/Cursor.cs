using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace CursorState
{
    public static class Cursor
    {

        /// <summary>
        /// Use this method to get information
        /// </summary>
        /// <returns></returns>
        public static CURSORINFO GetInfoCursor()
        {
            CURSORINFO pci;
            pci.cbSize = Marshal.SizeOf(typeof(CURSORINFO));
            GetCursorInfo(out pci);
            return pci;
        }


        /// <summary>
        /// Mouse coordinates on the screen
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public Int32 x;
            public Int32 y;
        }


        /// <summary>
        /// All informations of the cursor
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct CURSORINFO
        {
            public Int32 cbSize;        // Specifies the size, in bytes, of the structure. 
                                        
            public Int32 flags;         // Specifies the cursor state. This parameter can be one of the following values:
                                        //    0                 The cursor is hidden.
                                        //    CURSOR_SHOWING    The cursor is showing.

            public IntPtr hCursor;      // Handle to the cursor. 

            public POINT ptScreenPos;   // A POINT structure that receives the screen coordinates of the cursor. 
        }


        /// <summary>
        /// Get Cursor Infor form user32.dll
        /// </summary>
        /// <param name="pci"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        private static extern bool GetCursorInfo(out CURSORINFO pci);
    }
}
