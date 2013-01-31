
Public Class Engine

    Private Const MAIN_PATH As String = "C:\Program Files\Aqualle"

    Private Const OPTIONS_D As String = MAIN_PATH & "\Browser\Options"
    Private Const COOKIES_D As String = MAIN_PATH & "\Browser\Cookies"

    Private Const BOOKMARKS_P As String = MAIN_PATH & "\Browser\Options\bm.adb"
    Private Const CACHE_P As String = MAIN_PATH & "\Browser\Options\cache_1.adb"
    Private Const COOKIE_P As String = MAIN_PATH & "\Browser\Cookies\c_1.adb"
    Private Const HISTORY_P As String = MAIN_PATH & "\Browser\Options\h.adb"

    ''' <summary>
    ''' The cache that is stored from the information.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>

    Public ReadOnly Property Cache As String()
        Get
            If FileIO.FileSystem.DirectoryExists(OPTIONS_D) Then
                Dim cacheBlock() As String = New String() {}
                For i As Integer = 0 To FileIO.FileSystem.GetFiles(OPTIONS_D).Count - 1
                    If FileIO.FileSystem.GetFileInfo(FileIO.FileSystem.GetFiles(OPTIONS_D)(i)).FullName.StartsWith("cache_") Then
                        If cacheBlock(i) = Nothing Then
                            cacheBlock(i) = FileIO.FileSystem.GetFiles(OPTIONS_D)(i)
                        End If
                    End If
                Next
                Return cacheBlock
            Else
                Return Nothing
            End If
        End Get
    End Property

    ''' <summary>
    ''' The cookies in the web browser.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>

    Public ReadOnly Property Cookies As String()
        Get
            If FileIO.FileSystem.DirectoryExists(COOKIES_D) Then
                Dim cookieBlock() As String = New String() {}
                For i As Integer = 0 To FileIO.FileSystem.GetFiles(COOKIES_D).Count - 1
                    If FileIO.FileSystem.GetFiles(COOKIE_P)(i).StartsWith("c_") Then
                        If cookieBlock(i) = Nothing Then
                            cookieBlock(i) = FileIO.FileSystem.GetFiles(COOKIE_P)(i)
                        End If
                    End If
                Next
                Return cookieBlock
            Else
                Return Nothing
            End If
        End Get
    End Property

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

    ''' <summary>
    ''' Clear all of the cache.
    ''' </summary>
    ''' <remarks></remarks>

    Public Sub ClearCache()
        If FileIO.FileSystem.DirectoryExists(OPTIONS_D) Then
            For Each f As String In FileIO.FileSystem.GetFiles(OPTIONS_D)
                If f.StartsWith("cache_") Then
                    FileIO.FileSystem.DeleteFile(f)
                End If
            Next
        End If
    End Sub

End Class
