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
using System.Reflection;
using EnvDTE;
using ExtJs.Helpers;
using Microsoft.Practices.RecipeFramework;

namespace ExtJs.ValueProviders.ModelValueProviders
{
    internal class ModelTemplatesValueProvider : ValueProvider
    {
        public override bool OnBeginRecipe(object currentValue, out object newValue)
        {
            var service = GetService<DTE>(true);
            TemplateConfiguration templateConfig = TemplateConfiguration.GetConfiguration(service);
            var modelList = new List<string>();

            foreach (ModelProvider modelProvider in templateConfig.ModelProviders)
            {
                Assembly modelAssembly = Assembly.LoadFrom(modelProvider.ProviderAssemblyLocation);
                IEnumerable<Type> modelTypes = modelAssembly.GetTypes().Where(t => t.IsClass);
                modelList.AddRange(
                    modelTypes.Select(m => (new TypeFullName {Name = m.Name, Namespace = m.Namespace}).ToString()));
            }
            newValue = modelList.OrderBy(m => m).ToList();
            return true;
        }
    }
}