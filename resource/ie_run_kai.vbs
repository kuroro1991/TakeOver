Option Explicit
Dim objShell
Dim objWindow
Dim objIE
Dim arg

' �����󂯎��
arg = Wscript.Arguments(0)

' �V�F���̃I�u�W�F�N�g���쐬
Set objShell = CreateObject("Shell.Application")
Set objIE = Nothing  '������

' �E�B���h�E�̐��������[�v
For Each objWindow In objShell.Windows
    If TypeName(objWindow.document) = "HTMLDocument" Then
        Set objIE = objWindow
        Exit For
    End If
Next

Set objShell = Nothing

If objIE Is Nothing Then
    ' IE���N�����Ă��Ȃ��ꍇ(�E�B���h�E�ŊJ��)
    ' �I�u�W�F�N�g�̍쐬
    Set objIE = CreateObject("InternetExplorer.Application")  
    objIE.Navigate2 arg
Else
    ' IE���N�����Ă���ꍇ(�^�u�ŊJ��)
    objIE.Navigate2 arg, &H800
End If

' IE��\��������BTrue�ŕ\��
objIE.Visible = True 
Set objIE = Nothing