Imports System.Data.SqlClient

Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load() Handles Me.Load
        Dim showName As New FeatureControl.ReleaseFeatureToggles.ShowNameOnHomePage

        If showName.FeatureEnabled Then
            pnlName.Visible = True
        Else
            pnlName.Visible = False
        End If
    End Sub

    Private Function IsFeatureFlagEnabled(ByVal featureFlagName As String) As Boolean
        Dim retVal As Boolean

        Dim connectionString As String = ConfigurationManager.ConnectionStrings("myRnDConnectionString").ConnectionString

        Dim query As String = String.Format(
            "SELECT f.FeatureFlagEnabled FROM dbo.FeatureFlags f where f.FeatureFlagName = '{0}'",
            featureFlagName)

        Using conn As SqlConnection = New SqlConnection(connectionString)
            conn.Open()

            Using cmd As SqlCommand = New SqlCommand(query, conn)
                cmd.CommandType = Data.CommandType.Text

                Using rdr As SqlDataReader = cmd.ExecuteReader()
                    While rdr.Read()
                        retVal = rdr.GetBoolean(0)
                    End While
                End Using
            End Using
        End Using

        Return retVal
    End Function
End Class