
Imports System.IO

Module Program
    Private Random As New Random(Guid.NewGuid().GetHashCode())
    Private ReadOnly Wins as Decimal() = New Decimal() {1, 2.5, 3, 5, 10, 20, 35, 50}

    Sub Main(args As String())
        Const amountToRun = 50000
        Const totalSpent = amountToRun
        For count As Integer = 1 To 10 Step + 1
            Dim sw As New StreamWriter($"/home/mkb/Example2{count}.txt")

            Dim totalPayoutPercent = New List(Of Decimal)()
            For num As Integer = 1 To 500 Step + 1
                dim total as Decimal() =
                        Enumerable.Range(1, amountToRun).Select(Function(f)  Example2(Random.Next(0, 1001))).ToArray()
                WriteLine(sw,
                          $"Result{num} Total Spent {totalSpent.ToString("C")} ...  Profit { _
                             ((totalSpent) - (total.Sum())).ToString("C")}")
                Dim totalWins as Integer = 0
                Dim totalAmountWins as Decimal = 0
                For i As Integer = 0 To Wins.Length - 1 Step + 1
                    dim toSearch as Decimal = Wins(i)
                    dim winNumber = NumberOf(toSearch, total)
                    totalAmountWins += (winNumber*toSearch)
                    totalWins += winNumber
                    WriteLine(sw, $"{vbTab} Number of {toSearch.ToString("C")} wins:{winNumber}")
                Next
                Dim payOutPercent as Decimal = 100 - ((1 - (totalAmountWins/totalSpent))*100)
                WriteLine(sw, $"{vbTab}{vbTab}TotalNumberOfWins:{totalWins}")
                WriteLine(sw,
                          $"{vbTab}{vbTab}TotalAmountOfWins:{totalAmountWins}{Environment.NewLine}{vbTab}{vbTab _
                             }Total Payout % {payOutPercent}")
                WriteLine(sw, $"{"".PadRight(70, "-")}")
                totalPayoutPercent.Add(payOutPercent)
            Next
            WriteLine(sw, $"{"".PadRight(70, "-")}")
            WriteLine(sw, $"Average payout {totalPayoutPercent.Sum()/totalPayoutPercent.Count}%")
            WriteLine(sw, $"Min-Max {totalPayoutPercent.Min()}% - {totalPayoutPercent.Max()}%")
            sw.Close()
            sw.Dispose()
        next
    End Sub

    Private Sub WriteLine(ByRef sw as StreamWriter, text as String)
        sw.WriteLine(text)
        Console.WriteLine(text)
    End Sub

    Private Function NumberOf(ByVal numberToCheck as Decimal, ByRef total As Decimal()) As Integer
        Return total.Where(Function(e) e = numberToCheck).Count()
    End Function

    

    Function Calc91LittleAndOften(ByVal val) As Decimal

        If val > 400 AndAlso val <= 470 Then
            Return Wins(0)
        End If
        If val > 500 AndAlso val <= 555 Then
            Return Wins(1)
        End If
        If val > 900 AndAlso val <= 938 Then
            Return Wins(2)
        End If
        If val > 950 AndAlso val <= 980 Then
            Return Wins(3)
        End If
        If val > 985 AndAlso val <= 991 Then
            Return Wins(4)
        End If
        If val > 991 AndAlso val <= 994 Then
            Return Wins(5)
        End If
        If val > 994 AndAlso val <= 998 Then
            Return Wins(6)
        End If
        If val > 998 AndAlso val <= 1000 Then
            Return Wins(7)
        End If

        Return 0
    End Function
    
    
    Function Example2(ByVal val) As Decimal

        If val > 400 AndAlso val <= 457 Then
            Return Wins(0)
        End If
        If val > 500 AndAlso val <= 545 Then
            Return Wins(1)
        End If
        If val > 600 AndAlso val <= 631 Then
            Return Wins(2)
        End If
        If val > 700 AndAlso val <= 720 Then
            Return Wins(3)
        End If
        If val > 800 AndAlso val <= 820 Then
            Return Wins(4)
        End If
        If val > 950 AndAlso val <= 960 Then
            Return Wins(5)
        End If
        If val > 997 AndAlso val <= 1000 Then
            Return Wins(7)
        End If

        Return 0
    End Function

    Function BiggerButLessFrequent(ByVal val) As Decimal
        If val > 600 AndAlso val <= 629 Then
            Return Wins(3)
        End If
        If val > 650 AndAlso val <= 660 Then
            Return Wins(4)
        End If
        If val > 700 AndAlso val <= 709 Then
            Return Wins(5)
        End If
        If val > 800 AndAlso val <= 807 Then
            Return Wins(6)
        End If
        If val > 995 AndAlso val <= 1000 Then
            Return Wins(7)
        End If
        Return 0
    End Function
End Module