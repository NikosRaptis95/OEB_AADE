using accountsClassLibrary;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
namespace DesktopBusiness.CallForms
{
    public partial class CallKinKartFrm : CallKinListFrm
    {
        string idSyn;
        public CallKinKartFrm(string id) {
            this.Name = "CallKinKartFrm";
            this.BO = "accountsClassLibrary.dll";
            this.EXE = Application.ExecutablePath;
            idSyn = id;
            this.panel1.Visible = false;
            this.Width = this.Width + 150;
        }

        public override templates.Forms.def CallForm(List<string> id)
        {
            if (id.Count == 1 && id[0] == "new")
            {
                id[0] = "";
                id.Add("new");
                id.Add("");
                return (new MForms.frmKinFl(id[0], id[1], id[2], idSyn));
            }
            else
            {
                KinFl k = new KinFl();
                k.Fields.Seira = id[0];
                k.Fields.id = id[1];
                k.Fields.KoKiKin.id = id[2];
                if (k.Read().Length == 0)
                    return (new MForms.frmKinFl(id[0], id[1], id[2], idSyn));
                else
                {
                    MessageBox.Show("Αυτή η εγγραφή προέρχεται απο άλλη εγγραφή. Δεν μπορείτε να την καλέσετε !", "Προσοχή !");
                    return null;
                }
            }
        }
        public override List<string> GetData(string strFind)
        {
            // Δηλώνω κολόνες στο Grid
            List<Object> cols = new List<Object>();

            DataGridViewTextBoxColumn col0 = new DataGridViewTextBoxColumn();
            col0.DefaultCellStyle.Format = "dd/MM/yyyy";
            col0.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            cols.Add(col0);

            for (int i = 0; i < 5; i++) { cols.Add(new DataGridViewTextBoxColumn()); }

            DataGridViewTextBoxColumn col1 = new DataGridViewTextBoxColumn();
            col1.DefaultCellStyle.Format = "# ### ##0.00";
            col1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;            
            cols.Add(col1);

            DataGridViewTextBoxColumn col2 = new DataGridViewTextBoxColumn();
            col2.DefaultCellStyle.Format = "# ### ##0.00";
            col2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;            
            cols.Add(col2);

            DataGridViewTextBoxColumn col3 = new DataGridViewTextBoxColumn();
            col3.DefaultCellStyle.Format = "# ### ##0.00";
            col3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            col3.DefaultCellStyle.Font = new Font(DataGridView.DefaultFont, FontStyle.Bold);
            cols.Add(col3);

            List<string> fields = new List<string>() { "RegistryDate", "KoKiKin", "DescKoKi", "Seira", "id", "AitiKin", "Xreosi", "Pistosi", "Ypoloipo" };
            List<string> fname = new List<string>() { "Ημερομηνία", "ΚΚ", "Περιγραφή Κίνησης", "Σειρά", "Αρ.Παρασ.", "Αιτιολογία", "Χρέωση", "Πίστωση", "Υπόλοιπο" };

            // Τίτλος στο παράθυρο           
            fname = new alphaFrameWork.AlphaFramework().customizationforGrid(fname, this.Name);
            accountsClassLibrary.SynFl ms = new SynFl();
            ms.Read(idSyn);
            this.Text = "Καρτέλλα : " + ms.Fields.Name;

            // Καλώ κινήσεις ανα συναλλασσόμενο
            //accountsClassLibrary.KinFl AC = new accountsClassLibrary.KinFl(System.Guid.NewGuid().ToString());            
            //AC.Fields.idSyn.id = idSyn;          
            //new alphaFrameWork.AlphaFramework().Bind(DataGrid, AC.ReadZoom(KinFl.TypeOfKin.All), cols, fields, fname);
            accountsClassLibrary.SynFl AC = new accountsClassLibrary.SynFl(System.Guid.NewGuid().ToString());
            AC.Fields.id = idSyn;
            new alphaFrameWork.AlphaFramework().Bind(DataGrid, AC.ReadZoom(SynFl.TypeOfReadZoom.Kartella), cols, fields, fname);

            // Επιστρέφω το Primary Field του Grid
            List<string> s = new List<string>();
            s.Add("seira");
            s.Add("id");
            s.Add("KoKiKin");
            return (s);
        }

        public override void CustomizeMenu()  { }

    }
}
