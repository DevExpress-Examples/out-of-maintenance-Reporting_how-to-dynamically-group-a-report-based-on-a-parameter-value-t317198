<!-- default file list -->
*Files to look at*:

* [Form1.cs](./CS/WindowsFormsApplication1/Form1.cs) (VB: [Form1.vb](./VB/WindowsFormsApplication1/Form1.vb))
* [XtraReport1.cs](./CS/WindowsFormsApplication1/XtraReport1.cs) (VB: [XtraReport1.vb](./VB/WindowsFormsApplication1/XtraReport1.vb))
<!-- default file list end -->
# How to dynamically group a report based on a parameter value


This example illustrates how to group a report dynamically. Report grouping is changed once a new parameter value is submitted.<br><br>The main idea is to handle the <strong>XtraReport.BeforePrint</strong> event, clear the <strong>GroupHeader.GroupFields</strong> collection, and then add a new <strong>GroupField</strong> item based on a parameter value.

<br/>


