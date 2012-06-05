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
using System.Collections.Generic;
using ExtJs.Helpers;

namespace ExtJs.ValueProviders.CommonValueProviders
{
    internal static class TemplateOptionsHelper
    {
        public static List<string> CreateTemplateOptionsFor(ExtJsClassType extJsClassType)
        {
            switch (extJsClassType)
            {
                case ExtJsClassType.Controller:
                    return new List<string> {GlobalConstants.EmptyTemplateForController, GlobalConstants.FullTemplateForController};
                case ExtJsClassType.Model:
                    return new List<string> {GlobalConstants.EmptyTemplateForModel, GlobalConstants.FullTemplateForModel};
                case ExtJsClassType.Store:
                    return new List<string> {GlobalConstants.EmptyTemplateForStore, GlobalConstants.FullTemplateForStore};
                default:
                    return null;
            }
        }
    }
}