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
using System.ComponentModel.Design;
using System.Collections.Generic;
using ExtJs.Helpers;

namespace ExtJs.CustomWizardPages
{
    /// <summary>
    /// Example of a class that is a custom wizard page
    /// </summary>
    public partial class ControllerWizPage : CustomWizardPage
    {
        public ControllerWizPage(WizardForm parent)
            : base(parent)
        {
            InitializeComponent();
            this.textBoxControllerName.Focus();
        }


        #region Input Recipe Arguments
        [RecipeArgument]
        public string ControllerClassName
        {
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    this.textBoxControllerName.Text = value;
                }
                else
                {
                    this.textBoxControllerName.Text = null;
                }
            }
        }
        [RecipeArgument]
        public string ControllerTargetFolder { get; set; }
        [RecipeArgument]
        public List<string> ControllerTemplateOptions
        {
            set
            {
                if (value != null && value.Count > 0)
                {
                    foreach (var item in value)
                    {
                        this.comboBoxControllerTemplate.Items.Add(item);
                    }
                    if (value.Count > 0)
                    {
                        this.comboBoxControllerTemplate.SelectedIndex = 1;
                    }
                }

            }
        }
        [RecipeArgument]
        public List<string> ControllerAvailableModels
        {
            set
            {
                AddAvailableItemsToListBox(this.listBoxControllerModels, value);

            }
        }
        [RecipeArgument]
        public List<string> ControllerAvailableStores
        {
            set
            {
                AddAvailableItemsToListBox(this.listBoxControllerStores, value);

            }
        }
        [RecipeArgument]
        public List<string> ControllerAvailableViews
        {
            set
            {
                AddAvailableItemsToListBox(this.listBoxControllerViews, value);

            }
        } 
        #endregion

        #region Change Event Handlers
        private void comboBoxControllerTemplate_SelectedIndexChanged(object sender, EventArgs e)
        {
            var dictionaryService = GetService(typeof(IDictionaryService)) as IDictionaryService;
            if (comboBoxControllerTemplate.SelectedItem != null)
            {
                dictionaryService.SetValue("ControllerSelectedTemplate", comboBoxControllerTemplate.SelectedItem.ToString());
                if (comboBoxControllerTemplate.SelectedItem == "Empty Template")
                {
                    listBoxControllerModels.Enabled = false;
                    listBoxControllerStores.Enabled = false;
                    listBoxControllerViews.Enabled = false;
                }
                else
                {
                    listBoxControllerModels.Enabled = true;
                    listBoxControllerStores.Enabled = true;
                    listBoxControllerViews.Enabled = true;
                }

            }

        }

        private void textBoxControllerExtends_TextChanged(object sender, EventArgs e)
        {

            var dictionaryService = GetService(typeof(IDictionaryService)) as IDictionaryService;
            if (!string.IsNullOrEmpty(this.textBoxControllerExtends.Text))
            {
                dictionaryService.SetValue("ControllerExtends", this.textBoxControllerExtends.Text.Trim());
            }
        }

        private void textBoxControllerName_TextChanged(object sender, EventArgs e)
        {
            var dictionaryService = GetService(typeof(IDictionaryService)) as IDictionaryService;
            if (!string.IsNullOrEmpty(this.textBoxControllerName.Text))
            {
                dictionaryService.SetValue("ControllerClassName", this.textBoxControllerName.Text.Trim());
                dictionaryService.SetValue("TargetFile", this.textBoxControllerName.Text.Trim() + ".js");
            }
        }

        private void textBoxControllerName_Leave(object sender, EventArgs e)
        {
            if (Validations.FileExists(this.ControllerTargetFolder + textBoxControllerName.Text.Trim() + ".js", ExtJsClassType.Controller))
            {
                MessageBox.Show(ErrorMessages.FileAlreadyExists, MessageType.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.textBoxControllerName.Focus();
            }
           
        }

        private void listBoxControllerModels_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetSelectedItemsFromListBox(sender as ListBox, ExtJsClassType.Model);
        }

        private void listBoxControllerStores_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetSelectedItemsFromListBox(sender as ListBox, ExtJsClassType.Store);
        }

        private void listBoxControllerViews_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetSelectedItemsFromListBox(sender as ListBox, ExtJsClassType.View);
        } 
        #endregion

        #region Helper Methods
        private void AddAvailableItemsToListBox(ListBox listBox, List<string> value)
        {
            if (value != null && value.Count > 0)
            {
                foreach (var item in value)
                {
                    listBox.Items.Add(item);
                }

            }
        }

        private void GetSelectedItemsFromListBox(ListBox listBox, ExtJsClassType extJsClassType)
        {
            var dictionaryService = GetService(typeof(IDictionaryService)) as IDictionaryService;
            if (listBox.SelectedItems.Count > 0)
            {
                var selectedModels = new List<string>();
                foreach (var item in listBox.SelectedItems)
                {
                    selectedModels.Add(item.ToString());
                }
                if (selectedModels.Count > 0)
                {
                    dictionaryService.SetValue("ControllerSelected" + extJsClassType.ToString() + "s", selectedModels);
                }
            }
        } 
        #endregion

        
    }
}