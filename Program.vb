Imports System

Module Program
    Dim player_choice As ConsoleKeyInfo
    Dim current_plr As Integer = -1
    Dim plr1, plr2 As plr_data
    Dim board_layout(3, 3)
    Structure plr_data
        Dim symbol As String
        Dim selected_x As Integer
        Dim selected_y As Integer
    End Structure

    Sub Update_Board()
        Console.Clear()
        Console.WriteLine("   1   2   3")
        Console.WriteLine($"1 [{board_layout(0, 0)}] [{board_layout(0, 1)}] [{board_layout(0, 2)}]")
        Console.WriteLine($"2 [{board_layout(1, 0)}] [{board_layout(1, 1)}] [{board_layout(1, 2)}]")
        Console.WriteLine($"3 [{board_layout(2, 0)}] [{board_layout(2, 1)}] [{board_layout(2, 2)}]")
    End Sub

    Sub Configure_Player_Data()
        If UCase(plr1.symbol) = "X" Then
            plr1.symbol = "X"
            plr2.symbol = "O"
        ElseIf UCase(plr1.symbol) = "O" Then
            plr1.symbol = "O"
            plr2.symbol = "X"
        Else
            Console.WriteLine("Invalid user choice.")
            Threading.Thread.Sleep(1000)
            Main()
            Return
        End If
        current_plr = 0
    End Sub

    Sub User_Plot(ByRef current, ByRef plr)
        Console.WriteLine($"Player {current}, where do you want to plot your symbol ({plr.symbol})?")
        Console.Write("X:  ")
        plr.selected_x = Console.ReadLine()
        Console.Write("Y:  ")
        plr.selected_y = Console.ReadLine()

        If plr.selected_x < 1 Or plr.selected_x > 3 Or plr.selected_y < 1 Or plr.selected_y > 3 Then
            Console.WriteLine("Invalid plot!")
            Threading.Thread.Sleep(1000)
            Main()
            Return
        End If

        If board_layout(plr.selected_y - 1, plr.selected_x - 1) = "-" Then
            board_layout(plr.selected_y - 1, plr.selected_x - 1) = plr.symbol
        Else
            Console.WriteLine("Plot is already occupied!")
            Threading.Thread.Sleep(1000)
            Main()
            Return
        End If
        Check_Win()
        If current_plr = 0 Then
            current_plr = 1
        Else
            current_plr = 0
        End If
        Main()

    End Sub

    Sub Check_Win()
        If (board_layout(0, 0) = "X" And board_layout(0, 1) = "X" And board_layout(0, 2) = "X") Or (board_layout(1, 0) = "X" And board_layout(1, 1) = "X" And board_layout(1, 2) = "X") Or (board_layout(2, 0) = "X" And board_layout(2, 1) = "X" And board_layout(2, 2) = "X") Or (board_layout(0, 0) = "X" And board_layout(1, 0) = "X" And board_layout(2, 0) = "X") Or (board_layout(0, 1) = "X" And board_layout(1, 1) = "X" And board_layout(2, 1) = "X") Or (board_layout(0, 2) = "X" And board_layout(1, 2) = "X" And board_layout(2, 2) = "X") Or (board_layout(0, 0) = "X" And board_layout(1, 1) = "X" And board_layout(2, 2) = "X") Or (board_layout(0, 2) = "X" And board_layout(1, 1) = "X" And board_layout(2, 0) = "X") Then
            Update_Board()
            Console.WriteLine($"Player {current_plr + 1} has won!")
            EndMenu()
        ElseIf (board_layout(0, 0) = "O" And board_layout(0, 1) = "O" And board_layout(0, 2) = "O") Or (board_layout(1, 0) = "O" And board_layout(1, 1) = "O" And board_layout(1, 2) = "O") Or (board_layout(2, 0) = "O" And board_layout(2, 1) = "O" And board_layout(2, 2) = "O") Or (board_layout(0, 0) = "O" And board_layout(1, 0) = "O" And board_layout(2, 0) = "O") Or (board_layout(0, 1) = "O" And board_layout(1, 1) = "O" And board_layout(2, 1) = "O") Or (board_layout(0, 2) = "O" And board_layout(1, 2) = "O" And board_layout(2, 2) = "O") Or (board_layout(0, 0) = "O" And board_layout(1, 1) = "O" And board_layout(2, 2) = "O") Or (board_layout(0, 2) = "O" And board_layout(1, 1) = "O" And board_layout(2, 0) = "O") Then
            Update_Board()
            Console.WriteLine($"Player {current_plr + 1} has won!")
            EndMenu()
        End If
        Check_Draw()
    End Sub

    Sub Check_Draw()
        Dim draw As Boolean = True
        For x = 0 To 2
            For y = 0 To 2
                If board_layout(x, y) = "-" Then
                    draw = False
                End If
            Next
        Next
        If draw = True Then
            Update_Board()
            Console.WriteLine("Stalemate! You drawed.")
            EndMenu()
        End If
    End Sub

    Sub EndMenu()
        Do
            Console.WriteLine("Do you wish to:")
            Console.WriteLine("1. Play Again")
            Console.WriteLine("2. Exit")
            player_choice = Console.ReadKey
            Select Case player_choice.Key
                Case ConsoleKey.D1, ConsoleKey.NumPad1
                    current_plr = -1
                    Main()
                Case ConsoleKey.D2, ConsoleKey.NumPad2
                    Environment.Exit(0)
                Case Else
                    Console.WriteLine()
                    Console.WriteLine("Invalid user choice.")
                    Threading.Thread.Sleep(1000)
                    Console.Clear()
                    Update_Board()
                    Check_Win()
            End Select
        Loop Until player_choice.KeyChar = "1" Or player_choice.KeyChar = "2"

    End Sub

    Sub Main()
        Console.Clear()
        If current_plr < 0 Then
            Console.WriteLine("Is player 1's symbol X or O?")
            plr1.symbol = Console.ReadLine()
            Configure_Player_Data()
            For x = 0 To 2
                For y = 0 To 2
                    board_layout(x, y) = "-"
                Next
            Next
        End If
        Update_Board()
        If current_plr = 0 Then
            User_Plot(current_plr + 1, plr1)
        Else
            User_Plot(current_plr + 1, plr2)
        End If
    End Sub
End Module
