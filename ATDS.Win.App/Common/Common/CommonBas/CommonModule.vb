Option Strict Off
Option Explicit On
Imports MKOra.Core

Module basCommonModule
    '******************************************************************************
    ' ﾌﾟﾛｼﾞｪｸﾄ名  : ＭＫシステム共通
    ' ファイル名  : CommonModule.bas
    ' 内    容    : 共通 モジュール
    ' 備    考    :
    ' 関数一覧    : <Public>
    '               <Private>
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '
    '******************************************************************************
    '==============================================================================
    ' 変数
    '==============================================================================
    '++修正開始　2021年05月27:MK（ツール）- OR_005 VB→VB.NET変換
    'Public gobjOraSession As Object ' Oracle Object For Ole
    Public gobjOraSession As OraSession ' Oracle Object For Ole
    '--修正終了　2021年05月27:MK（ツール）- OR_005 VB→VB.NET変換
    '++修正開始　2021年05月27:MK（ツール）- OR_002 VB→VB.NET変換
    'Public gobjOraDatabase As Object ' Oracle Object For Ole
    Public gobjOraDatabase As OraDatabase ' Oracle Object For Ole
    '--修正終了　2021年05月27:MK（ツール）- OR_002 VB→VB.NET変換

    Public gclsLoginInfo As New clsUnitLoginInfo

    'Maruo 2006.12.21 INSERT START:計算課メニュー組み込み対応
    Public gstrLocalIP As String
    'Maruo 2006.12.21 INSERT END  :計算課メニュー組み込み対応
End Module
