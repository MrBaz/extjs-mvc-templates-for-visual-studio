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
    partial class ControllerWizPage : CustomWizardPage
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
            this.labelControllerName = new System.Windows.Forms.Label();
            this.textBoxControllerName = new System.Windows.Forms.TextBox();
            this.comboBoxControllerTemplate = new System.Windows.Forms.ComboBox();
            this.labelControllerExtends = new System.Windows.Forms.Label();
            this.labelControllerTemplate = new System.Windows.Forms.Label();
            this.textBoxControllerExtends = new System.Windows.Forms.TextBox();
            this.listBoxControllerModels = new System.Windows.Forms.ListBox();
            this.labelControllerModels = new System.Windows.Forms.Label();
            this.listBoxControllerViews = new System.Windows.Forms.ListBox();
            this.listBoxControllerStores = new System.Windows.Forms.ListBox();
            this.labelControllerStores = new System.Windows.Forms.Label();
            this.labelControllerViews = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // infoPanel
            // 
            this.infoPanel.Dock = System.Windows.Forms.DockStyle.None;
            this.infoPanel.Location = new System.Drawing.Point(3, 145);
            this.infoPanel.Size = new System.Drawing.Size(20, 275);
            this.infoPanel.Visible = false;
            // 
            // labelControllerName
            // 
            this.labelControllerName.AutoSize = true;
            this.labelControllerName.Location = new System.Drawing.Point(23, 21);
            this.labelControllerName.Name = "labelControllerName";
            this.labelControllerName.Size = new System.Drawing.Size(82, 13);
            this.labelControllerName.TabIndex = 3;
            this.labelControllerName.Text = "Controller Name";
            // 
            // textBoxControllerName
            // 
            this.textBoxControllerName.Location = new System.Drawing.Point(26, 37);
            this.textBoxControllerName.Name = "textBoxControllerName";
            this.textBoxControllerName.Size = new System.Drawing.Size(455, 20);
            this.textBoxControllerName.TabIndex = 0;
            this.textBoxControllerName.TextChanged += new System.EventHandler(this.textBoxControllerName_TextChanged);
            this.textBoxControllerName.Leave += new System.EventHandler(this.textBoxControllerName_Leave);
            // 
            // comboBoxControllerTemplate
            // 
            this.comboBoxControllerTemplate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxControllerTemplate.FormattingEnabled = true;
            this.comboBoxControllerTemplate.Location = new System.Drawing.Point(26, 77);
            this.comboBoxControllerTemplate.Name = "comboBoxControllerTemplate";
            this.comboBoxControllerTemplate.Size = new System.Drawing.Size(455, 21);
            this.comboBoxControllerTemplate.TabIndex = 1;
            this.comboBoxControllerTemplate.SelectedIndexChanged += new System.EventHandler(this.comboBoxControllerTemplate_SelectedIndexChanged);
            // 
            // labelControllerExtends
            // 
            this.labelControllerExtends.AutoSize = true;
            this.labelControllerExtends.Location = new System.Drawing.Point(23, 407);
            this.labelControllerExtends.Name = "labelControllerExtends";
            this.labelControllerExtends.Size = new System.Drawing.Size(92, 13);
            this.labelControllerExtends.TabIndex = 23;
            this.labelControllerExtends.Text = "Controller Extends";
            // 
            // labelControllerTemplate
            // 
            this.labelControllerTemplate.AutoSize = true;
            this.labelControllerTemplate.Location = new System.Drawing.Point(23, 61);
            this.labelControllerTemplate.Name = "labelControllerTemplate";
            this.labelControllerTemplate.Size = new System.Drawing.Size(98, 13);
            this.labelControllerTemplate.TabIndex = 17;
            this.labelControllerTemplate.Text = "Controller Template";
            // 
            // textBoxControllerExtends
            // 
            this.textBoxControllerExtends.Location = new System.Drawing.Point(26, 423);
            this.textBoxControllerExtends.Name = "textBoxControllerExtends";
            this.textBoxControllerExtends.Size = new System.Drawing.Size(455, 20);
            this.textBoxControllerExtends.TabIndex = 5;
            this.textBoxControllerExtends.Text = "Ext.app.Controller";
            this.textBoxControllerExtends.TextChanged += new System.EventHandler(this.textBoxControllerExtends_TextChanged);
            // 
            // listBoxControllerModels
            // 
            this.listBoxControllerModels.FormattingEnabled = true;
            this.listBoxControllerModels.Location = new System.Drawing.Point(26, 118);
            this.listBoxControllerModels.Name = "listBoxControllerModels";
            this.listBoxControllerModels.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxControllerModels.Size = new System.Drawing.Size(455, 82);
            this.listBoxControllerModels.TabIndex = 2;
            this.listBoxControllerModels.SelectedIndexChanged += new System.EventHandler(this.listBoxControllerModels_SelectedIndexChanged);
            // 
            // labelControllerModels
            // 
            this.labelControllerModels.AutoSize = true;
            this.labelControllerModels.Location = new System.Drawing.Point(23, 102);
            this.labelControllerModels.Name = "labelControllerModels";
            this.labelControllerModels.Size = new System.Drawing.Size(88, 13);
            this.labelControllerModels.TabIndex = 18;
            this.labelControllerModels.Text = "Controller Models";
            // 
            // listBoxControllerViews
            // 
            this.listBoxControllerViews.FormattingEnabled = true;
            this.listBoxControllerViews.Location = new System.Drawing.Point(26, 322);
            this.listBoxControllerViews.Name = "listBoxControllerViews";
            this.listBoxControllerViews.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxControllerViews.Size = new System.Drawing.Size(455, 82);
            this.listBoxControllerViews.TabIndex = 4;
            this.listBoxControllerViews.SelectedIndexChanged += new System.EventHandler(this.listBoxControllerViews_SelectedIndexChanged);
            // 
            // listBoxControllerStores
            // 
            this.listBoxControllerStores.FormattingEnabled = true;
            this.listBoxControllerStores.Location = new System.Drawing.Point(26, 220);
            this.listBoxControllerStores.Name = "listBoxControllerStores";
            this.listBoxControllerStores.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxControllerStores.Size = new System.Drawing.Size(455, 82);
            this.listBoxControllerStores.TabIndex = 3;
            this.listBoxControllerStores.SelectedIndexChanged += new System.EventHandler(this.listBoxControllerStores_SelectedIndexChanged);
            // 
            // labelControllerStores
            // 
            this.labelControllerStores.AutoSize = true;
            this.labelControllerStores.Location = new System.Drawing.Point(23, 204);
            this.labelControllerStores.Name = "labelControllerStores";
            this.labelControllerStores.Size = new System.Drawing.Size(84, 13);
            this.labelControllerStores.TabIndex = 20;
            this.labelControllerStores.Text = "Controller Stores";
            // 
            // labelControllerViews
            // 
            this.labelControllerViews.AutoSize = true;
            this.labelControllerViews.Location = new System.Drawing.Point(23, 306);
            this.labelControllerViews.Name = "labelControllerViews";
            this.labelControllerViews.Size = new System.Drawing.Size(82, 13);
            this.labelControllerViews.TabIndex = 22;
            this.labelControllerViews.Text = "Controller Views";
            // 
            // ControllerWizPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.comboBoxControllerTemplate);
            this.Controls.Add(this.labelControllerTemplate);
            this.Controls.Add(this.labelControllerExtends);
            this.Controls.Add(this.labelControllerViews);
            this.Controls.Add(this.textBoxControllerExtends);
            this.Controls.Add(this.listBoxControllerModels);
            this.Controls.Add(this.labelControllerModels);
            this.Controls.Add(this.listBoxControllerViews);
            this.Controls.Add(this.listBoxControllerStores);
            this.Controls.Add(this.labelControllerName);
            this.Controls.Add(this.labelControllerStores);
            this.Controls.Add(this.textBoxControllerName);
            this.InfoRTBoxSize = new System.Drawing.Size(0, 0);
            this.InfoRTBoxText = "\t\t\t\t\t\t\t\t\t\t\t\t\tYou can change the size of this info-box and put text in it by manip" +
    "ulating InfoRTBox element of the related Designer class";
            this.Name = "ControllerWizPage";
            this.Size = new System.Drawing.Size(513, 479);
            this.StepTitle = "ExtJs Controller";
            this.Controls.SetChildIndex(this.textBoxControllerName, 0);
            this.Controls.SetChildIndex(this.labelControllerStores, 0);
            this.Controls.SetChildIndex(this.labelControllerName, 0);
            this.Controls.SetChildIndex(this.listBoxControllerStores, 0);
            this.Controls.SetChildIndex(this.listBoxControllerViews, 0);
            this.Controls.SetChildIndex(this.labelControllerModels, 0);
            this.Controls.SetChildIndex(this.listBoxControllerModels, 0);
            this.Controls.SetChildIndex(this.textBoxControllerExtends, 0);
            this.Controls.SetChildIndex(this.labelControllerViews, 0);
            this.Controls.SetChildIndex(this.labelControllerExtends, 0);
            this.Controls.SetChildIndex(this.labelControllerTemplate, 0);
            this.Controls.SetChildIndex(this.infoPanel, 0);
            this.Controls.SetChildIndex(this.comboBoxControllerTemplate, 0);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private Label labelControllerName;
        private TextBox textBoxControllerName;
        private ComboBox comboBoxControllerTemplate;
        private Label labelControllerExtends;
        private Label labelControllerTemplate;
        private TextBox textBoxControllerExtends;
        private ListBox listBoxControllerModels;
        private Label labelControllerModels;
        private ListBox listBoxControllerViews;
        private ListBox listBoxControllerStores;
        private Label labelControllerStores;
        private Label labelControllerViews;
    }
}