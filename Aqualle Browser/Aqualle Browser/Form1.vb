Public Class Form1

    Private IsDevelopmentPadVisible As Boolean = False, IsWebsitePadVisible As Boolean

    Public Sub EnterPrivateMode()
        Me.Text = Me.Text & " - (Private Browsing)"
        Me.Icon = My.Resources._1359678290_49398
        MenuItem80.Text = "Disable Private Mode"
    End Sub

    Public Sub ShowDevelopmentPad()
        If IsDevelopmentPadVisible = False Then
            IsDevelopmentPadVisible = True
            panelDevelopmentPad.Visible = True
        ElseIf IsDevelopmentPadVisible = True Then
            IsDevelopmentPadVisible = False
            panelDevelopmentPad.Visible = False
        End If
    End Sub

    Private Sub MenuItem80_Click(sender As Object, e As EventArgs) Handles MenuItem80.Click
        If MenuItem80.Text = "Private Browsing" Then
            EnterPrivateMode()
        ElseIf MenuItem80.Text = "Disable Private Mode" Then
            Me.Text = Me.Text.Split("-")(0).Trim
            Me.Icon = My.Resources._1358199517_8819
            MenuItem80.Text = "Private Browsing"
        End If
    End Sub

    Private Sub btnDevelopment_Click(sender As Object, e As EventArgs) Handles btnDevelopment.Click
        ShowDevelopmentPad()
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        ShowDevelopmentPad()
    End Sub

    Public Sub ShowWebsitePad()
        If IsWebsitePadVisible = False Then
            IsWebsitePadVisible = True
            panelWebsiteInfo.Visible = True
        ElseIf IsWebsitePadVisible = True Then
            IsWebsitePadVisible = False
            panelWebsiteInfo.Visible = False
        End If
    End Sub

    Private Sub btnCertificate_Click(sender As Object, e As EventArgs) Handles btnCertificate.Click
        ShowWebsitePad()
    End Sub

    Private Sub tsBtnDevelopment_ButtonClick(sender As Object, e As EventArgs) Handles tsBtnDevelopment.ButtonClick
        ShowDevelopmentPad()
    End Sub

    Private Sub ShowDevelopmentPadToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ShowDevelopmentPadToolStripMenuItem.Click
        ShowDevelopmentPad()
    End Sub
End Class
