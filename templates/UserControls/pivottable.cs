using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AxMicrosoft.Office.Interop.Owc11;

namespace templates.UserControls
{
    public partial class pivottable : UserControl
    {
        AxPivotTable pt = new AxPivotTable();

        public pivottable()
        {
            InitializeComponent();
            this.Controls.Add(pt);
        }

        public class Field
        {
            public Field()
            {
                FieldName = "";
                Caption = "";
                RowAxis = false;
                DataAxis = false;
                InsertTotal = false;
                TotalName = "";
                TotalType = Microsoft.Office.Interop.Owc11.PivotTotalFunctionEnum.plFunctionUnknown;
            }
            public string FieldName { get; set; }
            public string Caption { get; set; }
            public Boolean RowAxis { get; set; }
            public Boolean DataAxis { get; set; }
            public Boolean InsertTotal { get; set; }
            public String TotalName { get; set; }
            public Microsoft.Office.Interop.Owc11.PivotTotalFunctionEnum TotalType { get; set; }
        }
        public void Go(string sql, List<Field> Fields)
        {
            #region Pivot
            string cs= new alphaFrameWork.datalayer().GetPivotConnectionString();
            pt.ConnectionString = cs;
            pt.CommandText = sql;

            pt.CtlHeight = 300;
            pt.CtlWidth = 700;

            pt.Dock = DockStyle.Fill;
            pt.MemberExpand = Microsoft.Office.Interop.Owc11.PivotTableMemberExpandEnum.plMemberExpandNever;
            pt.DisplayToolbar = false;
            pt.ActiveView.AllowEdits = false;

            // Columns
            for (int i = 0; i < Fields.Count; i++)
            {
                pt.ActiveView.FieldSets[Fields[i].FieldName].Fields[0].Caption = Fields[i].Caption;
                if(Fields[i].RowAxis) pt.ActiveView.RowAxis.InsertFieldSet(pt.ActiveView.FieldSets[Fields[i].FieldName]);
                if(Fields[i].DataAxis)
                {
                    pt.ActiveView.FieldSets[Fields[i].FieldName].Fields[0].Expanded = false;
                    pt.ActiveView.DataAxis.InsertFieldSet(pt.ActiveView.FieldSets[Fields[i].FieldName]);
                    pt.ActiveView.DataAxis.InsertTotal(pt.ActiveView.AddTotal(Fields[i].TotalName,
                                                                              pt.ActiveView.FieldSets[Fields[i].FieldName].Fields[0],
                                                                              Fields[i].TotalType));
                }
            }
            #endregion
        }
    }
}
