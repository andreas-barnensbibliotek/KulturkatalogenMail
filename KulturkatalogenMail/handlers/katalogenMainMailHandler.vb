﻿Imports Microsoft.VisualBasic
Imports System.Net.Mail
Imports System.Configuration
Public Class katalogenMainMailHandler

    Private _mailfran As String
    Private _mailTill As String
    Private _mailAmne As String
    Private _mailBody As String
    Private _status As String

    Public WriteOnly Property mailfran() As String
        Set(ByVal value As String)
            _mailfran = value
        End Set
    End Property
    Public WriteOnly Property mailtill() As String
        Set(ByVal value As String)
            _mailTill = value
        End Set
    End Property
    Public WriteOnly Property mailAmne() As String
        Set(ByVal value As String)
            _mailAmne = value
        End Set
    End Property
    Public WriteOnly Property mailBody() As String
        Set(ByVal value As String)
            _mailBody = value
        End Set
    End Property
    Public WriteOnly Property mailSend() As Boolean
        Set(ByVal value As Boolean)
            If value Then
                sendmailet()
            End If
        End Set
    End Property
    Public ReadOnly Property MailStatus() As String
        Get
            Return _status
        End Get
    End Property

    Private Sub sendmailet()
        Dim mailserver = ConfigurationManager.AppSettings("SMTPServerip")
        Try
            'Skapa mailet
            Dim mail As New MailMessage()

            'set adressen
            mail.From = New MailAddress(_mailfran)
            mail.To.Add(_mailTill)

            'set innehållet
            mail.Subject = _mailAmne
            mail.Body = _mailBody
            mail.IsBodyHtml = True

            'send meddelandet
            Dim smtp As New SmtpClient(mailserver)
            smtp.Send(mail)
            _status = "Mailet är skickat!"


        Catch ex As Exception
            'skicka fel om det blev nått
            _status = "Nått blev fel! " & ex.Message
        End Try

    End Sub
End Class
