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
    static class ErrorMessages
    {
        public const string FileAlreadyExists = "File with this name already exists";
        public const string ModelTemplateNotSelected = "Model template was not selected. The operation will not continue";
        public const string StoreTemplateNotSelected = "Store template was not selected. The operation will not continue";
        public const string ControllerTemplatesNotSelected = "Controller templates were not selected. The operation will not continue";
        public const string GeneralError = "An error occured while creating this class. The error information is given below\r\n{0}";
    }

    static class MessageType
    {
        public const string Error = "Error";

    }

    static class ProxyTypes
    {
        public const string DirectProxy = "direct";
        public const string AjaxProxy = "ajax";
        public const string NoProxy = "none";

    }

    public enum ExtJsClassType
    {
        Model,
        Store,
        View,
        Controller
    }
}
    