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
    partial class ModelWizPage : CustomWizardPage
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
            this.comboBoxModelTemplateOptions = new System.Windows.Forms.ComboBox();
            this.labelModelExtends = new System.Windows.Forms.Label();
            this.labelModelTemplateOptions = new System.Windows.Forms.Label();
            this.textBoxModelExtends = new System.Windows.Forms.TextBox();
            this.labelModelTemplate = new System.Windows.Forms.Label();
            this.comboBoxModelTemplate = new System.Windows.Forms.ComboBox();
            this.comboBoxProxyTypeOptions = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxProxyParms = new System.Windows.Forms.TextBox();
            this.checkBoxAutomaticStore = new System.Windows.Forms.CheckBox();
            this.textBoxModelName = new System.Windows.Forms.TextBox();
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
            this.labelModelName.Size = new System.Drawing.Size(67, 13);
            this.labelModelName.TabIndex = 3;
            this.labelModelName.Text = "Model Name";
            // 
            // comboBoxModelTemplateOptions
            // 
            this.comboBoxModelTemplateOptions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxModelTemplateOptions.FormattingEnabled = true;
            this.comboBoxModelTemplateOptions.Location = new System.Drawing.Point(26, 77);
            this.comboBoxModelTemplateOptions.Name = "comboBoxModelTemplateOptions";
            this.comboBoxModelTemplateOptions.Size = new System.Drawing.Size(455, 21);
            this.comboBoxModelTemplateOptions.TabIndex = 1;
            this.comboBoxModelTemplateOptions.SelectedIndexChanged += new System.EventHandler(this.comboBoxModelTemplateOptions_SelectedIndexChanged);
            // 
            // labelModelExtends
            // 
            this.labelModelExtends.AutoSize = true;
            this.labelModelExtends.Location = new System.Drawing.Point(23, 143);
            this.labelModelExtends.Name = "labelModelExtends";
            this.labelModelExtends.Size = new System.Drawing.Size(77, 13);
            this.labelModelExtends.TabIndex = 23;
            this.labelModelExtends.Text = "Model Extends";
            // 
            // labelModelTemplateOptions
            // 
            this.labelModelTemplateOptions.AutoSize = true;
            this.labelModelTemplateOptions.Location = new System.Drawing.Point(23, 61);
            this.labelModelTemplateOptions.Name = "labelModelTemplateOptions";
            this.labelModelTemplateOptions.Size = new System.Drawing.Size(122, 13);
            this.labelModelTemplateOptions.TabIndex = 17;
            this.labelModelTemplateOptions.Text = "Model Template Options";
            // 
            // textBoxModelExtends
            // 
            this.textBoxModelExtends.Location = new System.Drawing.Point(26, 159);
            this.textBoxModelExtends.Name = "textBoxModelExtends";
            this.textBoxModelExtends.Size = new System.Drawing.Size(455, 20);
            this.textBoxModelExtends.TabIndex = 3;
            this.textBoxModelExtends.Text = "Ext.data.Model";
            this.textBoxModelExtends.TextChanged += new System.EventHandler(this.textBoxModelExtends_TextChanged);
            // 
            // labelModelTemplate
            // 
            this.labelModelTemplate.AutoSize = true;
            this.labelModelTemplate.Location = new System.Drawing.Point(23, 102);
            this.labelModelTemplate.Name = "labelModelTemplate";
            this.labelModelTemplate.Size = new System.Drawing.Size(83, 13);
            this.labelModelTemplate.TabIndex = 18;
            this.labelModelTemplate.Text = "Model Template";
            // 
            // comboBoxModelTemplate
            // 
            this.comboBoxModelTemplate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxModelTemplate.FormattingEnabled = true;
            this.comboBoxModelTemplate.Location = new System.Drawing.Point(26, 118);
            this.comboBoxModelTemplate.Name = "comboBoxModelTemplate";
            this.comboBoxModelTemplate.Size = new System.Drawing.Size(455, 21);
            this.comboBoxModelTemplate.TabIndex = 2;
            this.comboBoxModelTemplate.SelectedIndexChanged += new System.EventHandler(this.comboBoxModelTemplate_SelectedIndexChanged);
            // 
            // comboBoxProxyTypeOptions
            // 
            this.comboBoxProxyTypeOptions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxProxyTypeOptions.FormattingEnabled = true;
            this.comboBoxProxyTypeOptions.Location = new System.Drawing.Point(26, 199);
            this.comboBoxProxyTypeOptions.Name = "comboBoxProxyTypeOptions";
            this.comboBoxProxyTypeOptions.Size = new System.Drawing.Size(455, 21);
            this.comboBoxProxyTypeOptions.TabIndex = 4;
            this.comboBoxProxyTypeOptions.SelectedIndexChanged += new System.EventHandler(this.comboBoxProxyTypeOptions_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 183);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 29;
            this.label1.Text = "Proxy Type";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 224);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(204, 13);
            this.label2.TabIndex = 30;
            this.label2.Text = "Proxy Parameters (Seperated by Commas)";
            // 
            // textBoxProxyParms
            // 
            this.textBoxProxyParms.Location = new System.Drawing.Point(26, 240);
            this.textBoxProxyParms.Name = "textBoxProxyParms";
            this.textBoxProxyParms.Size = new System.Drawing.Size(455, 20);
            this.textBoxProxyParms.TabIndex = 5;
            this.textBoxProxyParms.TextChanged += new System.EventHandler(this.textBoxProxyParms_TextChanged);
            // 
            // checkBoxAutomaticStore
            // 
            this.checkBoxAutomaticStore.AutoSize = true;
            this.checkBoxAutomaticStore.Location = new System.Drawing.Point(26, 268);
            this.checkBoxAutomaticStore.Name = "checkBoxAutomaticStore";
            this.checkBoxAutomaticStore.Size = new System.Drawing.Size(220, 17);
            this.checkBoxAutomaticStore.TabIndex = 32;
            this.checkBoxAutomaticStore.Text = "Automatically Create Store for This Model";
            this.checkBoxAutomaticStore.UseVisualStyleBackColor = true;
            this.checkBoxAutomaticStore.CheckedChanged += new System.EventHandler(this.checkBoxAutomaticStore_CheckedChanged);
            // 
            // textBoxModelName
            // 
            this.textBoxModelName.Location = new System.Drawing.Point(26, 37);
            this.textBoxModelName.Name = "textBoxModelName";
            this.textBoxModelName.Size = new System.Drawing.Size(455, 20);
            this.textBoxModelName.TabIndex = 0;
            this.textBoxModelName.TextChanged += new System.EventHandler(this.textBoxModelName_TextChanged);
            this.textBoxModelName.Leave += new System.EventHandler(this.textBoxModelName_Leave);
            // 
            // ModelWizPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.textBoxModelName);
            this.Controls.Add(this.checkBoxAutomaticStore);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxProxyParms);
            this.Controls.Add(this.comboBoxProxyTypeOptions);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxModelTemplateOptions);
            this.Controls.Add(this.comboBoxModelTemplate);
            this.Controls.Add(this.labelModelExtends);
            this.Controls.Add(this.labelModelTemplateOptions);
            this.Controls.Add(this.textBoxModelExtends);
            this.Controls.Add(this.labelModelTemplate);
            this.Controls.Add(this.labelModelName);
            this.InfoRTBoxSize = new System.Drawing.Size(0, 0);
            this.InfoRTBoxText = "\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\tYou can change the size of this info-box and put text in it by " +
    "manipulating InfoRTBox element of the related Designer class";
            this.Name = "ModelWizPage";
            this.Size = new System.Drawing.Size(517, 315);
            this.StepTitle = "ExtJs Model";
            this.Controls.SetChildIndex(this.labelModelName, 0);
            this.Controls.SetChildIndex(this.labelModelTemplate, 0);
            this.Controls.SetChildIndex(this.textBoxModelExtends, 0);
            this.Controls.SetChildIndex(this.labelModelTemplateOptions, 0);
            this.Controls.SetChildIndex(this.labelModelExtends, 0);
            this.Controls.SetChildIndex(this.comboBoxModelTemplate, 0);
            this.Controls.SetChildIndex(this.comboBoxModelTemplateOptions, 0);
            this.Controls.SetChildIndex(this.infoPanel, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.comboBoxProxyTypeOptions, 0);
            this.Controls.SetChildIndex(this.textBoxProxyParms, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.checkBoxAutomaticStore, 0);
            this.Controls.SetChildIndex(this.textBoxModelName, 0);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private Label labelModelName;
        private ComboBox comboBoxModelTemplateOptions;
        private Label labelModelExtends;
        private Label labelModelTemplateOptions;
        private TextBox textBoxModelExtends;
        private Label labelModelTemplate;
        private ComboBox comboBoxModelTemplate;
        private ComboBox comboBoxProxyTypeOptions;
        private Label label1;
        private Label label2;
        private TextBox textBoxProxyParms;
        private CheckBox checkBoxAutomaticStore;
        private TextBox textBoxModelName;
    }
}