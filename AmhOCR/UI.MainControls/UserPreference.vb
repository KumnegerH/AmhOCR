Public Class UserPreference

    Private Loaded As Boolean = False
    Private Sub UserPreference_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        Loaded = True
    End Sub

    Private Sub btnErrorColorChange_Click(sender As Object, e As EventArgs) Handles btnErrorColorChange.Click

        Using clrDialog = New ColorDialog

            clrDialog.FullOpen = False
            clrDialog.SolidColorOnly = True
            clrDialog.Color = lblSpellColor.BackColor
            If clrDialog.ShowDialog(Me) = DialogResult.OK Then
                lblSpellColor.BackColor = clrDialog.Color
            End If

        End Using

    End Sub

    Private Sub btnUserColorChange_Click(sender As Object, e As EventArgs) Handles btnUserColorChange.Click
        Using clrDialog = New ColorDialog

            clrDialog.FullOpen = False
            clrDialog.SolidColorOnly = True
            clrDialog.Color = lblUserColor.BackColor
            If clrDialog.ShowDialog(Me) = DialogResult.OK Then
                lblUserColor.BackColor = clrDialog.Color
            End If

        End Using
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        Me.DialogResult = DialogResult.OK

    End Sub


End Class