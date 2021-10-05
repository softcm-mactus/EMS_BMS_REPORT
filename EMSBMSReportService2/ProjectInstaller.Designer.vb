<System.ComponentModel.RunInstaller(True)> Partial Class ProjectInstaller
    Inherits System.Configuration.Install.Installer

    'Installer overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Component Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Component Designer
    'It can be modified using the Component Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.EMSBMSReportServiceInstaller = New System.ServiceProcess.ServiceProcessInstaller()
        Me.EMSBMSReportServer = New System.ServiceProcess.ServiceInstaller()
        '
        'EMSBMSReportServiceInstaller
        '
        Me.EMSBMSReportServiceInstaller.Account = System.ServiceProcess.ServiceAccount.LocalSystem
        Me.EMSBMSReportServiceInstaller.Password = Nothing
        Me.EMSBMSReportServiceInstaller.Username = Nothing
        '
        'EMSBMSReportServer
        '
        Me.EMSBMSReportServer.Description = "EMSBMSReportServer2"
        Me.EMSBMSReportServer.DisplayName = "EMSBMSReportServer2"
        Me.EMSBMSReportServer.ServiceName = "EMSBMSReportServer2"
        Me.EMSBMSReportServer.StartType = System.ServiceProcess.ServiceStartMode.Automatic
        '
        'ProjectInstaller
        '
        Me.Installers.AddRange(New System.Configuration.Install.Installer() {Me.EMSBMSReportServiceInstaller, Me.EMSBMSReportServer})

    End Sub

    Friend WithEvents EMSBMSReportServiceInstaller As ServiceProcess.ServiceProcessInstaller
    Friend WithEvents EMSBMSReportServer As ServiceProcess.ServiceInstaller
End Class
