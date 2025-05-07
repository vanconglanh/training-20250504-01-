'Copy constant from old system
Public Module mdlOraConstants

    'Editmode property values
    ' These are intended to match similar constants in the
    ' Visual Basic file CONSTANT.TXT
    Public Const ORADATA_EDITNONE As Short = 0
    Public Const ORADATA_EDITMODE As Short = 1
    Public Const ORADATA_EDITADD As Short = 2

    'Parameter Types
    Public Const ORAPARM_INPUT As Short = 1
    Public Const ORAPARM_OUTPUT As Short = 2
    Public Const ORAPARM_BOTH As Short = 3

    'Parameter Status
    Public Const ORAPSTAT_INPUT As Integer = &H1
    Public Const ORAPSTAT_OUTPUT As Integer = &H2
    Public Const ORAPSTAT_AUTOENABLE As Integer = &H4
    Public Const ORAPSTAT_ENABLE As Integer = &H8

    'CreateDynaset Method Options
    Public Const ORADYN_DEFAULT As Integer = &H0
    Public Const ORADYN_NO_AUTOBIND As Integer = &H1
    Public Const ORADYN_NO_BLANKSTRIP As Integer = &H2
    Public Const ORADYN_READONLY As Integer = &H4
    Public Const ORADYN_NOCACHE As Integer = &H8
    Public Const ORADYN_ORAMODE As Integer = &H10
    Public Const ORADYN_DBDEFAULT As Integer = &H20
    Public Const ORADYN_NO_MOVEFIRST As Integer = &H40
    Public Const ORADYN_DIRTY_WRITE As Integer = &H80

    'CreateSql Method options
    Public Const ORASQL_DEFAULT As Integer = &H0
    Public Const ORASQL_NO_AUTOBIND As Integer = &H1
    Public Const ORASQL_FAILEXEC As Integer = &H2

    '    Public Const ORADYN_DEFAULT = &H0&
    '    Public Const ORADYN_NO_AUTOBIND = &H1&
    '    Public Const ORADYN_NO_BLANKSTRIP = &H2&

    'OpenDatabase Method Options
    Public Const ORADB_DEFAULT As Integer = &H0
    Public Const ORADB_ORAMODE As Integer = &H1
    Public Const ORADB_NOWAIT As Integer = &H2
    Public Const ORADB_DBDEFAULT As Integer = &H4
    Public Const ORADB_DEFERRED As Integer = &H8

    'Parameter Types (ServerType)
    Public Const ORATYPE_VARCHAR2 As Short = 1
    Public Const ORATYPE_NUMBER As Short = 2
    Public Const ORATYPE_SINT As Short = 3
    Public Const ORATYPE_FLOAT As Short = 4
    Public Const ORATYPE_STRING As Short = 5
    Public Const ORATYPE_VARCHAR As Short = 9
    Public Const ORATYPE_DATE As Short = 12
    Public Const ORATYPE_UINT As Short = 68
    Public Const ORATYPE_CHAR As Short = 96
    Public Const ORATYPE_CHARZ As Short = 97
    Public Const ORATYPE_CURSOR As Short = 102
    Public Const ORATYPE_BINARY As Short = 202
    Public Const ORATYPE_LONG_RAW As Short = 24 'https://docs.oracle.com/cd/E11882_01/appdev.112/e10646/oci03typ.htm#LNOCI16266

    'OIP errors returned as part of the OLE Automation error.
    Public Const OERROR_ADVISEULINK As Short = 4096 ' Invalid advisory connection
    Public Const OERROR_POSITION As Short = 4098 ' Invalid database position
    Public Const OERROR_NOFIELDNAME As Short = 4099 ' Field 'field-name' not found
    Public Const OERROR_TRANSIP As Short = 4101 ' Transaction already in process
    Public Const OERROR_TRANSNIPC As Short = 4104 ' Commit detected with no active transaction
    Public Const OERROR_TRANSNIPR As Short = 4105 ' Rollback detected with no active transaction
    Public Const OERROR_NODSET As Short = 4106 ' No such set attached to connection
    Public Const OERROR_INVROWNUM As Short = 4108 ' Invalid row reference
    Public Const OERROR_TEMPFILE As Short = 4109 ' Error creating temporary file
    Public Const OERROR_DUPSESSION As Short = 4110 ' Duplicate session name
    Public Const OERROR_NOSESSION As Short = 4111 ' Session not found during detach
    Public Const OERROR_NOOBJECTN As Short = 4112 ' No such object named 'object-name'
    Public Const OERROR_DUPCONN As Short = 4113 ' Duplicate connection name
    Public Const OERROR_NOCONN As Short = 4114 ' No such connection during detach
    Public Const OERROR_BFINDEX As Short = 4115 ' Invalid field index
    Public Const OERROR_CURNREADY As Short = 4116 ' Cursor not ready for I-O
    Public Const OERROR_NOUPDATES As Short = 4117 ' Not an updatable set
    Public Const OERROR_NOTEDITING As Short = 4118 ' Attempt to update without edit or add operation
    Public Const OERROR_DATACHANGE As Short = 4119 ' Data has been modified
    Public Const OERROR_NOBUFMEM As Short = 4120 ' No memory for data transfer buffers
    Public Const OERROR_INVBKMRK As Short = 4121 ' Invalid bookmark
    Public Const OERROR_BNDVNOEN As Short = 4122 ' Bind variable not fully enabled
    Public Const OERROR_DUPPARAM As Short = 4123 ' Duplicate parameter name
    Public Const OERROR_INVARGVAL As Short = 4124 ' Invalid argument value
    Public Const OERROR_INVFLDTYPE As Short = 4125 ' Invalid field type
    Public Const OERROR_TRANSFORUP As Short = 4127 ' For Update detected with no active transaction
    Public Const OERROR_NOTUPFORUP As Short = 4128 ' For Update detected but not updatable set

    Public Const OERROR_TRANSLOCK As Short = 4129 ' Commit/Rollback with SELECT FOR UPDATE in progress
    Public Const OERROR_CACHEPARM As Short = 4130 ' Invalid cache parameter
    Public Const OERROR_FLDRQROWID As Short = 4131 ' Field processing requires ROWID

    'Booleans-These are defined as reserved
    ' words in Visual Basic
    'Public Const True = -1
    'Public Const False = 0

    'Constants for Update Source
    Public Const OFIELD_THISFIELD As Short = 0
    Public Const OFIELD_SYSDATE As Short = 1
    Public Const OFIELD_TIMESTAMP As Short = 2
    Public Const OFIELD_DATESTAMP As Short = 3
    Public Const OFIELD_FUNCTION As Short = 4
    Public Const OFIELD_OTHERFIELD As Short = 5
    Public Const OFIELD_STRLITERAL As Short = 6

    Public Const OFIELD_FOR_NONE As Short = 0
    Public Const OFIELD_FOR_INSERT As Short = 10
    Public Const OFIELD_FOR_UPDATE As Short = 100
    Public Const OFIELD_FOR_ALL As Short = 110

    'Constants for OraDynaset Add/Edit 
    'Internal usage in library MKOra.Core only
    Friend Const DYNASET_UNCHANGED As Short = 0
    Friend Const DYNASET_ADD As Short = 1
    Friend Const DYNASET_UPDATE As Short = 2
    Friend Const DYNASET_DELETE As Short = 3

    Public Const ORADB_BOOLEAN As Short = 1
    Public Const ORADB_BYTE As Short = 2
    Public Const ORADB_INTEGER As Short = 3
    Public Const ORADB_LONG As Short = 4
    Public Const ORADB_CURRENCY As Short = 5
    Public Const ORADB_SINGLE As Short = 6
    Public Const ORADB_DOUBLE As Short = 7
    Public Const ORADB_DATE As Short = 8
    Public Const ORADB_TEXT As Short = 10
    Public Const ORADB_LONGBINARY As Short = 11
    Public Const ORADB_MEMO As Short = 12

End Module
