Option Strict Off
Option Explicit On
Module SprConstants
    '----------------------------------------------------------
    '
    ' ﾌｧｲﾙ: SSOCX.BAS
    '
    ' Copyright (C) 1998 FarPoint Technologies.
    ' All rights reserved.
    '
    '----------------------------------------------------------

    ' *************************  fpSpreadｺﾝﾄﾛｰﾙ の定数 *************************

    ' Action ﾌﾟﾛﾊﾟﾃｨの定数
    Public Const SS_ACTION_ACTIVE_CELL As Short = 0
    Public Const SS_ACTION_GOTO_CELL As Short = 1
    Public Const SS_ACTION_SELECT_BLOCK As Short = 2
    Public Const SS_ACTION_CLEAR As Short = 3
    Public Const SS_ACTION_DELETE_COL As Short = 4
    Public Const SS_ACTION_DELETE_ROW As Short = 5
    Public Const SS_ACTION_INSERT_COL As Short = 6
    Public Const SS_ACTION_INSERT_ROW As Short = 7
    Public Const SS_ACTION_RECALC As Short = 11
    Public Const SS_ACTION_CLEAR_TEXT As Short = 12
    Public Const SS_ACTION_PRINT As Short = 13
    Public Const SS_ACTION_DESELECT_BLOCK As Short = 14
    Public Const SS_ACTION_DSAVE As Short = 15
    Public Const SS_ACTION_SET_CELL_BORDER As Short = 16
    Public Const SS_ACTION_ADD_MULTISELBLOCK As Short = 17
    Public Const SS_ACTION_GET_MULTI_SELECTION As Short = 18
    Public Const SS_ACTION_COPY_RANGE As Short = 19
    Public Const SS_ACTION_MOVE_RANGE As Short = 20
    Public Const SS_ACTION_SWAP_RANGE As Short = 21
    Public Const SS_ACTION_CLIPBOARD_COPY As Short = 22
    Public Const SS_ACTION_CLIPBOARD_CUT As Short = 23
    Public Const SS_ACTION_CLIPBOARD_PASTE As Short = 24
    Public Const SS_ACTION_SORT As Short = 25
    Public Const SS_ACTION_COMBO_CLEAR As Short = 26
    Public Const SS_ACTION_COMBO_REMOVE As Short = 27
    Public Const SS_ACTION_RESET As Short = 28
    Public Const SS_ACTION_SEL_MODE_CLEAR As Short = 29
    Public Const SS_ACTION_VMODE_REFRESH As Short = 30
    Public Const SS_ACTION_SMARTPRINT As Short = 32

    ' Appearance ﾌﾟﾛﾊﾟﾃｨの定数
    Public Const SS_APPEARANCE_FLAT As Short = 0
    Public Const SS_APPEARANCE_3D As Short = 1
    Public Const SS_APPEARANCE_3DWITHBORDER As Short = 2

    ' BackColorStyle ﾌﾟﾛﾊﾟﾃｨの定数
    Public Const SS_BACKCOLORSTYLE_OVERGRID As Short = 0
    Public Const SS_BACKCOLORSTYLE_UNDERGRID As Short = 1
    Public Const SS_BACKCOLORSTYLE_OVERHORZGRIDONLY As Short = 2
    Public Const SS_BACKCOLORSTYLE_OVERVERTGRIDONLY As Short = 3

    ' BorderStyle ﾌﾟﾛﾊﾟﾃｨの定数
    Public Const SS_BORDER_NONE As Short = 0
    Public Const SS_BORDER_FIXEDSINGLE As Short = 1

    ' ButtonDrawMode ﾌﾟﾛﾊﾟﾃｨの定数
    Public Const SS_BDM_ALWAYS As Short = 0
    Public Const SS_BDM_CURRENT_CELL As Short = 1
    Public Const SS_BDM_CURRENT_COLUMN As Short = 2
    Public Const SS_BDM_CURRENT_ROW As Short = 4
    Public Const SS_BDM_ALWAYS_BUTTON As Short = 8
    Public Const SS_BDM_ALWAYS_COMBO As Short = 16

    ' CellBorderStyle ﾌﾟﾛﾊﾟﾃｨの定数
    Public Const SS_BORDER_STYLE_DEFAULT As Short = 0
    Public Const SS_BORDER_STYLE_SOLID As Short = 1
    Public Const SS_BORDER_STYLE_DASH As Short = 2
    Public Const SS_BORDER_STYLE_DOT As Short = 3
    Public Const SS_BORDER_STYLE_DASH_DOT As Short = 4
    Public Const SS_BORDER_STYLE_DASH_DOT_DOT As Short = 5
    Public Const SS_BORDER_STYLE_BLANK As Short = 6
    Public Const SS_BORDER_STYLE_FINE_SOLID As Short = 11
    Public Const SS_BORDER_STYLE_FINE_DASH As Short = 12
    Public Const SS_BORDER_STYLE_FINE_DOT As Short = 13
    Public Const SS_BORDER_STYLE_FINE_DASH_DOT As Short = 14
    Public Const SS_BORDER_STYLE_FINE_DASH_DOT_DOT As Short = 15

    ' CellBorderType ﾌﾟﾛﾊﾟﾃｨの定数
    Public Const SS_BORDER_TYPE_NONE As Short = 0
    Public Const SS_BORDER_TYPE_OUTLINE As Short = 16
    Public Const SS_BORDER_TYPE_LEFT As Short = 1
    Public Const SS_BORDER_TYPE_RIGHT As Short = 2
    Public Const SS_BORDER_TYPE_TOP As Short = 4
    Public Const SS_BORDER_TYPE_BOTTOM As Short = 8

    ' CellType ﾌﾟﾛﾊﾟﾃｨの定数
    Public Const SS_CELL_TYPE_DATE As Short = 0
    Public Const SS_CELL_TYPE_EDIT As Short = 1
    Public Const SS_CELL_TYPE_FLOAT As Short = 2
    Public Const SS_CELL_TYPE_INTEGER As Short = 3
    Public Const SS_CELL_TYPE_PIC As Short = 4
    Public Const SS_CELL_TYPE_STATIC_TEXT As Short = 5
    Public Const SS_CELL_TYPE_TIME As Short = 6
    Public Const SS_CELL_TYPE_BUTTON As Short = 7
    Public Const SS_CELL_TYPE_COMBOBOX As Short = 8
    Public Const SS_CELL_TYPE_PICTURE As Short = 9
    Public Const SS_CELL_TYPE_CHECKBOX As Short = 10
    Public Const SS_CELL_TYPE_OWNER_DRAWN As Short = 11

    ' ClipboardOptions ﾌﾟﾛﾊﾟﾃｨの定数
    Public Const SS_CLIP_NOHEADERS As Short = 0
    Public Const SS_CLIP_COPYROWHEADERS As Short = 1
    Public Const SS_CLIP_PASTEROWHEADERS As Short = 2
    Public Const SS_CLIP_COPYCOLHEADERS As Short = 4
    Public Const SS_CLIP_PASTECOLHEADERS As Short = 8
    Public Const SS_CLIP_COPYPASTEALLHEADERS As Short = 15

    ' ColHeaderDisplay、RowHeaderDisplay ﾌﾟﾛﾊﾟﾃｨの定数
    Public Const SS_HEADER_BLANK As Short = 0
    Public Const SS_HEADER_NUMBERS As Short = 1
    Public Const SS_HEADER_LETTERS As Short = 2

    ' CursorStyle ﾌﾟﾛﾊﾟﾃｨの定数
    Public Const SS_CURSOR_STYLE_USER_DEFINED As Short = 0
    Public Const SS_CURSOR_STYLE_DEFAULT As Short = 1
    Public Const SS_CURSOR_STYLE_ARROW As Short = 2
    Public Const SS_CURSOR_STYLE_DEFCOLRESIZE As Short = 3
    Public Const SS_CURSOR_STYLE_DEFROWRESIZE As Short = 4

    ' CursorType ﾌﾟﾛﾊﾟﾃｨの定数
    Public Const SS_CURSOR_TYPE_DEFAULT As Short = 0
    Public Const SS_CURSOR_TYPE_COLRESIZE As Short = 1
    Public Const SS_CURSOR_TYPE_ROWRESIZE As Short = 2
    Public Const SS_CURSOR_TYPE_BUTTON As Short = 3
    Public Const SS_CURSOR_TYPE_GRAYAREA As Short = 4
    Public Const SS_CURSOR_TYPE_LOCKEDCELL As Short = 5
    Public Const SS_CURSOR_TYPE_COLHEADER As Short = 6
    Public Const SS_CURSOR_TYPE_ROWHEADER As Short = 7
    Public Const SS_CURSOR_TYPE_DRAGDROPAREA As Short = 8
    Public Const SS_CURSOR_TYPE_DRAGDROP As Short = 9

    ' DAutoSize ﾌﾟﾛﾊﾟﾃｨの定数
    Public Const SS_AUTOSIZE_NO As Short = 0
    Public Const SS_AUTOSIZE_MAX_COL_WIDTH As Short = 1
    Public Const SS_AUTOSIZE_BEST_GUESS As Short = 2

    ' EditEnterAction ﾌﾟﾛﾊﾟﾃｨの定数
    Public Const SS_CELL_EDITMODE_EXIT_NONE As Short = 0
    Public Const SS_CELL_EDITMODE_EXIT_UP As Short = 1
    Public Const SS_CELL_EDITMODE_EXIT_DOWN As Short = 2
    Public Const SS_CELL_EDITMODE_EXIT_LEFT As Short = 3
    Public Const SS_CELL_EDITMODE_EXIT_RIGHT As Short = 4
    Public Const SS_CELL_EDITMODE_EXIT_NEXT As Short = 5
    Public Const SS_CELL_EDITMODE_EXIT_PREVIOUS As Short = 6
    Public Const SS_CELL_EDITMODE_EXIT_SAME As Short = 7
    Public Const SS_CELL_EDITMODE_EXIT_NEXTROW As Short = 8

    ' OperationMode ﾌﾟﾛﾊﾟﾃｨの定数
    Public Const SS_OP_MODE_NORMAL As Short = 0
    Public Const SS_OP_MODE_READONLY As Short = 1
    Public Const SS_OP_MODE_ROWMODE As Short = 2
    Public Const SS_OP_MODE_SINGLE_SELECT As Short = 3
    Public Const SS_OP_MODE_MULTI_SELECT As Short = 4
    Public Const SS_OP_MODE_EXT_SELECT As Short = 5

    ' Position ﾌﾟﾛﾊﾟﾃｨの定数
    Public Const SS_POSITION_UPPER_LEFT As Short = 0
    Public Const SS_POSITION_UPPER_CENTER As Short = 1
    Public Const SS_POSITION_UPPER_RIGHT As Short = 2
    Public Const SS_POSITION_CENTER_LEFT As Short = 3
    Public Const SS_POSITION_CENTER_CENTER As Short = 4
    Public Const SS_POSITION_CENTER_RIGHT As Short = 5
    Public Const SS_POSITION_BOTTOM_LEFT As Short = 6
    Public Const SS_POSITION_BOTTOM_CENTER As Short = 7
    Public Const SS_POSITION_BOTTOM_RIGHT As Short = 8

    ' PrintOrientation ﾌﾟﾛﾊﾟﾃｨの定数
    Public Const SS_PRINTORIENT_DEFAULT As Short = 0
    Public Const SS_PRINTORIENT_PORTRAIT As Short = 1
    Public Const SS_PRINTORIENT_LANDSCAPE As Short = 2

    ' PrintType ﾌﾟﾛﾊﾟﾃｨの定数
    Public Const SS_PRINT_ALL As Short = 0
    Public Const SS_PRINT_CELL_RANGE As Short = 1
    Public Const SS_PRINT_CURRENT_PAGE As Short = 2
    Public Const SS_PRINT_PAGE_RANGE As Short = 3

    ' ScrollBars ﾌﾟﾛﾊﾟﾃｨの定数
    Public Const SS_SCROLLBAR_NONE As Short = 0
    Public Const SS_SCROLLBAR_H_ONLY As Short = 1
    Public Const SS_SCROLLBAR_V_ONLY As Short = 2
    Public Const SS_SCROLLBAR_BOTH As Short = 3

    ' ScrollBarTrack ﾌﾟﾛﾊﾟﾃｨの定数
    Public Const SS_SCROLLBARTRACK_OFF As Short = 0
    Public Const SS_SCROLLBARTRACK_VERTICAL As Short = 1
    Public Const SS_SCROLLBARTRACK_HORIZONTAL As Short = 2
    Public Const SS_SCROLLBARTRACK_BOTH As Short = 3

    ' SelBackColor ﾌﾟﾛﾊﾟﾃｨの定数
    Public Const SPREAD_COLOR_NONE As Integer = &H8000000B

    ' SelectBlockOptions ﾌﾟﾛﾊﾟﾃｨの定数
    Public Const SS_SELBLOCKOPT_COLS As Short = 1
    Public Const SS_SELBLOCKOPT_ROWS As Short = 2
    Public Const SS_SELBLOCKOPT_BLOCKS As Short = 4
    Public Const SS_SELBLOCKOPT_ALL As Short = 8

    ' SortBy ﾌﾟﾛﾊﾟﾃｨの定数
    Public Const SS_SORT_BY_ROW As Short = 0
    Public Const SS_SORT_BY_COL As Short = 1

    ' SortKeyOrder ﾌﾟﾛﾊﾟﾃｨの定数
    Public Const SS_SORT_ORDER_NONE As Short = 0
    Public Const SS_SORT_ORDER_ASCENDING As Short = 1
    Public Const SS_SORT_ORDER_DESCENDING As Short = 2

    ' TextTip ﾌﾟﾛﾊﾟﾃｨの定数
    Public Const SS_TEXTTIP_OFF As Short = 0
    Public Const SS_TEXTTIP_FIXED As Short = 1
    Public Const SS_TEXTTIP_FLOATING As Short = 2
    Public Const SS_TEXTTIP_FIXEDFOCUSONLY As Short = 3
    Public Const SS_TEXTTIP_FLOATINGFOCUSONLY As Short = 4

    ' TypeButtonAlign ﾌﾟﾛﾊﾟﾃｨの定数
    Public Const SS_CELL_BUTTON_ALIGN_BOTTOM As Short = 0
    Public Const SS_CELL_BUTTON_ALIGN_TOP As Short = 1
    Public Const SS_CELL_BUTTON_ALIGN_LEFT As Short = 2
    Public Const SS_CELL_BUTTON_ALIGN_RIGHT As Short = 3

    ' TypeButtonType ﾌﾟﾛﾊﾟﾃｨの定数
    Public Const SS_CELL_BUTTON_NORMAL As Short = 0
    Public Const SS_CELL_BUTTON_TWO_STATE As Short = 1

    ' TypeCheckTextAlign ﾌﾟﾛﾊﾟﾃｨの定数
    Public Const SS_CHECKBOX_TEXT_LEFT As Short = 0
    Public Const SS_CHECKBOX_TEXT_RIGHT As Short = 1

    ' TypeCheckType ﾌﾟﾛﾊﾟﾃｨの定数
    Public Const SS_CHECKBOX_NORMAL As Short = 0
    Public Const SS_CHECKBOX_THREE_STATE As Short = 1

    ' TypeDateFormat ﾌﾟﾛﾊﾟﾃｨの定数
    Public Const SS_CELL_DATE_FORMAT_DDMONYY As Short = 0
    Public Const SS_CELL_DATE_FORMAT_DDMMYY As Short = 1
    Public Const SS_CELL_DATE_FORMAT_MMDDYY As Short = 2
    Public Const SS_CELL_DATE_FORMAT_YYMMDD As Short = 3
    Public Const SS_CELL_DATE_FORMAT_YYMM As Short = 4
    Public Const SS_CELL_DATE_FORMAT_MMDD As Short = 5
    Public Const SS_CELL_DATE_FORMAT_NYYMMDD As Short = 6
    Public Const SS_CELL_DATE_FORMAT_NNYYMMDD As Short = 7
    Public Const SS_CELL_DATE_FORMAT_NNNNYYMMDD As Short = 8

    ' TypeEditCharCase ﾌﾟﾛﾊﾟﾃｨの定数
    Public Const SS_CELL_EDIT_CASE_LOWER_CASE As Short = 0
    Public Const SS_CELL_EDIT_CASE_NO_CASE As Short = 1
    Public Const SS_CELL_EDIT_CASE_UPPER_CASE As Short = 2

    ' TypeEditCharSet ﾌﾟﾛﾊﾟﾃｨの定数
    Public Const SS_CELL_EDIT_CHAR_SET_ASCII As Short = 0
    Public Const SS_CELL_EDIT_CHAR_SET_ALPHA As Short = 1
    Public Const SS_CELL_EDIT_CHAR_SET_ALPHANUMERIC As Short = 2
    Public Const SS_CELL_EDIT_CHAR_SET_NUMERIC As Short = 3
    Public Const SS_CELL_EDIT_CHAR_SET_KANJI_ONLY As Short = 4
    Public Const SS_CELL_EDIT_CHAR_SET_KANJI_ONLY_IME As Short = 5
    Public Const SS_CELL_EDIT_CHAR_SET_ALL_IME As Short = 6

    ' TypeHAlign ﾌﾟﾛﾊﾟﾃｨの定数
    Public Const SS_CELL_H_ALIGN_LEFT As Short = 0
    Public Const SS_CELL_H_ALIGN_RIGHT As Short = 1
    Public Const SS_CELL_H_ALIGN_CENTER As Short = 2

    ' TypeTextAlignVert ﾌﾟﾛﾊﾟﾃｨの定数
    Public Const SS_CELL_STATIC_V_ALIGN_BOTTOM As Short = 0
    Public Const SS_CELL_STATIC_V_ALIGN_CENTER As Short = 1
    Public Const SS_CELL_STATIC_V_ALIGN_TOP As Short = 2

    ' TypeTime24Hour ﾌﾟﾛﾊﾟﾃｨの定数
    Public Const SS_CELL_TIME_12_HOUR_CLOCK As Short = 0
    Public Const SS_CELL_TIME_24_HOUR_CLOCK As Short = 1
    Public Const SS_CELL_TIME_12_HOUR_CLOCK_AM As Short = 2
    Public Const SS_CELL_TIME_12_AM_HOUR_CLOCK As Short = 3

    ' TypeVAlign ﾌﾟﾛﾊﾟﾃｨの定数
    Public Const SS_CELL_V_ALIGN_TOP As Short = 0
    Public Const SS_CELL_V_ALIGN_BOTTOM As Short = 1
    Public Const SS_CELL_V_ALIGN_VCENTER As Short = 2

    ' UnitType ﾌﾟﾛﾊﾟﾃｨの定数
    Public Const SS_CELL_UNIT_NORMAL As Short = 0
    Public Const SS_CELL_UNIT_VGA As Short = 1
    Public Const SS_CELL_UNIT_TWIPS As Short = 2

    ' UserResize ﾌﾟﾛﾊﾟﾃｨの定数
    Public Const SS_USER_RESIZE_NONE As Short = 0
    Public Const SS_USER_RESIZE_COL As Short = 1
    Public Const SS_USER_RESIZE_ROW As Short = 2
    Public Const SS_USER_RESIZE_BOTH As Short = 3

    ' UserResizeCol、UserResizeRow ﾌﾟﾛﾊﾟﾃｨの定数
    Public Const SS_USER_RESIZE_DEFAULT As Short = 0
    Public Const SS_USER_RESIZE_ON As Short = 1
    Public Const SS_USER_RESIZE_OFF As Short = 2

    ' VScrollSpecialType ﾌﾟﾛﾊﾟﾃｨの定数
    Public Const SS_VSCROLLSPECIAL_NO_HOME_END As Short = 1
    Public Const SS_VSCROLLSPECIAL_NO_PAGE_UP_DOWN As Short = 2
    Public Const SS_VSCROLLSPECIAL_NO_LINE_UP_DOWN As Short = 4

    ' ActionKey ﾒｿｯﾄﾞの Action 引数の定数
    Public Const SS_KBA_CLEAR As Short = 0
    Public Const SS_KBA_CURRENT As Short = 1
    Public Const SS_KBA_POPUP As Short = 2

    ' AddCustomFunctionExt ﾒｿｯﾄﾞの Flags 引数の定数
    Public Const SS_CUSTFUNC_WANTCELLREF As Short = 1
    Public Const SS_CUSTFUNC_WANTRANGEREF As Short = 2

    ' CFGetParamInfo ﾒｿｯﾄﾞの Type 引数の定数
    Public Const SS_VALUE_TYPE_LONG As Short = 0
    Public Const SS_VALUE_TYPE_DOUBLE As Short = 1
    Public Const SS_VALUE_TYPE_STR As Short = 2
    Public Const SS_VALUE_TYPE_CELL As Short = 3
    Public Const SS_VALUE_TYPE_RANGE As Short = 4

    ' CFGetParamInfo ﾒｿｯﾄﾞの Status 引数の定数
    Public Const SS_VALUE_STATUS_OK As Short = 0
    Public Const SS_VALUE_STATUS_ERROR As Short = 1
    Public Const SS_VALUE_STATUS_EMPTY As Short = 2

    ' GetRefStyle ﾒｿｯﾄﾞの戻り値、SetRefStyle ﾒｿｯﾄﾞの RefStyle 引数の定数
    Public Const SS_REFSTYLE_DEFAULT As Short = 0
    Public Const SS_REFSTYLE_A1 As Short = 1
    Public Const SS_REFSTYLE_R1C1 As Short = 2

    ' PrintPageOrder ﾌﾟﾛﾊﾟﾃｨの定数
    Public Const SS_PAGEORDER_AUTO As Short = 0
    Public Const SS_PAGEORDER_DOWNTHENOVER As Short = 1
    Public Const SS_PAGEORDER_OVERTHENDOWN As Short = 2

    ' TextTipFetch ｲﾍﾞﾝﾄの MultiLine 引数の定数
    Public Const SS_TT_MULTILINE_SINGLE As Short = 0
    Public Const SS_TT_MULTILINE_MULTI As Short = 1
    Public Const SS_TT_MULTILINE_AUTO As Short = 2

    ' *************************  fpSpreadPreview ｺﾝﾄﾛｰﾙの定数 *************************

    ' GrayAreaMarginType ﾌﾟﾛﾊﾟﾃｨの定数
    Public Const SPV_GRAYAREAMARGINTYPE_SCALED As Short = 0
    Public Const SPV_GRAYAREAMARGINTYPE_ACTUAL As Short = 1

    ' MousePointer ﾌﾟﾛﾊﾟﾃｨの定数
    Public Const SPV_MOUSEPOINTER_DEFAULT As Short = 0
    Public Const SPV_MOUSEPOINTER_ARROW As Short = 1
    Public Const SPV_MOUSEPOINTER_CROSS As Short = 2
    Public Const SPV_MOUSEPOINTER_I_BEAM As Short = 3
    Public Const SPV_MOUSEPOINTER_ICON As Short = 4
    Public Const SPV_MOUSEPOINTER_SIZE As Short = 5
    Public Const SPV_MOUSEPOINTER_SIZE_NE_SW As Short = 6
    Public Const SPV_MOUSEPOINTER_SIZE_N_S As Short = 7
    Public Const SPV_MOUSEPOINTER_SIZE_NW_SE As Short = 8
    Public Const SPV_MOUSEPOINTER_SIZE_W_E As Short = 9
    Public Const SPV_MOUSEPOINTER_UP_ARROW As Short = 10
    Public Const SPV_MOUSEPOINTER_HOURGLASS As Short = 11
    Public Const SPV_MOUSEPOINTER_NO_DROP As Short = 12

    ' PageViewType ﾌﾟﾛﾊﾟﾃｨの定数
    Public Const SPV_PAGEVIEWTYPE_WHOLE_PAGE As Short = 0
    Public Const SPV_PAGEVIEWTYPE_NORMAL_SIZE As Short = 1
    Public Const SPV_PAGEVIEWTYPE_PERCENTAGE As Short = 2
    Public Const SPV_PAGEVIEWTYPE_PAGE_WIDTH As Short = 3
    Public Const SPV_PAGEVIEWTYPE_PAGE_HEIGHT As Short = 4
    Public Const SPV_PAGEVIEWTYPE_MULTIPLE_PAGES As Short = 5

    ' ScrollBarH ﾌﾟﾛﾊﾟﾃｨの定数
    Public Const SPV_SCROLLBARH_SHOW As Short = 0
    Public Const SPV_SCROLLBARH_AUTO As Short = 1
    Public Const SPV_SCROLLBARH_HIDE As Short = 2

    ' ScrollBarV ﾌﾟﾛﾊﾟﾃｨの定数
    Public Const SPV_SCROLLBARV_SHOW As Short = 0
    Public Const SPV_SCROLLBARV_AUTO As Short = 1
    Public Const SPV_SCROLLBARV_HIDE As Short = 2

    ' ZoomState ﾌﾟﾛﾊﾟﾃｨの定数
    Public Const SPV_ZOOMSTATE_INDETERMINATE As Short = 0
    Public Const SPV_ZOOMSTATE_IN As Short = 1
    Public Const SPV_ZOOMSTATE_OUT As Short = 2
    Public Const SPV_ZOOMSTATE_SWITCH As Short = 3

    ' *************************  OLE ﾄﾞﾗｯｸﾞ ｱﾝﾄﾞ ﾄﾞﾛｯﾌﾟ関連の定数 *************************
    ' OLEDropMode ﾌﾟﾛﾊﾟﾃｨの定数
    Public Const SS_OLEDROPMODE_NONE As Short = 0
    Public Const SS_OLEDROPMODE_MANUAL As Short = 1

    ' OLECompleteDrag、OLEDragDrop、OLEDragOver、OLEGiveFeedback
    ' OLEStartDrag の各ｲﾍﾞﾝﾄの Effect 引数の定数
    Public Const SS_OLEDROP_EFFECT_NONE As Short = 0
    Public Const SS_OLEDROP_EFFECT_COPY As Short = 1
    Public Const SS_OLEDROP_EFFECT_MOVE As Short = 2
    Public Const SS_OLEDROP_EFFECT_SCROLL As Double = -2147483648.0#

    ' OLEDragOver ｲﾍﾞﾝﾄの State 引数の定数
    Public Const SS_STATE_ENTER As Short = 0
    Public Const SS_STATE_LEAVE As Short = 1
    Public Const SS_STATE_OVER As Short = 2

    ' GetData、GetFormat、SetData の各ﾒｿｯﾄﾞの Format 引数の定数
    Public Const SS_CFTEXT As Short = 1
    Public Const SS_CFBITMAP As Short = 2
    Public Const SS_CFMETAFILE As Short = 3
    Public Const SS_CFDIB As Short = 8
    Public Const SS_CFPALETTE As Short = 9
    Public Const SS_CFEMETAFILE As Short = 14
    Public Const SS_CFFILES As Short = 15
    Public Const SS_CFRTF As Short = -16639
End Module