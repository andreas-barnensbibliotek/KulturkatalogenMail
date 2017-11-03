Imports System.Configuration
Public Class katalogenMailController


    Public Function arraangemangmail(maildata As arrangemangInfo, mailto As String) As String
        Dim arrobj As New ArrangemangMailTemplate
        Dim mailobj As New katalogenMainMailHandler
        Dim retstatus As String = ""

        If ConfigurationManager.AppSettings("sendmaildebug") = True Then

            Dim debugmail = ConfigurationManager.AppSettings("toMailadressdebug")
            maildata.UtovareData.Epost = ConfigurationManager.AppSettings("tackmaildebug")

            retstatus = arrobj.arrTackmailtemplate(maildata) & " - tack to " & maildata.UtovareData.Epost & " DEBUG "
            retstatus &= arrobj.arrmailtemplate(maildata, debugmail) & " -to " & debugmail & " DEBUG"
            Return retstatus
        Else
            If ConfigurationManager.AppSettings("sendmail") = True Then
                retstatus = arrobj.arrTackmailtemplate(maildata)
                retstatus &= arrobj.arrmailtemplate(maildata, mailto)
                Return retstatus
            Else
                Return "Send mail är inaktiverat"
            End If
        End If

    End Function

End Class
