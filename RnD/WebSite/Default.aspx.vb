Imports FeatureControl

Partial Class _Default
    Inherits Page

    Protected Sub Page_Load() Handles Me.Load
        Dim showName As New ReleaseFeatureToggles.ShowNameOnHomePage

        If showName.FeatureEnabled Then
            pnlName.Visible = True
        Else
            pnlName.Visible = False
        End If
    End Sub
End Class