Public Class mailInfo
    Public Sub New()

    End Sub

    Private _utovarid As Integer
    Public Property Utovarid() As Integer
        Get
            Return _utovarid
        End Get
        Set(ByVal value As Integer)
            _utovarid = value
        End Set
    End Property

    Private _utovaremailtoadress As String
    Public Property utovaremailtoadress() As String
        Get
            Return _utovaremailtoadress
        End Get
        Set(ByVal value As String)
            _utovaremailtoadress = value
        End Set
    End Property

    Private _konstformid As Integer
    Public Property Konstformid() As Integer
        Get
            Return _konstformid
        End Get
        Set(ByVal value As Integer)
            _konstformid = value
        End Set
    End Property

    Private _kulturkatalogenMailFromAdress As String
    Public Property KulturkatalogenMailFromAdress() As String
        Get
            Return _kulturkatalogenMailFromAdress
        End Get
        Set(ByVal value As String)
            _kulturkatalogenMailFromAdress = value
        End Set
    End Property

    Private _kulturkatalogenAvsNamn As String
    Public Property KulturkatalogenAvsNamn() As String
        Get
            Return _kulturkatalogenAvsNamn
        End Get
        Set(ByVal value As String)
            _kulturkatalogenAvsNamn = value
        End Set
    End Property

    Private _kulturkatalogenAvsEpost As String
    Public Property KulturkatalogenAvsEpost() As String
        Get
            Return _kulturkatalogenAvsEpost
        End Get
        Set(ByVal value As String)
            _kulturkatalogenAvsEpost = value
        End Set
    End Property

    Private _kulturkatalogenAvsTel As String
    Public Property KulturkatalogenAvsTel() As String
        Get
            Return _kulturkatalogenAvsTel
        End Get
        Set(ByVal value As String)
            _kulturkatalogenAvsTel = value
        End Set
    End Property

    Private _MailTemplateID As Integer
    Public Property MailTemplateId() As Integer
        Get
            Return _MailTemplateID
        End Get
        Set(ByVal value As Integer)
            _MailTemplateID = value
        End Set
    End Property

    Private _MailTempletHTML As String
    Public Property MailTemplateHTML() As String
        Get
            Return _MailTempletHTML
        End Get
        Set(ByVal value As String)
            _MailTempletHTML = value
        End Set
    End Property

    Private _mailArrData As arrangemangInfo
    Public Property MailArrdata() As arrangemangInfo
        Get
            Return _mailArrData
        End Get
        Set(ByVal value As arrangemangInfo)
            _mailArrData = value
        End Set
    End Property

    Private _motivering As String
    Public Property Motivering() As String
        Get
            Return _motivering
        End Get
        Set(ByVal value As String)
            _motivering = value
        End Set
    End Property
End Class
