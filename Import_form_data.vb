Sub GetFormData()
     'Note: this code requires a reference to the Word object model
    Application.ScreenUpdating = False
    Dim wdApp As New Word.Application
    Dim wdDoc As Word.Document
    Dim CCtrl As Word.ContentControl
    Dim strFolder As String, strFile As String
    Dim WkSht As Worksheet, i As Long, j As Long
    strFolder = GetFolder
    If strFolder = "" Then Exit Sub
    Set WkSht = ActiveSheet
    i = WkSht.Cells(WkSht.Rows.Count, 1).End(xlUp).Row
    strFile = Dir(strFolder & "\*.docm", vbNormal)
    While strFile <> ""
        i = i + 1
        Set wdDoc = wdApp.Documents.Open(Filename:=strFolder & "\" & strFile, AddToRecentFiles:=False, Visible:=False)
        With wdDoc
            j = 0
            For Each CCtrl In .ContentControls
                j = j + 1
                WkSht.Cells(i, j) = CCtrl.Range.Text
            Next
        End With
        wdDoc.Close SaveChanges:=False
        strFile = Dir()
    Wend
    wdApp.Quit
    Set wdDoc = Nothing: Set wdApp = Nothing: Set WkSht = Nothing
    Application.ScreenUpdating = True
End Sub
 
Function GetFolder() As String
    Dim oFolder As Object
    GetFolder = ""
    Set oFolder = CreateObject("Shell.Application").BrowseForFolder(0, "Choose a folder", 0)
    If (Not oFolder Is Nothing) Then GetFolder = oFolder.Items.Item.Path
    Set oFolder = Nothing
End Function