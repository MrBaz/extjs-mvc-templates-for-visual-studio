/* ****************************************************************************
 * 
 * Copyright (c) 2012 Vikas Goyal. All rights reserved.
 * 
 * This file is part of extjs-mvc-templates-for-visual-studio.
 *
 * This is free software: you can redistribute it and/or modify
 * it under the terms of the GNU Lesser General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * Ext.Direct.Mvc is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU Lesser General Public License for more details.
 *
 * You should have received a copy of the GNU Lesser General Public License
 * along with Ext.Direct.Mvc.  If not, see <http://www.gnu.org/licenses/>.
 *
 * ***************************************************************************/
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Practices.WizardFramework;

namespace ExtJs.CustomWizardPages
{
    partial class ViewWizPage : CustomWizardPage
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelViewName = new System.Windows.Forms.Label();
            this.labelViewExtends = new System.Windows.Forms.Label();
            this.textBoxViewExtends = new System.Windows.Forms.TextBox();
            this.textBoxViewName = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // infoPanel
            // 
            this.infoPanel.Dock = System.Windows.Forms.DockStyle.None;
            this.infoPanel.Location = new System.Drawing.Point(494, 3);
            this.infoPanel.Size = new System.Drawing.Size(20, 275);
            this.infoPanel.Visible = false;
            // 
            // labelViewName
            // 
            this.labelViewName.AutoSize = true;
            this.labelViewName.Location = new System.Drawing.Point(23, 21);
            this.labelViewName.Name = "labelViewName";
            this.labelViewName.Size = new System.Drawing.Size(61, 13);
            this.labelViewName.TabIndex = 3;
            this.labelViewName.Text = "View Name";
            // 
            // labelViewExtends
            // 
            this.labelViewExtends.AutoSize = true;
            this.labelViewExtends.Location = new System.Drawing.Point(23, 60);
            this.labelViewExtends.Name = "labelViewExtends";
            this.labelViewExtends.Size = new System.Drawing.Size(71, 13);
            this.labelViewExtends.TabIndex = 23;
            this.labelViewExtends.Text = "View Extends";
            // 
            // textBoxViewExtends
            // 
            this.textBoxViewExtends.Location = new System.Drawing.Point(26, 76);
            this.textBoxViewExtends.Name = "textBoxViewExtends";
            this.textBoxViewExtends.Size = new System.Drawing.Size(455, 20);
            this.textBoxViewExtends.TabIndex = 3;
            this.textBoxViewExtends.Text = "Ext.";
            this.textBoxViewExtends.TextChanged += new System.EventHandler(this.textBoxViewExtends_TextChanged);
            // 
            // textBoxViewName
            // 
            this.textBoxViewName.Location = new System.Drawing.Point(26, 37);
            this.textBoxViewName.Name = "textBoxViewName";
            this.textBoxViewName.Size = new System.Drawing.Size(455, 20);
            this.textBoxViewName.TabIndex = 0;
            this.textBoxViewName.TextChanged += new System.EventHandler(this.textBoxViewName_TextChanged);
            this.textBoxViewName.Leave += new System.EventHandler(this.textBoxViewName_Leave);
            // 
            // ViewWizPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.textBoxViewName);
            this.Controls.Add(this.labelViewExtends);
            this.Controls.Add(this.textBoxViewExtends);
            this.Controls.Add(this.labelViewName);
            this.InfoRTBoxSize = new System.Drawing.Size(0, 0);
            this.InfoRTBoxText = "\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\tYou can change the size of this info-box and put text in it " +
    "by manipulating InfoRTBox element of the related Designer class";
            this.Name = "ViewWizPage";
            this.Size = new System.Drawing.Size(517, 281);
            this.StepTitle = "ExtJs View";
            this.Controls.SetChildIndex(this.labelViewName, 0);
            this.Controls.SetChildIndex(this.textBoxViewExtends, 0);
            this.Controls.SetChildIndex(this.labelViewExtends, 0);
            this.Controls.SetChildIndex(this.infoPanel, 0);
            this.Controls.SetChildIndex(this.textBoxViewName, 0);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private Label labelViewName;
        private Label labelViewExtends;
        private TextBox textBoxViewExtends;
        private TextBox textBoxViewName;
    }
}