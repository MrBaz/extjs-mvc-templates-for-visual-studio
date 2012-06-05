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
    partial class StoreWizPage : CustomWizardPage
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
            this.labelModelName = new System.Windows.Forms.Label();
            this.comboBoxStoreTemplateOptions = new System.Windows.Forms.ComboBox();
            this.labelStoreExtends = new System.Windows.Forms.Label();
            this.labelStoreTemplateOptions = new System.Windows.Forms.Label();
            this.labelStoreTemplate = new System.Windows.Forms.Label();
            this.comboBoxStoreTemplate = new System.Windows.Forms.ComboBox();
            this.comboBoxProxyTypeOptions = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxProxyParms = new System.Windows.Forms.TextBox();
            this.textBoxStoreName = new System.Windows.Forms.TextBox();
            this.comboBoxStoreExtendOptions = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // infoPanel
            // 
            this.infoPanel.Dock = System.Windows.Forms.DockStyle.None;
            this.infoPanel.Location = new System.Drawing.Point(487, 37);
            this.infoPanel.Size = new System.Drawing.Size(20, 275);
            this.infoPanel.Visible = false;
            // 
            // labelModelName
            // 
            this.labelModelName.AutoSize = true;
            this.labelModelName.Location = new System.Drawing.Point(23, 21);
            this.labelModelName.Name = "labelModelName";
            this.labelModelName.Size = new System.Drawing.Size(63, 13);
            this.labelModelName.TabIndex = 3;
            this.labelModelName.Text = "Store Name";
            // 
            // comboBoxStoreTemplateOptions
            // 
            this.comboBoxStoreTemplateOptions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxStoreTemplateOptions.FormattingEnabled = true;
            this.comboBoxStoreTemplateOptions.Location = new System.Drawing.Point(26, 77);
            this.comboBoxStoreTemplateOptions.Name = "comboBoxStoreTemplateOptions";
            this.comboBoxStoreTemplateOptions.Size = new System.Drawing.Size(455, 21);
            this.comboBoxStoreTemplateOptions.TabIndex = 1;
            this.comboBoxStoreTemplateOptions.SelectedIndexChanged += new System.EventHandler(this.comboBoxStoreTemplateOptions_SelectedIndexChanged);
            // 
            // labelStoreExtends
            // 
            this.labelStoreExtends.AutoSize = true;
            this.labelStoreExtends.Location = new System.Drawing.Point(23, 144);
            this.labelStoreExtends.Name = "labelStoreExtends";
            this.labelStoreExtends.Size = new System.Drawing.Size(73, 13);
            this.labelStoreExtends.TabIndex = 23;
            this.labelStoreExtends.Text = "Store Extends";
            // 
            // labelStoreTemplateOptions
            // 
            this.labelStoreTemplateOptions.AutoSize = true;
            this.labelStoreTemplateOptions.Location = new System.Drawing.Point(23, 61);
            this.labelStoreTemplateOptions.Name = "labelStoreTemplateOptions";
            this.labelStoreTemplateOptions.Size = new System.Drawing.Size(118, 13);
            this.labelStoreTemplateOptions.TabIndex = 17;
            this.labelStoreTemplateOptions.Text = "Store Template Options";
            // 
            // labelStoreTemplate
            // 
            this.labelStoreTemplate.AutoSize = true;
            this.labelStoreTemplate.Location = new System.Drawing.Point(23, 102);
            this.labelStoreTemplate.Name = "labelStoreTemplate";
            this.labelStoreTemplate.Size = new System.Drawing.Size(79, 13);
            this.labelStoreTemplate.TabIndex = 18;
            this.labelStoreTemplate.Text = "Store Template";
            // 
            // comboBoxStoreTemplate
            // 
            this.comboBoxStoreTemplate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxStoreTemplate.FormattingEnabled = true;
            this.comboBoxStoreTemplate.Location = new System.Drawing.Point(26, 118);
            this.comboBoxStoreTemplate.Name = "comboBoxStoreTemplate";
            this.comboBoxStoreTemplate.Size = new System.Drawing.Size(455, 21);
            this.comboBoxStoreTemplate.TabIndex = 2;
            this.comboBoxStoreTemplate.SelectedIndexChanged += new System.EventHandler(this.comboBoxStoreTemplate_SelectedIndexChanged);
            // 
            // comboBoxProxyTypeOptions
            // 
            this.comboBoxProxyTypeOptions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxProxyTypeOptions.FormattingEnabled = true;
            this.comboBoxProxyTypeOptions.Location = new System.Drawing.Point(26, 202);
            this.comboBoxProxyTypeOptions.Name = "comboBoxProxyTypeOptions";
            this.comboBoxProxyTypeOptions.Size = new System.Drawing.Size(455, 21);
            this.comboBoxProxyTypeOptions.TabIndex = 4;
            this.comboBoxProxyTypeOptions.SelectedIndexChanged += new System.EventHandler(this.comboBoxProxyTypeOptions_SelectedIndexChanged_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 186);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 29;
            this.label1.Text = "Proxy Type";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 227);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(204, 13);
            this.label2.TabIndex = 30;
            this.label2.Text = "Proxy Parameters (Seperated by Commas)";
            // 
            // textBoxProxyParms
            // 
            this.textBoxProxyParms.Enabled = false;
            this.textBoxProxyParms.Location = new System.Drawing.Point(26, 243);
            this.textBoxProxyParms.Name = "textBoxProxyParms";
            this.textBoxProxyParms.Size = new System.Drawing.Size(455, 20);
            this.textBoxProxyParms.TabIndex = 5;
            this.textBoxProxyParms.TextChanged += new System.EventHandler(this.textBoxProxyParms_TextChanged);
            // 
            // textBoxStoreName
            // 
            this.textBoxStoreName.Location = new System.Drawing.Point(26, 37);
            this.textBoxStoreName.Name = "textBoxStoreName";
            this.textBoxStoreName.Size = new System.Drawing.Size(455, 20);
            this.textBoxStoreName.TabIndex = 0;
            this.textBoxStoreName.TextChanged += new System.EventHandler(this.textBoxStoreName_TextChanged);
            this.textBoxStoreName.Leave += new System.EventHandler(this.textBoxStoreName_Leave);
            // 
            // comboBoxStoreExtendOptions
            // 
            this.comboBoxStoreExtendOptions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxStoreExtendOptions.FormattingEnabled = true;
            this.comboBoxStoreExtendOptions.Location = new System.Drawing.Point(26, 160);
            this.comboBoxStoreExtendOptions.Name = "comboBoxStoreExtendOptions";
            this.comboBoxStoreExtendOptions.Size = new System.Drawing.Size(455, 21);
            this.comboBoxStoreExtendOptions.TabIndex = 3;
            this.comboBoxStoreExtendOptions.SelectedIndexChanged += new System.EventHandler(this.comboBoxStoreExtendOptions_SelectedIndexChanged);
            // 
            // StoreWizPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.comboBoxStoreExtendOptions);
            this.Controls.Add(this.textBoxStoreName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxProxyParms);
            this.Controls.Add(this.comboBoxProxyTypeOptions);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxStoreTemplateOptions);
            this.Controls.Add(this.comboBoxStoreTemplate);
            this.Controls.Add(this.labelStoreExtends);
            this.Controls.Add(this.labelStoreTemplateOptions);
            this.Controls.Add(this.labelStoreTemplate);
            this.Controls.Add(this.labelModelName);
            this.InfoRTBoxSize = new System.Drawing.Size(0, 0);
            this.InfoRTBoxText = "\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\tYou can change the size of this info-box and put text in it by m" +
    "anipulating InfoRTBox element of the related Designer class";
            this.Name = "StoreWizPage";
            this.Size = new System.Drawing.Size(514, 310);
            this.StepTitle = "ExtJs Store";
            this.Controls.SetChildIndex(this.labelModelName, 0);
            this.Controls.SetChildIndex(this.labelStoreTemplate, 0);
            this.Controls.SetChildIndex(this.labelStoreTemplateOptions, 0);
            this.Controls.SetChildIndex(this.labelStoreExtends, 0);
            this.Controls.SetChildIndex(this.comboBoxStoreTemplate, 0);
            this.Controls.SetChildIndex(this.comboBoxStoreTemplateOptions, 0);
            this.Controls.SetChildIndex(this.infoPanel, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.comboBoxProxyTypeOptions, 0);
            this.Controls.SetChildIndex(this.textBoxProxyParms, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.textBoxStoreName, 0);
            this.Controls.SetChildIndex(this.comboBoxStoreExtendOptions, 0);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private Label labelModelName;
        private ComboBox comboBoxStoreTemplateOptions;
        private Label labelStoreExtends;
        private Label labelStoreTemplateOptions;
        private Label labelStoreTemplate;
        private ComboBox comboBoxStoreTemplate;
        private ComboBox comboBoxProxyTypeOptions;
        private Label label1;
        private Label label2;
        private TextBox textBoxProxyParms;
        private TextBox textBoxStoreName;
        private ComboBox comboBoxStoreExtendOptions;
    }
}