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
    public partial class ViewWizPage : CustomWizardPage
    {
        public ViewWizPage(WizardForm parent)
            : base(parent)
        {
            InitializeComponent();
        }


        #region Input Recipe Arguments
        [RecipeArgument]
        public string ViewClassName
        {
            set {
                this.textBoxViewName.Text = !string.IsNullOrEmpty(value) ? value : null;
            }
        }
        [RecipeArgument]
        public string ViewExtends
        {
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    this.textBoxViewExtends.Text = value;
                }
                 
            }
        }
        [RecipeArgument]
        public string ViewTargetFolder { get; set; }

       
        #endregion

        #region Change Event Handlers

        private void textBoxViewName_TextChanged(object sender, EventArgs e)
        {
            IDictionaryService dictionaryService = GetService(typeof(IDictionaryService)) as IDictionaryService;
            if (!string.IsNullOrEmpty(this.textBoxViewName.Text))
            {
                dictionaryService.SetValue("ViewClassName", this.textBoxViewName.Text.Trim());
                dictionaryService.SetValue("TargetFile", this.textBoxViewName.Text.Trim() + ".js");
            }
        }

       

        private void textBoxViewExtends_TextChanged(object sender, EventArgs e)
        {
            IDictionaryService dictionaryService = GetService(typeof(IDictionaryService)) as IDictionaryService;
            if (!string.IsNullOrEmpty(this.textBoxViewExtends.Text))
            {
                dictionaryService.SetValue("ViewExtends", this.textBoxViewExtends.Text.Trim());
            }
        }

 

        private void textBoxViewName_Leave(object sender, EventArgs e)
        {
            if (Validations.FileExists(this.ViewTargetFolder + textBoxViewName.Text.Trim() + ".js", ExtJsClassType.View))
            {
                MessageBox.Show(ErrorMessages.FileAlreadyExists, MessageType.Error, MessageBoxButtons.OK,MessageBoxIcon.Error);
                this.textBoxViewName.Focus();
            }
        }

        #endregion
 
    }
}