Imports System.IO
Imports System.Reflection
Imports System.Text
Imports System.Configuration
Imports KulturkatalogenMail

Public Class katalogenMailController


    Public Function arraangemangmail(maildata As arrangemangInfo, mailto As String) As String
        'Dim arrobj As New ArrangemangMailTemplate
        'Dim mailobj As New katalogenMainMailHandler
        'Dim retstatus As String = ""

        'If ConfigurationManager.AppSettings("sendmaildebug") = True Then

        '    Dim debugmail = ConfigurationManager.AppSettings("toMailadressdebug")
        '    maildata.UtovareData.Epost = ConfigurationManager.AppSettings("tackmaildebug")

        '    retstatus = arrobj.arrTackmailtemplate(maildata) & " - tack to " & maildata.UtovareData.Epost & " DEBUG "
        '    retstatus &= arrobj.arrmailtemplate(maildata, debugmail) & " -to " & debugmail & " DEBUG"
        '    Return retstatus
        'Else
        '    If ConfigurationManager.AppSettings("sendmail") = True Then
        '        retstatus = arrobj.arrTackmailtemplate(maildata)
        '        retstatus &= arrobj.arrmailtemplate(maildata, mailto)
        '        Return retstatus
        '    Else
        '        Return "Send mail är inaktiverat"
        '    End If
        'End If

    End Function

    Public Function sendArrangemangsMail(mailobj As mailInfo) As String
        Dim tmpObj As New mailTemplateHandler
        Dim tmpMailTemplateHTML As StringBuilder = tmpObj.gethtmltemplate(mailobj.MailTemplateId)

        mailobj.MailTemplateHTML = tmpObj.addDataToTemplate(tmpMailTemplateHTML, mailobj)
        Return arrSendmail(mailobj)

    End Function

    Private Function arrSendmail(mailobj As mailInfo) As String
        Dim sendmailobj As New katalogenMainMailHandler

        If String.IsNullOrEmpty(mailobj.utovaremailtoadress) Then
            Return sendmailobj.MailStatus = "Det finns ingen mottagande epost kopplad till arrangemanget"
        Else

            sendmailobj.mailAmne = getMailAmnesrubrik(mailobj.MailTemplateId)
            sendmailobj.mailfran = ConfigurationManager.AppSettings("fromMailadress")
            sendmailobj.mailtill = mailobj.utovaremailtoadress
            sendmailobj.mailBody = mailobj.MailTemplateHTML

            Try
                sendmailobj.mailSend = True
                Return sendmailobj.MailStatus

            Catch ex As Exception
                Return "Det blev fel när mailet skulle skickas"

            End Try
        End If
    End Function
    Private Function getMailAmnesrubrik(mailtyp As Integer) As String
        Dim tmpObj As New mailTemplateHandler
        Return tmpObj.getmailSubject(mailtyp)

    End Function
End Class
