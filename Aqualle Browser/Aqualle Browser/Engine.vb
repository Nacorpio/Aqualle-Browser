
Public Class Engine

    Private Const MAIN_PATH As String = "C:\Program Files\Aqualle"

    Private Const OPTIONS_D As String = MAIN_PATH & "\Browser\Options"
    Private Const COOKIES_D As String = MAIN_PATH & "\Browser\Cookies"

    Private Const BOOKMARKS_P As String = MAIN_PATH & "\Browser\Options\bm.adb"
    Private Const CACHE_P As String = MAIN_PATH & "\Browser\Options\cache_1.adb"
    Private Const COOKIE_P As String = MAIN_PATH & "\Browser\Cookies\c_1.adb"
    Private Const HISTORY_P As String = MAIN_PATH & "\Browser\Options\h.adb"

    ''' <summary>
    ''' The current version of the browser.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>

    Public ReadOnly Property Version As String
        Get
            Return "0.0.1.0"
        End Get
    End Property

    Sub New(ByVal fileName As String)
        If FileIO.FileSystem.DirectoryExists(MAIN_PATH) Then
ON_START:
            FileIO.FileSystem.CreateDirectory(OPTIONS_D)
            FileIO.FileSystem.CreateDirectory(COOKIES_D)
        Else
            FileIO.FileSystem.CreateDirectory(MAIN_PATH)
            If FileIO.FileSystem.DirectoryExists(MAIN_PATH) Then
                GoTo ON_START
            Else
                Throw New Exception("An error occured: It's an unknown reason.")
            End If
        End If
    End Sub

    ''' <summary>
    ''' Clear all of the cookies.
    ''' </summary>
    ''' <remarks></remarks>

    Public Sub ClearCookies()
        If FileIO.FileSystem.DirectoryExists(COOKIES_D) Then
            For Each f As String In FileIO.FileSystem.GetFiles(COOKIES_D)
                If f.StartsWith("c_") Then
                    FileIO.FileSystem.DeleteFile(f)
                End If
            Next
        End If
    End Sub

End Class
