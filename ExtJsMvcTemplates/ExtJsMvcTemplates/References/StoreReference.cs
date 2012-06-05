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
using System.Runtime.Serialization;
using ExtJs.Helpers;
using Microsoft.Practices.RecipeFramework;
using EnvDTE;

namespace ExtJs.References
{
    [Serializable]
    internal class StoreReference : UnboundRecipeReference
    {
        public StoreReference(string recipeName)
            : base(recipeName)
        {
        }

        /// <summary>
        /// Required constructor for deserialization.
        /// </summary>
        protected StoreReference(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public override string AppliesTo
        {
            get { return GlobalConstants.ApplyToStore; }
        }

        public override bool IsEnabledFor(object target)
        {
            return GeneralUtility.IsTemplateEnabledFor(target, ExtJsClassType.Store.ToString(), GetService<DTE>(true));
        }
    }
}