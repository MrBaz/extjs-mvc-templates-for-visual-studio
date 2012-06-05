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
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Windows.Forms;
using ExtJs.Helpers;
using Microsoft.Practices.WizardFramework;

namespace ExtJs.CustomWizardPages
{
    /// <summary>
    /// Example of a class that is a custom wizard page
    /// </summary>
    public partial class StoreWizPage : CustomWizardPage
    {
        public StoreWizPage(WizardForm parent)
            : base(parent)
        {
            InitializeComponent();
            textBoxStoreName.Focus();
        }

        #region Input Recipe Arguments

        [RecipeArgument]
        public string StoreClassName
        {
            set {
                textBoxStoreName.Text = !string.IsNullOrEmpty(value) ? value : null;
            }
        }

        [RecipeArgument]
        public string StoreTargetFolder { get; set; }

        [RecipeArgument]
        public List<string> StoreTemplateOptions
        {
            set
            {
                if (value != null && value.Count > 0)
                {
                    foreach (string item in value)
                    {
                        comboBoxStoreTemplateOptions.Items.Add(item);
                    }
                    if (value.Count > 0)
                    {
                        comboBoxStoreTemplateOptions.SelectedIndex = 1;
                    }
                }
            }
        }

        [RecipeArgument]
        public List<string> StoreTemplate
        {
            set
            {
                if (value != null && value.Count > 0)
                {
                    foreach (string item in value)
                    {
                        comboBoxStoreTemplate.Items.Add(item);
                    }
                }
            }
        }

        [RecipeArgument]
        public List<string> StoreProxyType
        {
            set
            {
                if (value != null && value.Count > 0)
                {
                    foreach (string item in value)
                    {
                        comboBoxProxyTypeOptions.Items.Add(item);
                    }
                    comboBoxProxyTypeOptions.SelectedIndex = 0;
                    textBoxProxyParms.Enabled = false;
                }
                
            }
        }

        [RecipeArgument]
        public List<string> StoreExtendsOptions
        {
            set
            {
                if (value != null && value.Count > 0)
                {
                    foreach (string item in value)
                    {
                        comboBoxStoreExtendOptions.Items.Add(item);
                    }
                    comboBoxStoreExtendOptions.SelectedIndex = 0;
                }
                 
            }
        }

        #endregion

        #region Change Event Handlers

        private void textBoxProxyParms_TextChanged(object sender, EventArgs e)
        {
            var dictionaryService = GetService(typeof (IDictionaryService)) as IDictionaryService;
            if (!string.IsNullOrEmpty(textBoxProxyParms.Text))
            {
                dictionaryService.SetValue("StoreProxyParamsInput", textBoxProxyParms.Text.Trim());
            }
        }

        private void comboBoxProxyTypeOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            var dictionaryService = GetService(typeof (IDictionaryService)) as IDictionaryService;
            if (comboBoxProxyTypeOptions.SelectedItem != null)
            {
                dictionaryService.SetValue("StoreSelectedProxyType", comboBoxProxyTypeOptions.SelectedItem.ToString());
                if (comboBoxProxyTypeOptions.SelectedItem != ProxyTypes.DirectProxy)
                {
                    textBoxProxyParms.Enabled = false;
                }
                else
                {
                    textBoxProxyParms.Enabled = true;
                }
            }
        }

        private void textBoxStoreName_TextChanged(object sender, EventArgs e)
        {
            var dictionaryService = GetService(typeof (IDictionaryService)) as IDictionaryService;
            if (!string.IsNullOrEmpty(textBoxStoreName.Text))
            {
                dictionaryService.SetValue("StoreClassName", textBoxStoreName.Text.Trim());
                dictionaryService.SetValue("TargetFile", textBoxStoreName.Text.Trim() + ".js");
            }
        }

        private void comboBoxStoreTemplateOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            var dictionaryService = GetService(typeof (IDictionaryService)) as IDictionaryService;
            if (comboBoxStoreTemplateOptions.SelectedItem != null)
            {
                if (comboBoxStoreTemplateOptions.SelectedItem.ToString() == "Empty Template")
                {
                    comboBoxStoreTemplate.Enabled = false;
                    comboBoxProxyTypeOptions.Enabled = false;
                    textBoxProxyParms.Enabled = false;
                }
                else
                {
                    comboBoxStoreTemplate.Enabled = true;
                    comboBoxProxyTypeOptions.Enabled = true;
                    textBoxProxyParms.Enabled = true;
                }
                dictionaryService.SetValue("StoreSelectedTemplateOption",
                                           comboBoxStoreTemplateOptions.SelectedItem.ToString());
            }
        }

        private void comboBoxStoreTemplate_SelectedIndexChanged(object sender, EventArgs e)
        {
            var dictionaryService = GetService(typeof (IDictionaryService)) as IDictionaryService;
            if (comboBoxStoreTemplate.SelectedItem != null)
            {
                dictionaryService.SetValue("StoreSelectedTemplate", comboBoxStoreTemplate.SelectedItem.ToString());
            }
        }

        private void comboBoxStoreExtendOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            var dictionaryService = GetService(typeof (IDictionaryService)) as IDictionaryService;
            if (comboBoxStoreTemplate.SelectedItem != null)
            {
                dictionaryService.SetValue("StoreSelectedExtends", comboBoxStoreExtendOptions.SelectedItem.ToString());
            }
        }

        private void textBoxStoreName_Leave(object sender, EventArgs e)
        {
            if (Validations.FileExists(StoreTargetFolder + textBoxStoreName.Text.Trim() + ".js", ExtJsClassType.Store))
            {
                MessageBox.Show(ErrorMessages.FileAlreadyExists, MessageType.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxStoreName.Focus();
            }
        }

        private void comboBoxProxyTypeOptions_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            var dictionaryService = GetService(typeof (IDictionaryService)) as IDictionaryService;
            if (comboBoxProxyTypeOptions.SelectedItem != null)
            {
                dictionaryService.SetValue("StoreSelectedProxyType", comboBoxProxyTypeOptions.SelectedItem.ToString());
                if (comboBoxProxyTypeOptions.SelectedItem != ProxyTypes.DirectProxy)
                {
                    textBoxProxyParms.Enabled = false;
                }
                else
                {
                    textBoxProxyParms.Enabled = true;
                }
            }
        }

        #endregion
    }
}