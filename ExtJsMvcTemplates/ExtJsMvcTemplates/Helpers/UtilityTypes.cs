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
using System.IO;
using System.Linq;

namespace ExtJs.Helpers
{
    internal class TypeFullName
    {
        public TypeFullName()
        {
        }

        public TypeFullName(string fullPath)
        {
            if (!string.IsNullOrEmpty(fullPath))
            {
                string directoryName = Path.GetDirectoryName(fullPath);
                Namespace = directoryName.Substring(directoryName.IndexOf(TemplateConfiguration.GetConfiguration().ExtRootFolderName));
                Name = Path.GetFileNameWithoutExtension(fullPath);
            }
        }

        public string Name { get; set; }
        public string Namespace { get; set; }


        public override string ToString()
        {
            return Name + " (" + Namespace + ")";
        }

        public static string Parse(string displayName)
        {
            if (displayName.Contains(Path.DirectorySeparatorChar))
            {
                string[] nameParts = displayName.Split(' ');
                string nameSpace = nameParts[1];
                var rootNamespace = TemplateConfiguration.GetConfiguration().ExtRootFolderName;
                return
                    nameSpace.Replace("(", string.Empty).Replace(")", string.Empty)
                             .Replace(rootNamespace + @"\Model", string.Empty)
                             .Replace(rootNamespace + @"\model", string.Empty)
                             .Replace(rootNamespace + @"\Store", string.Empty)
                             .Replace(rootNamespace + @"\store", string.Empty)
                             .Replace(rootNamespace + @"\View", string.Empty)
                             .Replace(rootNamespace + @"\view", string.Empty)
                             .Replace('\\', '.') + "." +
                             nameParts[0];
            }
            else
            {
                return displayName.Substring(displayName.IndexOf("(") + 1).Replace(")", string.Empty) + "." +
                       displayName.Substring(0, displayName.IndexOf("(")).Trim();
            }
        }
    }


    internal class ExtJsModelField
    {
        public string FieldName { get; set; }
        public string FieldType { get; set; }
    }


    internal class ModelProvider
    {
        public string ProviderAssemblyLocation { get; set; }
    }
}