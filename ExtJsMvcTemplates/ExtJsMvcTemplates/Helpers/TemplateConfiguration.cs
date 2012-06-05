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
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using EnvDTE;
using System.IO;

namespace ExtJs.Helpers
{
    class TemplateConfiguration
    {
        private static TemplateConfiguration templateConfig;
        public List<ModelProvider> ModelProviders { get; set; }
        public DirectoryInfo SolutionFolderInfo { get; set; }
        public string ExtRootFolderName { get; set; }
        public string ExtRootNamespace { get; set; }
        public string CopyrightInfo { get; set; }
 
        private TemplateConfiguration()
        { }

        public static TemplateConfiguration GetConfiguration(DTE service = null)
        {
            if (templateConfig == null)
            {
                try
                {
                    DirectoryInfo solutionFolderInfo = null;
                    var configFilePath = GetConfigFilePath(service, ref solutionFolderInfo);
                    var templateXml = ReadConfiguration(configFilePath);
                    ProcessConfiguration(solutionFolderInfo, templateXml);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(string.Format(ErrorMessages.GeneralError, ex.Message), MessageType.Error,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                }
            }
            return templateConfig;
        }

        private static void ProcessConfiguration(DirectoryInfo solutionFolderInfo, XmlDocument templateXml)
        {
            
            var projectParentFolderLocation = solutionFolderInfo.Parent.Parent.FullName;
            templateConfig = new TemplateConfiguration
            {
                SolutionFolderInfo = solutionFolderInfo,
                ExtRootFolderName = templateXml.DocumentElement.SelectSingleNode("//AppSettings//ExtRootFolder").Attributes["Name"].Value,
                ExtRootNamespace = templateXml.DocumentElement.SelectSingleNode("//AppSettings//ExtRootNamespace").Attributes["Name"].Value,
                CopyrightInfo = GetCopyrightInfo(templateXml.DocumentElement.SelectSingleNode("//AppSettings//CopyrightInfoPath").Attributes["Location"].Value),
                ModelProviders = new List<ModelProvider>()
            };
            foreach (XmlNode modelProvider in templateXml.DocumentElement.SelectNodes("ModelProviders/ModelProvider"))
            {
                var isAbsolutePath = modelProvider.Attributes["Absolute"];
                if (isAbsolutePath != null && isAbsolutePath.Value == "true")
                {
                    projectParentFolderLocation = string.Empty;
                }
                templateConfig.ModelProviders.Add(new ModelProvider { ProviderAssemblyLocation = projectParentFolderLocation + modelProvider.Attributes["AssemblyLocation"].Value });
            }
        }

        private static XmlDocument ReadConfiguration(string configFilePath)
        {
            var templateXml = new XmlDocument();

            using (var reader = new XmlTextReader(configFilePath))
            {
                templateXml.Load(reader);
                reader.Close();
            }
            return templateXml;
        }

        private static string GetConfigFilePath(DTE service, ref DirectoryInfo solutionFolderInfo)
        {
            string configFilePath = @"C:\TemplateConfig.xml";
            if (service != null)
            {
                var currentProject = ((object[])service.ActiveSolutionProjects)[0] as Project;
                solutionFolderInfo = Directory.GetParent(currentProject.FullName);
                if (File.Exists(solutionFolderInfo.FullName + "\\TemplateConfig.xml"))
                {
                    configFilePath = solutionFolderInfo.FullName + "\\TemplateConfig.xml";
                }
            }
            return configFilePath;
        }


        public static string GetCopyrightInfo(string copyrightPath)
        {
            if (File.Exists(copyrightPath))
            {
                using (var reader = new StreamReader(copyrightPath))
                {
                    return reader.ReadToEnd();
                }
            }
            return string.Empty;
        }
    }
}
