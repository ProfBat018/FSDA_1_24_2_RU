using System;
using System.Runtime.InteropServices;

class Program
{
    static void Main()
    {
        ShowMessageBox("Legacy Code", "Это пример вызова MessageBox в MacOS через P/Invoke");
    }

    static void ShowMessageBox(string title, string message)
    {
        IntPtr alert = objc_msgSend(objc_getClass("NSAlert"), sel_registerName("new"));
        
        objc_msgSend(alert, sel_registerName("setMessageText:"), NSString_Create(title));
        objc_msgSend(alert, sel_registerName("setInformativeText:"), NSString_Create(message));
        objc_msgSend(alert, sel_registerName("addButtonWithTitle:"), NSString_Create("OK"));

        objc_msgSend(alert, sel_registerName("runModal"));
    }

    // P/Invoke для взаимодействия с Objective-C API
    [DllImport("/usr/lib/libobjc.dylib")]
    private static extern IntPtr objc_getClass(string className);

    [DllImport("/usr/lib/libobjc.dylib")]
    private static extern IntPtr sel_registerName(string selector);

    [DllImport("/usr/lib/libobjc.dylib")]
    private static extern IntPtr objc_msgSend(IntPtr receiver, IntPtr selector, IntPtr arg);

    private static IntPtr NSString_Create(string str)
    {
        IntPtr nsStringClass = objc_getClass("NSString");
        IntPtr initWithUTF8String = sel_registerName("stringWithUTF8String:");
        return objc_msgSend(nsStringClass, initWithUTF8String, Marshal.StringToHGlobalAuto(str));
    }
}