using CommonScripts.CustomComponent.ScriptListBox;
using CommonScripts.Model;
using CommonScripts.Presenter;
using CommonScripts.View.Interfaces;
using MetroFramework.Forms;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CommonScripts.View
{
    public partial class MainForm : MetroForm, IMainView
    {
        public MainPresenter Presenter { get; set; }
        private ScriptListManager scriptListManager;

        public MainForm()
        {
            InitializeComponent();
            scriptListManager = new ScriptListManager(StyleManager);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Presenter.LoadSettings();
        }

        private void lblRunAddScript_Click(object sender, EventArgs e)
        {

        }

        public void ShowScripts(IList<Script> scripts)
        {
            var controls = scriptListManager.CreateWithList(scripts).ToArray();
            pnlScripts.Controls.AddRange(controls);
        }
    }
}
