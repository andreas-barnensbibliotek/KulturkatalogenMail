Imports System.IO
Imports System.Reflection
Imports System.Text
Imports System.Configuration
Public Class ArrangemangMailTemplate

    Private _htmltemplsrc As String = ConfigurationManager.AppSettings("htmltemplatesrc")

    'Public Function arrTackmailtemplate(arrobj As arrangemangInfo) As String
    '    Dim mailobj As New katalogenMainMailHandler
    '    Dim mailto As String = arrobj.UtovareData.Epost

    '    If String.IsNullOrEmpty(mailto) Then
    '        Return mailobj.MailStatus = "Det finns ingen epost kopplad till arrangemanget"
    '    Else

    '        mailobj.mailAmne = "Kulturkatalogen- Arrangemang: " & arrobj.Rubrik
    '        mailobj.mailfran = ConfigurationManager.AppSettings("fromMailadress")
    '        mailobj.mailtill = mailto
    '        mailobj.mailBody = htmltemplate(arrobj, "tackmail")

    '        Try
    '            mailobj.mailSend = True
    '            Return mailobj.MailStatus

    '        Catch ex As Exception
    '            Return mailobj.MailStatus = "Det blev fel när Tackmailet skulle skickas!"

    '        End Try
    '    End If
    'End Function

    'Public Function arrmailtemplate(arrobj As arrangemangInfo, mailto As String) As String
    '    Dim mailobj As New katalogenMainMailHandler

    '    If String.IsNullOrEmpty(mailto) Then
    '        Return mailobj.MailStatus = "Det finns ingen användare kopplade till arrangemanget"
    '    Else

    '        mailobj.mailAmne = "Kulturkatalogen- Nytt Arrangemang: " & arrobj.Rubrik
    '        mailobj.mailfran = ConfigurationManager.AppSettings("fromMailadress")
    '        mailobj.mailtill = mailto
    '        mailobj.mailBody = htmltemplate(arrobj, "arrhandler")

    '        Try
    '            mailobj.mailSend = True
    '            Return mailobj.MailStatus

    '        Catch ex As Exception
    '            Return mailobj.MailStatus = "Det blev fel när mailet skulle skickas"

    '        End Try
    '    End If
    'End Function


    Public Function htmltemplate(arrobj As arrangemangInfo, mailtyp As String) As StringBuilder
        Dim getfile As String = ""
        Dim htmlstr As New StringBuilder

        Select Case mailtyp
            Case 1
                getfile = "arrhtmlTackTemplate.txt"
            Case Else
                getfile = "arrhtmlTemplate.txt"

        End Select

        htmlstr.Append(gethtmlfromfile(getfile, arrobj))

        Return htmlstr

    End Function



    Private Function gethtmlfromfile(Fil As String, arrobj As arrangemangInfo) As String
        Dim retstr As New StringBuilder

        Try
            Dim correctfilsrc As String = _htmltemplsrc & Fil

            Using sr As New StreamReader(correctfilsrc)
                ' Read the stream to a string and write the string to the console.
                retstr.Append(sr.ReadToEnd())

                retstr = addDataToTemplate(retstr, arrobj)
            End Using
        Catch e As Exception
            retstr.Clear()
            retstr.Append("nått gick fel vid hämtning av htmltemplate!")
        End Try

        Return retstr.ToString

    End Function

    Private Function faktatohtmlList(faktalist As List(Of faktainfo)) As String
        Dim listtemplate As New StringBuilder

        For Each item In faktalist
            listtemplate.Append("<p><b>" & item.Faktarubrik & " : </b> " & item.FaktaValue & "</p>")
        Next

        Return listtemplate.ToString

    End Function
    Private Function exempeltohtmlList(exempellist As List(Of mediaInfo)) As String

        Dim listtemplate As New StringBuilder
        Dim gettemplate As String = ""

        For Each item In exempellist

            Select Case item.MediaTyp
                Case 2
                    gettemplate = "exempelFilmTemplate.txt"
                Case Else
                    gettemplate = "exempelBildTemplate.txt"
            End Select

            Dim templatefilsrc As String = _htmltemplsrc & gettemplate
            Using sr As New StreamReader(templatefilsrc)
                ' Read the stream to a string and write the string to the console.
                listtemplate.Append(sr.ReadToEnd())

                listtemplate = addListToTemplate(listtemplate, item)
            End Using

        Next

        Return listtemplate.ToString

    End Function

    Private Function addDataToTemplate(retstr As StringBuilder, arrobj As arrangemangInfo) As StringBuilder

        retstr.Replace("{{datum}}", arrobj.Datum)
        retstr.Replace("{{rubrik}}", arrobj.Rubrik)
        retstr.Replace("{{underrubrik}}", arrobj.UnderRubrik)
        retstr.Replace("{{utovareid}}", arrobj.Utovarid)
        retstr.Replace("{{utovarenamn}}", arrobj.UtovareData.Organisation)
        retstr.Replace("{{MainImage}}", arrobj.MainImage.MediaUrl)

        retstr.Replace("{{innehall}}", arrobj.Innehall)
        retstr.Replace("{{exempelList}}", exempeltohtmlList(arrobj.MediaList))
        retstr.Replace("{{arrfaktalist}}", faktatohtmlList(arrobj.Faktalist))

        Return retstr

    End Function
    Private Function addListToTemplate(retstr As StringBuilder, arrobj As mediaInfo) As StringBuilder

        retstr.Replace("{{mediaalt}}", arrobj.MediaAlt)
        retstr.Replace("{{mediaurl}}", arrobj.MediaUrl)
        retstr.Replace("{{mediaLink}}", arrobj.mediaLink)
        retstr.Replace("{{mediaTitle}}", arrobj.mediaTitle)
        retstr.Replace("{{mediaBeskrivning}}", arrobj.mediaBeskrivning)

        Return retstr

    End Function

End Class
