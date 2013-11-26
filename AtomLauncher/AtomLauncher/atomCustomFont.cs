using System;
using System.Drawing;
using System.Drawing.Text;
using System.Runtime.InteropServices;

namespace AtomLauncher
{
    class atomCustomFont
    {
        [DllImport("gdi32.dll")]
        internal static extern IntPtr AddFontMemResourceEx(IntPtr pbfont, uint cbfont, IntPtr pdv, [In] ref uint pcFonts);

        public static FontFamily loadFont()
        {
            byte[] fontArray = AtomLauncher.Properties.Resources.visitor2;
            int dataLength = AtomLauncher.Properties.Resources.visitor2.Length;

            IntPtr ptrData = Marshal.AllocCoTaskMem(dataLength);

            Marshal.Copy(fontArray, 0, ptrData, dataLength);

            uint cFonts = 0;

            AddFontMemResourceEx(ptrData, (uint)fontArray.Length, IntPtr.Zero, ref cFonts);

            PrivateFontCollection pfc = new PrivateFontCollection();

            pfc.AddMemoryFont(ptrData, dataLength);

            Marshal.FreeCoTaskMem(ptrData);

            return pfc.Families[0];
        }
    }
}
