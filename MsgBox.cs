using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Timer;
public partial class MsgBox : Form {

    private Control parent;
    public MsgBox(Control parent) {
        this.parent = parent;
        InitializeComponent();
    }

    protected override void OnShown(EventArgs e) {
        base.OnShown(e);
        Rectangle r = Screen.FromControl(parent).Bounds;
        Left = r.Left+(r.Width-Width)/2;
        Top = r.Top+(r.Height-Height)/2;
    }

    private void button1_Click(object sender, EventArgs e) {
        Close();
    }
}
