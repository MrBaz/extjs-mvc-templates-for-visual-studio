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
using System.IO;
using System.Linq;
using System.Windows.Forms;
using EnvDTE;
using Microsoft.Practices.RecipeFramework.Library;

namespace ExtJs.Helpers
{
    internal static class GeneralUtility
    {
        public static string GetCopyrightInfo(string fileName)
        {
            var CopyrightInfo = TemplateConfiguration.GetConfiguration().CopyrightInfo;
            return String.Format(CopyrightInfo, fileName + ".js");
        }

        public static List<string> GetListofFiles(ExtJsClassType extJsClassType)
        {
            FileInfo[] typeFiles = GetListofFilesRaw(extJsClassType);
            IEnumerable<string> typeList = typeFiles.Select(t => (new TypeFullName(t.FullName)).ToString());
            return typeList.OrderBy(t => t).ToList();
        }

        public static FileInfo[] GetListofFilesRaw(ExtJsClassType extJsClassType)
        {
            DirectoryInfo directoryInfo = TemplateConfiguration.GetConfiguration().SolutionFolderInfo;
            DirectoryInfo typeDirectory =
                directoryInfo.GetDirectories(extJsClassType.ToString(), SearchOption.AllDirectories)[0];
            return typeDirectory.GetFiles("*.js", SearchOption.AllDirectories);
        }


        public static bool IsTemplateEnabledFor(object target, string templateName, DTE service = null)
        {
            try
            {
                var selectedItem = target as ProjectItem;
                if (selectedItem == null)
                {
                    return false;
                }
                string selectedFolderPath = DteHelper.GetFilePathRelative(selectedItem);
                var templatePath = TemplateConfiguration.GetConfiguration(service).ExtRootFolderName + "\\" + templateName;
                var wr = new StreamWriter(@"C:\test.text", true);
                if (selectedFolderPath.ToLower().Contains(templatePath.ToLower()))
                {
                    wr.WriteLine("SelectedFolderPath:{0}, TemplatePath:{1}, Valid", selectedFolderPath, templatePath);
                    wr.Close();
                    return true;
                }
                wr.WriteLine("SelectedFolderPath:{0}, TemplatePath:{1}, Invalid", selectedFolderPath, templatePath);
                wr.Close();
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(ErrorMessages.GeneralError, ex.Message), MessageType.Error,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return false;
            }
        }
    }
}