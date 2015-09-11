Public Class MaskTableEntry
    Implements IComparable(Of MaskTableEntry)
    Dim l_seed As String
    Dim l_clear As Char
    Dim l_encrypted As String
    Dim l_masked As Char
    Public Property Seed As String
        Set(value As String)
            l_seed = value
        End Set
        Get
            Return l_seed
        End Get
    End Property
    Public Property ClearChar As Char
        Get
            Return l_clear
        End Get
        Set(value As Char)
            l_clear = value
        End Set
    End Property
    Public Property MaskedChar As Char
        Get
            Return l_masked
        End Get
        Set(value As Char)
            l_masked = value
            l_encrypted = AES_Encrypt(l_masked, l_seed)
        End Set
    End Property
    Private ReadOnly Property EncryptedText As String
        Get
            Return l_encrypted
        End Get
    End Property
    Private Function AES_Encrypt(ByVal input As String, ByVal pass As String) As String
        Dim AES As New System.Security.Cryptography.RijndaelManaged
        Dim Hash_AES As New System.Security.Cryptography.MD5CryptoServiceProvider
        Dim encrypted As String = ""
        Try
            Dim hash(31) As Byte
            Dim temp As Byte() = Hash_AES.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes(pass))
            Array.Copy(temp, 0, hash, 0, 16)
            Array.Copy(temp, 0, hash, 15, 16)
            AES.Key = hash
            AES.Mode = Security.Cryptography.CipherMode.ECB
            Dim DESEncrypter As System.Security.Cryptography.ICryptoTransform = AES.CreateEncryptor
            Dim Buffer As Byte() = System.Text.ASCIIEncoding.ASCII.GetBytes(input)
            encrypted = Convert.ToBase64String(DESEncrypter.TransformFinalBlock(Buffer, 0, Buffer.Length))

        Catch ex As Exception
        End Try

        Return encrypted
    End Function

    Private Function compareto(ByVal Other As MaskTableEntry) As Integer Implements System.IComparable(Of MaskTableEntry).CompareTo
        Dim ReturnValue As Integer
        If Other IsNot Nothing Then
            Select Case Other.EncryptedText
                Case l_encrypted
                    ReturnValue = 0
                Case Is < l_encrypted
                    ReturnValue = -1
                Case Is > l_encrypted
                    ReturnValue = 1
            End Select
        Else
            ReturnValue = 0
        End If

        Return ReturnValue


    End Function
    Public Sub New(ThisSeed As String, ThisMaskedChar As Char)
        Me.Seed = ThisSeed
        Me.MaskedChar = ThisMaskedChar


    End Sub
End Class
