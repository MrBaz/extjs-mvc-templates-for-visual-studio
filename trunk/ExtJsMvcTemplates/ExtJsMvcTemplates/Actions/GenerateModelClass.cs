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
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using EnvDTE;
using ExtJs.Helpers;
using Microsoft.Practices.Common.Services;
using Microsoft.Practices.ComponentModel;
using Microsoft.Practices.RecipeFramework;
using Microsoft.Practices.RecipeFramework.Library;
using Microsoft.Practices.RecipeFramework.Services;
using Microsoft.Practices.RecipeFramework.VisualStudio.Library.Templates;
using Microsoft.VisualStudio.TextTemplating;
using Action = Microsoft.Practices.RecipeFramework.Action;

#endregion Using Directives

namespace ExtJs.Actions
{
    internal class GenerateModelClassAction : Action
    {
        #region Input Properties

        [Input]
        public string ModelSelectedProxyType { get; set; }

        [Input]
        public string ModelProxyParamsInput { get; set; }

        [Input]
        public string ModelSelectedTemplateOption { get; set; }

        [Input]
        public string ModelSelectedTemplate { get; set; }

        [Input]
        public string CreateStoreForModel { get; set; }

        [Input]
        public string ModelClassName { get; set; }

        [Input]
        public string ModelNamespace { get; set; }

        [Input]
        public Project CurrentProject { get; set; }

        #endregion Input Properties

        #region Output Properties

        [Output]
        public string ModelProxyApi { get; set; }

        [Output]
        public string ModelProxyParams { get; set; }

        [Output]
        public string ModelFields { get; set; }

        [Output]
        public bool IsValid { get; set; }

        [Output]
        public string CopyrightInfo { get; set; }

        #endregion Output Properties

        #region IAction Memebers Implementation

        public override void Execute()
        {
            InitializeOutputValues();
            CopyrightInfo = GeneralUtility.GetCopyrightInfo(ModelClassName);
            ProcessModelTemplateOption();
            ProcessAutoCreateStoreOption();
        }

        public override void Undo()
        {
            InitializeOutputValues();
        }

        #endregion

        #region Helper Methods

        private void InitializeOutputValues()
        {
            IsValid = true;
            ModelProxyApi = string.Empty;
            ModelProxyParams = string.Empty;
            ModelFields = string.Empty;
        }

