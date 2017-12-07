Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports KulturkatalogenMail

<TestClass()> Public Class UnitTest1

    <TestMethod()> Public Sub TestMethod1()

        Dim obj As New katalogenMailController

        Dim testfakta As New faktainfo
        testfakta.Faktarubrik = "Testrubrik"
        testfakta.FaktaValue = "test värde med en massa text"
        Dim initestmage As New mediaInfo
        initestmage.MediaUrl = "https://i.pinimg.com/736x/be/8d/2d/be8d2da1e4a6d3c9a5e0cc7616e23f22--pink-minion-minion-girl.jpg"
        initestmage.MediaAlt = "testar"

        Dim testexempel As New mediaInfo
        testexempel.MediaFilename = "detta är en film"
        testexempel.MediaUrl = "https://www.youtube.com/embed/GXsnIHayBVA"
        testexempel.MediaTyp = 2
        testexempel.MediaAlt = "detta är alternativtext"
        testexempel.mediaTitle = "rubrik å sånt"
        testexempel.mediaBeskrivning = "här kommer texten till alltihop"

        Dim testexempel2 As New mediaInfo
        testexempel2.MediaFilename = "detta är en bild"
        testexempel2.MediaUrl = "https://www.defensetech.org/wp-content/uploads/2017/03/Russian-T-90A-tank-1200x800.jpg"
        testexempel2.MediaTyp = 1
        testexempel2.MediaAlt = "bild text"
        testexempel2.mediaTitle = "rubrik å sånt"
        testexempel2.mediaBeskrivning = "här kommer texten till alltihop"

        Dim arrdata = New arrangemangInfo
        With arrdata
            .Datum = "20170905"
            .Arrid = 1
            .Rubrik = "test"
            .Innehall = "massat text om ingenting hur man skriver en massa nonsen som inget!"
            .MainImage.MediaUrl = "https://i.ytimg.com/vi/Cxy88GeEAxg/maxresdefault.jpg"

            .Faktalist.Add(testfakta)
            .MediaList.Add(testexempel)
            .MediaList.Add(testexempel2)

        End With

        'Dim retstri As String = obj.arraangemangmail(arrdata, "andreas.josefsson@kulturivast.se")

        'Dim rettets As String = retstri
    End Sub

    <TestMethod()> Public Sub TestMethod_mailtest()
        Dim arrdata = New arrangemangInfo
        With arrdata
            .Datum = "20170905"
            .Arrid = 1
            .Rubrik = "test"
            .UnderRubrik = "underrubriktext"
            .UtovareData.Organisation = "firman"

        End With

        Dim mailobj As New mailInfo
        With mailobj
            .utovaremailtoadress = "test@test.se"
            .MailTemplateId = 1

            .Konstformid = 1
            .MailArrdata = arrdata
            .Motivering = "standard text om arrangemanget"
            .KulturkatalogenAvsNamn = "konsulent för konstformen"
            .KulturkatalogenAvsEpost = "konsulent@test.se"
            .KulturkatalogenAvsTel = "142536"
        End With

        Dim obj As New katalogenMailController
        obj.sendArrangemangsMail(mailobj)

    End Sub


End Class