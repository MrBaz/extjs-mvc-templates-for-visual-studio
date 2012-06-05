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
using System.IO;
using EnvDTE;
using ExtJs.Helpers;
using Microsoft.Practices.RecipeFramework;
using Microsoft.Practices.RecipeFramework.Library;

namespace ExtJs.ValueProviders.CommonValueProviders
{
    public class NamespaceValueProvider : ValueProvider
    {
        public override bool OnBeginRecipe(object currentValue, out object newValue)
        {
            var service = base.GetService<DTE>(true);
            newValue = string.Empty;
            string selectedFolderPath = DteHelper.GetFilePathRelative((ProjectItem) DteHelper.GetTarget(service));
            string[] pathParts =
                selectedFolderPath.Split(new[] {Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar},
                                         StringSplitOptions.RemoveEmptyEntries);
            if (pathParts.Length > 3)
            {
                if (pathParts[1] == TemplateConfiguration.GetConfiguration().ExtRootFolderName &&
                    (pathParts[2].Equals(ExtJsClassType.Model.ToString(),StringComparison.InvariantCultureIgnoreCase) ||
                     pathParts[2].Equals(ExtJsClassType.View.ToString(), StringComparison.InvariantCultureIgnoreCase) ||
                     pathParts[2].Equals(ExtJsClassType.Store.ToString(), StringComparison.InvariantCultureIgnoreCase) ||
                     pathParts[2].Equals(ExtJsClassType.Controller.ToString(), StringComparison.InvariantCultureIgnoreCase)))
                {
                    for (var i = 3; i < pathParts.Length; i++)
                    {
                        newValue += pathParts[i] + ".";
                    }
                }
            }
            return true;
        }
    }
}