Option Strict Off
Option Explicit On
Module basFolderDialog
	
	Private Enum NWinOSPlatformTypes
		winVerPlatformWin32s = 0
		winVerPlatformWin32Windows = 1
		winVerPlatformWin32NT = 2
	End Enum
	
	Public Enum NSHBrowseFolderOutMessages
		shBFFMInitialized = 1
		shBFFMSelChanged = 2
		shBFFMValidateFailed = 3
		shBFFMValidateFailedW = 4
		shBFFMIUnknown = 5
	End Enum
	
	Public Enum NSHBrowseFolderInMessages
		shBFFMSetStatusText = 1124
		shBFFMEnableOK = 1125
		shBFFMSetSelection = 1126
		shBFFMSetSelectionW = 1127
		shBFFMSetStatusTextW = 1128
		shBFFMSetOKText = 1129
		shBFFMSetExpanded = 1130
	End Enum
	
	Public Enum NSHFileAttributes
		shFGAOCanCopy = &H1
		shFGAOCanMove = &H2
		shFGAOCanLink = &H4
		shFGAOStorage = &H8
		shFGAOCanRename = &H10
		shFGAOCanDelete = &H20
		shFGAOHasPropSheet = &H40
		shFGAODropTarget = &H100
		shFGAOEncrypted = &H2000
		shFGAOIsSlow = &H4000
		shFGAOGhosted = &H8000
		shFGAOLink = &H10000
		shFGAOShare = &H20000
		shFGAOReadOnly = &H40000
		shFGAOHidden = &H80000
		shFGAONonEnumerated = &H100000
		shFGAONewContent = &H200000
		shFGAOCanMoniker = &H400000
		shFGAOHasStorage = &H400000
		shFGAOStream = &H400000
		shFGAOStorageAncestor = &H800000
		shFGAOValidate = &H1000000
		shFGAORemovable = &H2000000
		shFGAOCompressed = &H4000000
		shFGAOBrowsable = &H8000000
		shFGAOFileSysAncestor = &H10000000
		shFGAOFolder = &H20000000
		shFGAOFileSystem = &H40000000
		shFGAOHasSubFolder = &H80000000
	End Enum
	
	Public Enum NSHFileInfoFlags
		shGFILargeIcon = &H0
		shGFISmallIcon = &H1
		shGFIOpenIcon = &H2
		shGFIShellIconSize = &H4
		shGFIPIDL = &H8
		shGFIUseFileAttributes = &H10
		shGFIAddOverlays = &H20
		shGFIOverlayIndex = &H40
		shGFIIcon = &H100
		shGFIDisplayName = &H200
		shGFITypeName = &H400
		shGFIAttributes = &H800
		shGFIIconLocation = &H1000
		shGFIExeType = &H2000
		shGFISysIconIndex = &H4000
		shGFILinkOverlay = &H8000
		shGFISelected = &H10000
		shGFIAttrSpecified = &H20000
	End Enum
	
	Public Enum NSHSpecialFolderIDs
		shCSIDLInvalid = -1
		shCSIDLDesktop = &H0
		shCSIDLInternet = &H1
		shCSIDLPrograms = &H2
		shCSIDLControls = &H3
		shCSIDLPrinters = &H4
		shCSIDLPersonal = &H5
		shCSIDLFavorites = &H6
		shCSIDLStartUp = &H7
		shCSIDLRecent = &H8
		shCSIDLSendTo = &H9
		shCSIDLBitBucket = &HA
		shCSIDLStartMenu = &HB
		shCSIDLMyDocuments = &HC
		shCSIDLMyMusic = &HD
		shCSIDLMyVideo = &HE
		shCSIDLDesktopDirectory = &H10
		shCSIDLDrives = &H11
		shCSIDLNetwork = &H12
		shCSIDLNethood = &H13
		shCSIDLFonts = &H14
		shCSIDLTemplates = &H15
		shCSIDLCommonStartMenu = &H16
		shCSIDLCommonPrograms = &H17
		shCSIDLCommonStartUp = &H18
		shCSIDLCommonDesktopDirectory = &H19
		shCSIDLAppData = &H1A
		shCSIDLPrintHood = &H1B
		shCSIDLLocalAppData = &H1C
		shCSIDLAltStartUp = &H1D
		shCSIDLCommonAltStartUp = &H1E
		shCSIDLCommonFavorites = &H1F
		shCSIDLInternetCache = &H20
		shCSIDLCookies = &H21
		shCSIDLHistory = &H22
		shCSIDLCommonAppData = &H23
		shCSIDLWindows = &H24
		shCSIDLSystem = &H25
		shCSIDLProgramFiles = &H26
		shCSIDLMyPictures = &H27
		shCSIDLProfile = &H28
		shCSIDLSystemX86 = &H29
		shCSIDLProgramFilesX86 = &H2A
		shCSIDLProgramFilesCommon = &H2B
		shCSIDLProgramFilesCommonX86 = &H2C
		shCSIDLCommonTemplates = &H2D
		shCSIDLCommonDocuments = &H2E
		shCSIDLCommonAdminTools = &H2F
		shCSIDLAdminTools = &H30
		shCSIDLConnections = &H31
		shCSIDLCommonMusic = &H35
		shCSIDLCommonPictures = &H36
		shCSIDLCommonVideo = &H37
		shCSIDLResources = &H38
		shCSIDLResourcesLocalized = &H39
		shCSIDLCommonOEMLinks = &H3A
		shCSIDLCDBurnArea = &H3B
		shCSIDLComputersNearMe = &H3D
		shCSIDLFlagCreate = &H8000
		shCSIDLFlagDontVerify = &H4000
		shCSIDLFlagMask = &HFF00
	End Enum
	
	Public Enum NSHBrowseInfoFlags
		shBIFDefault = &H0
		shBIFReturnOnlyFSDirs = &H1
		shBIFDontGoBelowDomain = &H2
		shBIFStatusText = &H4
		shBIFReturnFSAncestores = &H8
		shBIFEditBox = &H10
		shBIFValidate = &H20
		shBIFNewDialogStyle = &H40
		shBIFUseNewUI = NSHBrowseInfoFlags.shBIFEditBox Or NSHBrowseInfoFlags.shBIFNewDialogStyle
		shBIFBrowseIncludeURLs = &H80
		shBIFUAHint = &H100
		shBIFNoNewFolderButton = &H200
		shBIFNoTranslateTargets = &H400
		shBIFBrowseForComputer = &H1000
		shBIFBrowseForPrinter = &H2000
		shBIFBrowseIncludeFiles = &H4000
		shBIFShareable = &H8000
	End Enum
	
	Private Enum NSHStrRetTypes
		shStrRetWSTR = &H0
		shStrRetOffset = &H1
		shStrRetCSTR = &H2
	End Enum
	
	Private Enum NSHGetDisplayNameFlags
		shGDNNormal = &H0
		shGDNInFolder = &H1
		shGDNForEditing = &H1000
		shGDNForAddressBar = &H4000
		shGDNForParsing = &H8000
	End Enum
	
	Private Enum NAutoCallConv
		atCCFastCall = 0
		atCCCDecl = 1
		atCCMSCPascal = 2
		atCCPascal = 2
		atCCMacPascal = 3
		atCCStdCall = 4
		atCCFPFastCall = 5
		atCCSysCall = 6
		atCCMPWCDecl = 7
		atCCMPWPascal = 8
	End Enum
	
	Private Structure TSHBrowseInfo
		Dim hwndOwner As Integer
		Dim PIDLRoot As Integer
		Dim DisplayName As Integer
		Dim title As Integer
		Dim Flags As Integer
		Dim Callback As Integer
		Dim lParam As Integer
		Dim ImageIndex As Integer
	End Structure
	
	Private Structure TSHFileInfo
		Dim hIcon As Integer
		Dim IconIndex As Integer
		Dim Attributes As NSHFileAttributes
		<VBFixedArray(259)> Dim DisplayName() As Byte
		'UPGRADE_NOTE: TypeName was upgraded to TypeName_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
		<VBFixedArray(79)> Dim TypeName_Renamed() As Byte
		
		'UPGRADE_TODO: "Initialize" must be called to initialize instances of this structure. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="B4BFF9E0-8631-45CF-910E-62AB3970F27B"'
		Public Sub Initialize()
			ReDim DisplayName(259)
		End Sub
	End Structure
	
	Private Structure TSHFileInfoW
		Dim hIcon As Integer
		Dim IconIndex As Integer
		Dim Attributes As NSHFileAttributes
		<VBFixedArray(519)> Dim DisplayName() As Byte
		'UPGRADE_NOTE: TypeName was upgraded to TypeName_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
		<VBFixedArray(159)> Dim TypeName_Renamed() As Byte
		
		'UPGRADE_TODO: "Initialize" must be called to initialize instances of this structure. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="B4BFF9E0-8631-45CF-910E-62AB3970F27B"'
		Public Sub Initialize()
			ReDim DisplayName(519)
		End Sub
	End Structure
	
	Private Structure TSHStrRet
		Dim FormatType As NSHStrRetTypes
		Dim DataLong As Integer
		<VBFixedArray(255)> Dim DataChar() As Byte
		
		'UPGRADE_TODO: "Initialize" must be called to initialize instances of this structure. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="B4BFF9E0-8631-45CF-910E-62AB3970F27B"'
		Public Sub Initialize()
			ReDim DataChar(255)
		End Sub
	End Structure
	
	Private Structure TSHStrRetChar
		Dim FormatType As NSHStrRetTypes
		<VBFixedArray(259)> Dim Data() As Byte
		
		'UPGRADE_TODO: "Initialize" must be called to initialize instances of this structure. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="B4BFF9E0-8631-45CF-910E-62AB3970F27B"'
		Public Sub Initialize()
			ReDim Data(259)
		End Sub
	End Structure
	
	Private Structure TWinOSVersionInfo
		Dim OSVersionInfoSize As Integer
		Dim MajorVersion As Integer
		Dim MinorVersion As Integer
		Dim BuildNumber As Integer
		Dim PlatformId As NWinOSPlatformTypes
		<VBFixedArray(127)> Dim CSDVersion() As Byte
		
		'UPGRADE_TODO: "Initialize" must be called to initialize instances of this structure. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="B4BFF9E0-8631-45CF-910E-62AB3970F27B"'
		Public Sub Initialize()
			ReDim CSDVersion(127)
		End Sub
	End Structure
	
	'UPGRADE_WARNING: Structure TWinOSVersionInfo may require marshalling attributes to be passed as an argument in this Declare statement. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
	Private Declare Function GetVersionExA Lib "kernel32.dll" (ByRef RefVersionInformation As TWinOSVersionInfo) As Integer
	
	'UPGRADE_WARNING: Structure TSHBrowseInfo may require marshalling attributes to be passed as an argument in this Declare statement. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
	Private Declare Function SHBrowseForFolderA Lib "shell32.dll" (ByRef RefBrowseInfo As TSHBrowseInfo) As Integer
	
	'UPGRADE_WARNING: Structure TSHBrowseInfo may require marshalling attributes to be passed as an argument in this Declare statement. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
	Private Declare Function SHBrowseForFolderW Lib "shell32.dll" (ByRef RefBrowseInfo As TSHBrowseInfo) As Integer
	
	'UPGRADE_WARNING: Structure TSHFileInfo may require marshalling attributes to be passed as an argument in this Declare statement. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
	Private Declare Function SHGetFileInfoA Lib "shell32.dll" (ByVal PIDL As Integer, ByVal FileAttributes As Integer, ByRef RefInfo As TSHFileInfo, Optional ByVal InfoSize As Integer = 352, Optional ByVal Flags As NSHFileInfoFlags = NSHFileInfoFlags.shGFIPIDL Or NSHFileInfoFlags.shGFIDisplayName) As Integer
	
	'UPGRADE_WARNING: Structure TSHFileInfoW may require marshalling attributes to be passed as an argument in this Declare statement. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
	Private Declare Function SHGetFileInfoW Lib "shell32.dll" (ByVal PIDL As Integer, ByVal FileAttributes As Integer, ByRef RefInfo As TSHFileInfoW, Optional ByVal InfoSize As Integer = 692, Optional ByVal Flags As NSHFileInfoFlags = NSHFileInfoFlags.shGFIPIDL Or NSHFileInfoFlags.shGFIDisplayName) As Integer
	
	Private Declare Function SHGetPathFromIDListA Lib "shell32.dll" (ByVal PIDL As Integer, ByVal BufPath As String) As Integer
	
	Private Declare Function SHGetPathFromIDListW Lib "shell32.dll" (ByVal PIDL As Integer, ByRef BufPath As Byte) As Integer
	
	'UPGRADE_WARNING: Structure NSHSpecialFolderIDs may require marshalling attributes to be passed as an argument in this Declare statement. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
	'UPGRADE_WARNING: Structure OLE_HANDLE may require marshalling attributes to be passed as an argument in this Declare statement. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
	Private Declare Function SHGetSpecialFolderLocation Lib "shell32.dll" (ByVal hWnd As Integer, ByVal CSIDL As NSHSpecialFolderIDs, ByRef RetPIDL As Integer) As Integer
	
	'UPGRADE_WARNING: Structure IUnknown may require marshalling attributes to be passed as an argument in this Declare statement. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
	Private Declare Function SHGetDesktopFolder Lib "shell32.dll" (ByRef RetFolder As stdole.IUnknown) As Integer
	
	Private Declare Sub SHFlushSFCache Lib "shell32.dll" ()
	
	Private Declare Function SHGetIDListFromPath Lib "shell32.dll"  Alias "#28"(ByRef Path As Byte, ByRef RetPIDL As Integer, ByRef RetAttr As Integer) As Integer
	
	Private Declare Function CoTaskMemFree Lib "ole32.dll" (ByVal PIDL As Integer) As Integer
	
	'UPGRADE_ISSUE: Declaring a parameter 'As Any' is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"'
	'UPGRADE_WARNING: Structure OLE_HANDLE may require marshalling attributes to be passed as an argument in this Declare statement. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
	'++修正開始　2021年05月07:MK（ツール）- VB_003 VB→VB.NET変換
	'Private Declare Function SendMessageA Lib "user32.dll" (ByVal hWnd As Integer, ByVal Message As Integer, ByVal wParam As Integer, ByRef lParam As Any) As Integer
	Private Declare Function SendMessageA Lib "user32.dll" (ByVal hWnd As Integer, ByVal Message As Integer, ByVal wParam As Integer, ByRef lParam As Object) As Integer
	'--修正終了　2021年05月07:MK（ツール）- VB_003 VB→VB.NET変換
	
	'UPGRADE_ISSUE: Declaring a parameter 'As Any' is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"'
	'UPGRADE_WARNING: Structure OLE_HANDLE may require marshalling attributes to be passed as an argument in this Declare statement. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
	'++修正開始　2021年05月07:MK（ツール）- VB_003 VB→VB.NET変換
	'Private Declare Function SendMessageW Lib "user32.dll" (ByVal hWnd As Integer, ByVal Message As Integer, ByVal wParam As Integer, ByRef lParam As Any) As Integer
	Private Declare Function SendMessageW Lib "user32.dll" (ByVal hWnd As Integer, ByVal Message As Integer, ByVal wParam As Integer, ByRef lParam As Object) As Integer
	'--修正終了　2021年05月07:MK（ツール）- VB_003 VB→VB.NET変換
	
	'UPGRADE_WARNING: Structure OLE_HANDLE may require marshalling attributes to be passed as an argument in this Declare statement. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
	Private Declare Function SetWindowTextA Lib "user32.dll" (ByVal hWnd As Integer, ByVal Text As String) As Integer
	
	'UPGRADE_WARNING: Structure OLE_HANDLE may require marshalling attributes to be passed as an argument in this Declare statement. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
	Private Declare Function SetWindowTextW Lib "user32.dll" (ByVal hWnd As Integer, ByRef Text As Byte) As Integer
	
	'UPGRADE_WARNING: Structure NAutoCallConv may require marshalling attributes to be passed as an argument in this Declare statement. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
	'UPGRADE_WARNING: Structure IUnknown may require marshalling attributes to be passed as an argument in this Declare statement. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
	Private Declare Function DispCallFunc Lib "oleaut32.dll" (ByVal SourceObject As stdole.IUnknown, ByVal Offset As Integer, ByVal CallConv As NAutoCallConv, ByVal ReturnType As Short, ByVal ArgsCount As Integer, ByRef ArgsTypesArray As Short, ByRef ArgsPointerArray As Integer, ByRef RetResult As Object) As Integer
	
	Private Declare Function StrLenA Lib "kernel32.dll"  Alias "lstrlenA"(ByVal Pointer As Integer) As Integer
	
	Private Declare Function StrLenW Lib "kernel32.dll"  Alias "lstrlenW"(ByVal Pointer As Integer) As Integer
	
	'UPGRADE_ISSUE: Declaring a parameter 'As Any' is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"'
	'UPGRADE_ISSUE: Declaring a parameter 'As Any' is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"'
	'++修正開始　2021年05月07:MK（ツール）- VB_003 VB→VB.NET変換
	'Private Declare Sub CopyMemory Lib "kernel32.dll"  Alias "RtlMoveMemory"(ByRef RetDest As Any, ByRef Source As Any, Optional ByVal Length As Integer = 4)
	Private Declare Sub CopyMemory Lib "kernel32.dll"  Alias "RtlMoveMemory"(ByRef RetDest As Object, ByRef Source As Object, Optional ByVal Length As Integer = 4)
	'--修正終了　2021年05月07:MK（ツール）- VB_003 VB→VB.NET変換
	
	'UPGRADE_WARNING: Arrays in structure mudtOSVersionInfo may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
	Private mudtOSVersionInfo As TWinOSVersionInfo
	
	Private Function mfncSetWindowText(ByVal hWnd As Integer, ByVal pstrText As String) As Integer
		
		Dim abBuffer() As Byte
		If mfncOSIsNT() = True Then
			
			
			'UPGRADE_TODO: Code was upgraded to use System.Text.UnicodeEncoding.Unicode.GetBytes() which may not have the same behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="93DD716C-10E3-41BE-A4A8-3BA40157905B"'
			abBuffer = System.Text.UnicodeEncoding.Unicode.GetBytes(pstrText & vbNullChar)
			
			mfncSetWindowText = SetWindowTextW(hWnd, abBuffer(0))
			
		Else
			
			mfncSetWindowText = SetWindowTextA(hWnd, pstrText & vbNullChar)
			
		End If
		
	End Function
	
	Private Function SendMessageNumber(ByVal hWnd As Integer, ByVal Message As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Integer
		
		If mfncOSIsNT() = True Then
			
			SendMessageNumber = SendMessageW(hWnd, Message, wParam, lParam)
			
		Else
			
			SendMessageNumber = SendMessageA(hWnd, Message, wParam, lParam)
			
		End If
		
	End Function
	
	Private Function mfncSendMessageString(ByVal hWnd As Integer, ByVal Message As Integer, ByVal wParam As Integer, ByRef lParam As String) As Integer
		
		Dim abBuffer() As Byte
		Dim sBuffer As String
		
		If mfncOSIsNT() = True Then
			
			'UPGRADE_TODO: Code was upgraded to use System.Text.UnicodeEncoding.Unicode.GetBytes() which may not have the same behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="93DD716C-10E3-41BE-A4A8-3BA40157905B"'
			abBuffer = System.Text.UnicodeEncoding.Unicode.GetBytes(lParam & vbNullChar)
			
			mfncSendMessageString = SendMessageW(hWnd, Message, wParam, abBuffer(0))
			
			'UPGRADE_TODO: Code was upgraded to use System.Text.UnicodeEncoding.Unicode.GetString() which may not have the same behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="93DD716C-10E3-41BE-A4A8-3BA40157905B"'
			sBuffer = System.Text.UnicodeEncoding.Unicode.GetString(abBuffer) & vbNullChar
			
			lParam = Left(sBuffer, InStr(1, sBuffer, vbNullChar))
			
		Else
			
			'UPGRADE_ISSUE: Constant vbFromUnicode was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"'
			'UPGRADE_TODO: Code was upgraded to use System.Text.UnicodeEncoding.Unicode.GetBytes() which may not have the same behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="93DD716C-10E3-41BE-A4A8-3BA40157905B"'
			abBuffer = System.Text.UnicodeEncoding.Unicode.GetBytes(StrConv(lParam & vbNullChar, vbFromUnicode))
			
			mfncSendMessageString = SendMessageA(hWnd, Message, wParam, abBuffer(0))
			
			'UPGRADE_ISSUE: Constant vbUnicode was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"'
			sBuffer = StrConv(System.Text.UnicodeEncoding.Unicode.GetString(abBuffer), vbUnicode) & vbNullChar
			
			lParam = Left(sBuffer, InStr(1, sBuffer, vbNullChar))
			
		End If
		
	End Function
	
	Private Function BrowseFolderCallback(ByVal hWnd As Integer, ByVal Message As Integer, ByVal wParam As Integer, ByVal cDialog As clsFolderDialog) As Integer
		
		Dim strBuff As String
		
		Select Case Message
			Case NSHBrowseFolderOutMessages.shBFFMInitialized
				
				strBuff = cDialog.DialogCaption
				
				If (0 < Len(strBuff)) Then
					
					Call mfncSetWindowText(hWnd, strBuff)
					
				End If
				
				If mfncOSIsNT() = True Then
					
					Call SendMessageNumber(hWnd, NSHBrowseFolderInMessages.shBFFMSetSelectionW, 0, cDialog.FolderIDList)
					
				Else
					
					Call SendMessageNumber(hWnd, NSHBrowseFolderInMessages.shBFFMSetSelection, 0, cDialog.FolderIDList)
					
				End If
				
			Case NSHBrowseFolderOutMessages.shBFFMSelChanged
				
				strBuff = PIDLToPath(wParam)
				
				If mfncOSIsNT() = True Then
					
					Call mfncSendMessageString(hWnd, NSHBrowseFolderInMessages.shBFFMSetStatusTextW, 0, strBuff)
					
				Else
					
					Call mfncSendMessageString(hWnd, NSHBrowseFolderInMessages.shBFFMSetStatusText, 0, strBuff)
					
				End If
				
				Select Case True
					Case cDialog.DialogStyle And NSHBrowseInfoFlags.shBIFReturnOnlyFSDirs
						
						If PIDLsAttributes(wParam) And NSHFileAttributes.shFGAOFileSystem Then
							
							Call SendMessageNumber(hWnd, NSHBrowseFolderInMessages.shBFFMEnableOK, 0, 1)
							
						Else
							
							Call SendMessageNumber(hWnd, NSHBrowseFolderInMessages.shBFFMEnableOK, 0, 0)
							
						End If
						
				End Select
				
		End Select
		
	End Function
	
	Private Function mfncPtrPtr(ByVal plngValue As Integer) As Integer
		
		mfncPtrPtr = plngValue
		
	End Function
	
	Public Function PIDLToPath(ByVal plngPIDL As Integer) As String
		
		Dim lngLength As Integer
		Dim strBuff As String
		Dim abytBuff() As Byte
		
		If (plngPIDL <> 0) Then
			
			If mfncOSIsNT() = True Then
				
				ReDim abytBuff(2047)
				
				Call SHGetPathFromIDListW(plngPIDL, abytBuff(0))
				
				'UPGRADE_TODO: Code was upgraded to use System.Text.UnicodeEncoding.Unicode.GetString() which may not have the same behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="93DD716C-10E3-41BE-A4A8-3BA40157905B"'
				strBuff = System.Text.UnicodeEncoding.Unicode.GetString(abytBuff)
				
			Else
				
				strBuff = New String(vbNullChar, 1024)
				
				Call SHGetPathFromIDListA(plngPIDL, strBuff)
				
			End If
			
			strBuff = strBuff & vbNullChar
			
			lngLength = InStr(1, strBuff, vbNullChar)
			
			PIDLToPath = Left(strBuff, lngLength - 1)
			
		End If
		
	End Function
	
	Public Function PIDLFromPath(ByVal pstrPath As String) As Integer
		
		Dim abytBuff() As Byte
		Dim lngAttr As Integer
		Dim lngPIDL As Integer
		
		If (mfncOSIsNT() = True) Then
			
			'UPGRADE_TODO: Code was upgraded to use System.Text.UnicodeEncoding.Unicode.GetBytes() which may not have the same behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="93DD716C-10E3-41BE-A4A8-3BA40157905B"'
			abytBuff = System.Text.UnicodeEncoding.Unicode.GetBytes(pstrPath & vbNullChar)
			
		Else
			
			'UPGRADE_ISSUE: Constant vbFromUnicode was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"'
			'UPGRADE_TODO: Code was upgraded to use System.Text.UnicodeEncoding.Unicode.GetBytes() which may not have the same behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="93DD716C-10E3-41BE-A4A8-3BA40157905B"'
			abytBuff = System.Text.UnicodeEncoding.Unicode.GetBytes(StrConv(pstrPath & vbNullChar, vbFromUnicode))
			
		End If
		
		Call SHGetIDListFromPath(abytBuff(0), lngPIDL, lngAttr)
		
		PIDLFromPath = lngPIDL
		
	End Function
	
	Public Function PIDLFromID(ByVal ID As NSHSpecialFolderIDs) As Integer
		
		Dim lngPIDL As Integer
		
		Call SHGetSpecialFolderLocation(0, ID, lngPIDL)
		
		PIDLFromID = lngPIDL
		
	End Function
	
	Public Sub PIDLFree(ByRef plngPIDL As Integer)
		
		If (plngPIDL <> 0) Then
			
			Call CoTaskMemFree(plngPIDL)
			
			plngPIDL = 0
			
		End If
		
	End Sub
	
	Public Function PIDLBrowse(ByVal cDialog As clsFolderDialog, Optional ByVal PIDLRoot As Integer = NSHSpecialFolderIDs.shCSIDLDesktop, Optional ByVal hwndOwner As Integer = 0, Optional ByVal pstrTitle As String = vbNullString, Optional ByVal Flags As NSHBrowseInfoFlags = NSHBrowseInfoFlags.shBIFDefault) As Integer
		
		Dim uInfo As TSHBrowseInfo
		Dim strDisplayName As String
		Dim lngLength As Integer
		Dim abytDisplayName() As Byte
		Dim abytbTitle() As Byte
		
		With uInfo
			
			.hwndOwner = hwndOwner
			
			'UPGRADE_ISSUE: ObjPtr function is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"'
			.lParam = ObjPtr(cDialog)
			
			'UPGRADE_WARNING: Add a delegate for AddressOf BrowseFolderCallback Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="E9E157F7-EF0C-4016-87B7-7D7FBBC6EE08"'
			.Callback = mfncPtrPtr(AddressOf BrowseFolderCallback)
			
			If (0 < Len(pstrTitle)) Then
				
				If mfncOSIsNT() = True Then
					
					'UPGRADE_TODO: Code was upgraded to use System.Text.UnicodeEncoding.Unicode.GetBytes() which may not have the same behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="93DD716C-10E3-41BE-A4A8-3BA40157905B"'
					abytbTitle = System.Text.UnicodeEncoding.Unicode.GetBytes(pstrTitle & vbNullChar)
					
				Else
					
					'UPGRADE_ISSUE: Constant vbFromUnicode was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"'
					'UPGRADE_TODO: Code was upgraded to use System.Text.UnicodeEncoding.Unicode.GetBytes() which may not have the same behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="93DD716C-10E3-41BE-A4A8-3BA40157905B"'
					abytbTitle = System.Text.UnicodeEncoding.Unicode.GetBytes(StrConv(pstrTitle & vbNullChar, vbFromUnicode))
					
				End If
				
				'UPGRADE_ISSUE: VarPtr function is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"'
				.title = VarPtr(abytbTitle(0))
				
			End If
			
			.PIDLRoot = PIDLRoot
			
			.Flags = Flags
			
			ReDim abytDisplayName(2047)
			
			'UPGRADE_ISSUE: VarPtr function is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"'
			.DisplayName = VarPtr(abytDisplayName(0))
			
		End With
		
		If mfncOSIsNT() = True Then
			
			PIDLBrowse = SHBrowseForFolderW(uInfo)
			
			'UPGRADE_TODO: Code was upgraded to use System.Text.UnicodeEncoding.Unicode.GetString() which may not have the same behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="93DD716C-10E3-41BE-A4A8-3BA40157905B"'
			strDisplayName = System.Text.UnicodeEncoding.Unicode.GetString(abytDisplayName) & vbNullChar
			
		Else
			
			PIDLBrowse = SHBrowseForFolderA(uInfo)
			
			'UPGRADE_ISSUE: Constant vbUnicode was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"'
			strDisplayName = StrConv(System.Text.UnicodeEncoding.Unicode.GetString(abytDisplayName), vbUnicode) & vbNullChar
			
		End If
		
		lngLength = InStr(1, strDisplayName, vbNullChar)
		
		If (1 < lngLength) Then
			
			cDialog.FolderDisplayName = Left(strDisplayName, lngLength - 1)
			
		End If
		
	End Function
	
	Public Function PIDLToDisplayName(ByVal plngPIDL As Integer) As String
		
		'UPGRADE_WARNING: Arrays in structure uInfoA may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
		Dim uInfoA As TSHFileInfo
		'UPGRADE_WARNING: Arrays in structure uInfoW may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
		Dim uInfoW As TSHFileInfoW
		Dim strBuff As String
		
		If mfncOSIsNT() = True Then
			
			If SHGetFileInfoW(plngPIDL, 0, uInfoW) <> 0 Then
				
				'UPGRADE_TODO: Code was upgraded to use System.Text.UnicodeEncoding.Unicode.GetString() which may not have the same behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="93DD716C-10E3-41BE-A4A8-3BA40157905B"'
				strBuff = System.Text.UnicodeEncoding.Unicode.GetString(uInfoW.DisplayName) & vbNullChar
				
				PIDLToDisplayName = Left(strBuff, InStr(1, strBuff, vbNullChar) - 1)
				
			End If
			
		Else
			
			If SHGetFileInfoA(plngPIDL, 0, uInfoA) <> 0 Then
				
				'UPGRADE_ISSUE: Constant vbUnicode was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"'
				strBuff = StrConv(System.Text.UnicodeEncoding.Unicode.GetString(uInfoA.DisplayName), vbUnicode) & vbNullChar
				
				PIDLToDisplayName = Left(strBuff, InStr(1, strBuff, vbNullChar) - 1)
				
			End If
			
		End If
		
	End Function
	
	Public Function PIDLsAttributes(ByVal plngPIDL As Integer) As NSHFileAttributes
		
		'UPGRADE_WARNING: Arrays in structure uInfo may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
		Dim uInfo As TSHFileInfo
		
		PIDLsAttributes = 0
		
		If (0 <> SHGetFileInfoA(plngPIDL, 0, uInfo,  , NSHFileInfoFlags.shGFIPIDL Or NSHFileInfoFlags.shGFIAttributes)) Then
			
			PIDLsAttributes = uInfo.Attributes
			
		End If
		
	End Function
	
	Public Function PIDLToUniqueName(ByVal plngPIDL As Integer) As String
		
		Dim oFolder As stdole.IUnknown
		'UPGRADE_WARNING: Arrays in structure uRet may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
		Dim uRet As TSHStrRet
		'UPGRADE_WARNING: Arrays in structure uRetChars may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
		Dim uRetChars As TSHStrRetChar
		Dim aiPointers() As Integer
		Dim aiTypes() As Short
		Dim avParams() As Object
		Dim vResult As Object
		Dim hResult As Integer
		Dim abBuffer() As Byte
		Dim iLength As Integer
		
		Call SHGetDesktopFolder(oFolder)
		
		If oFolder Is Nothing Then
			
			Exit Function
			
		End If
		
		ReDim aiPointers(2)
		ReDim aiTypes(2)
		'UPGRADE_ISSUE: As Variant was removed from ReDim avParams(0 To 2) statement. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="19AFCB41-AA8E-4E6B-A441-A3E802E5FD64"'
		ReDim avParams(2)
		
		aiTypes(0) = VariantType.Integer
		aiTypes(1) = VariantType.Integer
		aiTypes(2) = VariantType.Integer
		
		'UPGRADE_WARNING: Couldn't resolve default property of object avParams(0). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		avParams(0) = plngPIDL
		'UPGRADE_WARNING: Couldn't resolve default property of object avParams(1). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		avParams(1) = NSHGetDisplayNameFlags.shGDNForParsing
		'UPGRADE_ISSUE: VarPtr function is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"'
		'UPGRADE_WARNING: Couldn't resolve default property of object avParams(2). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		avParams(2) = VarPtr(uRet)
		
		'UPGRADE_ISSUE: VarPtr function is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"'
		aiPointers(0) = VarPtr(avParams(0))
		'UPGRADE_ISSUE: VarPtr function is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"'
		aiPointers(1) = VarPtr(avParams(1))
		'UPGRADE_ISSUE: VarPtr function is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"'
		aiPointers(2) = VarPtr(avParams(2))
		
		hResult = DispCallFunc(oFolder, 44, NAutoCallConv.atCCStdCall, VariantType.Integer, 3, aiTypes(0), aiPointers(0), vResult)
		
		If 0 <> hResult Then
			
			Exit Function
			
		End If
		
		'UPGRADE_WARNING: Couldn't resolve default property of object vResult. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		If 0 <> vResult Then
			
			Exit Function
			
		End If
		
		Select Case uRet.FormatType
			Case NSHStrRetTypes.shStrRetWSTR
				
				iLength = StrLenW(uRet.DataLong)
				
				If 0 < iLength Then
					
					ReDim abBuffer((iLength * 2) - 1)
					
					Call CopyMemory(abBuffer(0), uRet.DataLong, iLength * 2)
					
					'UPGRADE_TODO: Code was upgraded to use System.Text.UnicodeEncoding.Unicode.GetString() which may not have the same behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="93DD716C-10E3-41BE-A4A8-3BA40157905B"'
					PIDLToUniqueName = System.Text.UnicodeEncoding.Unicode.GetString(abBuffer)
					
					Call CoTaskMemFree(uRet.DataLong)
					
					Erase abBuffer
					
				End If
				
			Case NSHStrRetTypes.shStrRetOffset
				
				iLength = StrLenW(uRet.DataLong + plngPIDL)
				
				If 0 < iLength Then
					
					ReDim abBuffer((iLength * 2) - 1)
					
					Call CopyMemory(abBuffer(0), uRet.DataLong + plngPIDL, iLength * 2)
					
					'UPGRADE_TODO: Code was upgraded to use System.Text.UnicodeEncoding.Unicode.GetString() which may not have the same behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="93DD716C-10E3-41BE-A4A8-3BA40157905B"'
					PIDLToUniqueName = System.Text.UnicodeEncoding.Unicode.GetString(abBuffer)
					
					Erase abBuffer
					
				End If
				
			Case NSHStrRetTypes.shStrRetCSTR
				
				'UPGRADE_ISSUE: LSet cannot assign one type to another. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"'
				uRetChars = LSet(uRet)
				
				'UPGRADE_ISSUE: Constant vbUnicode was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"'
				PIDLToUniqueName = StrConv(System.Text.UnicodeEncoding.Unicode.GetString(uRetChars.Data), vbUnicode) & vbNullChar
				
				iLength = InStr(1, PIDLToUniqueName, vbNullChar)
				
				PIDLToUniqueName = Left(PIDLToUniqueName, iLength - 1)
				
		End Select
		
		Erase aiPointers
		Erase aiTypes
		Erase avParams
		
		'UPGRADE_NOTE: Object oFolder may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		oFolder = Nothing
		
	End Function
	
	Private Function mfncOSIsNT() As Boolean
		
		If (mudtOSVersionInfo.OSVersionInfoSize = 0) Then
			
			mudtOSVersionInfo.OSVersionInfoSize = Len(mudtOSVersionInfo)
			
			If (GetVersionExA(mudtOSVersionInfo) = 0) Then
				
				mudtOSVersionInfo.OSVersionInfoSize = 0
				
			End If
			
		End If
		
		mfncOSIsNT = CBool(NWinOSPlatformTypes.winVerPlatformWin32NT = mudtOSVersionInfo.PlatformId)
		
	End Function
End Module
