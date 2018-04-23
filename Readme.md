# How to dynamically group a report based on a parameter value


This example illustrates how to group a report dynamically. Report grouping is changed once a new parameter value is submitted.<br><br>The main idea is to handle the <strong>XtraReport.BeforePrint</strong> event, clear the <strong>GroupHeader.GroupFields</strong> collection, and then add a new <strong>GroupField</strong> item based on a parameter value.

<br/>


