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

namespace ExtJs.Helpers
{
    class GlobalConstants
    {
        //Template Options
        public const string EmptyTemplateForController = "Empty Template";
        public const string EmptyTemplateForModel = "Empty Template";
        public const string EmptyTemplateForStore = "Empty Template";
        public const string EmptyTemplateForView = "Empty Template";

        public const string FullTemplateForController = "Using ExtJs models, views and stores";
        public const string FullTemplateForModel = "Derived from a domain model";
        public const string FullTemplateForStore = "Using an ExtJs model";
        
        //Applied to options
        public const string ApplyToController = "ExtJs Controller Folder";
        public const string ApplyToModel = "ExtJs Model Folder";
        public const string ApplyToView = "ExtJs View Folder";
        public const string ApplyToStore = "ExtJs Store Folder";

        //Type of stores
        public const string FlatStore = "Ext.data.Store";
        public const string TreeStore = "Ext.data.TreeStore";

    }
}
