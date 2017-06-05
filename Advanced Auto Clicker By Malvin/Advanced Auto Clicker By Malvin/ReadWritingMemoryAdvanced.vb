﻿Public Class ReadWritingMemoryAdvanced
    Public Declare Function ReadMemoryByte Lib "kernel32" Alias "ReadProcessMemory" (ByVal Handle As Integer, ByVal Address As Integer, ByRef Value As Byte, Optional ByVal Size As Integer = 2, Optional ByRef Bytes As Integer = 0) As Byte
    Public Declare Function ReadMemoryInteger Lib "kernel32" Alias "ReadProcessMemory" (ByVal Handle As Integer, ByVal Address As Integer, ByRef Value As Integer, Optional ByVal Size As Integer = 4, Optional ByRef Bytes As Integer = 0) As Integer
    Public Declare Function ReadMemoryFloat Lib "kernel32" Alias "ReadProcessMemory" (ByVal Handle As Integer, ByVal Address As Integer, ByRef Value As Single, Optional ByVal Size As Integer = 4, Optional ByRef Bytes As Integer = 0) As Single
    Public Declare Function ReadMemoryDouble Lib "kernel32" Alias "ReadProcessMemory" (ByVal Handle As Integer, ByVal Address As Integer, ByRef Value As Double, Optional ByVal Size As Integer = 8, Optional ByRef Bytes As Integer = 0) As Double
    Public Declare Function ReadMemoryShort Lib "kernel32" Alias "ReadProcessMemory" (ByVal Handle As Integer, ByVal Address As Integer, ByRef Value As Short, Optional ByVal Size As Integer = 2, Optional ByRef Bytes As Integer = 0) As Short
    Public Declare Function WriteMemoryShort Lib "kernel32" Alias "WriteProcessMemory" (ByVal Handle As Integer, ByVal Address As Integer, ByRef Value As Short, Optional ByVal Size As Integer = 2, Optional ByRef Bytes As Integer = 0) As Short
    Public Declare Function WriteMemoryByte Lib "kernel32" Alias "WriteProcessMemory" (ByVal Handle As Integer, ByVal Address As Integer, ByRef Value As Byte, Optional ByVal Size As Integer = 2, Optional ByRef Bytes As Integer = 0) As Byte
    Public Declare Function WriteMemoryInteger Lib "kernel32" Alias "WriteProcessMemory" (ByVal Handle As Integer, ByVal Address As Integer, ByRef Value As Integer, Optional ByVal Size As Integer = 4, Optional ByRef Bytes As Integer = 0) As Integer
    Public Declare Function WriteMemoryFloat Lib "kernel32" Alias "WriteProcessMemory" (ByVal Handle As Integer, ByVal Address As Integer, ByRef Value As Single, Optional ByVal Size As Integer = 2, Optional ByRef Bytes As Integer = 0) As Single
    Public Declare Function WriteMemoryDouble Lib "kernel32" Alias "WriteProcessMemory" (ByVal Handle As Integer, ByVal Address As Integer, ByRef Value As Double, Optional ByVal Size As Integer = 2, Optional ByRef Bytes As Integer = 0) As Double

    Public Shared Function ReadByte(ByVal EXENAME As String, ByVal Address As Integer) As Byte
        Dim Value As Byte
        If Process.GetProcessesByName(EXENAME).Length <> 0 Then
            Dim Handle As Integer = Process.GetProcessesByName(EXENAME)(0).Handle
            If Handle <> 0 Then
                ReadMemoryByte(Handle, Address, Value)
            End If
        End If
        Return Value
    End Function

    Public Shared Function ReadInteger(ByVal EXENAME As String, ByVal Address As Integer) As Integer
        Dim Value As Integer
        If Process.GetProcessesByName(EXENAME).Length <> 0 Then
            Dim Handle As Integer = Process.GetProcessesByName(EXENAME)(0).Handle
            If Handle <> 0 Then
                ReadMemoryInteger(Handle, Address, Value)
            End If
        End If
        Return Value
    End Function

    Public Shared Function ReadFloat(ByVal EXENAME As String, ByVal Address As Integer) As Single
        Dim Value As Single
        If Process.GetProcessesByName(EXENAME).Length <> 0 Then
            Dim Handle As Integer = Process.GetProcessesByName(EXENAME)(0).Handle
            If Handle <> 0 Then
                ReadMemoryFloat(Handle, Address, Value)
            End If
        End If
        Return Value
    End Function

    Public Shared Function ReadDouble(ByVal EXENAME As String, ByVal Address As Integer) As Double
        Dim Value As Double
        If Process.GetProcessesByName(EXENAME).Length <> 0 Then
            Dim Handle As Integer = Process.GetProcessesByName(EXENAME)(0).Handle
            If Handle <> 0 Then
                ReadMemoryByte(Handle, Address, Value)
            End If
        End If
        Return Value
    End Function

    Public Shared Function ReadPointerByte(ByVal EXENAME As String, ByVal Pointer As Integer, ByVal ParamArray Offset As Integer()) As Byte
        Dim Value As Byte
        If Process.GetProcessesByName(EXENAME).Length <> 0 Then
            Dim Handle As Integer = Process.GetProcessesByName(EXENAME)(0).Handle
            If Handle <> 0 Then
                For Each I As Integer In Offset
                    ReadMemoryInteger(Handle, Pointer, Pointer)
                    Pointer += I
                Next
                ReadMemoryByte(Handle, Pointer, Value)
            End If
        End If
        Return Value
    End Function

    Public Shared Function ReadPointerInteger(ByVal EXENAME As String, ByVal Pointer As Integer, ByVal ParamArray Offset As Integer()) As Integer
        Dim Value As Integer
        If Process.GetProcessesByName(EXENAME).Length <> 0 Then
            Dim Handle As Integer = Process.GetProcessesByName(EXENAME)(0).Handle
            If Handle <> 0 Then
                For Each I As Integer In Offset
                    ReadMemoryInteger(Handle, Pointer, Pointer)
                    Pointer += I
                Next
                ReadMemoryInteger(Handle, Pointer, Value)
            End If
        End If
        Return Value
    End Function

    Public Shared Function ReadPointerFloat(ByVal EXENAME As String, ByVal Pointer As Integer, ByVal ParamArray Offset As Integer()) As Single
        Dim Value As Single
        If Process.GetProcessesByName(EXENAME).Length <> 0 Then
            Dim Handle As Integer = Process.GetProcessesByName(EXENAME)(0).Handle
            If Handle <> 0 Then
                For Each I As Integer In Offset
                    ReadMemoryInteger(Handle, Pointer, Pointer)
                    Pointer += I
                Next
                ReadMemoryFloat(Handle, Pointer, Value)
            End If
        End If
        Return Value
    End Function

    Public Shared Function ReadPointerDouble(ByVal EXENAME As String, ByVal Pointer As Integer, ByVal ParamArray Offset As Integer()) As Double
        Dim Value As Double
        If Process.GetProcessesByName(EXENAME).Length <> 0 Then
            Dim Handle As Integer = Process.GetProcessesByName(EXENAME)(0).Handle
            If Handle <> 0 Then
                For Each I As Integer In Offset
                    ReadMemoryInteger(Handle, Pointer, Pointer)
                    Pointer += I
                Next
                ReadMemoryDouble(Handle, Pointer, Value)
            End If
        End If
        Return Value
    End Function

    Public Sub WriteByte(ByVal EXENAME As String, ByVal Address As Integer, ByVal Value As Byte)
        If Process.GetProcessesByName(EXENAME).Length <> 0 Then
            Dim Handle As Integer = Process.GetProcessesByName(EXENAME)(0).Handle
            If Handle <> 0 Then
                WriteMemoryByte(Handle, Address, Value)
            End If
        End If
    End Sub

    Public Shared Sub WriteInteger(ByVal EXENAME As String, ByVal Address As Integer, ByVal Value As Integer)
        If Process.GetProcessesByName(EXENAME).Length <> 0 Then
            Dim Handle As Integer = Process.GetProcessesByName(EXENAME)(0).Handle
            If Handle <> 0 Then
                WriteMemoryInteger(Handle, Address, Value)
            End If
        End If
    End Sub

    Public Shared Sub WriteFloat(ByVal EXENAME As String, ByVal Address As Integer, ByVal Value As Single)
        If Process.GetProcessesByName(EXENAME).Length <> 0 Then
            Dim Handle As Integer = Process.GetProcessesByName(EXENAME)(0).Handle
            If Handle <> 0 Then
                WriteMemoryFloat(Handle, Address, Value)
            End If
        End If
    End Sub

    Public Sub WriteDouble(ByVal EXENAME As String, ByVal Address As Integer, ByVal Value As Double)
        If Process.GetProcessesByName(EXENAME).Length <> 0 Then
            Dim Handle As Integer = Process.GetProcessesByName(EXENAME)(0).Handle
            If Handle <> 0 Then
                WriteMemoryDouble(Handle, Address, Value)
            End If
        End If
    End Sub

    Public Sub WritePointerByte(ByVal EXENAME As String, ByVal Pointer As Integer, ByVal Value As Byte, ByVal ParamArray Offset As Integer())
        If Process.GetProcessesByName(EXENAME).Length <> 0 Then
            Dim Handle As Integer = Process.GetProcessesByName(EXENAME)(0).Handle
            If Handle <> 0 Then
                For Each I As Integer In Offset
                    ReadMemoryInteger(Handle, Pointer, Pointer)
                    Pointer += I
                Next
                WriteMemoryByte(Handle, Pointer, Value)
            End If
        End If
    End Sub

    Public Sub WritePointerInteger(ByVal EXENAME As String, ByVal Pointer As Integer, ByVal Value As Integer, ByVal ParamArray Offset As Integer())
        If Process.GetProcessesByName(EXENAME).Length <> 0 Then
            Dim Handle As Integer = Process.GetProcessesByName(EXENAME)(0).Handle
            If Handle <> 0 Then
                For Each I As Integer In Offset
                    ReadMemoryInteger(Handle, Pointer, Pointer)
                    Pointer += I
                Next
                WriteMemoryInteger(Handle, Pointer, Value)
            End If
        End If
    End Sub

    Public Sub WritePointerFloat(ByVal EXENAME As String, ByVal Pointer As Integer, ByVal Value As Single, ByVal ParamArray Offset As Integer())
        If Process.GetProcessesByName(EXENAME).Length <> 0 Then
            Dim Handle As Integer = Process.GetProcessesByName(EXENAME)(0).Handle
            If Handle <> 0 Then
                For Each I As Integer In Offset
                    ReadMemoryInteger(Handle, Pointer, Pointer)
                    Pointer += I
                Next
                WriteMemoryFloat(Handle, Pointer, Value)
            End If
        End If
    End Sub

    Public Sub WritePointerDouble(ByVal EXENAME As String, ByVal Pointer As Integer, ByVal Value As Double, ByVal ParamArray Offset As Integer())
        If Process.GetProcessesByName(EXENAME).Length <> 0 Then
            Dim Handle As Integer = Process.GetProcessesByName(EXENAME)(0).Handle
            If Handle <> 0 Then
                For Each I As Integer In Offset
                    ReadMemoryInteger(Handle, Pointer, Pointer)
                    Pointer += I
                Next
                WriteMemoryDouble(Handle, Pointer, Value)
            End If
        End If
    End Sub

    Public Shared Function ReadPointerShort(ByVal EXENAME As String, ByVal Pointer As Integer, ByVal ParamArray Offset As Integer()) As Integer
        Dim Value As Integer
        If Process.GetProcessesByName(EXENAME).Length <> 0 Then
            Dim Handle As Integer = Process.GetProcessesByName(EXENAME)(0).Handle
            If Handle <> 0 Then
                For Each I As Integer In Offset
                    ReadMemoryInteger(Handle, Pointer, Pointer)
                    Pointer += I
                Next
                ReadMemoryShort(Handle, Pointer, Value)
            End If
        End If
        Return Value
    End Function

    Public Sub WritePointerShort(ByVal EXENAME As String, ByVal Pointer As Integer, ByVal Value As Integer, ByVal ParamArray Offset As Integer())
        If Process.GetProcessesByName(EXENAME).Length <> 0 Then
            Dim Handle As Integer = Process.GetProcessesByName(EXENAME)(0).Handle
            If Handle <> 0 Then
                For Each I As Integer In Offset
                    ReadMemoryInteger(Handle, Pointer, Pointer)
                    Pointer += I
                Next
                WriteMemoryShort(Handle, Pointer, Value)
            End If
        End If
    End Sub
End Class