        private void ProcessModelTemplateOption()
        {
            try
            {
                switch (ModelSelectedTemplateOption)
                {
                    case GlobalConstants.EmptyTemplateForModel:
                        break;
                    case GlobalConstants.FullTemplateForModel:
                        if (string.IsNullOrEmpty(ModelSelectedTemplate))
                        {
                            MessageBox.Show(ErrorMessages.ModelTemplateNotSelected, MessageType.Error,
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Error);
                            ModelFields = string.Empty;
                            IsValid = false;
                        }
                        else
                        {
                            CreateFields();
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

        private void ProcessAutoCreateStoreOption()
        {
            if (CreateStoreForModel.ToBool())
            {
                try
                {
                    CreateStore();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(string.Format(ErrorMessages.GeneralError, ex.Message), MessageType.Error,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
            }
        }

        private void CreateStore()
        {
            string template = @"Text\Store.js.t4";
            string templateBasePath = GetTemplateBasePath();
            if (!Path.IsPathRooted(template))
            {
                template = Path.Combine(templateBasePath, template);
            }
            template = new FileInfo(template).FullName;
            if (!template.StartsWith(templateBasePath))
            {
                throw new ArgumentException("Template Not found");
            }
            string templateCode = File.ReadAllText(template);

            var addProjectItemAction = new AddProjectItemAction();
            addProjectItemAction.Content = Render(templateCode, template).ToString();
            addProjectItemAction.IsValid = true;
            addProjectItemAction.TargetFileName = ModelClassName + "s.js";
            addProjectItemAction.Project = CurrentProject;
            addProjectItemAction.Execute(DteHelper.FindInCollection(CurrentProject.ProjectItems, TemplateConfiguration.GetConfiguration().ExtRootFolderName + "\\Store"));
        }

        private void CreateProxy()
        {
            switch (ModelSelectedProxyType)
            {
                case ProxyTypes.DirectProxy:
                    ModelProxyApi =
                        "api:{\r\n\t\t\t create: /*Controller.ActionMethod*/,\r\n\t\t\t read: /*Controller.ActionMethod*/, \r\n\t\t\t update: /*Controller.ActionMethod*/, \r\n\t\t\t destroy: /*Controller.ActionMethod*/\r\n\t\t}";
                    if (!string.IsNullOrEmpty(ModelProxyParamsInput))
                    {
                        ModelProxyParams = "paramOrder: [" + ModelProxyParamsInput + "],";
                    }
                    else
                    {
                        ModelProxyParams = string.Empty;
                    }
                    break;
                case ProxyTypes.AjaxProxy:
                    break;
                default:
                    break;
            }
        }

        private void CreateFields()
        {
            string typeName = TypeFullName.Parse(ModelSelectedTemplate);
            TemplateConfiguration templateConfig = TemplateConfiguration.GetConfiguration(GetService<DTE>(true));

            foreach (ModelProvider modelProvider in templateConfig.ModelProviders)
            {
                Assembly modelAssembly = Assembly.LoadFrom(modelProvider.ProviderAssemblyLocation);
                Type modelType = modelAssembly.GetType(typeName);
                if (modelType != null)
                {
                    TraslateFields(modelType);
                    break;
                }
            }
        }

        private object Render(string templateCode, string template)
        {
            string basePath = GetBasePath();
            var additionalArguments = new Dictionary<string, string>();
            ITextTemplatingEngine engine = new Engine();
            var service = (IValueInfoService)GetService(typeof(IValueInfoService));
            var arguments = new Dictionary<string, PropertyData>();

            additionalArguments.Add("StoreNamespace", string.Empty);
            additionalArguments.Add("StoreSelectedProxyType", ProxyTypes.NoProxy);
            additionalArguments.Add("StoreProxyApi", string.Empty);
            additionalArguments.Add("StoreSelectedExtends", GlobalConstants.FlatStore);
            additionalArguments.Add("StoreSelectedModel", "." + ModelNamespace + ModelClassName);
            additionalArguments.Add("StoreProxyParams", string.Empty);
            additionalArguments.Add("StoreClassName", ModelClassName + "s");

            foreach (string str2 in additionalArguments.Keys)
            {
                Type type = null;
                if (additionalArguments[str2] != null)
                {
                    type = additionalArguments[str2].GetType();
                }
                else
                {
                    continue;
                }
                var data = new PropertyData(additionalArguments[str2], type);
                arguments.Add(str2, data);
            }
            var host = new TemplateHost(basePath, arguments)
            {
                TemplateFile = template
            };
            string str3 = engine.ProcessTemplate(templateCode, host);
            if (host.Errors.HasErrors)
            {
                throw new TemplateException(host.Errors);
            }
            if (host.Errors.HasWarnings)
            {
                var builder = new StringBuilder();
                foreach (CompilerError error in host.Errors)
                {
                    builder.AppendLine(error.ToString());
                }
            }
            return str3;
        }

        private string GetTemplateBasePath()
        {
            return new DirectoryInfo(GetBasePath() + @"\Templates").FullName;
        }

        private string GetBasePath()
        {
            return GetService<IConfigurationService>(true).BasePath;
        }

        private void TraslateFields(Type modelType)
        {
            PropertyInfo[] properties = modelType.GetProperties();
            string jsFieldType;
            foreach (PropertyInfo property in properties)
            {
                switch (property.PropertyType.ToString())
                {
                    case "System.Int32":
                        jsFieldType = "int";
                        break;
                    case "System.Decimal":
                        jsFieldType = "int";
                        break;
                    case "System.Double":
                        jsFieldType = "int";
                        break;
                    case "System.Single":
                        jsFieldType = "int";
                        break;
                    case "System.UInt32":
                        jsFieldType = "int";
                        break;
                    case "System.Int64":
                        jsFieldType = "int";
                        break;
                    case "System.UInt64":
                        jsFieldType = "int";
                        break;
                    case "System.Int16":
                        jsFieldType = "int";
                        break;
                    case "System.UInt16":
                        jsFieldType = "int";
                        break;
                    case "System.Boolean":
                        jsFieldType = "bool";
                        break;
                    case "System.String":
                        jsFieldType = "string";
                        break;
                    case "System.Char":
                        jsFieldType = "string";
                        break;
                    default:
                        jsFieldType = "object";
                        break;
                }
                if (!string.IsNullOrEmpty(ModelFields))
                {
                    ModelFields += ",\r\n\t\t";
                }
                ModelFields += "{\r\n\t\t\tname: " + "'" + property.Name + "'" + ",\r\n\t\t\ttype: " + "'" + jsFieldType +
                               "'\r\n\t\t}";
            }
        }

        #endregion
    }
}