Public Class MaskCube
    Private Faces As New Dictionary(Of Short, MaskTable)
    Private tbl As MaskTable()
    Public Sub New(ThisSeed As String, Dimensions As Short)
        Dim NewSeed As String = ThisSeed
        Dim n As Integer = 0
        For i = 0 To Dimensions
            ReDim Preserve tbl(n)
            tbl(n) = New MaskTable(NewSeed)
            Faces.Add(i, tbl(n))
            NewSeed = Faces(i).GetMaskedValue(NewSeed)
        Next
    End Sub
    Public Function Mask(CubeFace As Short, ClearTextString As String) As String
        Dim returnvalue As String
        returnvalue = Faces(CubeFace).GetMaskedValue(ClearTextString)
        Return returnvalue
    End Function

End Class
