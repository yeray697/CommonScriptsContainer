﻿using MetroSet_UI.Forms;
using System;
using System.Reflection;
using System.Windows.Forms;

namespace CommonScripts.View.Base
{
    public partial class BaseForm : MetroSetForm
    {
        private const int WS_EX_COMPOSITED = 0x02000000;
        private const int WS_MINIMIZEBOX = 0x20000;
        private const int CS_DBLCLKS = 0x8;

        public BaseForm()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            //Override to leave default Form OnLoad method, as MetroSetForm implements an animation that cannot be disabled
            var ptr = typeof(Form).GetMethod("OnLoad", BindingFlags.Instance | BindingFlags.NonPublic).MethodHandle.GetFunctionPointer();
            var baseOnLoad = (Action<EventArgs>)Activator.CreateInstance(typeof(Action<EventArgs>), this, ptr);
            baseOnLoad(e);
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                //Helps with the refresh of the UI when resizing the window
                cp.ExStyle |= WS_EX_COMPOSITED;
                //Allow to minimize from taskbar, as FormBorderStyle.None (because of MetroSetForm) removes that behaviour
                cp.Style |= WS_MINIMIZEBOX;
                cp.ClassStyle |= CS_DBLCLKS;
                return cp;
            }
        }
    }
}
