Option Explicit
Dim objShell
Dim objWindow
Dim objIE

'�V�F���̃I�u�W�F�N�g���쐬
Set objShell = CreateObject("Shell.Application")
Set objIE = Nothing  '������

'�E�B���h�E�̐��������[�v
For Each objWindow In objShell.Windows
    If TypeName(objWindow.document) = "HTMLDocument" Then
        Set objIE = objWindow
        Exit For
    End If
Next

Set objShell = Nothing

If objIE Is Nothing Then
    MsgBox "New Window"
    '�I�u�W�F�N�g�̍쐬
    Set objIE = CreateObject("InternetExplorer.Application")
    '�w�肵��URL���J��
    objIE.Navigate2 "https://news.google.com/news/?edchanged=1&ned=jp&hl=ja"
Else
    MsgBox "New Tab"
    '�V�����^�u�ŕ\��
    objIE.Navigate2 "https://transit.yahoo.co.jp/", &H800
End If

'IE��\��������BTrue�ŕ\��
objIE.Visible = True 
Set objIE = Nothing