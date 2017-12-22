Imports System.IO
Imports System.Reflection
Imports System.Text
Imports System.Configuration
Imports KulturkatalogenMail

Public Class katalogenMailController




    Public Function sendArrangemangsMail(mailobj As mailInfo) As String
        Dim tmpObj As New mailTemplateHandler
        Dim tmpMailTemplateHTML As New StringBuilder
        Dim ret As String = "Fel vid hämtning av Templates"
        Select Case mailobj.MailTemplateId
            Case "1" 'Nytt arrangemang
                tmpMailTemplateHTML = tmpObj.gethtmltemplate("1")
                mailobj.MailTemplateHTML = tmpObj.addDataToTemplate(tmpMailTemplateHTML, mailobj)
                ret = arrSendmail(mailobj, mailobj.utovaremailtoadress, 1)

                tmpMailTemplateHTML = tmpObj.gethtmltemplate("2")
                mailobj.MailTemplateHTML = tmpObj.addDataToTemplate(tmpMailTemplateHTML, mailobj)
                arrSendmail(mailobj, mailobj.KulturkatalogenAvsEpost, 2)
            Case "2" 'godkänt
                tmpMailTemplateHTML = tmpObj.gethtmltemplate("3")
                mailobj.MailTemplateHTML = tmpObj.addDataToTemplate(tmpMailTemplateHTML, mailobj)
                ret = arrSendmail(mailobj, mailobj.utovaremailtoadress, 3)

                tmpMailTemplateHTML = tmpObj.gethtmltemplate("4")
                mailobj.MailTemplateHTML = tmpObj.addDataToTemplate(tmpMailTemplateHTML, mailobj)
                arrSendmail(mailobj, mailobj.KulturkatalogenAvsEpost, 4)
            Case "3" 'Nekat
                tmpMailTemplateHTML = tmpObj.gethtmltemplate("7")
                mailobj.MailTemplateId = 7
                mailobj.MailTemplateHTML = tmpObj.addDataToTemplate(tmpMailTemplateHTML, mailobj)
                ret = arrSendmail(mailobj, mailobj.utovaremailtoadress, 7)

                mailobj.MailTemplateId = 8
                tmpMailTemplateHTML = tmpObj.gethtmltemplate("8")
                mailobj.MailTemplateHTML = tmpObj.addDataToTemplate(tmpMailTemplateHTML, mailobj)
                arrSendmail(mailobj, mailobj.KulturkatalogenAvsEpost, 8)
            Case "4" 'arkiv
                tmpMailTemplateHTML = tmpObj.gethtmltemplate("5")
                mailobj.MailTemplateHTML = tmpObj.addDataToTemplate(tmpMailTemplateHTML, mailobj)
                ret = arrSendmail(mailobj, mailobj.utovaremailtoadress, 5)

            Case "0" 'renew
                tmpMailTemplateHTML = tmpObj.gethtmltemplate("6")
                mailobj.MailTemplateHTML = tmpObj.addDataToTemplate(tmpMailTemplateHTML, mailobj)
                ret = arrSendmail(mailobj, mailobj.utovaremailtoadress, 6)

        End Select

        Return ret

    End Function

    Private Function arrSendmail(mailobj As mailInfo, mailto As String, mailrubrik As Integer) As String
        Dim sendmailobj As New katalogenMainMailHandler

        If String.IsNullOrEmpty(mailto) Then
            Return sendmailobj.MailStatus = "Det finns ingen mottagande epost kopplad till arrangemanget"
        Else

            sendmailobj.mailAmne = getMailAmnesrubrik(mailrubrik)
            sendmailobj.mailfran = ConfigurationManager.AppSettings("fromMailadress")
            sendmailobj.mailtill = mailto
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
