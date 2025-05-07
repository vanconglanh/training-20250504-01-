Option Strict Off
Option Explicit On
Module basCheckFileExists
    '******************************************************************************
    ' ﾌﾟﾛｼﾞｪｸﾄ名  : ＭＫシステム共通
    ' ファイル名  : CheckFileExists.bas
    ' 内    容    : ファイル存在チェック処理
    ' 備    考    :
    ' 関数一覧    : <Public>
    '                   gfncCheckFileExists    (ファイル存在チェック処理)
    '               <Private>
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   02.00       2004/08/11  廣井  芳明         新規作成
    '
    '******************************************************************************
    '==============================================================================
    ' ＡＰＩ関数
    '==============================================================================
    ' ファイルの存在チェック
    '++修正開始　2021年05月29日:MK（手）- VB→VB.NET変換
    'Private Declare Function PathFileExists Lib "SHLWAPI.DLL"  Alias "PathFileExistsA"(ByVal pszPath As String) As Integer
    '--修正開始　2021年05月29日:MK（手）- VB→VB.NET変換
    '******************************************************************************
    ' 関 数 名  : gfncCheckFileExists
    ' スコープ  : Public
    ' 処理内容  : ファイル存在チェック処理
    ' 備    考  :
    ' 返 り 値  : True （ファイルあり）
    '             False（ファイルなし）
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrFilePath        String            I     検索対象ファイル
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   02.00       2004/08/11  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Function gfncCheckFileExists(ByVal pstrFilePath As String) As Boolean

        Dim lngRet As Integer

        '++修正開始　2021年05月29日:MK（手）- VB→VB.NET変換
        'lngRet = PathFileExists(pstrFilePath)
        If Len(pstrFilePath) > 0 Then
            If pstrFilePath(pstrFilePath.Length - 1) = "\" Then
                lngRet = System.IO.Directory.Exists(pstrFilePath)
            Else
                lngRet = System.IO.File.Exists(pstrFilePath)
            End If
        End If

        '--修正開始　2021年05月29日:MK（手）- VB→VB.NET変換

        gfncCheckFileExists = Not (lngRet = 0)

    End Function
End Module