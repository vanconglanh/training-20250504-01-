Public Module ConvPublic
    Public Const ERR_INVALID_ARGUMENT As Short = 5
    Public Const vbUnicode As Integer = 64
    Public Const vbFromUniCode As Integer = 128

    'Public Const PGRIDLib_HeightSizingConstants_pghs_不可 As Short = 1 ' PGRIDLib.HeightSizingConstants.pghs_不可
    Public Const PGRIDLib_ColStyleConstants_pgcs_ラベル As Short = 2 ' PGRIDLib.ColStyleConstants.pgcs_ラベル 
    Public Const PGRIDLib_ColAlignmentHConstants_pgcah_中央揃え As Short = 3 'PGRIDLib.ColAlignmentHConstants.pgcah_中央揃え
    Public Const PGRIDLib_ColAlignmentHConstants_pgcah_右揃え As Short = 4 ' PGRIDLib.ColAlignmentHConstants.pgcah_右揃え 
    Public Const PGRIDLib_ColAlignmentHConstants_pgcah_左揃え As Short = 7 ' PGRIDLib.ColAlignmentHConstants.pgcah_左揃え
    Public Const PGRIDLib_ColStyleConstants_pgcs_チェックボックス As Short = 5 '  PGRIDLib.ColStyleConstants.pgcs_チェックボックス 
    Public Const PGRIDLib_ColStyleConstants_pgcs_テキスト As Short = 6 ' PGRIDLib.ColStyleConstants.pgcs_テキスト 
    Public Const PGRIDLib_ColStyleConstants_pgcs_数字 As Short = 7 ' PGRIDLib.ColStyleConstants.pgcs_テキスト 

    Public Const MSFlexGridLib_SelectionModeSettings_flexSelectionFree As Short = 0
    Public Const MSFlexGridLib_SelectionModeSettings_flexSelectionByCell As Short = 1
    Public Const MSFlexGridLib_SelectionModeSettings_flexSelectionByRow As Short = 2
    Public Const MSFlexGridLib_SelectionModeSettings_flexSelectionByColumn As Short = 3

    Public Const MSFlexGridLib_CellPropertySettings_flexcpAlignment As Short = 2 'VSFlex6.CellPropertySettings.flexcpAlignment 
    Public Const MSFlexGridLib_AlignmentSettings_flexAlignCenterCenter As Short = 4 'VSFlex6.AlignmentSettings.flexAlignCenterCenter
    Public Const MSFlexGridLib_AlignmentSettings_flexAlignLeftCenter As Short = 10 'VSFlex6.AlignmentSettings.flexAlignLeftCenter
    Public Const MSFlexGridLib_AlignmentSettings_flexAlignRightCenter As Short = 3 'VSFlex6.AlignmentSettings.flexAlignLeftCenter

    Public Const FPSpread_TypeHAlignConstants_TypeHAlignGeneral As Short = 0 ' セルの内容の解釈に従ってセル内容を配置します。
    Public Const FPSpread_TypeHAlignConstants_TypeHAlignLeft As Short = 1 'セルの内容を左に揃えます。
    Public Const FPSpread_TypeHAlignConstants_TypeHAlignCenter As Short = 2 'セルの内容を水平方向の中央に揃えます。
    Public Const FPSpread_TypeHAlignConstants_TypeHAlignRight As Short = 3 'テキストが特定の領域に満たされるように、テキストに空白が挿入されることを示します。
    Public Const FPSpread_TypeHAlignConstants_TypeHAlignJustify As Short = 4 'テキストが特定の領域に満たされるように、テキストに空白が挿入されることを示します。
    Public Const FPSpread_TypeHAlignConstants_TypeHAlignDistributed As Short = 5 'テキストが特定の領域に満たされるように、テキストに空白が挿入されることを示します。

    Public Const FPSpread_TypeVAlignConstants_TypeVAlignGeneral As Short = 0 ' セルの内容の解釈に従ってセル内容を配置します。
    Public Const FPSpread_TypeVAlignConstants_TypeVAlignLeft As Short = 1 'セルの内容を左に揃えます。
    Public Const FPSpread_TypeVAlignConstants_TypeVAlignCenter As Short = 2 'セルの内容を水平方向の中央に揃えます。
    Public Const FPSpread_TypeVAlignConstants_TypeVAlignRight As Short = 3 'テキストが特定の領域に満たされるように、テキストに空白が挿入されることを示します。
    Public Const FPSpread_TypeVAlignConstants_TypeVAlignJustify As Short = 4 'テキストが特定の領域に満たされるように、テキストに空白が挿入されることを示します。
    Public Const FPSpread_TypeVAlignConstants_TypeVAlignDistributed As Short = 5 'テキストが特定の領域に満たされるように、テキストに空白が挿入されることを示します。

    Public Const FPSpread_OperationModeConstants_OperationModeNormal As Short = 0
    Public Const FPSpread_OperationModeConstants_OperationModeRead As Short = 1
    Public Const FPSpread_OperationModeConstants_OperationModeRow As Short = 2
    Public Const FPSpread_OperationModeConstants_OperationModeSingle As Short = 3
    Public Const FPSpread_OperationModeConstants_OperationModeMulti As Short = 4
    Public Const FPSpread_OperationModeConstants_OperationModeExtended As Short = 5

    Public Const FPSpread_EditEnterActionConstants_EditEnterActionNone As Short = 0
    Public Const FPSpread_EditEnterActionConstants_EditEnterActionUp As Short = 1
    Public Const FPSpread_EditEnterActionConstants_EditEnterActionDown As Short = 2
    Public Const FPSpread_EditEnterActionConstants_EditEnterActionLeft As Short = 3
    Public Const FPSpread_EditEnterActionConstants_EditEnterActionRight As Short = 4
    Public Const FPSpread_EditEnterActionConstants_EditEnterActionNext As Short = 5
    Public Const FPSpread_EditEnterActionConstants_EditEnterActionPrevious As Short = 6
    Public Const FPSpread_EditEnterActionConstants_EditEnterActionSame As Short = 7
    Public Const FPSpread_EditEnterActionConstants_EditEnterActionNextRow As Short = 8

    Public Const FPSpread_UserResizeConstants2_UserResizeOff As Boolean = False
    Public Const FPSpread_UserResizeConstants2_UserResizeOn As Boolean = True


    Public Const FPSpread_CellTypeConstants_CellTypeFloat As Short = PGRIDLib_ColStyleConstants_pgcs_数字
    Public Const FPSpread_CellTypeConstants_CellTypeEdit As Short = PGRIDLib_ColStyleConstants_pgcs_テキスト

    'Public Const xNumLib_NonDisplayModeConstants_fdndm_常時 As Short = 1 'xNumLib.NonDisplayModeConstants.fdndm_常時
    'Public Const xNumLib_NonDisplayModeConstants_fdndm_禁止 As Short = 2 'xNumLib.NonDisplayModeConstants.fdndm_禁止

    'Public Const xNumLib_DecimalFigsConstants_fddf_小数部なし As Short = 0
    'Public Const xNumLib_DecimalFigsConstants_fddf_小数部1桁 As Short = 1
    'Public Const xNumLib_DecimalFigsConstants_fddf_小数部2桁 As Short = 2
    'Public Const xNumLib_DecimalFigsConstants_fddf_小数部3桁 As Short = 3

    Public Const FPSPREAD_CELL_NEWLINE_CHAR As String = Chr(13) & Chr(10)
End Module
