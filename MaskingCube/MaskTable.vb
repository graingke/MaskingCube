Public Class MaskTable
    Private msked() As MaskTableEntry
    Private dict As Dictionary(Of Char, MaskTableEntry)
    Public Sub New(Seed As String)
        Dim i As Byte
        Dim x As Byte
        Dim l As New List(Of MaskTableEntry)
        i = Asc("A")
        Do Until i > Asc("z")
            ReDim Preserve msked(x)
            msked(x) = New MaskTableEntry(Seed, Chr(i))
            l.Add(msked(x))
            If i <> Asc("Z") Then
                i += 1
            Else
                i = Asc("a")
            End If
        Loop
        l.Sort()
        i = Asc("A")

        For Each thismask As MaskTableEntry In l
            thismask.ClearChar = Chr(i)
            If i <> Asc("Z") Then
                i += 1
            Else
                i = Asc("a")
            End If
        Next
        dict = l.ToDictionary(Function(p) p.ClearChar)


        l = Nothing

    End Sub
    Public Function GetMaskedValue(ClearText As String) As String
        Dim buildstring As New System.Text.StringBuilder()
        Dim i As Integer
        Dim out As Char
        Dim input() As Char = ClearText.ToCharArray
        For i = input.GetLowerBound(0) To input.GetUpperBound(0)
            If dict.ContainsKey(input(i)) = True Then
                out = dict(input(i)).MaskedChar
            Else
                out = input(i)
            End If
            buildstring.Append(out)
        Next
        GetMaskedValue = buildstring.ToString


    End Function
End Class
