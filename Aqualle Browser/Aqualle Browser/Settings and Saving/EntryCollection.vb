Imports System.Text.RegularExpressions

Public Class EntryCollection

    Inherits List(Of Entry)

    ''' <summary>
    ''' Import a collection of entries from a file, using its source.
    ''' </summary>
    ''' <param name="fileName">The path of the file to read.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>

    Public Shared Function Import(ByVal fileName As String) As EntryCollection
        Dim regex As New Regex("{var name=""(.*?)"" value=""(.*?)""}")
        Dim results As New List(Of Entry)
        For Each m As Match In regex.Matches(FileIO.FileSystem.ReadAllText(fileName))
            results.Add(New Entry(m.Value))
        Next
        Return results
    End Function

End Class
