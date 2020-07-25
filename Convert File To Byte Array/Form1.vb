Imports System.Text

Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim Open As New OpenFileDialog
        Open.ShowDialog()

        If String.IsNullOrEmpty(Open.FileName) Then End

        Dim Buff As Byte() = My.Computer.FileSystem.ReadAllBytes(Open.FileName)

        Dim SB As New StringBuilder
        SB.AppendLine("Dim Buff As New List(Of Byte)")

        For i = 0 To Buff.Count - 1 Step 100

            Dim LineB As New StringBuilder
            LineB.Append("{")

            Dim U As Integer = i + 99

            For j = i To i + 99
                LineB.Append(Buff(j))

                If Not j = U Then
                    If j = Buff.Count - 1 Then
                        Exit For
                    End If

                    LineB.Append(", ")
                End If

            Next

            LineB.Append("}")

            SB.Append("Buff.AddRange(")
            SB.Append(LineB.ToString)
            SB.Append(")")
            SB.AppendLine()

        Next

        SB.AppendLine()

        Clipboard.SetText(SB.ToString)

        Beep()
        End
    End Sub
End Class
