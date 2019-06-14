Option Explicit
Dim objShell
Dim objWindow
Dim objIE

'シェルのオブジェクトを作成
Set objShell = CreateObject("Shell.Application")
Set objIE = Nothing  '初期化

'ウィンドウの数だけループ
For Each objWindow In objShell.Windows
    If TypeName(objWindow.document) = "HTMLDocument" Then
        Set objIE = objWindow
        Exit For
    End If
Next

Set objShell = Nothing

If objIE Is Nothing Then
    MsgBox "New Window"
    'オブジェクトの作成
    Set objIE = CreateObject("InternetExplorer.Application")
    '指定したURLを開く
    objIE.Navigate2 "https://news.google.com/news/?edchanged=1&ned=jp&hl=ja"
Else
    MsgBox "New Tab"
    '新しいタブで表示
    objIE.Navigate2 "https://transit.yahoo.co.jp/", &H800
End If

'IEを表示させる。Trueで表示
objIE.Visible = True 
Set objIE = Nothing