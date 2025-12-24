using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopBusiness.iForms
{
    public partial class frmMain : templates.Forms.Main
    {
        public string PRG= "prg=OEB";

        public frmMain()
        {
            
            this.BO = "accountsClassLibrary.dll";
            this.EXE = "DesktopBPR.exe";
        }

        public override void CustomizeMenu()
        {
            base.CustomizeMenu();
            if (!System.IO.File.Exists("bpr.ini"))  System.IO.File.WriteAllText("bpr.ini", "prg=OEB");
            PRG = System.IO.File.ReadAllText("bpr.ini");   // OEB ή BPR
            if (PRG.ToUpper().IndexOf("PRG=OEB") > -1 ) PRG = "prg=OEB";
            // fileMenu
            {
                ToolStripMenuItem fileMenuItem0 = new ToolStripMenuItem("Λογαριασμοί");
                fileMenu.DropDownItems.Insert(0, fileMenuItem0);

                ToolStripMenuItem fileMenuItem01 = new ToolStripMenuItem(_s.G(3));
                fileMenuItem01.Click += (object sender, EventArgs e) =>
                {
                    Form childForm = new CallForms.CallSynFrm(accountsClassLibrary.SynFl.TypeOfSynFl.Customers);
                    childForm.MdiParent = this;
                    childForm.Show();
                };
                fileMenu.DropDownItems.Insert(0, fileMenuItem01);

                ToolStripMenuItem fileMenuItem02 = new ToolStripMenuItem(_s.G(6));
                fileMenuItem02.Click += (object sender, EventArgs e) =>
                {
                    Form childForm = new CallForms.CallSynFrm(accountsClassLibrary.SynFl.TypeOfSynFl.Supliers);
                    childForm.MdiParent = this;
                    childForm.Show();
                };
                fileMenu.DropDownItems.Insert(1, fileMenuItem02);

                ToolStripMenuItem fileMenuItem03 = new ToolStripMenuItem(_s.G(3)+ " && "+ _s.G(6));
                fileMenuItem03.Click += (object sender, EventArgs e) =>
                {
                    Form childForm = new CallForms.CallSynFrm(accountsClassLibrary.SynFl.TypeOfSynFl.CustomersSupliers);
                    childForm.MdiParent = this;
                    childForm.Show();
                };
                fileMenu.DropDownItems.Insert(2, fileMenuItem03);

                ToolStripMenuItem fileMenuItem04 = new ToolStripMenuItem("Όλοι");
                fileMenuItem04.Click += (object sender, EventArgs e) =>
                {
                    Form childForm = new CallForms.CallSynFrm(accountsClassLibrary.SynFl.TypeOfSynFl.All);
                    childForm.MdiParent = this;
                    childForm.Show();
                };
                fileMenu.DropDownItems.Insert(3, fileMenuItem04);
                
                fileMenuItem0.DropDownItems.AddRange(new ToolStripItem[] { fileMenuItem01,
                                                                           fileMenuItem02,
                                                                           fileMenuItem03,
                                                                           fileMenuItem04 });

                fileMenu.DropDownItems.Insert(1, new ToolStripSeparator());

                ToolStripMenuItem fileMenuItem05 = new ToolStripMenuItem("Προιόντα");
                fileMenuItem05.Visible = true;
                fileMenuItem05.Click += (object sender, EventArgs e) =>
                {
                    Form childForm = new CallForms.CallMtlFrm();
                    childForm.MdiParent = this;
                    childForm.Show();
                };

                fileMenu.DropDownItems.Insert(1, fileMenuItem05);
                fileMenu.DropDownItems.Insert(1, new ToolStripSeparator());

                ToolStripMenuItem fileMenuItem06 = new ToolStripMenuItem(_s.G(7));
                fileMenuItem06.Click += (object sender, EventArgs e) =>
                {
                    Form childForm = new CallForms.CallErgFrm();
                    childForm.MdiParent = this;
                    childForm.Show();
                };
               
                fileMenu.DropDownItems.Insert(1, fileMenuItem06);
                fileMenu.DropDownItems.Insert(1, new ToolStripSeparator());
                if (PRG.Trim() == "prg=OEB")
                {
                    fileMenu.DropDownItems.Clear();
                    ToolStripMenuItem fileMenuItem99 = new ToolStripMenuItem("Έξοδος");
                    fileMenuItem99.Click += (object sender, EventArgs e) =>
                    {
                        this.Close();
                    };
                   
                    fileMenu.DropDownItems.Add(fileMenuItem99);
                    //fileMenu.Visible = false;
                }
            }

            // editMenu
            {
               
                ToolStripMenuItem editMenu1 = new ToolStripMenuItem(_s.G(3));

                ToolStripMenuItem editMenuItem11 = new ToolStripMenuItem("Εισπράξεις απο "+ _s.G(2));
                editMenuItem11.Click += (object sender, EventArgs e) =>
                {
                    Form childForm = new CallForms.CallKinListFrm(accountsClassLibrary.KinFl.TypeOfKin.RecieveFromCustomer);
                    childForm.MdiParent = this;
                    childForm.Show();
                };
                editMenu1.DropDownItems.Add(editMenuItem11);

                ToolStripMenuItem editMenuItem12 = new ToolStripMenuItem("Πιστώσεις "+_s.G(3));
                editMenuItem12.Click += (object sender, EventArgs e) =>
                {
                    Form childForm = new CallForms.CallKinListFrm(accountsClassLibrary.KinFl.TypeOfKin.CreditToCustomer);
                    childForm.MdiParent = this;
                    childForm.Show();
                };
                editMenu1.DropDownItems.Add(editMenuItem12);

                ToolStripMenuItem editMenuItem13 = new ToolStripMenuItem("Χρεώσεις " + _s.G(3));
                editMenuItem13.Click += (object sender, EventArgs e) =>
                {
                    Form childForm = new CallForms.CallKinListFrm(accountsClassLibrary.KinFl.TypeOfKin.DebitToCustomer);
                    childForm.MdiParent = this;
                    childForm.Show();
                };
                editMenu1.DropDownItems.Add(editMenuItem13);

                ToolStripMenuItem editMenuItem14 = new ToolStripMenuItem("Πληρωμές σε " + _s.G(2));
                editMenuItem14.Click += (object sender, EventArgs e) =>
                {
                    Form childForm = new CallForms.CallKinListFrm(accountsClassLibrary.KinFl.TypeOfKin.PaymentToCustomer);
                    childForm.MdiParent = this;
                    childForm.Show();
                };
                editMenu1.DropDownItems.Add(editMenuItem14);

                editMenu.DropDownItems.Add(editMenu1);
                

                ToolStripMenuItem editMenu2 = new ToolStripMenuItem(_s.G(6));
                if (PRG != "prg=OEB")
                    editMenu.DropDownItems.Add(new ToolStripSeparator());

                ToolStripMenuItem editMenuItem15 = new ToolStripMenuItem("Πληρωμές σε  " + _s.G(5));
                editMenuItem15.Click += (object sender, EventArgs e) =>
                {
                    Form childForm = new CallForms.CallKinListFrm(accountsClassLibrary.KinFl.TypeOfKin.PaymentToSuplier);
                    childForm.MdiParent = this;
                    childForm.Show();
                };
                editMenu2.DropDownItems.Add(editMenuItem15);

                ToolStripMenuItem editMenuItem16 = new ToolStripMenuItem("Χρεώσεις  " + _s.G(6));
                editMenuItem16.Click += (object sender, EventArgs e) =>
                {
                    Form childForm = new CallForms.CallKinListFrm(accountsClassLibrary.KinFl.TypeOfKin.DebitToSuplier);
                    childForm.MdiParent = this;
                    childForm.Show();
                };
                editMenu2.DropDownItems.Add(editMenuItem16);

                ToolStripMenuItem editMenuItem17 = new ToolStripMenuItem("Πιστώσεις  " + _s.G(6));
                editMenuItem17.Click += (object sender, EventArgs e) =>
                {
                    Form childForm = new CallForms.CallKinListFrm(accountsClassLibrary.KinFl.TypeOfKin.CreditToSuplier);
                    childForm.MdiParent = this;
                    childForm.Show();
                };
                editMenu2.DropDownItems.Add(editMenuItem17);

                ToolStripMenuItem editMenuItem18 = new ToolStripMenuItem("Εισπράξεις απο  " + _s.G(5));
                editMenuItem18.Click += (object sender, EventArgs e) =>
                {
                    Form childForm = new CallForms.CallKinListFrm(accountsClassLibrary.KinFl.TypeOfKin.RecieveFromSuplier);
                    childForm.MdiParent = this;
                    childForm.Show();
                };
                editMenu2.DropDownItems.Add(editMenuItem18);

                editMenu.DropDownItems.Add(editMenu2);



                if (PRG != "prg=OEB")
                    editMenu.DropDownItems.Add(new ToolStripSeparator());

                ToolStripMenuItem editMenuItem19 = new ToolStripMenuItem( _s.G(8));
                editMenuItem19.Click += (object sender, EventArgs e) =>
                {
                    Form childForm = new CallForms.CallKErFrm();
                    childForm.MdiParent = this;
                    childForm.Show();
                };
                editMenu.DropDownItems.Add(editMenuItem19);

                if (PRG != "prg=OEB")
                    editMenu.DropDownItems.Add(new ToolStripSeparator());

                ToolStripMenuItem editMenuItem20 = new ToolStripMenuItem(_s.G(9));
                editMenuItem20.Click += (object sender, EventArgs e) =>
                {
                    Form childForm = new CallForms.CAll_AADEFrm();
                    childForm.MdiParent = this;
                    childForm.Show();
                };
                editMenu.DropDownItems.Add(editMenuItem20);

                if (PRG == "prg=OEB")
                {
                    editMenu1.Visible = false;
                    editMenu2.Visible = false;
                    editMenuItem19.Visible = false;
                }

            }

            // viewMenu
            {
                ToolStripMenuItem ViewMenuItem0 = new ToolStripMenuItem("Αναφορές");                
                viewMenu.DropDownItems.Add(ViewMenuItem0);

                ToolStripMenuItem viewMenuItem01 = new ToolStripMenuItem("Ισοζύγιο");
                viewMenuItem01.Click += (object sender, EventArgs e) =>
                {
                    Form childForm = new reports.repFiltro("iso", true, true, false);
                    childForm.MdiParent = this;                    
                    childForm.Show();
                };

                ToolStripMenuItem viewMenuItem02 = new ToolStripMenuItem("Ημερολόγιο");
                viewMenuItem02.Click += (object sender, EventArgs e) =>
                {
                    Form childForm = new reports.repFiltro("hme", true, true, false);
                    childForm.MdiParent = this;
                    childForm.Show();
                };

                ToolStripMenuItem viewMenuItem03 = new ToolStripMenuItem("Καρτέλλα");
                viewMenuItem03.Click += (object sender, EventArgs e) =>
                {
                    Form childForm = new reports.repFiltro("kart", true, true, false);
                    childForm.MdiParent = this;
                    childForm.Show();
                };

                ViewMenuItem0.DropDownItems.AddRange(new ToolStripItem[] { viewMenuItem01, viewMenuItem02, viewMenuItem03 } );
                if (PRG == "prg=OEB")
                    ViewMenuItem0.Visible = false;
            }

            // toolsMenu
            {
                

                ToolStripMenuItem toolsMenuItem1 = new ToolStripMenuItem("Επιλογές");                
                toolsMenuItem1.Click += (object sender, EventArgs e) =>
                {
                    Form childForm = new optionsFrm();
                    childForm.MdiParent = this;                    
                    childForm.Show();
                };



                toolsMenu.DropDownItems.AddRange(new ToolStripItem[] { toolsMenuItem1 });
            }

            // toolStrip
            {
                accountsClassLibrary.FilPin r = new accountsClassLibrary.FilPin();
                r.Read("xr001");
                string s = r.Fields.Name;


                toolsStripItem0 = new ToolStripMenuItem(s);
                toolsStripItem0.ToolTipText = "Γενική εικόνα ! ";
                toolsStripItem0.Click += (object sender, EventArgs e) =>
                {
                    Form childForm = new reportForms.genView();
                    childForm.MdiParent = this;
                    childForm.Show();
                };

                ToolStripMenuItem toolsStripItem1 = new ToolStripMenuItem(s);
                toolsStripItem1.ToolTipText = "Μεταβιβάσεις εισπράξεων ! ";
                toolsStripItem1.Text = "Μεταβιβάσεις εισπράξεων !";
                toolsStripItem1.Alignment = ToolStripItemAlignment.Left;
                toolsStripItem1.Dock = DockStyle.Left;
                toolsStripItem1.Click += (object sender, EventArgs e) =>
                {
                    Form childForm = new CallForms.CAll_AADEFrm();
                    childForm.MdiParent = this;
                    childForm.Show();
                };

                if (PRG == "prg=OEB")
                {                   
                    toolStrip.Items.AddRange(new ToolStripItem[] { toolsStripItem1 });
                }
                else
                {
                    toolStrip.Items.AddRange(new ToolStripItem[] { toolsStripItem0, toolsStripItem1 });
                }
            }
        }
        ToolStripMenuItem toolsStripItem0;

        public override List<templates.user> setUsers()
        {            
            List<templates.user> users = new List<templates.user>();
            try {
                
                accountsClassLibrary.FilPin f = new accountsClassLibrary.FilPin("%");
                DataTable dt = new DataTable();
                dt = f.ReadZoom(accountsClassLibrary.FilPin.TypeOfPin.Users);

                for (int i = 0; i < dt.Rows.Count; i++)
                    users.Add(new templates.user() { username = dt.Rows[i]["Name"].ToString(), password = "" });
                
            }
            catch(Exception ex) { MessageBox.Show(ex.Message, "Δεν μπορώ να συνδεθω στην βάση !"); }
            

            return users;
        }

        public override void getUsers(string User)
        {
            Program.global.username = User;
            toolsStripItem0.Text = Program.global.username + " - " + toolsStripItem0.Text;

            accountsClassLibrary.FilPin f = new accountsClassLibrary.FilPin();
            f.Fields.id = "xr002";
            f.Fields.Name = User;
            f.Update();
        }

        public override List<string> getProgramDetails()
        {
            List<string> r = new List<string>();
            if(System.IO.File.Exists("SN.txt")==false) System.IO.File.WriteAllText("SN.txt", System.Guid.NewGuid().ToString());
            try { r.Add(System.IO.File.ReadAllText("SN.txt")); }
            catch { r.Add("1234567890"); }

            r.Add(this.Name);
            r.Add("Open");
            accountsClassLibrary.FilPin f = new accountsClassLibrary.FilPin();
            f.Read("xr001");
            r.Add(f.Fields.Name);
            r.Add(Environment.MachineName);
            alphaFrameWork.AlphaFramework a = new alphaFrameWork.AlphaFramework();
            r.Add(a.GetProcessorId());
            r.Add(a.GetWindowsInfo());
            r.Add(Application.ExecutablePath);

            String typeapp = File.ReadAllText(@"params\typeapp.param");
            typeapp = typeapp.Trim().Replace("TypeApp = ", "").Replace("//Test or Release", "");
            String level = File.ReadAllText(@"params\level.param");
            level = level.Trim();

            Label_toolStripStatus.Text =" Data:"+ Label_toolStripStatus.Text+"  - ΑΑΔΕ:" + typeapp + " - Program:" + level;


            return r;
        }

        S _s = new S(new alphaFrameWork.AlphaFramework().lang);
        class S
        {
            private string lang = "gr";
            public S(string _lang) { lang = _lang; }

            public string G(int id)
            {
                switch (lang)
                {
                    case "gr":
                        switch (id)
                        {
                            case 1: return "Πελάτης";
                            case 2: return "Πελάτες";
                            case 3: return "Πελατών";
                            case 4: return "Προμηθευτής";
                            case 5: return "Προμηθευτές";
                            case 6: return "Προμηθευτών";
                            case 7: return "Υπηρεσιών";
                            case 8: return "Εργασιών";
                            case 9: return "Μεταβιβάσεις εισπράξεων";
                            default: return "Δεν βρέθηκε η συμβολοσειρά";
                        }
                    default:
                        switch (id)
                        {
                            case 1: return "Customer";
                            case 2: return "Customers";
                            case 3: return "Customers";
                            case 4: return "Supplier";
                            case 5: return "Suppliers";
                            case 6: return "Suppliers";
                            case 7: return "Services";
                            case 8: return "Tasks";
                            case 9: return "transfer of receipts";
                            default: return "String not found";
                        }
                }
            }

        }

    }
}
