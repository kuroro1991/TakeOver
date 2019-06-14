Option Explicit
Dim objShell
Dim objWindow
Dim objIE
Dim arg

' 引数受け取り
arg = Wscript.Arguments(0)

' シェルのオブジェクトを作成
Set objShell = CreateObject("Shell.Application")
Set objIE = Nothing  '初期化

' ウィンドウの数だけループ
For Each objWindow In objShell.Windows
    If TypeName(objWindow.document) = "HTMLDocument" Then
        Set objIE = objWindow
        Exit For
    End If
Next

Set objShell = Nothing

If objIE Is Nothing Then
    ' IEが起動していない場合(ウィンドウで開く)
    ' オブジェクトの作成
    Set objIE = CreateObject("InternetExplorer.Application")  
    objIE.Navigate2 arg
Else
    ' IEが起動している場合(タブで開く)
    objIE.Navigate2 arg, &H800
End If

' IEを表示させる。Trueで表示
objIE.Visible = True 
Set objIE = Nothing