Public Class Entry

    Private _Name As String, _Value As String, _
    _Content As String

    '{var name="myName" value="myValue"}

    '$C = Computer Name
    '$U = User Name
    '$L = Logged In User

    '#C = Copyright ©
    '#TM = Trademark ™
    '#R = Register ®

    Sub New(ByVal Content As String)
        Dim block As String = Split(Content, "name=""")(1)
        _Name = Split(block, """")(0)
        block = Split(Content, "value=""")(1)
        _Value = Split(Content, """")(0).Replace("#C", "©"). _
                                         Replace("#TM", "™"). _
                                         Replace("#R", "®"). _
                                         Replace("$C", My.Computer.Name). _
                                         Replace("$U", Environment.GetEnvironmentVariable("USERNAME"))
        _Content = Content
    End Sub

    ''' <summary>
    ''' Set a new value to the entry.
    ''' </summary>
    ''' <param name="newValue"></param>
    ''' <remarks></remarks>

    Public Sub SetValue(ByVal newValue As String)
        If newValue <> String.Empty Then
            _Value = newValue
            _Content = "{var name=""" & _Name & """ value=""" & _Value & """}"
        End If
    End Sub

    ''' <summary>
    ''' Set a new name to the entry.
    ''' </summary>
    ''' <param name="newValue"></param>
    ''' <remarks></remarks>

    Public Sub SetName(ByVal newValue As String)
        If newValue <> String.Empty Then
            _Name = newValue
            _Content = "{var name=""" & _Name & """ value=""" & _Value & """}"
        End If
    End Sub

    ''' <summary>
    ''' The name of the property.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>

    Public ReadOnly Property Name As String
        Get
            Return _Name
        End Get
    End Property

    ''' <summary>
    ''' The value of the property.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>

    Public ReadOnly Property Value As String
        Get
            Return _Value
        End Get
    End Property

    ''' <summary>
    ''' The full content of the property.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>

    Public ReadOnly Property Content As String
        Get
            Return _Content
        End Get
    End Property

End Class
