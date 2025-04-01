/* C# trainer class.
 * Adapted from code by Cless
 */

using System.Diagnostics;
using System.Runtime.InteropServices;


public class Trainer
{
    private const int PROCESS_ALL_ACCESS = 0x1F0FFF;

    [DllImport("kernel32")]
    private static extern int OpenProcess(int AccessType, int InheritHandle, int ProcessId);

    [DllImport("kernel32", EntryPoint = "ReadProcessMemory")]
    private static extern int ReadProcessMemoryInteger(int Handle, int Address, ref int Value, int Size, ref int BytesRead);

    [DllImport("kernel32", EntryPoint = "ReadProcessMemory")]
    private static extern float ReadProcessMemoryFloat(int Handle, int Address, ref float Value, int Size, ref int BytesRead);

    [DllImport("kernel32", EntryPoint = "ReadProcessMemory")]
    private static extern double ReadProcessMemoryDouble(int Handle, int Address, ref double Value, int Size, ref int BytesRead);

    [DllImport("kernel32")]
    private static extern int CloseHandle(int Handle);

    public static int ReadPointerInteger(Process[] Proc, int Pointer, int[] Offset) {
        int Value = 0;
        checked {
            try {
                if (Proc.Length != 0) {
                    int Bytes = 0;
                    int Handle = OpenProcess(PROCESS_ALL_ACCESS, 0, Proc[0].Id);
                    if (Handle != 0) {
                        foreach (int i in Offset) {
                            ReadProcessMemoryInteger((int)Handle, Pointer, ref Pointer, 4, ref Bytes);
                            Pointer += i;
                        }
                        ReadProcessMemoryInteger((int)Handle, Pointer, ref Value, 4, ref Bytes);
                        CloseHandle(Handle);
                    }
                }
            } catch { }
        }
        return Value;
    }

    public static float ReadPointerFloat(Process[] Proc, int Pointer, int[] Offset) {
        float Value = 0;
        checked {
            try {
                if (Proc.Length != 0) {
                    int Bytes = 0;
                    int Handle = OpenProcess(PROCESS_ALL_ACCESS, 0, Proc[0].Id);
                    if (Handle != 0) {
                        foreach (int i in Offset) {
                            ReadProcessMemoryInteger((int)Handle, Pointer, ref Pointer, 4, ref Bytes);
                            Pointer += i;
                        }
                        ReadProcessMemoryFloat((int)Handle, Pointer, ref Value, 4, ref Bytes);
                        CloseHandle(Handle);
                    }
                }
            } catch { }
        }
        return Value;
    }

    public static double ReadPointerDouble(Process[] Proc, int Pointer, int[] Offset) {
        double Value = 0;
        checked {
            try {
                if (Proc.Length != 0) {
                    int Bytes = 0;
                    int Handle = OpenProcess(PROCESS_ALL_ACCESS, 0, Proc[0].Id);
                    if (Handle != 0) {
                        foreach (int i in Offset) {
                            ReadProcessMemoryInteger((int)Handle, Pointer, ref Pointer, 4, ref Bytes);
                            Pointer += i;
                        }
                        ReadProcessMemoryDouble((int)Handle, Pointer, ref Value, 8, ref Bytes);
                        CloseHandle(Handle);
                    }
                }
            } catch { }
        }
        return Value;
    }
}