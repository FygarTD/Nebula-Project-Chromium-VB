Imports System
Imports System.Windows.Forms
Imports DotNetBrowser.Browser
Imports DotNetBrowser.Engine
Imports DotNetBrowser.WinForms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        components = New System.ComponentModel.Container()
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Text = "Form1"
    End Sub

End Class

Partial Public Class Form1
    Inherits Form
    Private ReadOnly engine As IEngine
    Private ReadOnly browser As IBrowser

    Public Sub New()
        InitializeComponent()

        ' Create and initialize the IEngine
        engine = EngineFactory.Create()



        ' Create the Windows Forms BrowserView control
        Dim browserView As New BrowserView() With {.Dock = DockStyle.Fill}

        ' Create the IBrowser
        browser = engine.CreateBrowser()
        browser.Navigation.LoadUrl("https://google.ca")

        ' Initialize the Windows Forms BrowserView control
        browserView.InitializeFrom(browser)

        ' Add the BrowserView control to the Form
        Controls.Add(browserView)
        AddHandler Me.Closed, AddressOf Form1Closed
    End Sub

    Private Sub Form1Closed(ByVal sender As Object, ByVal e As EventArgs)
        browser.Dispose()
        engine.Dispose()
    End Sub
End Class
