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
        Me.ServiceProcessInstaller0 = New System.ServiceProcess.ServiceProcessInstaller()
        Me.EMSBMSReportService = New System.ServiceProcess.ServiceInstaller()
        '
        'ServiceProcessInstaller0
        '
        Me.ServiceProcessInstaller0.Account = System.ServiceProcess.ServiceAccount.LocalSystem
        Me.ServiceProcessInstaller0.Password = Nothing
        Me.ServiceProcessInstaller0.Username = Nothing
        '
        'EMSBMSReportService
        '
        Me.EMSBMSReportService.ServiceName = "EMSReportServiceWirelessCDU"
        Me.EMSBMSReportService.StartType = System.ServiceProcess.ServiceStartMode.Automatic
        '
        'ProjectInstaller
        '
        Me.Installers.AddRange(New System.Configuration.Install.Installer() {Me.ServiceProcessInstaller0, Me.EMSBMSReportService})

    End Sub

    Friend WithEvents ServiceProcessInstaller0 As ServiceProcess.ServiceProcessInstaller
    Friend WithEvents EMSBMSReportService As ServiceProcess.ServiceInstaller
End Class
