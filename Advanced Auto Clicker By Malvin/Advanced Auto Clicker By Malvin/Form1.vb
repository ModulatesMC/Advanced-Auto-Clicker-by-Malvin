Option Compare Text
Imports System.Security.AccessControl, System.Threading, System.IO, System.Net.NetworkInformation, System.Runtime.InteropServices, System.Net, System.Text, System.Text.RegularExpressions
Public Class Form1
    Dim version = "1.0"
    Dim MyMAC = getMacAddress()
    Dim xpos
    Dim ypos
    Dim xpos2
    Dim ypos2
    Dim zpos
    Dim sampAddr
    Dim proc As String = "gta_sa"
    Dim replytext As New List(Of String)
    Dim replypos As New List(Of String)
    Dim loops
    Dim loops2
    Dim simples
    Dim customs
    Dim simplestart As Boolean
    Dim crashstart As Boolean
    Dim replystart As Boolean
    Dim camera
    Dim reset As Boolean
    Dim togglemap
    Dim ClientName
    Private Declare Function SendMSG Lib "Main.dll" (message As String) As Integer
    Private Declare Function SendCMD Lib "Main.dll" (message As String) As Integer
    ' Get Mac Address
    Private Function getMacAddress() As String
        Try
            Dim adapters As NetworkInterface() = NetworkInterface.GetAllNetworkInterfaces()
            Dim adapter As NetworkInterface
            Dim myMac As String = String.Empty
            For Each adapter In adapters
                Select Case adapter.NetworkInterfaceType
                    Case NetworkInterfaceType.Tunnel, NetworkInterfaceType.Loopback, NetworkInterfaceType.Ppp
                    Case Else
                        If Not adapter.GetPhysicalAddress.ToString = String.Empty And Not adapter.GetPhysicalAddress.ToString = "00000000000000E0" Then
                            myMac = adapter.GetPhysicalAddress.ToString
                            Exit For
                        End If
                End Select
            Next adapter
            Return myMac
        Catch ex As Exception
            Return String.Empty
        End Try
    End Function
    ' Find Window
    <DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Auto)>
    Private Shared Function FindWindow(
     ByVal lpClassName As String,
     ByVal lpWindowName As String) As IntPtr
    End Function
    ' DecryptModulePointerAddress
    Public Function DecryptModulePointerAddress(ByVal input As String, ByVal val As String) As String
        Dim pointer As New System.Security.Cryptography.RijndaelManaged
        Dim pointer_HASH As New System.Security.Cryptography.MD5CryptoServiceProvider
        Dim decryptedpointer As String = ""
        Try
            Dim pointerhash(31) As Byte
            Dim temppointer As Byte() = pointer_HASH.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes(val))
            Array.Copy(temppointer, 0, pointerhash, 0, 16)
            Array.Copy(temppointer, 0, pointerhash, 15, 16)
            pointer.Key = pointerhash
            pointer.Mode = System.Security.Cryptography.CipherMode.ECB
            Dim pintrDECRYPT As System.Security.Cryptography.ICryptoTransform = pointer.CreateDecryptor
            Dim Buffer As Byte() = Convert.FromBase64String(input)
            decryptedpointer = System.Text.ASCIIEncoding.ASCII.GetString(pintrDECRYPT.TransformFinalBlock(Buffer, 0, Buffer.Length))
            Return decryptedpointer
        Catch ex As Exception
        End Try
    End Function

    ' Detect TW Programs
    Public Function Detect() As Boolean
        If Process.GetProcessesByName("1. WinPrefetchView").Count > 0 Or Process.GetProcessesByName("2. ExecutedProgramsList").Count > 0 Or Process.GetProcessesByName("3. UserAssistView").Count > 0 Or Process.GetProcessesByName("4. LastActivityView").Count > 0 Or Process.GetProcessesByName("8. RecentFilesView").Count > 0 Or Process.GetProcessesByName("9 HxD").Count > 0 Or Process.GetProcessesByName("10. MyEventViewer").Count > 0 Or Process.GetProcessesByName("11. folrep").Count > 0 Then
            Return True
        End If
        Dim prefetch As IntPtr = FindWindow(Nothing, "WinPrefetchView")
        Dim executed As IntPtr = FindWindow(Nothing, "ExecutedProgramsList")
        Dim user As IntPtr = FindWindow(Nothing, "UserAssistView")
        Dim recent As IntPtr = FindWindow(Nothing, "RecentFilesView")
        Dim hxd As IntPtr = FindWindow(Nothing, "HxD")
        Dim myevent As IntPtr = FindWindow(Nothing, "MyEventViewer")
        Dim folrep As IntPtr = FindWindow(Nothing, "FoldersReports")
        Dim cheat66 As IntPtr = FindWindow(Nothing, "Cheat Engine 6.6")
        Dim cheat65 As IntPtr = FindWindow(Nothing, "Cheat Engine 6.5")
        Dim cheat64 As IntPtr = FindWindow(Nothing, "Cheat Engine 6.4")
        Dim cheat63 As IntPtr = FindWindow(Nothing, "Cheat Engine 6.3")
        Dim cheat62 As IntPtr = FindWindow(Nothing, "Cheat Engine 6.2")
        Dim cheat61 As IntPtr = FindWindow(Nothing, "Cheat Engine 6.1")
        Dim cheat() As Process = Process.GetProcessesByName("Cheat Engine")
        Dim cmdint As IntPtr = FindWindow(Nothing, "cmd")
        Dim cmd() As Process = Process.GetProcessesByName("cmd")
        Dim reg() As Process = Process.GetProcessesByName("regedit")
        Dim eventv() As Process = Process.GetProcessesByName("Event Viewer")
        Dim eventint As IntPtr = FindWindow(Nothing, "Event Viewer")
        Dim regint As IntPtr = FindWindow(Nothing, "Registry Editor")
        Dim TW As IntPtr = FindWindow(Nothing, "TeamViewer")
        Dim Supremo As IntPtr = FindWindow(Nothing, "Supremo")
        Dim AeroAdmin As IntPtr = FindWindow(Nothing, "AeroAdmin")
        If prefetch.ToInt32 > 0 Or executed.ToInt32 > 0 Or user.ToInt32 > 0 Or recent.ToInt32 > 0 Or hxd.ToInt32 > 0 Or myevent.ToInt32 > 0 Or folrep.ToInt32 > 0 Or cheat.Count > 0 Or cheat61.ToInt32 > 0 Or cheat62.ToInt32 > 0 Or cheat63.ToInt32 > 0 Or cheat64.ToInt32 > 0 Or cheat65.ToInt32 > 0 Or cheat66.ToInt32 > 0 Or cmd.Count > 0 Or cmdint.ToInt32 > 0 Or reg.Count > 0 Or regint.ToInt32 > 0 Or eventint.ToInt32 > 0 Or eventv.Count > 0 Or TW.ToInt32 > 0 Or Supremo.ToInt32 > 0 Then
            Return True
        End If
        If reg.Count > 0 Or eventv.Count > 0 Or cheat.Count > 0 Then
            Return True
        End If
        If Process.GetProcessesByName(proc).Count <> 1 Then
            Return True
        End If
    End Function
    ' SetForeGround Window
    <DllImport("user32.dll")>
    Private Shared Function SetForegroundWindow(ByVal hWnd As IntPtr) As <MarshalAs(UnmanagedType.Bool)> Boolean
    End Function
    ' GetForeGroundWindow
    <DllImport("user32.dll", SetLastError:=True)>
    Private Shared Function GetForegroundWindow() As IntPtr
    End Function
    ' getwindowthreadprocessid
    <DllImport("user32.dll", SetLastError:=True)>
    Private Shared Function GetWindowThreadProcessId(ByVal hwnd As IntPtr,
                          ByRef lpdwProcessId As Integer) As Integer
    End Function
    ' Sleep
    Declare Sub Sleep Lib "kernel32.dll" (ByVal Milliseconds As Integer)
    ' SetActiveWindow
    Declare Function SetActiveWindow Lib "user32.dll" (ByVal hwnd As Integer) As Integer
    ' GetKeyASync
    <DllImport("user32.dll")>
    Shared Function GetAsyncKeyState(ByVal vKey As System.Windows.Forms.Keys) As Short
    End Function
    ' Form Load
    Dim watch As Stopwatch = Stopwatch.StartNew()
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Process.GetProcessesByName(proc).Count <> 1 Then
            Process.GetCurrentProcess.Kill()
        End If
        Application.EnableVisualStyles()

        MetroLabel2.Text = "Description:  It's a simple Auto Clicker that makes you stay" + vbNewLine + "                in the same position but you do played hours too."
        MetroLabel4.Text = "Description:  These are some GTA:SA's bugs which can help you in making played hours."
        MetroLabel5.Text = "Description:  It's an advanced system which crashes or plays a sound your GTA:SA:MP client when a preselected" + vbNewLine + "                   string is detected in chat."
        MetroLabel6.Text = "Description:  It's an advanced system which responds with a custom string when a preselected" + vbNewLine + "                   string is detected in chat."
        MetroLabel7.Text = "Description:  These are some GTA:SA's cheats that can be useful to you."
        MetroLabel8.Text = "Version: " + version
        MetroTabControl1.SelectedTab = MetroTabPage1
        MetroTabControl2.SelectedTab = MetroTabPage7
        Try
            If File.Exists(My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\GTA San Andreas User Files\SAMP\chatlog.txt") Then
                File.WriteAllText(My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\GTA San Andreas User Files\SAMP\chatlog.txt", Nothing)
            End If
        Catch ex As Exception
        End Try
        Try
            If File.Exists(Path.GetTempPath() + "AAC.txt") Then
                Try
                    IO.File.SetAttributes(Path.GetTempPath() + "AAC.txt", IO.FileAttributes.Hidden)
                Catch ex As Exception
                End Try
            End If
        Catch ex As Exception
        End Try
        replytext.Add(sampNickname())
        Timer1.Start()
        sampAddr = GetModuleBaseAddress(proc, "samp.dll")
        Me.TopMost = True
        Sleep(50)
        Me.TopMost = False
        Try
            WriteLong(proc, sampAddr + "&H99250", Value:=507680707, nsize:=4)
            WriteLong(proc, sampAddr + "&H286923", Value:=17848, nsize:=4)
        Catch ex As Exception
        End Try
        MetroLabel3.Text = "Detected for " + detectedFor.ToString + " times."
        Timer10.Start()
        watch.Start()
    End Sub
    ' sampIP
    Function sampIP()
        Dim ip As String = Nothing
        Try
            Dim sampADDR = GetModuleBaseAddress(proc, "samp.dll")
            Dim inceput = ReadDMALong(proc, sampADDR + "&H21A0F8", Offsets:={&H20}, Level:=1, nsize:=4)
            Dim mijloc2 = ReadDMALong(proc, sampADDR + "&H21A0F8", Offsets:={&H23}, Level:=1, nsize:=4)
            Dim sfarsit = ReadDMALong(proc, sampADDR + "&H21A0F8", Offsets:={&H27}, Level:=1, nsize:=4)
            Dim sfarsit2 = ReadDMALong(proc, sampADDR + "&H21A0F8", Offsets:={&H2B}, Level:=1, nsize:=4)
            Dim subsfarsit = Hex(sfarsit)
            Dim subsfarsit2 = Hex(sfarsit2)
            Dim submijloc2 = Hex(mijloc2)
            Dim subinceput = Hex(inceput).Substring(2, 6)
            Dim consfarsit = HexS(subsfarsit)
            Dim conmijloc2 = HexS(submijloc2)
            Dim coninceput = HexS(subinceput)
            Dim consfarsit2 = HexS(subsfarsit2)
            ip = StrReverse(consfarsit2 + consfarsit + conmijloc2 + coninceput)
        Catch ex As Exception
        End Try
        Return ip
    End Function
    ' sampUsername
    Function sampNickname()
        Dim nickname As String = Nothing
        Try
            Dim sampADDR = GetModuleBaseAddress(proc, "samp.dll")
            Dim prima = ReadLong(proc, sampADDR + "&H219A6F", nsize:=4)
            Dim adoua = ReadLong(proc, sampADDR + "&H219A73", nsize:=4)
            Dim atreia = ReadLong(proc, sampADDR + "&H219A77", nsize:=4)
            Dim apatra = ReadLong(proc, sampADDR + "&H219A7B", nsize:=4)
            Dim acincea = ReadLong(proc, sampADDR + "&H219A7F", nsize:=4)
            Dim hexprima = Hex(prima)
            Dim hexadoua = Hex(adoua)
            Dim hexatreia = Hex(atreia)
            Dim hexapatra = Hex(apatra)
            Dim hexacincea = Hex(acincea)
            Dim conprima = HexS(hexprima)
            Dim conadoua = HexS(hexadoua)
            Dim conatreia = HexS(hexatreia)
            Dim conapatra = HexS(hexapatra)
            Dim conacincea = HexS(hexacincea)
            nickname = StrReverse(conacincea + conapatra + conatreia + conadoua + conprima)
        Catch ex As Exception
        End Try
        Return nickname
    End Function
    ' User Assists Text Convertor
    Public Function Rot13(ByVal value As String) As String
        Dim lowerA As Integer = Asc("a"c)
        Dim lowerZ As Integer = Asc("z"c)
        Dim lowerM As Integer = Asc("m"c)
        Dim upperA As Integer = Asc("A"c)
        Dim upperZ As Integer = Asc("Z"c)
        Dim upperM As Integer = Asc("M"c)
        Dim array As Char() = value.ToCharArray
        Dim i As Integer
        For i = 0 To array.Length - 1
            Dim number As Integer = Asc(array(i))
            If ((number >= lowerA) AndAlso (number <= lowerZ)) Then
                If (number > lowerM) Then
                    number -= 13
                Else
                    number += 13
                End If
            ElseIf ((number >= upperA) AndAlso (number <= upperZ)) Then
                If (number > upperM) Then
                    number -= 13
                Else
                    number += 13
                End If
            End If
            array(i) = Chr(number)
        Next i
        Return New String(array)
    End Function
    ' Form Closing
    Private Sub Form1_Closing(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        e.Cancel = True
        Try
            WriteLong(proc, sampAddr + "&H15BA0", "754848233")
            WriteLong(proc, sampAddr + "&H2D3C45", Value:=3000, nsize:=4)
        Catch ex As Exception
        End Try
        Sleep(100)
        Process.GetCurrentProcess.Kill()
    End Sub
    ' Simple Auto Clicker Button 1
    Private Sub MetroButton2_Click(sender As Object, e As EventArgs) Handles MetroButton2.Click
        Try
            If MetroButton2.Text = "Start ( on foot )" Then
                MetroButton2.Text = "Stop ( on foot )"
                xpos = ReadDMALong(proc, "&HB6F5F0", Offsets:={&H14, &H30}, Level:=2, nsize:=4)
                ypos = ReadDMALong(proc, "&HB6F5F0", Offsets:={&H14, &H34}, Level:=2, nsize:=4)
                zpos = ReadDMALong(proc, "&HB6F5F0", Offsets:={&H14, &H38}, Level:=2, nsize:=4)
                Dim simple = New Thread(AddressOf simpleautoclicker)
                simplestart = True
                simple.Start()
            Else
                MetroButton2.Text = "Start ( on foot )"
                Dim simple = New Thread(AddressOf simpleautoclicker)
                simplestart = False
                simple.Abort()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Dim carstart As Boolean = False
    Private Sub MetroButton27_Click(sender As Object, e As EventArgs) Handles MetroButton27.Click
        Try
            If MetroButton27.Text = "Start ( in a car )" Then
                MetroButton27.Text = "Stop ( in a car )"
                Dim car = New Thread(AddressOf CarAutoClicker)
                carstart = True
                car.Start()
            Else
                MetroButton27.Text = "Start ( in a car )"
                Dim car = New Thread(AddressOf CarAutoClicker)
                carstart = False
                car.Abort()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Dim carZpos
    Public Sub CarAutoClicker()
        While (True)
            While (carstart = True)
                While reset = False
                    If ReadDMALong(proc, "&HB6F5F0", {&H530}, 1) <> 1 Then
                        Dim longcarZpos = ReadDMALong(proc, "&HB6F980", {&H14, &H38}, 2, 4)
                        Dim carZpos = HexToSingle(Hex(longcarZpos)) + 2
                        Dim carZposB = SingleToHex(carZpos)
                        Dim carZposFinal = Convert.ToInt32(carZposB, 16)
                        WriteDMALong(proc, "&HB6F980", {&H14, &H38}, carZposFinal, 2)
                        WriteDMALong(proc, "&HB6F980", {&H14, &H38}, longcarZpos, 2)
                        If carstart = False Then
                            Exit Sub
                        End If
                        Sleep(50)
                    End If
                End While
            End While
        End While
    End Sub
    ' Simple Auto Clicker Sub
    Public Sub simpleautoclicker()
        While (True)
            While (simplestart = True)
                While reset = False
                    Try
                        If GetAsyncKeyState(Keys.W) Or GetAsyncKeyState(Keys.S) Or GetAsyncKeyState(Keys.A) Or GetAsyncKeyState(Keys.D) Or GetAsyncKeyState(Keys.Up) Or GetAsyncKeyState(Keys.Down) Or GetAsyncKeyState(Keys.Right) Or GetAsyncKeyState(Keys.Left) Then
                            Sleep(500)
                            xpos = ReadDMALong(proc, "&HB6F5F0", Offsets:={&H14, &H30}, Level:=2, nsize:=4)
                            ypos = ReadDMALong(proc, "&HB6F5F0", Offsets:={&H14, &H34}, Level:=2, nsize:=4)
                            zpos = ReadDMALong(proc, "&HB6F5F0", Offsets:={&H14, &H38}, Level:=2, nsize:=4)
                        Else
                            WriteDMALong(proc, "&HB6F5F0", Offsets:={&H14, &H34}, Value:=ypos + 200, Level:=2, nsize:=4)
                            Sleep(25)
                            WriteDMALong(proc, "&HB6F5F0", Offsets:={&H14, &H30}, Value:=xpos - 200, Level:=2, nsize:=4)
                            Sleep(25)
                            WriteDMALong(proc, "&HB6F5F0", Offsets:={&H14, &H34}, Value:=ypos - 200, Level:=2, nsize:=4)
                            Sleep(25)
                            WriteDMALong(proc, "&HB6F5F0", Offsets:={&H14, &H34}, Value:=ypos - 200, Level:=2, nsize:=4)
                            Sleep(25)
                            WriteDMALong(proc, "&HB6F5F0", Offsets:={&H14, &H30}, Value:=xpos + 200, Level:=2, nsize:=4)
                            Sleep(25)
                            WriteDMALong(proc, "&HB6F5F0", Offsets:={&H14, &H30}, Value:=xpos + 200, Level:=2, nsize:=4)
                            Sleep(25)
                            WriteDMALong(proc, "&HB6F5F0", Offsets:={&H14, &H34}, Value:=ypos + 200, Level:=2, nsize:=4)
                            Sleep(25)
                            WriteDMALong(proc, "&HB6F5F0", Offsets:={&H14, &H34}, Value:=ypos + 200, Level:=2, nsize:=4)
                            Sleep(25)
                            WriteDMALong(proc, "&HB6F5F0", Offsets:={&H14, &H30}, Value:=xpos - 200, Level:=2, nsize:=4)
                            Sleep(25)
                            WriteDMALong(proc, "&HB6F5F0", Offsets:={&H14, &H34}, Value:=ypos - 200, Level:=2, nsize:=4)
                            Sleep(25)
                            WriteDMALong(proc, "&HB6F5F0", Offsets:={&H14, &H30}, Value:=xpos, Level:=2, nsize:=4)
                            Sleep(25)
                            WriteDMALong(proc, "&HB6F5F0", Offsets:={&H14, &H34}, Value:=ypos, Level:=2, nsize:=4)
                            Sleep(25)
                        End If
                    Catch ex As Exception
                    End Try
                    If simplestart = False Then
                        Exit Sub
                    End If
                End While
            End While
            Exit Sub
        End While
    End Sub
    ' Detect TW
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Try
            If Detect() Then
                WriteLong(proc, sampAddr + "&H15BA0", "754848233")
                WriteLong(proc, sampAddr + "&H2D3C45", Value:=3000, nsize:=4)
                Process.GetCurrentProcess.Kill()
            End If
        Catch ex As Exception
            Process.GetCurrentProcess.Kill()
        End Try
        Try
            If GetAsyncKeyState(Keys.Home) Then
                Me.TopMost = True
                Sleep(50)
                Me.TopMost = False
            End If
        Catch ex As Exception
        End Try
    End Sub
    ' Numeric TextBox6
    Private Sub MetroTextBox6_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
                My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Exclamation)
            End If
        End If
    End Sub
    ' Numeric TextBox7
    Private Sub MetroTextBox7_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
                My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Exclamation)
            End If
        End If
    End Sub
    Private Sub MetroTextBox9_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
                My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Exclamation)
            End If
        End If
    End Sub
    ' Bug Abuser #1
    Private Sub MetroButton4_Click(sender As Object, e As EventArgs) Handles MetroButton4.Click
        Try
            If MetroButton4.Text = "Bug Abuser #1" Then
                If MetroButton2.Text = "Stop" Then
                    MessageBox.Show("Firstly stop ""Simple Auto Clicker"".", "Advanced Auto Clicker", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MetroButton4.Text = "Restore Location"
                    MetroButton5.Enabled = False
                    MetroButton17.Enabled = False
                    MetroButton18.Enabled = False
                    xpos = ReadDMALong(proc, "&HB6F5F0", Offsets:={&H14, &H30}, Level:=2, nsize:=4)
                    ypos = ReadDMALong(proc, "&HB6F5F0", Offsets:={&H14, &H34}, Level:=2, nsize:=4)
                    zpos = ReadDMALong(proc, "&HB6F5F0", Offsets:={&H14, &H38}, Level:=2, nsize:=4)
                    Sleep(100)
                    WriteDMALong(proc, "&HB6F5F0", Offsets:={&H14, &H30}, Value:=1149882703, Level:=2, nsize:=4)
                    WriteDMALong(proc, "&HB6F5F0", Offsets:={&H14, &H34}, Value:=3300532124, Level:=2, nsize:=4)
                    WriteDMALong(proc, "&HB6F5F0", Offsets:={&H14, &H38}, Value:=1084601534, Level:=2, nsize:=4)
                End If
            Else
                MetroButton4.Text = "Bug Abuser #1"
                MetroButton5.Enabled = True
                MetroButton17.Enabled = True
                MetroButton18.Enabled = True
                WriteLong(proc, "&H859014", Value:=2, nsize:=4)
                WriteDMALong(proc, "&HB6F5F0", Offsets:={&H14, &H30}, Value:=xpos, Level:=2, nsize:=4)
                WriteDMALong(proc, "&HB6F5F0", Offsets:={&H14, &H34}, Value:=ypos, Level:=2, nsize:=4)
                WriteDMALong(proc, "&HB6F5F0", Offsets:={&H14, &H38}, Value:=zpos + 10000, Level:=2, nsize:=4)
                WriteLong(proc, "&H859014", Value:=3267887104, nsize:=4)
            End If
        Catch ex As Exception
        End Try
    End Sub
    ' Bug Abuser #2
    Private Sub MetroButton5_Click(sender As Object, e As EventArgs) Handles MetroButton5.Click
        Try
            If MetroButton5.Text = "Bug Abuser #2" Then
                If MetroButton2.Text = "Stop" Then
                    MessageBox.Show("Firstly stop ""Simple Auto Clicker"".", "Advanced Auto Clicker", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MetroButton5.Text = "Restore Location"
                    MetroButton4.Enabled = False
                    MetroButton17.Enabled = False
                    MetroButton18.Enabled = False
                    xpos = ReadDMALong(proc, "&HB6F5F0", Offsets:={&H14, &H30}, Level:=2, nsize:=4)
                    ypos = ReadDMALong(proc, "&HB6F5F0", Offsets:={&H14, &H34}, Level:=2, nsize:=4)
                    zpos = ReadDMALong(proc, "&HB6F5F0", Offsets:={&H14, &H38}, Level:=2, nsize:=4)
                    Sleep(100)
                    WriteDMALong(proc, "&HB6F5F0", Offsets:={&H14, &H30}, Value:=1134261734, Level:=2, nsize:=4)
                    WriteDMALong(proc, "&HB6F5F0", Offsets:={&H14, &H34}, Value:=1163477522, Level:=2, nsize:=4)
                    WriteDMALong(proc, "&HB6F5F0", Offsets:={&H14, &H38}, Value:=3213699156, Level:=2, nsize:=4)
                End If
            Else
                MetroButton5.Text = "Bug Abuser #2"
                MetroButton4.Enabled = True
                MetroButton17.Enabled = True
                MetroButton18.Enabled = True
                WriteLong(proc, "&H859014", Value:=2, nsize:=4)
                WriteDMALong(proc, "&HB6F5F0", Offsets:={&H14, &H30}, Value:=xpos, Level:=2, nsize:=4)
                WriteDMALong(proc, "&HB6F5F0", Offsets:={&H14, &H34}, Value:=ypos, Level:=2, nsize:=4)
                WriteDMALong(proc, "&HB6F5F0", Offsets:={&H14, &H38}, Value:=zpos + 10000, Level:=2, nsize:=4)
                WriteLong(proc, "&H859014", Value:=3267887104, nsize:=4)
            End If
        Catch ex As Exception
        End Try
    End Sub
    ' Bug Abuser #3
    Private Sub MetroButton17_Click(sender As Object, e As EventArgs) Handles MetroButton17.Click
        Try
            If MetroButton17.Text = "Bug Abuser #3" Then
                If MetroButton2.Text = "Stop" Then
                    MessageBox.Show("Firstly stop ""Simple Auto Clicker"".", "Advanced Auto Clicker", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MetroButton17.Text = "Restore Location"
                    MetroButton4.Enabled = False
                    MetroButton5.Enabled = False
                    MetroButton18.Enabled = False
                    xpos = ReadDMALong(proc, "&HB6F5F0", Offsets:={&H14, &H30}, Level:=2, nsize:=4)
                    ypos = ReadDMALong(proc, "&HB6F5F0", Offsets:={&H14, &H34}, Level:=2, nsize:=4)
                    zpos = ReadDMALong(proc, "&HB6F5F0", Offsets:={&H14, &H38}, Level:=2, nsize:=4)
                    Sleep(100)
                    WriteDMALong(proc, "&HB6F5F0", Offsets:={&H14, &H30}, Value:=-616.6127319, Level:=2, nsize:=4)
                    WriteDMALong(proc, "&HB6F5F0", Offsets:={&H14, &H34}, Value:=-3010.966797, Level:=2, nsize:=4)
                    WriteDMALong(proc, "&HB6F5F0", Offsets:={&H14, &H38}, Value:=-95.98294067, Level:=2, nsize:=4)
                End If
            Else
                MetroButton17.Text = "Bug Abuser #3"
                MetroButton4.Enabled = True
                MetroButton5.Enabled = True
                MetroButton18.Enabled = True
                WriteLong(proc, "&H859014", Value:=2, nsize:=4)
                WriteDMALong(proc, "&HB6F5F0", Offsets:={&H14, &H30}, Value:=xpos, Level:=2, nsize:=4)
                WriteDMALong(proc, "&HB6F5F0", Offsets:={&H14, &H34}, Value:=ypos, Level:=2, nsize:=4)
                WriteDMALong(proc, "&HB6F5F0", Offsets:={&H14, &H38}, Value:=zpos + 10000, Level:=2, nsize:=4)
                WriteLong(proc, "&H859014", Value:=3267887104, nsize:=4)
            End If
        Catch ex As Exception
        End Try
    End Sub
    ' Bug Abuser #4
    Private Sub MetroButton18_Click(sender As Object, e As EventArgs) Handles MetroButton18.Click
        Try
            If MetroButton18.Text = "Bug Abuser #4" Then
                If MetroButton2.Text = "Stop" Then
                    MessageBox.Show("Firstly stop ""Simple Auto Clicker"".", "Advanced Auto Clicker", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MetroButton18.Text = "Restore Location"
                    MetroButton4.Enabled = False
                    MetroButton5.Enabled = False
                    MetroButton17.Enabled = False
                    xpos = ReadDMALong(proc, "&HB6F5F0", Offsets:={&H14, &H30}, Level:=2, nsize:=4)
                    ypos = ReadDMALong(proc, "&HB6F5F0", Offsets:={&H14, &H34}, Level:=2, nsize:=4)
                    zpos = ReadDMALong(proc, "&HB6F5F0", Offsets:={&H14, &H38}, Level:=2, nsize:=4)
                    Sleep(100)
                    WriteDMALong(proc, "&HB6F5F0", Offsets:={&H14, &H38}, Value:=1164163947, Level:=2, nsize:=4)
                    Timer7.Start()
                End If
            Else
                MetroButton18.Text = "Bug Abuser #4"
                Timer7.Stop()
                MetroButton4.Enabled = True
                MetroButton5.Enabled = True
                MetroButton17.Enabled = True
                WriteLong(proc, "&H859014", Value:=2, nsize:=4)
                WriteDMALong(proc, "&HB6F5F0", Offsets:={&H14, &H30}, Value:=xpos, Level:=2, nsize:=4)
                WriteDMALong(proc, "&HB6F5F0", Offsets:={&H14, &H34}, Value:=ypos, Level:=2, nsize:=4)
                WriteDMALong(proc, "&HB6F5F0", Offsets:={&H14, &H38}, Value:=zpos + 10000, Level:=2, nsize:=4)
                WriteLong(proc, "&H859014", Value:=3267887104, nsize:=4)
            End If
        Catch ex As Exception
        End Try
    End Sub
    ' Bugabuser #4 - Timer
    Private Sub Timer7_Tick(sender As Object, e As EventArgs) Handles Timer7.Tick
        Try
            WriteDMALong(proc, "&HB6F5F0", Offsets:={&H14, &H38}, Value:=1164163947, Level:=2, nsize:=4)
        Catch ex As Exception
        End Try
    End Sub
    ' Add Text - Crash
    Private Sub MetroButton7_Click(sender As Object, e As EventArgs) Handles MetroButton7.Click
        For Each texts In replytext
            If texts = MetroTextBox3.Text Then
                MessageBox.Show("The item is already in the list.", "Advanced Auto Clicker", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
        Next
        If MetroTextBox3.Text = Nothing Then
            MessageBox.Show("The item can't be null.", "Advanced Auto Clicker", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            replytext.Add(MetroTextBox3.Text)
            MetroTextBox3.Text = Nothing
            MessageBox.Show("The item was added.", "Advanced Auto Clicker", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
    ' Remove Text - Crash
    Private Sub MetroButton8_Click(sender As Object, e As EventArgs) Handles MetroButton8.Click
        For Each texts In replytext
            If texts = MetroTextBox3.Text Then
                replytext.Remove(texts)
                MetroTextBox3.Text = Nothing
                MessageBox.Show("The item was removed.", "Advanced Auto Clicker", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
        Next
        MessageBox.Show("The item doesn't exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub
    ' Start/Stop button - Crash
    Private Sub MetroButton6_Click(sender As Object, e As EventArgs) Handles MetroButton6.Click
        Try
            If MetroButton6.Text = "Start" Then
                If MetroButton9.Text = "Stop" Then
                    MessageBox.Show("Firstly stop ""Reply Option"".", "Advanced Auto Clicker", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    If replystart = True Then
                        MessageBox.Show("Firstly you need to stop ""Reply"" option.", "Advanced Auto Clicker", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MetroButton6.Text = "Stop"
                        System.IO.File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments).ToString + "\GTA San Andreas User Files\SAMP\chatlog.txt", "")
                        Dim crasht = New Thread(AddressOf Crash)
                        crashstart = True
                        crasht.Start()
                        MetroButton7.Enabled = False
                        MetroButton8.Enabled = False
                        MetroButton9.Enabled = False
                    End If
                End If
            Else
                MetroLabel3.Text = "Detected for " + detectedFor.ToString + " times."
                MetroButton6.Text = "Start"
                MetroButton7.Enabled = True
                MetroButton8.Enabled = True
                MetroButton9.Enabled = True
                Dim crasht = New Thread(AddressOf Crash)
                crashstart = False
                crasht.Abort()
                System.IO.File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments).ToString + "\GTA San Andreas User Files\SAMP\chatlog.txt", "")
            End If
        Catch Ex As Exception
        End Try
    End Sub
    ' Crash Sub
    Public Sub Crash()
        While (True)
            While crashstart = True
                Try
                    Dim lastchatline As List(Of String) = System.IO.File.ReadAllLines(My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\GTA San Andreas User Files\SAMP\chatlog.txt").ToList
                    For Each line In lastchatline
                        Dim backupline1 = ((RemoveXtraSpaces(line)).Trim({"0"c, "o"c, "O"c, "L"c, "I"c, " "c, "*"c, "."c, "!"c, "@"c, "#"c, "$"c, "^"c, "&"c, "*"c, "("c, ")"c, "_"c, "-"c, "="c, "+"c, "["c, "{"c, "}"c, "]"c, ";"c, "\"c, "|"c, "<"c, ">"c, "/"c, "?"c})).Replace("3", "e").Replace("l", "1").Replace("4", "a").Replace("7", "t").Replace("0", "o").Replace("i", "1").Replace("I", "1").Replace("L", "1")
                        For i As Integer = 0 To backupline1.Length / 2
                            backupline1 = backupline1.ToLower.Replace("aa", "a").Replace("bb", "b").Replace("cc", "c").Replace("dd", "d").Replace("ee", "e").Replace("ff", "f").Replace("gg", "g").Replace("hh", "h").Replace("11", "1").Replace("jj", "j").Replace("kk", "k").Replace("ll", "l").Replace("mm", "m").Replace("nn", "n").Replace("00", "0").Replace("pp", "p").Replace("qq", "q").Replace("rr", "r").Replace("ss", "s").Replace("tt", "t").Replace("uu", "u").Replace("vv", "v").Replace("ww", "w").Replace("xx", "x").Replace("yy", "y").Replace("zz", "z")
                        Next
                        For Each item In replytext
                            Dim backupitem1 = ((RemoveXtraSpaces(item)).Trim({"0"c, "o"c, "O"c, "L"c, "I"c, " "c, "*"c, "."c, "!"c, "@"c, "#"c, "$"c, "^"c, "&"c, "*"c, "("c, ")"c, "_"c, "-"c, "="c, "+"c, "["c, "{"c, "}"c, "]"c, ";"c, "\"c, "|"c, "<"c, ">"c, "/"c, "?"c})).Replace("3", "e").Replace("l", "1").Replace("4", "a").Replace("7", "t").Replace("0", "o").Replace("i", "1").Replace("I", "1").Replace("L", "1")
                            For i As Integer = 0 To backupitem1.Length / 2
                                backupitem1 = backupitem1.ToLower.Replace("aa", "a").Replace("bb", "b").Replace("cc", "c").Replace("dd", "d").Replace("ee", "e").Replace("ff", "f").Replace("gg", "g").Replace("hh", "h").Replace("11", "1").Replace("jj", "j").Replace("kk", "k").Replace("ll", "l").Replace("mm", "m").Replace("nn", "n").Replace("00", "0").Replace("pp", "p").Replace("qq", "q").Replace("rr", "r").Replace("ss", "s").Replace("tt", "t").Replace("uu", "u").Replace("vv", "v").Replace("ww", "w").Replace("xx", "x").Replace("yy", "y").Replace("zz", "z")
                            Next
                            If backupline1.ToLower.Contains(backupitem1.ToLower) Then
                                If MetroCheckBox7.Checked = True Then
                                    Dim toggle As Boolean = False
                                    For i As Integer = 0 To 9999
                                        If toggle = False Then
                                            toggle = True
                                            For Each app As Process In Process.GetProcessesByName(proc)
                                                Dim theHandle As IntPtr = FindWindow(Nothing, app.MainWindowTitle)
                                                If theHandle <> IntPtr.Zero Then
                                                    SetForegroundWindow(theHandle)
                                                End If
                                            Next
                                        End If
                                        Sleep(500)
                                        My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Beep)
                                        If MetroButton6.Text = "Start" Then
                                            Exit For
                                        End If
                                    Next
                                    Exit For
                                Else
                                    Timer1.Stop()
                                    Timer2.Stop()
                                    Timer3.Stop()
                                    Timer4.Stop()
                                    Timer5.Stop()
                                    Timer7.Stop()
                                    Timer8.Stop()
                                    Process.GetProcessesByName(proc)(0).Kill()
                                    Sleep(10)
                                    Process.GetCurrentProcess.Kill()
                                End If
                                Exit For
                            End If
                        Next
                    Next
                    System.IO.File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments).ToString + "\GTA San Andreas User Files\SAMP\chatlog.txt", "")
                    Sleep(150)
                Catch Ex As Exception
                End Try
                If crashstart = False Then
                    Exit Sub
                End If
            End While
        End While
    End Sub
    ' HexS
    Function HexS(ByVal hex As String) As String
        Try
            Dim text As New System.Text.StringBuilder(hex.Length \ 2)
            For i As Integer = 0 To hex.Length - 2 Step 2
                text.Append(Chr(Convert.ToByte(hex.Substring(i, 2), 16)))
            Next
            Return text.ToString
        Catch Ex As Exception
        End Try
    End Function
    ' Hex To Single
    Private Function HexToSingle(ByVal hexValue As String) As Single
        Try
            Dim iInputIndex As Integer = 0
            Dim iOutputIndex As Integer = 0
            Dim bArray(3) As Byte
            For iInputIndex = 0 To hexValue.Length - 1 Step 2
                bArray(iOutputIndex) = Byte.Parse(hexValue.Chars(iInputIndex) & hexValue.Chars(iInputIndex + 1), Globalization.NumberStyles.HexNumber)
                iOutputIndex += 1
            Next
            Array.Reverse(bArray)
            Return BitConverter.ToSingle(bArray, 0)
        Catch ex As Exception
        End Try
    End Function
    ' GetModulebaseAddress
    Public Function GetModuleBaseAddress(ByVal ProcessName As String, ByVal ModuleName As String) As Integer
        Dim BaseAddress As Integer
        Try
            For Each PM As ProcessModule In Process.GetProcessesByName(ProcessName)(0).Modules
                If ModuleName = PM.ModuleName Then
                    BaseAddress = PM.BaseAddress
                End If
            Next
        Catch ex As Exception

        End Try
        Return BaseAddress
    End Function
    ' Reply Button
    Private Sub MetroButton11_Click(sender As Object, e As EventArgs) Handles MetroButton11.Click
        Try
            If MetroButton11.Text = "Start" Then
                If MetroButton11.Text = "Stop" Then
                    MessageBox.Show("Firstly stop ""Crash Option"".", "Advanced Auto Clicker", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    If replytext.Count < 1 Or replypos.Count < 1 Then
                        MessageBox.Show("You must add some texts that you can reply with or some text to detect.", "Advanced Auto Clicker", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        If crashstart = True Then
                            MessageBox.Show("Firstly you need to stop ""Crash/Play Sound"" Option.", "Advanced Auto Clicker", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Else
                            If MetroTrackBar2.Value < MetroTrackBar1.Value Then
                                MessageBox.Show("First ""Time to Reply"" value must be lower then the second.", "Advanced Auto Clicker", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Else
                                MetroButton11.Text = "Stop"
                                System.IO.File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments).ToString + "\GTA San Andreas User Files\SAMP\chatlog.txt", "")
                                Dim reply = New Thread(AddressOf replysub)
                                replystart = True
                                reply.Start()
                                MetroButton10.Enabled = False
                                MetroTrackBar1.Enabled = False
                                MetroTrackBar2.Enabled = False
                                MetroButton7.Enabled = False
                                MetroButton8.Enabled = False
                                MetroButton9.Enabled = False
                                MetroButton13.Enabled = False
                                MetroButton12.Enabled = False
                                MetroTrackBar3.Enabled = False
                            End If
                        End If
                    End If
                End If
            Else
                MetroLabel3.Text = "Detected for " + detectedFor.ToString + " times."
                MetroButton11.Text = "Start"
                Dim reply = New Thread(AddressOf replysub)
                replystart = False
                reply.Abort()
                MetroTrackBar3.Enabled = True
                MetroButton10.Enabled = True
                MetroButton7.Enabled = True
                MetroButton8.Enabled = True
                MetroTrackBar1.Enabled = True
                MetroTrackBar2.Enabled = True
                MetroButton9.Enabled = True
                MetroButton13.Enabled = True
                MetroButton12.Enabled = True
                xpos = ReadDMALong(proc, "&HB6F5F0", Offsets:={&H14, &H30}, Level:=2, nsize:=4)
                ypos = ReadDMALong(proc, "&HB6F5F0", Offsets:={&H14, &H34}, Level:=2, nsize:=4)
                zpos = ReadDMALong(proc, "&HB6F5F0", Offsets:={&H14, &H38}, Level:=2, nsize:=4)
                reset = False
                System.IO.File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments).ToString + "\GTA San Andreas User Files\SAMP\chatlog.txt", "")
            End If
        Catch Ex As Exception
        End Try
    End Sub
    ' Reply Sub
    Public Shared Function RemoveXtraSpaces(strVal As String) As String
        Dim iCount As Integer = 1
        Dim sTempstrVal As String
        sTempstrVal = ""
        For iCount = 1 To Len(strVal)
            sTempstrVal = sTempstrVal + Mid(strVal, iCount, 1).Trim
        Next
        RemoveXtraSpaces = sTempstrVal
        Return RemoveXtraSpaces
    End Function
    Public Sub replysub()
        While (True)
            While replystart = True
                Try
                    Dim lastchatline As List(Of String) = System.IO.File.ReadAllLines(My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\GTA San Andreas User Files\SAMP\chatlog.txt").ToList
                    For Each line In lastchatline
                        Dim backupline1 = ((RemoveXtraSpaces(line)).Trim({"0"c, "o"c, "O"c, "L"c, "I"c, " "c, "*"c, "."c, "!"c, "@"c, "#"c, "$"c, "^"c, "&"c, "*"c, "("c, ")"c, "_"c, "-"c, "="c, "+"c, "["c, "{"c, "}"c, "]"c, ";"c, "\"c, "|"c, "<"c, ">"c, "/"c, "?"c})).Replace("3", "e").Replace("l", "1").Replace("4", "a").Replace("7", "t").Replace("0", "o").Replace("i", "1").Replace("I", "1").Replace("L", "1")
                        For i As Integer = 0 To backupline1.Length / 2
                            backupline1 = backupline1.ToLower.Replace("aa", "a").Replace("bb", "b").Replace("cc", "c").Replace("dd", "d").Replace("ee", "e").Replace("ff", "f").Replace("gg", "g").Replace("hh", "h").Replace("11", "1").Replace("jj", "j").Replace("kk", "k").Replace("ll", "l").Replace("mm", "m").Replace("nn", "n").Replace("00", "0").Replace("pp", "p").Replace("qq", "q").Replace("rr", "r").Replace("ss", "s").Replace("tt", "t").Replace("uu", "u").Replace("vv", "v").Replace("ww", "w").Replace("xx", "x").Replace("yy", "y").Replace("zz", "z")
                        Next
                        For Each item In replytext
                            Dim backupitem1 = ((RemoveXtraSpaces(item)).Trim({"0"c, "o"c, "O"c, "L"c, "I"c, " "c, "*"c, "."c, "!"c, "@"c, "#"c, "$"c, "^"c, "&"c, "*"c, "("c, ")"c, "_"c, "-"c, "="c, "+"c, "["c, "{"c, "}"c, "]"c, ";"c, "\"c, "|"c, "<"c, ">"c, "/"c, "?"c})).Replace("3", "e").Replace("l", "1").Replace("4", "a").Replace("7", "t").Replace("0", "o").Replace("i", "1").Replace("I", "1").Replace("L", "1")
                            For i As Integer = 0 To backupitem1.Length / 2
                                backupitem1 = backupitem1.ToLower.Replace("aa", "a").Replace("bb", "b").Replace("cc", "c").Replace("dd", "d").Replace("ee", "e").Replace("ff", "f").Replace("gg", "g").Replace("hh", "h").Replace("11", "1").Replace("jj", "j").Replace("kk", "k").Replace("ll", "l").Replace("mm", "m").Replace("nn", "n").Replace("00", "0").Replace("pp", "p").Replace("qq", "q").Replace("rr", "r").Replace("ss", "s").Replace("tt", "t").Replace("uu", "u").Replace("vv", "v").Replace("ww", "w").Replace("xx", "x").Replace("yy", "y").Replace("zz", "z")
                            Next
                            If backupline1.ToLower.Contains(backupitem1.ToLower) Then
                                Sleep(50)
                                If backupline1.Contains("'") Then
                                    If backupline1.IndexOf("'") <> backupline1.LastIndexOf("'") Then
                                        Dim startpos = (line.IndexOf("'"))
                                        Dim endpos = line.LastIndexOf("'")
                                        Dim lastchatline2 = line.Remove(endpos)
                                        Dim sResult = lastchatline2.Substring(startpos + 1)
                                        If sResult.Length > 0 Then
                                            reset = True
                                            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Beep)
                                            Dim rnd2 = New Random()
                                            Dim randomtime = CInt(rnd2.Next(MetroTrackBar1.Value, MetroTrackBar2.Value))
                                            Sleep(randomtime)
                                            If reset = True Then
                                                SendMSG(sResult)
                                            End If
                                            Sleep(MetroTrackBar3.Value)
                                            reset = False
                                            Exit For
                                        Else
                                            Dim rnd = New Random()
                                            Dim randomFruit = replypos(rnd.Next(0, replypos.Count))
                                            reset = True
                                            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Beep)
                                            Dim rnd2 = New Random()
                                            Dim randomtime = CInt(rnd2.Next(MetroTrackBar1.Value, MetroTrackBar2.Value))
                                            Sleep(randomtime)
                                            If reset = True Then
                                                SendMSG(randomFruit)
                                            End If
                                            Sleep(MetroTrackBar3.Value)
                                            reset = False
                                            Exit For
                                        End If
                                    End If
                                End If
                                If backupline1.Contains(Chr(34)) Then
                                    If backupline1.IndexOf(Chr(34)) <> backupline1.LastIndexOf(Chr(34)) Then
                                        Dim startpos2 = (line.IndexOf(Chr(34)))
                                        Dim endpos2 = line.LastIndexOf(Chr(34))
                                        Dim lastchatline3 = line.Remove(endpos2)
                                        Dim sResult2 = lastchatline3.Substring(startpos2 + 1)
                                        If sResult2.Length > 0 Then
                                            reset = True
                                            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Beep)
                                            Dim rnd2 = New Random()
                                            Dim randomtime = CInt(rnd2.Next(MetroTrackBar1.Value, MetroTrackBar2.Value))
                                            Sleep(randomtime)
                                            If reset = True Then
                                                SendMSG(sResult2)
                                            End If
                                            Sleep(MetroTrackBar3.Value)
                                            reset = False
                                            Exit For
                                        Else
                                            Dim rnd = New Random()
                                            Dim randomFruit = replypos(rnd.Next(0, replypos.Count))
                                            reset = True
                                            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Beep)
                                            Dim rnd2 = New Random()
                                            Dim randomtime = CInt(rnd2.Next(MetroTrackBar1.Value, MetroTrackBar2.Value))
                                            Sleep(randomtime)
                                            If reset = True Then
                                                SendMSG(randomFruit)
                                            End If
                                            Sleep(MetroTrackBar3.Value)
                                            reset = False
                                            Exit For
                                        End If
                                    End If
                                End If
                                Try
                                    Dim rnd = New Random()
                                    Dim randomFruit = replypos(rnd.Next(0, replypos.Count))
                                    reset = True
                                    My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Beep)
                                    Dim rnd2 = New Random()
                                    Dim randomtime = CInt(rnd2.Next(MetroTrackBar1.Value, MetroTrackBar2.Value))
                                    Sleep(randomtime)
                                    If reset = True Then
                                        SendMSG(randomFruit)
                                    End If
                                    Sleep(MetroTrackBar3.Value)
                                    reset = False
                                    Exit For
                                Catch ex As Exception
                                End Try
                            End If
                        Next
                        System.IO.File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments).ToString + "\GTA San Andreas User Files\SAMP\chatlog.txt", "")
                        Sleep(150)
                    Next
                Catch Ex As Exception
                End Try
                If replystart = False Then
                    Exit Sub
                End If
            End While
        End While
    End Sub
    ' Add Reply Pos Text
    Private Sub MetroButton13_Click(sender As Object, e As EventArgs) Handles MetroButton13.Click
        For Each texts In replypos
            If texts = MetroTextBox5.Text Then
                MessageBox.Show("The item is already in the list.", "Advanced Auto Clicker", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
        Next
        If MetroTextBox5.Text = Nothing Then
            MessageBox.Show("The item can't be null.", "Advanced Auto Clicker", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else

            replypos.Add(MetroTextBox5.Text)
            MetroTextBox5.Text = Nothing
            MessageBox.Show("The item was added.", "Advanced Auto Clicker", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
    ' Remove Reply Pos Text
    Private Sub MetroButton12_Click(sender As Object, e As EventArgs) Handles MetroButton12.Click
        For Each texts In replypos
            If texts = MetroTextBox5.Text Then
                replypos.Remove(texts)
                MetroTextBox5.Text = Nothing
                MessageBox.Show("The item was removed.", "Advanced Auto Clicker", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
        Next
        MessageBox.Show("The item doesn't exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub
    ' Add Reply Pos Text
    Private Sub MetroButton10_Click(sender As Object, e As EventArgs) Handles MetroButton10.Click
        For Each texts In replytext
            If texts = MetroTextBox4.Text Then
                MessageBox.Show("The item is already in the list.", "Advanced Auto Clicker", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
        Next
        If MetroTextBox4.Text = Nothing Then
            MessageBox.Show("The item can't be null.", "Advanced Auto Clicker", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            replytext.Add(MetroTextBox4.Text)
            MetroTextBox4.Text = Nothing
            MessageBox.Show("The item was added.", "Advanced Auto Clicker", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
    ' Remove Reply Pos Text
    Private Sub MetroButton9_Click(sender As Object, e As EventArgs) Handles MetroButton9.Click
        For Each texts In replytext
            If texts = MetroTextBox4.Text Then
                replytext.Remove(texts)
                MetroTextBox4.Text = Nothing
                MessageBox.Show("The item was removed.", "Advanced Auto Clicker", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
        Next
        MessageBox.Show("The item doesn't exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub
    ' Camera Pos changer
    Private Sub MetroCheckBox3_CheckedChanged(sender As Object, e As EventArgs) Handles MetroCheckBox3.CheckedChanged
        If MetroCheckBox3.Checked = True Then
            loops = 0
            Timer2.Start()
        Else
            Timer2.Stop()
        End If
    End Sub
    ' Camera Pos Changer Timer
    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Try
            If reset = False Then
                If loops <= 500 Then
                    Dim camerax = ReadFloat(proc, "&HB6F258", nsize:=4)
                    WriteFloat(proc, "&HB6F258", Value:=camerax + 0.015)
                    loops += 1
                Else
                    Dim camerax = ReadFloat(proc, "&HB6F258", nsize:=4)
                    WriteFloat(proc, "&HB6F258", Value:=camerax - 0.015)
                    loops += 1
                    If loops > 1000 Then
                        loops = 0
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    ' Auto Heal
    Private Sub MetroCheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles MetroCheckBox2.CheckedChanged
        Try
            Dim sampADDR = GetModuleBaseAddress(proc, "samp.dll")
            If MetroCheckBox2.Checked = True Then
                WriteLong(proc, sampADDR + "&H15BA0", "754880707")
            Else
                WriteLong(proc, sampADDR + "&H15BA0", "754848233")
            End If
        Catch ex As Exception

        End Try
    End Sub
    ' Infinity Run
    Private Sub MetroCheckBox4_CheckedChanged(sender As Object, e As EventArgs) Handles MetroCheckBox4.CheckedChanged
        If MetroCheckBox4.Checked = True Then
            Timer3.Start()
        Else
            Timer3.Stop()
        End If
    End Sub
    ' Infinity Run Timer
    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick
        Try
            WriteLong(proc, "&HB7CDB4", Value:=1162129409)
        Catch Ex As Exception
        End Try
    End Sub
    ' Teleport Map
    Private Sub MetroCheckBox5_CheckedChanged(sender As Object, e As EventArgs) Handles MetroCheckBox5.CheckedChanged
        Try
            If MetroCheckBox5.Checked = True Then
                MetroLabel10.Visible = True
                togglemap = ReadLong(proc, "&HBA6778", nsize:=4)
                Timer4.Start()
            Else
                MetroLabel10.Visible = False
                Timer4.Stop()
            End If
        Catch ex As Exception
        End Try
    End Sub
    ' Teleport Map Timer
    Private Sub Timer4_Tick(sender As Object, e As EventArgs) Handles Timer4.Tick
        Try
            Dim xmap = ReadLong(proc, "&HBA67B8", nsize:=4)
            Dim ymap = ReadLong(proc, "&HBA67BC", nsize:=4)
            If togglemap = 0 Then
                If GetAsyncKeyState(Keys.Space) Then
                    Dim xpos = ReadDMALong(proc, "&HB6F5F0", Offsets:={&H14, &H30}, Level:=2, nsize:=4)
                    Dim ypos = ReadDMALong(proc, "&HB6F5F0", Offsets:={&H14, &H34}, Level:=2, nsize:=4)
                    Dim zpos = ReadDMALong(proc, "&HB6F5F0", Offsets:={&H14, &H34}, Level:=2, nsize:=4)
                    WriteLong(proc, "&H859014", Value:=2, nsize:=4)
                    Sleep(10)
                    WriteDMALong(proc, "&HB6F5F0", Offsets:={&H14, &H38}, Value:=zpos * 2, Level:=2, nsize:=4)
                    Sleep(10)
                    WriteDMALong(proc, "&HB6F5F0", Offsets:={&H14, &H30}, Value:=xmap, Level:=2, nsize:=4)
                    Sleep(10)
                    WriteDMALong(proc, "&HB6F5F0", Offsets:={&H14, &H34}, Value:=ymap, Level:=2, nsize:=4)
                    Sleep(10)
                    WriteDMALong(proc, "&HB6F5F0", Offsets:={&H14, &H38}, Value:=0, Level:=2, nsize:=4)
                    Sleep(2000)
                    WriteLong(proc, "&H859014", Value:=3267887104, nsize:=4)
                End If
            End If
            togglemap = ReadLong(proc, "&HBA6778", nsize:=4)
        Catch ex As Exception
        End Try
    End Sub
    ' Show Items replytext
    Private Sub MetroButton14_Click(sender As Object, e As EventArgs) Handles MetroButton14.Click
        Dim sResult As String = ""
        Dim i = 0
        For Each elem As String In replytext
            i += 1
            sResult &= i.ToString & ". """ & elem & """" & vbNewLine
        Next
        MessageBox.Show(sResult, "Items", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
    ' Show items replypos
    Private Sub MetroButton15_Click(sender As Object, e As EventArgs) Handles MetroButton15.Click
        Dim sResult As String = ""
        Dim i = 0
        For Each elem As String In replypos
            i += 1
            sResult &= i.ToString & ". """ & elem & """" & vbNewLine
        Next
        MessageBox.Show(sResult, "Items", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
    ' Show items replytext
    Private Sub MetroButton16_Click(sender As Object, e As EventArgs) Handles MetroButton16.Click
        Dim sResult As String = ""
        Dim i = 0
        For Each elem As String In replytext
            i += 1
            sResult &= i.ToString & ". """ & elem & """" & vbNewLine
        Next
        MessageBox.Show(sResult, "Items", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
    ' Slap 
    Private Sub MetroCheckBox6_CheckedChanged(sender As Object, e As EventArgs) Handles MetroCheckBox6.CheckedChanged
        If MetroCheckBox6.Checked = True Then
            Timer5.Start()
            MetroLabel9.Visible = True
        Else
            MetroLabel9.Visible = False
            Timer5.Stop()
        End If
    End Sub
    ' Slap Timer
    Private Sub Timer5_Tick(sender As Object, e As EventArgs) Handles Timer5.Tick
        Try
            Dim slap = ReadDMALong(proc, "&HB6F5F0", Offsets:={&H14, &H38}, Level:=2, nsize:=4)
            Dim slapkey = ReadLong(proc, "&HBA6768", nsize:=4)
            Try
                If slapkey = 1 Then
                    WriteLong(proc, "&H859014", Value:=2, nsize:=4)
                    WriteDMALong(proc, "&HB6F5F0", Offsets:={&H14, &H38}, Value:=slap + 4000000, Level:=2, nsize:=4)
                    Sleep(10)
                    WriteLong(proc, "&H859014", Value:=3267887104, nsize:=4)
                End If
            Catch ex As Exception
            End Try
        Catch ex As Exception
        End Try
    End Sub
    ' Play Sound
    Private Sub MetroCheckBox7_CheckedChanged(sender As Object, e As EventArgs) Handles MetroCheckBox7.CheckedChanged
        If MetroCheckBox7.Checked = True Then
            MetroCheckBox8.Checked = False
        Else
            MetroCheckBox8.Checked = True
        End If
    End Sub
    ' Crash ss
    Private Sub MetroCheckBox8_CheckedChanged(sender As Object, e As EventArgs) Handles MetroCheckBox8.CheckedChanged
        If MetroCheckBox8.Checked = True Then
            MetroCheckBox7.Checked = False
        Else
            MetroCheckBox7.Checked = True
        End If
    End Sub
    ' Slapper
    Private Sub MetroCheckBox9_CheckedChanged(sender As Object, e As EventArgs) Handles MetroCheckBox9.CheckedChanged
        If MetroCheckBox9.Checked = True Then
            xpos2 = ReadDMALong(proc, "&HB6F5F0", Offsets:={&H14, &H30}, Level:=2, nsize:=4)
            ypos2 = ReadDMALong(proc, "&HB6F5F0", Offsets:={&H14, &H34}, Level:=2, nsize:=4)
            Timer8.Start()
        Else
            Timer8.Stop()
        End If
    End Sub
    ' Slapper Timer
    Private Sub Timer8_Tick(sender As Object, e As EventArgs) Handles Timer8.Tick
        Try
            Dim slap = ReadDMALong(proc, "&HB6F5F0", Offsets:={&H14, &H38}, Level:=2, nsize:=4)
            WriteLong(proc, "&H859014", Value:=2, nsize:=4)
            WriteDMALong(proc, "&HB6F5F0", Offsets:={&H14, &H38}, Value:=slap + 4000000, Level:=2, nsize:=4)
            Sleep(10)
            WriteDMALong(proc, "&HB6F5F0", Offsets:={&H14, &H30}, Value:=xpos2, Level:=2, nsize:=4)
            WriteDMALong(proc, "&HB6F5F0", Offsets:={&H14, &H34}, Value:=ypos2, Level:=2, nsize:=4)
            WriteLong(proc, "&H859014", Value:=3267887104, nsize:=4)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub MetroTextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MetroTextBox1.KeyPress
        If e.KeyChar = Convert.ToChar(1) Then
            If MetroTextBox1.Text.Length > 0 Then
                MetroTextBox1.SelectAll()
                e.Handled = True
            End If
        End If
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            If MetroTextBox1.Text.Length = 0 Then
                SendMSG(" ")
                MetroTextBox1.Text = Nothing
                e.Handled = True
            Else
                If MetroTextBox1.Text.Substring(0, 1) = "/" Then
                    SendCMD(MetroTextBox1.Text)
                Else
                    SendMSG(MetroTextBox1.Text)
                End If
                MetroTextBox1.Text = Nothing
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub MetroButton3_Click(sender As Object, e As EventArgs) Handles MetroButton3.Click
        If MetroTextBox1.Text.Length > 0 Then
            If MetroTextBox1.Text.Substring(0, 1) = "/" Then
                SendCMD(MetroTextBox1.Text)
            Else
                SendMSG(MetroTextBox1.Text)
            End If
            MetroTextBox1.Text = Nothing
        End If
    End Sub
    Dim detectedFor = 0
    Dim lastDetectedFor = 0
    Dim lastSize = -1
    Dim lastLenght
    Private Const WM_USER As Integer = &H400
    Private Const EM_SETEVENTMASK As Integer = (WM_USER + 69)
    Private Const WM_SETREDRAW As Integer = &HB
    Private OldEventMask As IntPtr
    <DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Auto)>
    Private Shared Function SendMessage(ByVal hWnd As IntPtr, ByVal Msg As UInteger, ByVal wParam As IntPtr, ByVal lParam As IntPtr) As IntPtr
    End Function
    Public Function BeginUpdate()
        SendMessage(RichTextBox1.Handle, WM_SETREDRAW, IntPtr.Zero, IntPtr.Zero)
        OldEventMask = SendMessage(RichTextBox1.Handle, EM_SETEVENTMASK, IntPtr.Zero, IntPtr.Zero)
    End Function
    Public Function EndUpdate()
        SendMessage(RichTextBox1.Handle, WM_SETREDRAW, New IntPtr(1), IntPtr.Zero)
        OldEventMask = SendMessage(RichTextBox1.Handle, EM_SETEVENTMASK, IntPtr.Zero, OldEventMask)
    End Function
    Dim lastCheckedLine
    Private Sub Timer10_Tick(sender As Object, e As EventArgs) Handles Timer10.Tick
        If replystart = True Or crashstart = True Then
            MetroLabel3.Text = "This function wont't work while ""Reply"" or ""Crash/PlaySound"" option is running."
        Else
            BeginUpdate()
            detectedFor = 0
            Try

                Dim infoReader As System.IO.FileInfo
                infoReader = My.Computer.FileSystem.GetFileInfo(My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\GTA San Andreas User Files\SAMP\chatlog.txt")
                If lastSize <> infoReader.Length Then
                    RichTextBox1.Text = Nothing
                    lastSize = infoReader.Length
                    For Each s As String In System.IO.File.ReadAllLines(My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\GTA San Andreas User Files\SAMP\chatlog.txt")
                        Dim index As Integer = s.IndexOf("{")
                        While (index <> -1)
                            If s.IndexOf("}", index) <> -1 Then
                                s = String.Format("{0}{1}", s.Substring(0, index), s.Substring(s.IndexOf("}", index) + 1))
                            End If
                            index = s.IndexOf("{", If(index + 1 > s.Length, 0, index + 1))
                        End While
                        PrependText(RichTextBox1, s + vbNewLine)
                    Next
                    If lastLenght <> RichTextBox1.Lines.Length Then
                        For Each Line In RichTextBox1.Lines
                            If Not Line Is Nothing Then
                                For Each Line2 In replytext
                                    If Line.ToLower.ToString.Trim.Contains(RemoveXtraSpaces(Line2).ToLower) Then
                                        Dim s$ = Line.ToLower.Trim
                                        RichTextBox1.Select(RichTextBox1.Text.IndexOf(Line), Line.Length)
                                        If RichTextBox1.SelectionColor = Color.Yellow Then
                                        Else
                                            RichTextBox1.SelectionColor = Color.Yellow
                                            RichTextBox1.Select(0, 0)
                                            detectedFor = detectedFor + 1
                                        End If
                                    End If
                                Next
                            End If
                        Next
                    End If
                    If lastDetectedFor < detectedFor Then
                        MetroLabel3.Text = "Detected for " + detectedFor.ToString + " times."
                        If MetroCheckBox11.Checked = True Then
                            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Beep)
                            lastDetectedFor = detectedFor
                        End If
                    End If
                    If watch.ElapsedMilliseconds > 3600000 Then
                        RichTextBox1.Text = Nothing
                        File.WriteAllText(My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\GTA San Andreas User Files\SAMP\chatlog.txt", Nothing)
                        watch.Restart()
                    End If
                End If
                lastLenght = RichTextBox1.Lines.Length
                EndUpdate()
            Catch Ex As Exception
                lastSize = -1
            End Try
        End If
    End Sub
    Public Shared Sub PrependText(textBox As RichTextBox, text As String)
        If text.Length > 0 Then
            Dim start = textBox.SelectionStart
            Dim length = textBox.SelectionLength
            Try
                textBox.[Select](0, 0)
                textBox.SelectedText = text
            Finally
                If textBox.Width = 0 OrElse textBox.Height = 0 Then
                    textBox.[Select](start, length)
                End If
            End Try
        End If
    End Sub
    Private Sub MetroLink1_Click(sender As Object, e As EventArgs) Handles MetroLink1.Click
        Try
            Process.Start("www.ugbase.eu")
        Catch ex As Exception
        End Try
    End Sub
    Private Sub MetroButton1_Click(sender As Object, e As EventArgs) Handles MetroButton1.Click
        Try
            If replytext.Count > 0 Then
                If File.Exists(Path.GetTempPath() + "AAC.txt") Then
                    Dim inforeader As FileInfo
                    inforeader = My.Computer.FileSystem.GetFileInfo(Path.GetTempPath() + "AAC.txt")
                    If inforeader.Length > 0 Then
                        Dim result = MessageBox.Show("Are you sure you want to replace the last saved items ?", "Items", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                        If result = DialogResult.Yes Then
                            Try
                                System.IO.File.Delete(Path.GetTempPath() + "AAC.txt")
                            Catch ex As Exception
                            End Try
                            IO.File.CreateText(Path.GetTempPath() + "AAC.txt").Close()
                            Try
                                IO.File.SetAttributes(Path.GetTempPath() + "AAC.txt", IO.FileAttributes.Hidden)
                            Catch ex As Exception
                            End Try
                            Dim file As System.IO.StreamWriter
                            For Each item In replytext
                                file = My.Computer.FileSystem.OpenTextFileWriter(Path.GetTempPath() + "AAC.txt", True)
                                file.WriteLine(item)
                                file.Close()
                            Next
                            MessageBox.Show("These items were saved, you can load them now.", "Items", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Else
                            Exit Sub
                        End If
                    End If
                Else
                    Try
                        System.IO.File.Delete(Path.GetTempPath() + "AAC.txt")
                    Catch ex As Exception
                    End Try
                    IO.File.CreateText(Path.GetTempPath() + "AAC.txt").Close()
                    Try
                        IO.File.SetAttributes(Path.GetTempPath() + "AAC.txt", IO.FileAttributes.Hidden)
                    Catch ex As Exception
                    End Try
                    Dim file As System.IO.StreamWriter
                    For Each item In replytext
                        file = My.Computer.FileSystem.OpenTextFileWriter(Path.GetTempPath() + "AAC.txt", True)
                        file.WriteLine(item)
                        file.Close()
                    Next
                    MessageBox.Show("These items were saved, you can load them now.", "Items", MessageBoxButtons.OK, MessageBoxIcon.Information)

                End If
            Else
                MessageBox.Show("You need to add atleast 1 item to save it.", "Items", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch Ex As Exception
        End Try
    End Sub
    Private Sub MetroButton19_Click(sender As Object, e As EventArgs) Handles MetroButton19.Click
        If System.IO.File.Exists(Path.GetTempPath() + "AAC.txt") Then
            Try
                IO.File.SetAttributes(Path.GetTempPath() + "AAC.txt", IO.FileAttributes.Hidden)
            Catch ex As Exception
            End Try
            If replytext.Count > 0 Then
                Dim result = MessageBox.Show("Are you sure you want to replace the loaded items ?", "Items", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                If result = DialogResult.Yes Then
                    Dim liness As List(Of String) = File.ReadAllLines(Path.GetTempPath() + "AAC.txt").ToList
                    replytext.Clear()
                    For Each line In liness
                        replytext.Add(line)
                    Next
                    MessageBox.Show("The items were loaded.", "Items", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    Exit Sub
                End If
            Else
                Dim liness As List(Of String) = File.ReadAllLines(Path.GetTempPath() + "AAC.txt").ToList
                replytext.Clear()
                For Each line In liness
                    replytext.Add(line)
                Next
                MessageBox.Show("The items were loaded.", "Items", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Else
            MessageBox.Show("Firstly you must save some items.", "Items", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
    Private Sub MetroButton20_Click(sender As Object, e As EventArgs) Handles MetroButton20.Click
        If File.Exists(Path.GetTempPath() + "AAC.txt") Then
            Try
                System.IO.File.Delete(Path.GetTempPath() + "AAC.txt")
            Catch ex As Exception
                MessageBox.Show("I can't delete that.", "Items", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End Try
            MessageBox.Show("The profile was deleted.", "Items", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Nothing to delete.", "Items", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
    Private Sub MetroButton23_Click(sender As Object, e As EventArgs) Handles MetroButton23.Click
        Try
            If replytext.Count > 0 Then
                If File.Exists(Path.GetTempPath() + "AAC.txt") Then
                    Dim inforeader As FileInfo
                    inforeader = My.Computer.FileSystem.GetFileInfo(Path.GetTempPath() + "AAC.txt")
                    If inforeader.Length > 0 Then
                        Dim result = MessageBox.Show("Are you sure you want to replace the last saved items ?", "Items", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                        If result = DialogResult.Yes Then
                            Try
                                System.IO.File.Delete(Path.GetTempPath() + "AAC.txt")
                            Catch ex As Exception
                            End Try
                            IO.File.CreateText(Path.GetTempPath() + "AAC.txt").Close()
                            Try
                                IO.File.SetAttributes(Path.GetTempPath() + "AAC.txt", IO.FileAttributes.Hidden)
                            Catch ex As Exception
                            End Try
                            Dim file As System.IO.StreamWriter
                            For Each item In replytext
                                file = My.Computer.FileSystem.OpenTextFileWriter(Path.GetTempPath() + "AAC.txt", True)
                                file.WriteLine(item)
                                file.Close()
                            Next
                            MessageBox.Show("These items were saved, you can load them now.", "Items", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Else
                            Exit Sub
                        End If
                    End If
                Else
                    Try
                        System.IO.File.Delete(Path.GetTempPath() + "AAC.txt")
                    Catch ex As Exception
                    End Try
                    IO.File.CreateText(Path.GetTempPath() + "AAC.txt").Close()
                    Try
                        IO.File.SetAttributes(Path.GetTempPath() + "AAC.txt", IO.FileAttributes.Hidden)
                    Catch ex As Exception
                    End Try
                    Dim file As System.IO.StreamWriter
                    For Each item In replytext
                        file = My.Computer.FileSystem.OpenTextFileWriter(Path.GetTempPath() + "AAC.txt", True)
                        file.WriteLine(item)
                        file.Close()
                    Next
                    MessageBox.Show("These items were saved, you can load them now.", "Items", MessageBoxButtons.OK, MessageBoxIcon.Information)

                End If
            Else
                MessageBox.Show("You need to add atleast 1 item to save it.", "Items", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch Ex As Exception
        End Try
    End Sub
    Private Sub MetroButton22_Click(sender As Object, e As EventArgs) Handles MetroButton22.Click
        If System.IO.File.Exists(Path.GetTempPath() + "AAC.txt") Then
            Try
                IO.File.SetAttributes(Path.GetTempPath() + "AAC.txt", IO.FileAttributes.Hidden)
            Catch ex As Exception
            End Try
            If replytext.Count > 0 Then
                Dim result = MessageBox.Show("Are you sure you want to replace the loaded items ?", "Items", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                If result = DialogResult.Yes Then
                    Dim liness As List(Of String) = File.ReadAllLines(Path.GetTempPath() + "AAC.txt").ToList
                    replytext.Clear()
                    For Each line In liness
                        replytext.Add(line)
                    Next
                    MessageBox.Show("The items were loaded.", "Items", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    Exit Sub
                End If
            Else
                Dim liness As List(Of String) = File.ReadAllLines(Path.GetTempPath() + "AAC.txt").ToList
                replytext.Clear()
                For Each line In liness
                    replytext.Add(line)
                Next
                MessageBox.Show("The items were loaded.", "Items", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Else
            MessageBox.Show("Firstly you must save some items.", "Items", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
    Private Sub MetroButton21_Click(sender As Object, e As EventArgs) Handles MetroButton21.Click
        If File.Exists(Path.GetTempPath() + "AAC.txt") Then
            Try
                System.IO.File.Delete(Path.GetTempPath() + "AAC.txt")
            Catch ex As Exception
                MessageBox.Show("I can't delete that.", "Items", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End Try
            MessageBox.Show("The profile was deleted.", "Items", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Nothing to delete.", "Items", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
    Dim CMDToSend
    Private Sub MetroCheckBox10_CheckedChanged(sender As Object, e As EventArgs) Handles MetroCheckBox10.CheckedChanged
        If MetroCheckBox10.Checked = True Then
            MetroLabel12.Visible = True
            MetroTrackBar4.Visible = True
            MetroLabel13.Visible = True
            MetroTextBox8.Visible = True
            MetroButton24.Visible = True
            MetroLabel20.Visible = True
        Else
            MetroLabel12.Visible = False
            MetroLabel20.Visible = False
            MetroTrackBar4.Visible = False
            MetroLabel13.Visible = False
            MetroTextBox8.Visible = False
            MetroButton24.Visible = False
        End If
    End Sub
    Private Sub MetroTextBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
                My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Exclamation)
            End If
        End If
    End Sub
    Private Sub Timer11_Tick(sender As Object, e As EventArgs) Handles Timer11.Tick
        Try
            SendCMD(CMDToSend)
        Catch ex As Exception
        End Try
    End Sub
    Private Sub MetroButton24_Click(sender As Object, e As EventArgs) Handles MetroButton24.Click
        If MetroButton24.Text = "Start" Then
            Timer11.Interval = MetroTrackBar4.Value
            If MetroTextBox8.Text.Length = 0 Then
                MessageBox.Show("You must type a command to send.", "CMD Sender", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ElseIf MetroTextBox8.Text.Substring(0, 1) = "/" Then
                CMDToSend = MetroTextBox8.Text
                Timer11.Start()
                MetroButton24.Text = "Stop"
                MetroTextBox8.Enabled = False
                MetroTrackBar4.Enabled = False
            Else
                CMDToSend = "/" + MetroTextBox8.Text
                Timer11.Start()
                MetroButton24.Text = "Stop"
                MetroTextBox8.Enabled = False
                MetroTrackBar4.Enabled = False
            End If
        Else
            MetroTextBox8.Enabled = True
            MetroTrackBar4.Enabled = True
            MetroButton24.Text = "Start"
            Timer11.Stop()
        End If
    End Sub

    Private Sub MetroCheckBox12_CheckedChanged(sender As Object, e As EventArgs) Handles MetroCheckBox12.CheckedChanged
        If MetroCheckBox12.Checked = True Then
            Try
                WriteLong(proc, "&H74542B", 2425393296)
                WriteLong(proc, "&H74542F", 2425393296)
                WriteXBytes(proc, "&H74805A", 905)

            Catch ex As Exception
                MetroCheckBox12.Checked = False
            End Try
        Else
            Try
                WriteLong(proc, "&H74542B", 369054032)
                WriteLong(proc, "&H74542F", 8749824)
                WriteXBytes(proc, "&H74805A", -20)
            Catch ex As Exception
                MetroCheckBox12.Checked = False
            End Try
        End If
    End Sub

    Private Sub MetroButton25_Click(sender As Object, e As EventArgs) Handles MetroButton25.Click
        Try
            WriteLong(proc, sampAddr + "&H15BA0", "754848233")
            WriteLong(proc, sampAddr + "&H2D3C45", Value:=3000, nsize:=4)
        Catch ex As Exception
        End Try
        If MetroCheckBox12.Checked Then
            Try
                WriteLong(proc, "&H74542B", 369054032)
                WriteLong(proc, "&H74542F", 8749824)
                WriteXBytes(proc, "&H74805A", -20)
            Catch ex As Exception
            End Try
        End If
        Process.GetCurrentProcess.Kill()
    End Sub
    <DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Auto)>
    Private Shared Function ShowWindow(ByVal hwnd As IntPtr, ByVal nCmdShow As Integer) As Boolean
    End Function
    Private Sub MetroButton26_Click(sender As Object, e As EventArgs) Handles MetroButton26.Click
        Me.ShowInTaskbar = True
        ShowWindow(Me.Handle, 6)
    End Sub

    Private Sub MetroTrackBar1_Scroll(sender As Object, e As ScrollEventArgs) Handles MetroTrackBar1.Scroll
        MetroLabel15.Text = MetroTrackBar1.Value.ToString + " (" + TimeSpan.FromMilliseconds(MetroTrackBar1.Value).Seconds.ToString + " sec)"
    End Sub

    Private Sub MetroTrackBar2_Scroll(sender As Object, e As ScrollEventArgs) Handles MetroTrackBar2.Scroll
        MetroLabel16.Text = MetroTrackBar2.Value.ToString + " (" + TimeSpan.FromMilliseconds(MetroTrackBar2.Value).Seconds.ToString + " sec)"
    End Sub

    Private Sub MetroTrackBar3_Scroll(sender As Object, e As ScrollEventArgs) Handles MetroTrackBar3.Scroll
        MetroLabel19.Text = MetroTrackBar3.Value.ToString + " (" + TimeSpan.FromMilliseconds(MetroTrackBar3.Value).Minutes.ToString + " min)"
    End Sub

    Private Sub MetroTrackBar4_Scroll(sender As Object, e As ScrollEventArgs) Handles MetroTrackBar4.Scroll
        MetroLabel20.Text = MetroTrackBar4.Value.ToString + " (" + TimeSpan.FromMilliseconds(MetroTrackBar4.Value).Minutes.ToString + " min)"
    End Sub
    Public hwnd
    Public Function SingleToHex(ByVal Tmp As Single) As String
        Dim arr = BitConverter.GetBytes(Tmp)
        Array.Reverse(arr)
        Return BitConverter.ToString(arr).Replace("-", "")
    End Function

    Private Sub MetroCheckBox13_CheckedChanged(sender As Object, e As EventArgs) Handles MetroCheckBox13.CheckedChanged
        If MetroCheckBox13.Checked = True Then
            Me.TopMost = True
        Else
            Me.TopMost = False
        End If
    End Sub
End Class
