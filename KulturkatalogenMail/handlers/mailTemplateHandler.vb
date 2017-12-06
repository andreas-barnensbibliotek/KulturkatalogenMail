Imports System.IO
Imports System.Reflection
Imports System.Text
Imports System.Configuration
Public Class mailTemplateHandler
    Private Enum Mailnamntyp
        Nyttarr_to_utovare = 1
        Nyttarr_to_konsulent = 2
        Approved_to_utovare = 3
        Approved_to_konsulent = 4
        Archive_to_utovare = 5
        ReNew_to_utovare = 6
        Denied_to_utovare = 7
        Denied_to_konsulent = 8
    End Enum
    Private _htmltemplsrc As String = ConfigurationManager.AppSettings("htmltemplatesrc")
    Public Function gethtmltemplate(mailtyp As Integer) As StringBuilder
        Dim getfile As String = ""
        Dim htmlstr As New StringBuilder

        Select Case mailtyp
            Case Mailnamntyp.Nyttarr_to_utovare
                getfile = "MailTemplate_pub_TackNyttArr.txt"
            Case Mailnamntyp.Nyttarr_to_konsulent
                getfile = "MailTemplate_pri_TackNyttArr.txt"
            Case Mailnamntyp.Approved_to_utovare
                getfile = "MailTemplate_pub_Approved.txt"
            Case Mailnamntyp.Approved_to_konsulent
                getfile = "MailTemplate_pri_Approved.txt"
            Case Mailnamntyp.Archive_to_utovare
                getfile = "MailTemplate_pub_Archive.txt"
            Case Mailnamntyp.ReNew_to_utovare
                getfile = "MailTemplate_pub_ReNew.txt"
            Case Mailnamntyp.Denied_to_utovare
                getfile = "MailTemplate_pub_Denied.txt"
            Case Mailnamntyp.Denied_to_konsulent
                getfile = "MailTemplate_pri_Denied.txt"
        End Select

        htmlstr.Append(gethtmlfromfile(getfile))

        Return htmlstr

    End Function

    Public Function getmailSubject(mailtyp As Integer) As String
        Dim getmailtyp As String = ""

        Select Case mailtyp
            Case Mailnamntyp.Nyttarr_to_utovare
                getmailtyp = "Nytt Arrangemang - Kulturkatalogen Väst"

            Case Mailnamntyp.Nyttarr_to_konsulent
                getmailtyp = "Nytt Arrangemang - Kulturkatalogen Väst"

            Case Mailnamntyp.Approved_to_utovare
                getmailtyp = "Ansökan godkänd - Kulturkatalogen Väst"

            Case Mailnamntyp.Approved_to_konsulent
                getmailtyp = "godkänd ansökan - Kulturkatalogen Väst"

            Case Mailnamntyp.Archive_to_utovare
                getmailtyp = "Ansökan avpublicerad - Kulturkatalogen Väst"

            Case Mailnamntyp.ReNew_to_utovare
                getmailtyp = "Dags att göra ny ansökan - Kulturkatalogen Väst"

            Case Mailnamntyp.Denied_to_utovare
                getmailtyp = "Ansökan nekad - Kulturkatalogen Väst"

            Case Mailnamntyp.Denied_to_konsulent
                getmailtyp = "Nekad ansökan - Kulturkatalogen Väst"
        End Select


        Return getmailtyp

    End Function
    Private Function gethtmlfromfile(Fil As String) As StringBuilder
        Dim retstr As New StringBuilder

        Try
            Dim correctfilsrc As String = _htmltemplsrc & Fil

            Using sr As New StreamReader(correctfilsrc)
                ' Read the stream to a string and write the string to the console.
                retstr.Append(sr.ReadToEnd())

            End Using
        Catch e As Exception
            retstr.Clear()
            retstr.Append("nått gick fel vid hämtning av htmltemplate!")
        End Try

        Return retstr

    End Function


    Public Function addDataToTemplate(retstr As StringBuilder, arrobj As mailInfo) As String

        retstr.Replace("{{datum}}", arrobj.MailArrdata.Datum)
        retstr.Replace("{{rubrik}}", arrobj.MailArrdata.Rubrik)
        retstr.Replace("{{underrubrik}}", arrobj.MailArrdata.UnderRubrik)
        retstr.Replace("{{utovarenamn}}", arrobj.MailArrdata.UtovareData.Organisation)

        retstr.Replace("{{detailLink}}", detaljlink(arrobj.MailArrdata.Arrid))

        retstr.Replace("{{KulturkatalogenAvsNamn}}", arrobj.KulturkatalogenAvsNamn)
        retstr.Replace("{{KulturkatalogenAvsEpost}}", arrobj.KulturkatalogenAvsEpost)
        retstr.Replace("{{KulturkatalogenAvsTel}}", arrobj.KulturkatalogenAvsTel)

        Return retstr.ToString

    End Function
    Private Function detaljlink(arrid As Integer) As String

        Dim detailLink As New StringBuilder

        detailLink.Append(ConfigurationManager.AppSettings("serverurl"))
        detailLink.Append("/Kulturkatalogen/ArrangemangDetail/id/")
        detailLink.Append(arrid.ToString)

        Return detailLink.ToString
    End Function
End Class
