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
#region Using Directives

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ExtJs.Helpers;
using Microsoft.Practices.RecipeFramework;
using Action = Microsoft.Practices.RecipeFramework.Action;

#endregion

namespace ExtJs.Actions
{
    internal class GenerateControllerClassAction : Action
    {
        #region Input Properties

        [Input]
        public string ControllerClassName { get; set; }

        [Input]
        public string ControllerSelectedTemplate { get; set; }

        [Input]
        public List<string> ControllerSelectedModels { get; set; }

        [Input]
        public List<string> ControllerSelectedStores { get; set; }

        [Input]
        public List<string> ControllerSelectedViews { get; set; }

        #endregion

        #region Output Properties

        [Output]
        public string ControllerModels { get; set; }

        [Output]
        public string ControllerStores { get; set; }

        [Output]
        public string ControllerViews { get; set; }

        [Output]
        public bool IsValid { get; set; }

        [Output]
        public string CopyrightInfo { get; set; }

        #endregion

        #region IAction Memebers Implementation
        public override void Execute()
        {
            InitializeOutputValues();
            CopyrightInfo = GeneralUtility.GetCopyrightInfo(ControllerClassName);
            ProcessControllerTemplateOptions();
        }

        public override void Undo()
        {
            InitializeOutputValues();
        } 
        #endregion

        #region Helper Methods
        private void ProcessControllerTemplateOptions()
        {
            try
            {
                switch (ControllerSelectedTemplate)
                {
                    case GlobalConstants.EmptyTemplateForController:
                        break;
                    case GlobalConstants.FullTemplateForController:
                        CreateFullTemplatedController();
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(ErrorMessages.GeneralError, ex.Message), MessageType.Error,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                IsValid = false;
            }
        }

        private void InitializeOutputValues()
        {
            IsValid = true;
            ControllerModels = string.Empty;
            ControllerStores = string.Empty;
            ControllerViews = string.Empty;
        }

        private void CreateFullTemplatedController()
        {
            if (ControllerSelectedModels != null && ControllerSelectedModels.Count > 0)
                ControllerModels = FormatTemplate(ControllerSelectedModels);
            if (ControllerSelectedStores != null && ControllerSelectedStores.Count > 0)
                ControllerStores = FormatTemplate(ControllerSelectedStores);
            if (ControllerSelectedViews != null && ControllerSelectedViews.Count > 0)
                ControllerViews = FormatTemplate(ControllerSelectedViews);
        }

        private static string FormatTemplate(IEnumerable<string> objectValues)
        {
            var formattedObject = string.Empty;
            foreach (string item in objectValues)
            {
                string formattedItemName = TypeFullName.Parse(item);
                if (formattedItemName.StartsWith("."))
                {
                    formattedItemName = formattedItemName.Remove(0, 1);
                }
                if (formattedObject == string.Empty)
                {
                    formattedObject = "'" + formattedItemName + "'";
                }
                else
                {
                    formattedObject = formattedObject + ",\r\n\t\t'" + formattedItemName + "'";
                }
            }
            return formattedObject;
        } 
        #endregion
    }
}