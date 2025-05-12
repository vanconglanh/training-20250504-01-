

Imports NLog

Public Class NLogHelper

    Public Shared logger As Logger = LogManager.GetLogger("")

    Public Shared Sub LogDebug(logContent As String)
        logger.Debug(logContent)
    End Sub

    Public Shared Sub LogInfo(logContent As String)
        logger.Info(logContent)
    End Sub

    Public Shared Sub LogWarning(logContent As String)
        logger.Warn(logContent)
    End Sub

    Public Shared Sub LogError(logContent As String)
        logger.Error(logContent)
    End Sub

    Public Shared Sub LogFatal(logContent As String)
        logger.Fatal(logContent)
    End Sub

End Class
