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
using System.Windows.Forms;
using ExtJs.Helpers;
using Microsoft.Practices.RecipeFramework;
using Action = Microsoft.Practices.RecipeFramework.Action;

#endregion

namespace ExtJs.Actions
{
    internal class GenerateStoreClassAction : Action
    {
        #region Input Properties

        [Input]
        public string StoreClassName { get; set; }

        [Input]
        public string StoreSelectedProxyType { get; set; }

        [Input]
        public string StoreProxyParamsInput { get; set; }

        [Input]
        public string StoreSelectedTemplateOption { get; set; }

        [Input]
        public string StoreSelectedTemplate { get; set; }

        #endregion Input Properties

        #region Output Properties

        [Output]
        public string StoreSelectedModel { get; set; }

        [Output]
        public string StoreProxyApi { get; set; }

        [Output]
        public string StoreProxyParams { get; set; }

        [Output]
        public bool IsValid { get; set; }

        [Output]
        public string CopyrightInfo { get; set; }

        #endregion Output Properties

        #region IAction Memebers Implementation
        public override void Execute()
        {
            InitializeOutputValues();
            CopyrightInfo = GeneralUtility.GetCopyrightInfo(StoreClassName);
            ProcessStoreTemplateOption();
        }

        public override void Undo()
        {
            InitializeOutputValues();
        } 
        #endregion

        #region Helper Methods
        private void ProcessStoreTemplateOption()
        {
            try
            {
                switch (StoreSelectedTemplateOption)
                {
                    case GlobalConstants.EmptyTemplateForStore:
                        break;
                    case GlobalConstants.FullTemplateForStore:
                        if (string.IsNullOrEmpty(StoreSelectedTemplate))
                        {
                            MessageBox.Show(ErrorMessages.StoreTemplateNotSelected, MessageType.Error, MessageBoxButtons.OK,
                                            MessageBoxIcon.Error);
                            StoreSelectedModel = string.Empty;
                            IsValid = false;
                        }
                        else
                        {
                            CreateModelName();
                        }
                        CreateProxy();
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
            StoreSelectedModel = string.Empty;
            StoreProxyApi = string.Empty;
            StoreProxyParams = string.Empty;
        }

        private void CreateModelName()
        {
            StoreSelectedModel = TypeFullName.Parse(StoreSelectedTemplate);
        }

        private void CreateProxy()
        {
            switch (StoreSelectedProxyType)
            {
                case ProxyTypes.DirectProxy:
                    StoreProxyApi =
                        "api:{\r\n\t\t\t create: /*Controller.ActionMethod*/,\r\n\t\t\t read: /*Controller.ActionMethod*/, \r\n\t\t\t update: /*Controller.ActionMethod*/, \r\n\t\t\t destroy: /*Controller.ActionMethod*/\r\n\t\t}";
                    if (!String.IsNullOrEmpty(StoreProxyParamsInput))
                    {
                        StoreProxyParams = "paramOrder: [" + StoreProxyParamsInput + "],";
                    }
                    else
                    {
                        StoreProxyParams = string.Empty;
                    }
                    break;
                case ProxyTypes.AjaxProxy:
                    break;
                default:
                    break;
            }
        } 
        #endregion
    }
}