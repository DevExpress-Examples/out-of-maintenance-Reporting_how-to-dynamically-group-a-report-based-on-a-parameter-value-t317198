Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports DevExpress.XtraReports.UI

Namespace WindowsFormsApplication1
	Partial Public Class XtraReport1
		Inherits DevExpress.XtraReports.UI.XtraReport

		Public Sub New()
			InitializeComponent()
		End Sub

		Private levelIndent As Integer = 50
		Private Sub XtraReport1_BeforePrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles MyBase.BeforePrint
'INSTANT VB NOTE: The variable report was renamed since Visual Basic does not handle local variables named the same as class members well:
			Dim report_Renamed As XtraReport = TryCast(sender, XtraReport)
			ClearGroups(report_Renamed)
			Dim groupCount As Integer = DirectCast(parameterMultiGroupField.Value, String()).Length
			For i As Integer = groupCount - 1 To 0 Step -1
				Dim groupHeader As New GroupHeaderBand()
				groupHeader.Height = 20
				groupHeader.Name = "groupHeader" & i
				Dim field As String = DirectCast(parameterMultiGroupField.Value, String())(i)
				groupHeader.GroupFields.Add(New GroupField(field))

				Dim groupLabel As New XRLabel()
				groupHeader.Controls.Add(groupLabel)
				groupLabel.SizeF = New SizeF(100, 20)
				groupLabel.LocationF = New PointF(levelIndent * i, 0)
				groupLabel.BackColor = Color.PowderBlue
				groupLabel.DataBindings.Add("Text", Nothing, String.Format("{0}.{1}", report_Renamed.DataMember, field), field & ": {0}")
				report_Renamed.Bands.Add(groupHeader)
			Next i
		End Sub

		Private Sub ClearGroups(ByVal report As XtraReport)
			Dim groupBand As GroupHeaderBand = TryCast(report.Bands(DevExpress.XtraReports.UI.BandKind.GroupHeader), GroupHeaderBand)
			If groupBand Is Nothing Then
				Return
			Else
				groupBand.Controls.Clear()
				report.Bands.Remove(groupBand)
				ClearGroups(report)
			End If
		End Sub

	End Class
End Namespace
