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
    public partial class ModelWizPage : CustomWizardPage
    {
        public ModelWizPage(WizardForm parent)
            : base(parent)
        {
            InitializeComponent();
        }

        #region Input Recipe Arguments

        [RecipeArgument]
        public string ModelClassName
        {
            set { textBoxModelName.Text = !string.IsNullOrEmpty(value) ? value : null; }
        }

        [RecipeArgument]
        public string ModelTargetFolder { get; set; }

        [RecipeArgument]
        public List<string> ModelTemplateOptions
        {
            set
            {
                if (value != null && value.Count > 0)
                {
                    foreach (string item in value)
                    {
                        comboBoxModelTemplateOptions.Items.Add(item);
                    }
                    if (value.Count > 0)
                    {
                        comboBoxModelTemplateOptions.SelectedIndex = 0;
                    }
                }
            }
        }

        [RecipeArgument]
        public List<string> ModelTemplate
        {
            set
            {
                if (value != null && value.Count > 0)
                {
                    foreach (string item in value)
                    {
                        comboBoxModelTemplate.Items.Add(item);
                    }
                }
            }
        }

        [RecipeArgument]
        public List<string> ModelProxyType
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
                }
            }
        }
        [RecipeArgument]
        public string CreateStoreForModel
        {
            set 
            {
                var createStoreForModelOption = false;
                if (value != null)
                {
                    createStoreForModelOption = value.ToBool();
                }
                checkBoxAutomaticStore.Checked = createStoreForModelOption; 
            }
        }
        #endregion

        #region Change Event Handlers

        private void textBoxModelName_TextChanged(object sender, EventArgs e)
        {
            var dictionaryService = GetService(typeof (IDictionaryService)) as IDictionaryService;
            if (!string.IsNullOrEmpty(textBoxModelName.Text))
            {
                dictionaryService.SetValue("ModelClassName", textBoxModelName.Text.Trim());
                dictionaryService.SetValue("TargetFile", textBoxModelName.Text.Trim() + ".js");
            }
        }

        private void textBoxModelName_Leave(object sender, EventArgs e)
        {
            if (Validations.FileExists(ModelTargetFolder + textBoxModelName.Text.Trim() + ".js", ExtJsClassType.Model))
            {
                MessageBox.Show(ErrorMessages.FileAlreadyExists, MessageType.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxModelName.Focus();
            }
        }


        private void comboBoxModelTemplateOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            var dictionaryService = GetService(typeof (IDictionaryService)) as IDictionaryService;
            if (comboBoxModelTemplateOptions.SelectedItem != null)
            {
                if (comboBoxModelTemplateOptions.SelectedItem.ToString() == GlobalConstants.EmptyTemplateForModel)
                {
                    comboBoxModelTemplate.Enabled = false;
                }
                else
                {
                    comboBoxModelTemplate.Enabled = true;
                }
                dictionaryService.SetValue("ModelSelectedTemplateOption",
                                           comboBoxModelTemplateOptions.SelectedItem.ToString());
            }
        }

        private void comboBoxModelTemplate_SelectedIndexChanged(object sender, EventArgs e)
        {
            var dictionaryService = GetService(typeof (IDictionaryService)) as IDictionaryService;
            if (comboBoxModelTemplate.SelectedItem != null)
            {
                dictionaryService.SetValue("ModelSelectedTemplate", comboBoxModelTemplate.SelectedItem.ToString());
            }
        }

        private void textBoxModelExtends_TextChanged(object sender, EventArgs e)
        {
            var dictionaryService = GetService(typeof (IDictionaryService)) as IDictionaryService;
            if (!string.IsNullOrEmpty(textBoxModelExtends.Text))
            {
                dictionaryService.SetValue("ModelExtends", textBoxModelExtends.Text.Trim());
            }
        }


        private void textBoxProxyParms_TextChanged(object sender, EventArgs e)
        {
            var dictionaryService = GetService(typeof (IDictionaryService)) as IDictionaryService;
            if (!string.IsNullOrEmpty(textBoxProxyParms.Text))
            {
                dictionaryService.SetValue("ModelProxyParamsInput", textBoxProxyParms.Text.Trim());
            }
        }

        private void comboBoxProxyTypeOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            var dictionaryService = GetService(typeof (IDictionaryService)) as IDictionaryService;
            if (comboBoxProxyTypeOptions.SelectedItem != null)
            {
                dictionaryService.SetValue("ModelSelectedProxyType", comboBoxProxyTypeOptions.SelectedItem.ToString());

                if (comboBoxProxyTypeOptions.SelectedItem.ToString() != ProxyTypes.DirectProxy)
                {
                    textBoxProxyParms.Enabled = false;
                }
                else
                {
                    textBoxProxyParms.Enabled = true;
                }
            }
        }

        private void checkBoxAutomaticStore_CheckedChanged(object sender, EventArgs e)
        {
            var dictionaryService = GetService(typeof (IDictionaryService)) as IDictionaryService;
            dictionaryService.SetValue("CreateStoreForModel", checkBoxAutomaticStore.Checked.ToString());
        }

        #endregion
    }
}