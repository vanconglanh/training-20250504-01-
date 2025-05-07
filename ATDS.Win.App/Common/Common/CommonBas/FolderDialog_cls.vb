Option Strict Off
Option Explicit On
Friend Class clsFolderDialog
	
	Private mlngPIDLFolder As Integer
	Private mlngPIDLRoot As Integer
	Private miRootID As basFolderDialog.NSHSpecialFolderIDs
	Private mstrTitle As String
	Private mstrDisplay As String
	Private mstrCaption As String
	Private miStyle As basFolderDialog.NSHBrowseInfoFlags
	Private mhWndOwner As Integer
	
	
	Public Property FolderPath() As String
		Get
			
			FolderPath = PIDLToPath(mlngPIDLFolder)
			
		End Get
		Set(ByVal Value As String)
			
			Dim lngPIDL As Integer
			
			lngPIDL = PIDLFromPath(Value)
			
			If (lngPIDL <> 0) Then
				
				Call PIDLFree(mlngPIDLFolder)
				
				mlngPIDLFolder = lngPIDL
				
			End If
			
		End Set
	End Property
	
	Public ReadOnly Property FolderUniqueName() As String
		Get
			
			FolderUniqueName = PIDLToUniqueName(mlngPIDLFolder)
			
		End Get
	End Property
	
	Friend ReadOnly Property FolderIDList() As Integer
		Get
			
			FolderIDList = mlngPIDLFolder
			
		End Get
	End Property
	
	
	Public Property RootFolderPath() As String
		Get
			
			RootFolderPath = PIDLToPath(mlngPIDLRoot)
			
		End Get
		Set(ByVal Value As String)
			
			Dim lngPIDL As Integer
			
			lngPIDL = PIDLFromPath(Value)
			
			If (lngPIDL <> 0) Then
				
				Call PIDLFree(mlngPIDLRoot)
				
				mlngPIDLRoot = lngPIDL
				
				miRootID = basFolderDialog.NSHSpecialFolderIDs.shCSIDLInvalid
				
			End If
			
		End Set
	End Property
	
	
	Public Property RootFolderID() As basFolderDialog.NSHSpecialFolderIDs
		Get
			
			RootFolderID = miRootID
			
		End Get
		Set(ByVal Value As basFolderDialog.NSHSpecialFolderIDs)
			
			Dim lngPIDL As Integer
			
			If (miRootID <> Value) Then
				
				lngPIDL = PIDLFromID(Value)
				
				If (lngPIDL <> 0) Then
					
					Call PIDLFree(mlngPIDLRoot)
					
					mlngPIDLRoot = lngPIDL
					
					miRootID = Value
					
				End If
				
			End If
			
		End Set
	End Property
	
	
	Public Property FolderDisplayName() As String
		Get
			
			FolderDisplayName = mstrDisplay
			
		End Get
		Set(ByVal Value As String)
			
			mstrDisplay = Value
			
		End Set
	End Property
	
	
	Public Property DialogOwnerHWnd() As Integer
		Get
			
			DialogOwnerHWnd = mhWndOwner
			
		End Get
		Set(ByVal Value As Integer)
			
			mhWndOwner = Value
			
		End Set
	End Property
	
	
	Public Property DialogTitle() As String
		Get
			
			DialogTitle = mstrTitle
			
		End Get
		Set(ByVal Value As String)
			
			mstrTitle = Value
			
		End Set
	End Property
	
	
	Public Property DialogCaption() As String
		Get
			
			DialogCaption = mstrCaption
			
		End Get
		Set(ByVal Value As String)
			
			mstrCaption = Value
			
		End Set
	End Property
	
	
	Public Property DialogStyle() As basFolderDialog.NSHBrowseInfoFlags
		Get
			
			DialogStyle = miStyle
			
		End Get
		Set(ByVal Value As basFolderDialog.NSHBrowseInfoFlags)
			
			miStyle = Value
			
		End Set
	End Property
	
	Public Function FolderIDSet(ByVal plngID As Integer) As Boolean
		
		Dim lngPIDL As Integer
		
		lngPIDL = PIDLFromID(plngID)
		
		If (lngPIDL <> 0) Then
			
			Call PIDLFree(mlngPIDLFolder)
			
			mlngPIDLFolder = lngPIDL
			
			FolderIDSet = True
			
		End If
		
	End Function
	
	Public Function DialogShow() As MsgBoxResult
		
		Dim lngPIDL As Integer
		
		lngPIDL = PIDLBrowse(Me, mlngPIDLRoot, mhWndOwner, mstrTitle, miStyle)
		
		If (lngPIDL <> 0) Then
			
			Call PIDLFree(mlngPIDLFolder)
			
			mlngPIDLFolder = lngPIDL
			
			DialogShow = MsgBoxResult.OK
			
		Else
			
			DialogShow = MsgBoxResult.Cancel
			
		End If
		
	End Function
	
	'UPGRADE_NOTE: Class_Initialize was upgraded to Class_Initialize_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
	Private Sub Class_Initialize_Renamed()
		
		mlngPIDLFolder = PIDLFromID(basFolderDialog.NSHSpecialFolderIDs.shCSIDLDesktop)
		
		mlngPIDLRoot = PIDLFromID(basFolderDialog.NSHSpecialFolderIDs.shCSIDLDesktop)
		
	End Sub
	Public Sub New()
		MyBase.New()
		Class_Initialize_Renamed()
	End Sub
	
	'UPGRADE_NOTE: Class_Terminate was upgraded to Class_Terminate_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
	Private Sub Class_Terminate_Renamed()
		
		Call PIDLFree(mlngPIDLFolder)
		
		Call PIDLFree(mlngPIDLRoot)
		
	End Sub
	Protected Overrides Sub Finalize()
		Class_Terminate_Renamed()
		MyBase.Finalize()
	End Sub
End Class