/* C# trainer class.
 * Based on code by Cless
 */

using System;
using System.Diagnostics;
using System.Runtime.InteropServices;


public class Trainer
{
    [DllImport("kernel32")]
    private static extern int OpenProcess(int AccessType, int InheritHandle, int ProcessId);

    [DllImport("kernel32", EntryPoint = "CloseHandle")]
    public static extern int CloseProcessHandle(int Handle);

    [DllImport("kernel32")]
    private static extern double ReadProcessMemory(int Handle, int Address, byte[] Buffer, int Size, ref int BytesRead);

    [DllImport("kernel32", EntryPoint = "ReadProcessMemory")]
    private static extern int ReadProcessMemoryInteger(int Handle, int Address, ref int Value, int Size, ref int BytesRead);

    [DllImport("kernel32", EntryPoint = "ReadProcessMemory")]
    private static extern int ReadProcessMemoryFloat(int Handle, int Address, ref float Value, int Size, ref int BytesRead);

    public static int OpenProcessHandle(string Name)
    {
        const int PROCESS_ALL_ACCESS = 0x1F0FFF;
        Process[] Procs = Process.GetProcessesByName(Name);
        return (Procs.Length != 0) ? OpenProcess(PROCESS_ALL_ACCESS, 0, Procs[0].Id) : 0;
    }

    public static int ReadPointerInteger(int Handle, int Pointer)
    {
        int Value = 0;
        int BytesRead = 0;
        return (Pointer != 0 && ReadProcessMemoryInteger(Handle, Pointer, ref Value, 4, ref BytesRead) != 0) ? Value : 0;
    }

    public static float ReadPointerFloat(int Handle, int Pointer)
    {
        float Value = 0;
        int BytesRead = 0;
        return (Pointer != 0 && ReadProcessMemoryFloat(Handle, Pointer, ref Value, 4, ref BytesRead) != 0) ? Value : 0;
    }

    public static string ReadPointerString(int Handle, int Pointer, int Size)
    {
        byte[] Value = new byte[Size];
        int BytesRead = 0;
        return (Pointer != 0 && ReadProcessMemory(Handle, Pointer, Value, Size, ref BytesRead) != 0) ? System.Text.Encoding.ASCII.GetString(Value) : "";
    }

    public static int FindPointer(int Handle, int Pointer, int[] Offset)
    {
        foreach (int i in Offset)
        {
            Pointer = ReadPointerInteger(Handle, Pointer);
            if (Pointer == 0)
            {
                return 0;
            }
            try
            {
                checked
                {
                    Pointer += i;
                }
            }
            catch (OverflowException)
            {
                return 0;
            }
        }
        return Pointer;
    }

    public static int ReadPointerInteger(int Handle, int Pointer, int[] Offset)
    {
        return ReadPointerInteger(Handle, FindPointer(Handle, Pointer, Offset));
    }

    public static float ReadPointerFloat(int Handle, int Pointer, int[] Offset)
    {
        return ReadPointerFloat(Handle, FindPointer(Handle, Pointer, Offset));
    }

    public static string ReadPointerString(int Handle, int Pointer, int[] Offset, int Size)
    {
        return ReadPointerString(Handle, FindPointer(Handle, Pointer, Offset), Size);
    }
}
