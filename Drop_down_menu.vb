Sub Document_Open()
Application.ScreenUpdating = True
'Note: A VBA Reference to the Excel Object Model is required, via Tools|References
Dim xlApp As New Excel.Application, xlWkBk As Excel.Workbook
Dim StrWkBkNm As String, StrWkShtNm As String, LRow As Long, i As Long, v As Long
StrWkBkNm = "C:\Sample_data.xlsx"
StrWkShtNm = "Courses"
If Dir(StrWkBkNm) = "" Then
  MsgBox "Cannot find the designated workbook: " & StrWkBkNm, vbExclamation
  Exit Sub
End If
With xlApp
  'Hide our Excel session
  .Visible = False
  ' Open the workbook
  Set xlWkBk = .Workbooks.Open(FileName:=StrWkBkNm, ReadOnly:=True, AddToMRU:=False)
  ' Process the workbook.
  With xlWkBk
      With .Worksheets(StrWkShtNm)
        ' Find the last-used row in column A.
        LRow = .Cells(.Rows.Count, 1).End(xlUp).Row
        ' Populate the content control titled 'ID', with Column A for the 'ID' as the
        ' content control Text and the values from columns B-E as the content control
        ' value, using a "|" separator
        ActiveDocument.SelectContentControlsByTitle("Dropdown1")(1).DropdownListEntries.Clear
        For i = 1 To LRow
          ActiveDocument.SelectContentControlsByTitle("Dropdown1")(1).DropdownListEntries.Add _
            Text:=Trim(.Range("A" & i))
            Next
        ActiveDocument.SelectContentControlsByTitle("Dropdown2")(1).DropdownListEntries.Clear
        For i = 1 To LRow
          ActiveDocument.SelectContentControlsByTitle("Dropdown2")(1).DropdownListEntries.Add _
            Text:=Trim(.Range("A" & i))
            Next
        ActiveDocument.SelectContentControlsByTitle("Dropdown3")(1).DropdownListEntries.Clear
        For i = 1 To LRow
          ActiveDocument.SelectContentControlsByTitle("Dropdown3")(1).DropdownListEntries.Add _
            Text:=Trim(.Range("A" & i))
            Next
        ActiveDocument.SelectContentControlsByTitle("Dropdown4")(1).DropdownListEntries.Clear
        For i = 1 To LRow
          ActiveDocument.SelectContentControlsByTitle("Dropdown4")(1).DropdownListEntries.Add _
            Text:=Trim(.Range("A" & i))
            Next
          'or, for example, to add the contents of column B to the content control's 'value':
          'ActiveDocument.SelectContentControlsByTitle("ID")(1).DropdownListEntries.Add _
            Text:=Trim(.Range("A" & i)), Value:=Trim(.Range("B" & i))
      End With
    .Close False
  End With
  .Quit
End With
' Release Excel object memory
Set xlWkBk = Nothing: Set xlApp = Nothing
Application.ScreenUpdating = True
End Sub
