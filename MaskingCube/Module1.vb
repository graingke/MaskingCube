Module Module1

    Sub Main()
        Dim seed As String
        Dim mskcub As MaskCube
        Dim texttomask As String
        Dim i As Integer
        Dim TheseChars() As Char

        Console.Write("Enter starter text:     ")
        Console.WriteLine()
        seed = Console.ReadLine()

        Console.WriteLine("Enter text to mask:    ")
        texttomask = Console.ReadLine()
        mskcub = New MaskCube(seed, Len(texttomask))

        TheseChars = texttomask.ToCharArray
        For i = TheseChars.GetLowerBound(0) To TheseChars.GetUpperBound(0)
            Console.WriteLine(mskcub.Mask(i, TheseChars(i)))
        Next





        Console.ReadLine()
    End Sub




End Module
