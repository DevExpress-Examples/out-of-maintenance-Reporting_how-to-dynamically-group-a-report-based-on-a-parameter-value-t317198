using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace WindowsFormsApplication1 {
    public partial class XtraReport1 : DevExpress.XtraReports.UI.XtraReport {
        public XtraReport1() {
            InitializeComponent();
        }

        int levelIndent = 50;
        private void XtraReport1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e) {
            XtraReport report = sender as XtraReport;
            ClearGroups(report);
            int groupCount = ((string[])parameterMultiGroupField.Value).Length;
            for(int i = groupCount - 1; i >= 0; i--) {
                GroupHeaderBand groupHeader = new GroupHeaderBand();
                groupHeader.Height = 20;
                groupHeader.Name = "groupHeader" + i;
                string field = ((string[])parameterMultiGroupField.Value)[i];
                groupHeader.GroupFields.Add(new GroupField(field));

                XRLabel groupLabel = new XRLabel();
                groupHeader.Controls.Add(groupLabel);
                groupLabel.SizeF = new SizeF(100, 20);
                groupLabel.LocationF = new PointF(levelIndent * i, 0);
                groupLabel.BackColor = Color.PowderBlue;
                groupLabel.DataBindings.Add("Text", null, String.Format("{0}.{1}", report.DataMember, field), field + ": {0}");
                report.Bands.Add(groupHeader);
            }
        }

        private void ClearGroups(XtraReport report) {
            GroupHeaderBand groupBand = report.Bands[DevExpress.XtraReports.UI.BandKind.GroupHeader] as GroupHeaderBand;
            if(groupBand == null)
                return;
            else {
                groupBand.Controls.Clear();
                report.Bands.Remove(groupBand);
                ClearGroups(report);
            }
        }

    }
}
